using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Excel = Microsoft.Office.Interop.Excel;
using Devcorp.Controls.Design;
using System.Drawing;

namespace CellArtAddIn
{
    /// <summary>
    /// Excel2003と互換性の色を求めるためのクラス
    /// </summary>
    public static class CompatibleColor
    {
        // 2003互換色のリスト(RGBとLab)
        private static List<Tuple<Color, CIELab>> m_color;

        // 高速化のために用意した、任意のRGB→一番近い互換色のDictionary
        private static Dictionary<Color, Color>   m_knownColor;

        static CompatibleColor()
        {
            m_color = createLabColorTable();
            m_knownColor = new Dictionary<Color, Color>();
        }

        static private List<Tuple<Color, CIELab>> createLabColorTable()
        {
            // ExcelのCellのサイズを変更する
            var ws = Globals.ThisAddIn.Application.ActiveSheet as Excel.Worksheet;
            if (ws == null)
            {
                return null;
            }

            // 2003互換色をRGB→Labに変換して格納
            var result = new List<Tuple<Color, CIELab>>();
            for (int i = 1; i < 56; ++i)
            {
                ws.Cells[1, 1].Interior.ColorIndex = i;
                int   color     = (int) ws.Cells[1, 1].Interior.Color; // Colorはdouble型なのでキャストしておく
                Color colorRGB  = Color.FromArgb(color & 0xFF, (color & 0xFF00) >> 8, (color & 0xFF0000) >> 16);
                CIELab colorLab = ColorSpaceHelper.RGBtoLab(colorRGB);
                result.Add(new Tuple<Color, CIELab>(colorRGB, colorLab));
            }

            return result;
        }

        static public Color FindNearestCompatibleColor(Color a_color)
        {
            // 既に計算していたら、その結果を返す
            Color compatiColor;
            if (m_knownColor.TryGetValue(a_color, out compatiColor))
            {
                return compatiColor;
            }

            // 起動時にWorksheetが無い場合はnullになるので、nullチェック
            if (m_color == null)
            {
                m_color = createLabColorTable();
            }

            // 最もユークリッド距離が近い色を求める
            // 56色しかないので線形探索で求めちゃう。。。
            // http://www.theswamp.org/index.php?topic=41911.0
            var lab   = ColorSpaceHelper.RGBtoLab(a_color);
            var items = m_color.AsParallel().Select(tuple => new {color = tuple.Item1, distance = Math.Pow(tuple.Item2.L - lab.L, 2) +
                                                                                                  Math.Pow(tuple.Item2.A - lab.A, 2) +
                                                                                                  Math.Pow(tuple.Item2.B - lab.B, 2) });
            compatiColor = items.AsParallel().Aggregate((lhs, rhs) => lhs.distance < rhs.distance ? lhs : rhs).color;

            // 高速化のため、計算結果を格納しておく
            m_knownColor.Add(a_color, compatiColor);

            // 見つけた互換色を返す
            return compatiColor;
        }
    }
}
