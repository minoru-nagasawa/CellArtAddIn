// ★★★注意★★★★★★★★★★★★★★★★★★★★★★★★★★★★★
// このサンプルではunsafeを使用しているため、プロジェクトのプロパティで
// アンセーフコードの許可を設定する必要があります。
// ★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;

namespace BitmapPlus
{
    /// <summary>
    /// Bitmap処理を高速化するためのクラス
    /// usingで使えるように、IDisposableを実装
    /// </summary>
    /// <seealso cref="http://homepage2.nifty.com/nonnon/SoftSample/CS.NET/SampleBitmapPlus.html"/>
    public class BitmapPlus : IDisposable
    {
        #region IDisposable
        // Dispose したかどうか
        // http://msdn.microsoft.com/ja-jp/library/fs2xkftw.aspx
        // http://yohshiy.blog.fc2.com/blog-entry-212.html
        private bool _disposed = false;

        // IDisposable に必須のメソッドの実装
        public void Dispose()
        {
            Dispose(true);

            // Dispose() によってリソースの解放を行ったので、
            // GC での解放が必要が無いことを GC に通知します。
            GC.SuppressFinalize(this);
        }

        // ファイナライザー(デストラクター)
        // Dispose() が呼び出されていない場合のみ
        // 実行されます。
        ~BitmapPlus()
        {
            Dispose(false);
        }

        // このメソッドの呼び出され方は 2 パターンあります。
        // disposing が true であれば、 Dispose() から呼び出されています。
        // disposing が false であれば、 ファイナライザー(~BitmapPlus)
        // から呼び出されています。
        protected virtual void Dispose(bool disposing)
        {
            // Dispose がまだ実行されていないときだけ実行
            if (_disposed)
            {
                return; 
            }

            // disposing が true の場合(Dispose() が実行された場合)は
            // マネージリソースも解放します。
            if (disposing)
            {
                // マネージリソースの解放
                //_bmp = null; // 上位で同じオブジェクトを使用するので、BitmapのDisposeはしない
            }

            // アンマネージリソースの解放
            EndAccess();
            _disposed = true;
        }
        #endregion

        /// <summary>
        /// オリジナルのBitmapオブジェクト
        /// </summary>
        private Bitmap _bmp = null;

        /// <summary>
        /// Bitmapに直接アクセスするためのオブジェクト
        /// </summary>
        private BitmapData _img = null;

        /// <summary>
        /// この System.Drawing.Image の幅 (ピクセル単位) を取得します。
        /// </summary>
        public int Width
        {
            get
            {
                return _bmp.Width;
            }
        }
        
        /// <summary>
        /// この System.Drawing.Image の高さ (ピクセル単位) を取得します。
        /// </summary>
        public int Height
        {
            get
            {
                return _bmp.Height;
            }
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="original"></param>
        public BitmapPlus(Bitmap original)
        {
            // オリジナルのBitmapオブジェクトを保存
            _bmp = original;

            // 高速化開始
            BeginAccess();
        }

        /// <summary>
        /// BitmapのGetPixel同等
        /// </summary>
        /// <param name="baseX">Ｘ座標</param>
        /// <param name="y">Ｙ座標</param>
        /// <returns>Colorオブジェクト</returns>
        public Color GetPixel(int x, int y)
        {
            unsafe
            {
                // Bitmap処理の高速化を開始している場合はBitmapメモリへの直接アクセス
                byte* adr = (byte*)_img.Scan0;
                int pos = x * 3 + _img.Stride * y;
                byte b = adr[pos + 0];
                byte g = adr[pos + 1];
                byte r = adr[pos + 2];
                return Color.FromArgb(r, g, b);
            }
        }

        /// <summary>
        /// BitmapのSetPixel同等
        /// </summary>
        /// <param name="baseX">Ｘ座標</param>
        /// <param name="y">Ｙ座標</param>
        /// <param name="col">Colorオブジェクト</param>
        public void SetPixel(int x, int y, Color col)
        {
            unsafe
            {
                // Bitmap処理の高速化を開始している場合はBitmapメモリへの直接アクセス
                byte* adr = (byte*)_img.Scan0;
                int pos = x * 3 + _img.Stride * y;
                adr[pos + 0] = col.B;
                adr[pos + 1] = col.G;
                adr[pos + 2] = col.R;
            }
        }

        /// <summary>
        /// Bitmap処理の高速化開始
        /// using前提のためprivate化
        /// </summary>
        private void BeginAccess()
        {
            // Bitmapに直接アクセスするためのオブジェクト取得(LockBits)
            _img = _bmp.LockBits(new Rectangle(0, 0, _bmp.Width, _bmp.Height),
                System.Drawing.Imaging.ImageLockMode.ReadWrite,
                System.Drawing.Imaging.PixelFormat.Format24bppRgb);
        }

        /// <summary>
        /// Bitmap処理の高速化終了
        /// using前提のためprivate化
        /// </summary>
        private void EndAccess()
        {
            if (_img != null)
            {
                // Bitmapに直接アクセスするためのオブジェクト開放(UnlockBits)
                _bmp.UnlockBits(_img);
                _img = null;
            }
        }
    }
}