using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace git_test
{
    /// <summary>
    /// Consoleへの描画を管理するクラス
    /// </summary>
    public class ConsoleCanvasManager : IDisposable
    {
        /// <summary> コンソールの描画を開始するY座標 </summary>
        private readonly int _consoleTop;

        /// <summary> 横幅 </summary>
        private int _w;
        /// <summary> 縦幅 </summary>
        private int _h;

        /// <summary> ConsoleCanvasのリスト </summary>
        private readonly List<ConsoleCanvas> _canvasList;

        /// <summary> キャンバスのバッファ </summary>
        StringBuilder _sb = new StringBuilder();

        /// <summary> カーソルのx座標 </summary>
        private int _cx;
        /// <summary> カーソルのy座標 </summary>
        private int _cy;

        /// <summary>
        /// Consoleへの描画を管理するクラス
        /// サイズは自動的に設定されます
        /// </summary>
        public ConsoleCanvasManager()
            : this(Console.WindowWidth - 1, Console.WindowHeight - 1)
        {
        }

        /// <summary>
        /// Consoleへの描画を管理するクラス
        /// </summary>
        /// <param name="w">横幅</param>
        /// <param name="h">縦幅</param>
        public ConsoleCanvasManager(int w, int h)
        {
            //座標を取得する
            _consoleTop = Console.CursorTop;

            _sb = new StringBuilder();
            _canvasList = new List<ConsoleCanvas>();

            SetCursor(0, 0); //カーソルの設定
            Resize(w, h); //サイズの設定
        }

        /// <summary>
        /// サイズを変更する
        /// </summary>
        /// <param name="w">横幅</param>
        /// <param name="h">縦幅</param>
        public void Resize(int w, int h)
        {
            _w = w;
            _h = h;
        }

        /// <summary>
        /// カーソルを設定する
        /// </summary>
        /// <param name="x">x座標</param>
        /// <param name="y">y座標</param>
        public void SetCursor(int x, int y)
        {
            SetCursor(x, y, false);
        }

        /// <summary>
        /// カーソルを設定する
        /// </summary>
        /// <param name="x">x座標</param>
        /// <param name="y">y座標</param>
        public void SetCursor(int x, int y, bool refresh)
        {
            _cx = x;
            _cy = y;
            if (refresh)
                Console.SetCursorPosition(_cx, _cy);
        }

        /// <summary>
        /// テキストを描画する
        /// </summary>
        /// <param name="x">x座標</param>
        /// <param name="y">y座標</param>
        /// <param name="text">テキスト</param>
        public void DrawString(int x, int y, string text)
        {
            if (y >= _h)
                return; //縦方向にはみ出したものは描画しない

            int drawLendth = Math.Min(text.Length, _w - x); //書き込む長さを設定する
            int startIndex = y * (_w + 1) + x;

            _sb.Remove(startIndex, drawLendth);
            _sb.Insert(startIndex, text.Substring(0, drawLendth));
        }

        /// <summary>
        /// 描画するキャンバスを追加する
        /// </summary>
        /// <param name="canvas">追加するキャンバス</param>
        public void AddCanvas(ConsoleCanvas canvas)
        {
            _canvasList.Add(canvas);
        }

        /// <summary>
        /// 全て描画します
        /// </summary>
        public void DrawAllCanvas()
        {
            ClearBuffer(); //画面をクリアする

            _canvasList.ForEach(canvas =>
            {
                canvas.Draw(this); //描画
                canvas.SB.Clear(); //クリア
            }); //全て描画

            int left = Console.WindowLeft;
            int top = Console.WindowTop;

            Console.CursorVisible = false; //カーソルのちらつきを抑えるために見えなくする
            try
            {
                Console.SetCursorPosition(0, _consoleTop);

                Console.Write(_sb.ToString());

                Console.SetCursorPosition(_cx, _consoleTop + _cy);
            }
            finally
            {
                Console.CursorVisible = true; //カーソルを見えるように戻す
            }
        }

        /// <summary>
        /// 画面をクリアする
        /// </summary>
        private void ClearBuffer()
        {
            _sb.Clear();

            for (int i = 0; i < _h; i++)
            {
                _sb.Append(' ', _w);
                _sb.Append('\n');
            }
        }

        /// <summary>
        /// 解放する
        /// </summary>
        public void Dispose()
        {
            SetCursor(0, _consoleTop + _h, true);
        }
    }

}
