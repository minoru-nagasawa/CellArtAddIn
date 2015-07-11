using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using BitmapPlus;
using bambit.forms.controls;
using Excel = Microsoft.Office.Interop.Excel;

namespace CellArtAddIn
{
    public partial class MyUserControl : UserControl
    {
        // getColorとgetCompatibleColorを代入するためのDelegate
        delegate Color GetColorMethod(BitmapPlus.BitmapPlus a_bmpPlus, int a_x, int a_y, int a_widthPerCell, int a_heightPerCell);

        private Bitmap m_bitmap = null;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a_ws"></param>
        /// <param name="a_r"></param>
        /// <param name="a_column"></param>
        /// <returns></returns>
        /// <seealso cref="http://www.excelforum.com/excel-programming-vba-macros/337375-setting-column-width.html"/>
        static private double setColWidth(Excel.Worksheet a_ws, double a_pixel, double a_dpi, int a_column)
        {
            // 近くに幅を設定
            double curPoint = a_ws.Cells[1, 1].Width;
            double curChars = a_ws.Cells[1, 1].ColumnWidth;
            double curPixel = curPoint * a_dpi / 72;
            a_ws.Cells[1, 1].ColumnWidth = a_pixel * curChars / curPixel;

            // ちょっとずつ広げたり狭めたりして、一致する幅を探す
            double targetPoint = a_pixel * 72 / a_dpi;
            while (a_ws.Cells[1, 1].Width > targetPoint)
            {
                a_ws.Cells[1, 1].ColumnWidth -= 0.1;
            }
            while (a_ws.Cells[1, 1].Width < targetPoint)
            {
                a_ws.Cells[1, 1].ColumnWidth += 0.1;
            }

            return a_ws.Cells[1, 1].ColumnWidth;
        }

        static private Color getColor(BitmapPlus.BitmapPlus a_bmpPlus, int a_x, int a_y, int a_widthPerCell, int a_heightPerCell)
        {
            int totalA = 0;
            int totalR = 0;
            int totalG = 0;
            int totalB = 0;
            for (int x = a_x; x < a_x + a_widthPerCell; ++x)
            {
                for (int y = a_y; y < a_y + a_heightPerCell; ++y)
                {
                    var c = a_bmpPlus.GetPixel(x, y);
                    totalA += c.A;
                    totalR += c.R;
                    totalG += c.G;
                    totalB += c.B;
                }
            }

            int size = a_widthPerCell * a_heightPerCell;
            return Color.FromArgb(totalA / size, totalR / size, totalG / size, totalB / size);
        }

        static private Color getCompatibleColor(BitmapPlus.BitmapPlus a_bmpPlus, int a_x, int a_y, int a_widthPerCell, int a_heightPerCell)
        {
            var color = getColor(a_bmpPlus, a_x, a_y, a_widthPerCell, a_heightPerCell);
            return CompatibleColor.FindNearestCompatibleColor(color);
        }

        public MyUserControl()
        {
            InitializeComponent();
            c_labelSize.Text = "";
        }

