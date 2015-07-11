using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Excel = Microsoft.Office.Interop.Excel;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Tools.Excel;
using System.Windows.Forms;
using Microsoft.Office.Tools;
using System.Windows.Threading;

// リボンの追加
// http://dev.classmethod.jp/tool/excel_addin_ribbon/
// http://code.msdn.microsoft.com/office/10-C-Office-cd6ea602

// アイコン
// http://sozai.7gates.net/0100/?limit=14&offset=238

//インストーラの作り方
// http://wannabe-note.com/525
//
// セットアッププロジェクトでのインストーラの作り方
// この中の「Shared PIA availability」辺りはExcel2007 or 2010のやりかたがわからなかったのでやってない
// https://msdn.microsoft.com/ja-JP/library/ff937654.aspx

namespace CellArtAddIn
{
    public partial class ThisAddIn
    {
        private UserControl m_control = new MyUserControl();

        // http://stackoverflow.com/questions/5567858/vsto-invoking-on-main-excel-thread
        private Dispatcher m_dispatcher = Dispatcher.CurrentDispatcher;
        public Dispatcher Dispatcher
        {
            get
            {
                return m_dispatcher;
            }
        }

        private CustomTaskPane m_panel;
        public CustomTaskPane CustomPanel
        {
            get
            {
                return m_panel;
            }
        }

        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            m_control.AutoSize = true;
            m_panel = CustomTaskPanes.Add(m_control, "Cell Art");
            m_panel.Width = m_control.PreferredSize.Width + 10;
            m_panel.VisibleChanged += (snd, ev) =>
            {
                var r = Globals.Ribbons.GetRibbon(typeof(MyRibbon));
                var ribbon = r as MyRibbon;
                if (ribbon != null)
                {
                    ribbon.ChangeStatus(m_panel.Visible);
                }
            };
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
        }

        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }
        
        #endregion
    }
}