        private void c_browseBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.FileName = "";
            ofd.DefaultExt = "*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pathTbx.Text = ofd.FileName;
                updateImage(pathTbx.Text);
            }
        }

        private void c_executeBtn_Click(object sender, EventArgs e)
        {
            // ないと思うけどnullチェック
            if (m_bitmap == null)
            {
                return;
            }

            // 実行確認
            if (MessageBox.Show("Updates the active sheet. Are you sure?", "Note", MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                return;
            }

            // 出力対象のアクティブなシートを取得
            var ws = Globals.ThisAddIn.Application.ActiveSheet as Excel.Worksheet;
            if (ws == null)
            {
                MessageBox.Show("No sheet.");
                return;
            }
            // DPIの取得
            double dpiX, dpiY;
            Graphics g = this.CreateGraphics();
            try
            {
                dpiX = g.DpiX;
                dpiY = g.DpiY;
            }
            finally
            {
                g.Dispose();
            }

            // 出力結果のサイズを取得+チェック
            int lastX = m_bitmap.Width / (int)c_numResoHori.Value;
            int lastY = m_bitmap.Height / (int)c_numResoVert.Value;
            if (lastX > ws.Columns.Count)
            {
                MessageBox.Show(string.Format("Result width is too large. (Max = {0}, Result = {1})", ws.Columns.Count, lastX));
                return;
            }
            if (lastY > ws.Rows.Count)
            {
                MessageBox.Show(string.Format("Result height is too large. (Max = {0}, Result = {1})", ws.Rows.Count, lastY));
                return;
            }

            // Color Modeに従い色取得関数をセット
            GetColorMethod getColorMethod;
            if (c_colorModeAll.Checked)
            {
                getColorMethod = getColor;
            }
            else
            {
                getColorMethod = getCompatibleColor;
            }

            // 進捗状況を表示したいので、ProgressBarDialogを生成しておく
            using (var progressBar = new ProgressBarDialog())
            {
                progressBar.c_progressBar.Minimum = 0;
                progressBar.c_progressBar.Maximum = lastX;

                // セルの色設定は時間がかかるので別スレッドで実行(結局UIスレッドの気がする)
                Globals.ThisAddIn.Dispatcher.BeginInvoke((Action)(() =>
                {
                    // 更新を無効化 (確実に戻したいのでfinallyで戻す)
                    Globals.ThisAddIn.Application.ScreenUpdating = false;
                    try
                    {
                        // ExcelのCellのサイズを変更する
                        ws.Cells[1, 1].Resize[lastY].EntireRow.RowHeight = (double)c_numCellHeight.Value * 72 / dpiY;
                        ws.Cells[1, 1].Resize[ColumnSize: lastX].EntireColumn.ColumnWidth = setColWidth(ws, (double)c_numCellWidth.Value, dpiX, 1);

                        // セルに色を設定
                        int progress = 0;
                        using (var bmpPlus = new BitmapPlus.BitmapPlus(m_bitmap))
                        {
                            int widthPerCell  = (int)c_numResoHori.Value;
                            int heightPerCell = (int)c_numResoVert.Value;
                            int transparencyColor = c_pbxTransparency.BackColor.ToArgb();
                            for (int x = 1, imageX = 0; x <= lastX; ++x, imageX += widthPerCell)
                            {
                                for (int y = 1, imageY = 0; y <= lastY; ++y, imageY += heightPerCell)
                                {
                                    var color = getColorMethod(bmpPlus, imageX, imageY, widthPerCell, heightPerCell);
                                    if (c_cbxUseTransparency.Checked && color.ToArgb() == transparencyColor)
                                    {
                                        ws.Cells[y, x].Clear();
                                    }
                                    else
                                    {
                                        ws.Cells[y, x].Interior.Color = color;
                                    }
                                }

                                // 進捗状況を更新
                                ++progress;
                                progressBar.c_progressBar.Value = progress; // 結局UIスレッドなのでInvokeしないで大丈夫
                                Application.DoEvents();

                                // キャンセルチェック
                                if (progressBar.IsCancelled)
                                {
                                    return;
                                }
                            }
                        }
                    }
                    finally
                    {
                        // 更新を戻す
                        Globals.ThisAddIn.Application.ScreenUpdating = true;

                        // 進捗ダイアログを閉じる
                        progressBar.Close();
                    }
                }));

                // 進捗状況ダイアログを表示
                var result = progressBar.ShowDialog();
            }
        }

        private void updateImage(string a_path)
        {
            if (!File.Exists(a_path))
            {
                return;
            }

            if (m_bitmap != null)
            {
                m_bitmap.Dispose();
                m_bitmap = null;
            }

            try
            {
                m_bitmap = new Bitmap(a_path);
	        }
	        catch (ArgumentException)
	        {
                c_pbxImage.Image = null;
                c_labelSize.Text = "";
                c_executeBtn.Enabled = false;
                return;
	        }

            c_pbxImage.Image = m_bitmap;
            c_labelSize.Text = string.Format("width = {0}, height = {1}", m_bitmap.Width, m_bitmap.Height);
            c_numResoHori.Maximum = m_bitmap.Width;
            c_numResoVert.Maximum = m_bitmap.Height;
            c_executeBtn.Enabled = true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <seealso cref="http://dobon.net/vb/dotnet/form/colordialog.html"/>
        private void c_btnSetTransparency_Click(object sender, EventArgs e)
        {
            //ColorDialogクラスのインスタンスを作成
            ColorDialog cd = new ColorDialog();

            //はじめに選択されている色を設定
            cd.Color = c_pbxTransparency.BackColor;
            //色の作成部分を表示可能にする
            //デフォルトがTrueのため必要はない
            cd.AllowFullOpen = true;
            //純色だけに制限しない
            //デフォルトがFalseのため必要はない
            cd.SolidColorOnly = false;

            //ダイアログを表示する
            if (cd.ShowDialog() == DialogResult.OK)
            {
                updateTransparencyColor(cd.Color);
            }
        }

        private void c_pbxImage_MouseDown(object sender, MouseEventArgs e)
        {
            if (m_bitmap == null)
            {
                return;
            }

            Point point = c_pbxImage.TranslatePointToImageCoordinates(e.Location);
            if (0 <= point.X && point.X < m_bitmap.Width
            &&  0 <= point.Y && point.Y < m_bitmap.Height)
            {
                // 選択した色で更新
                Color selectedColor = m_bitmap.GetPixel(point.X, point.Y); ;
                updateTransparencyColor(selectedColor);
            }
        }

        private void updateTransparencyColor(Color a_color)
        {
            c_pbxTransparency.BackColor = a_color;
            c_txtTransparency.Text = string.Format("(R, G, B) = ({0}, {1}, {2})", a_color.R, a_color.G, a_color.B);
        }
    }
}
