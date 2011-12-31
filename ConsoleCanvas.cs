using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace git_test
{
    /// <summary>
    /// Consoleへの描画を管理するクラス
    /// </summary>
    public class ConsoleCanvasManager
    {
        /// <summary> コンソールの描画を開始するY座標 </summary>
        private readonly int _consoleTop;

        /// <summary> 横幅 </summary>
        private int _w;
        /// <summary> 縦幅 </summary>
        private int _h;

        private readonly List<ConsoleCanvas> _canvasList;

        /// <summary> キャンバスのバッファ </summary>
        StringBuilder _sb = new StringBuilder();

        /// <summary>
        /// Consoleへの描画を管理するクラス
        /// サイズは自動的に設定されます
        /// </summary>
        public ConsoleCanvasManager()
            : this(Console.BufferWidth - 1,Console.BufferHeight)
        {
        }

        /// <summary>
        /// Consoleへの描画を管理するクラス
        /// </summary>
        /// <param name="w">横幅</param>
        /// <param name="h">縦幅</param>
        public ConsoleCanvasManager(int w,int h)
        {
            //座標を取得する
            _consoleTop = Console.CursorTop;

            _sb = new StringBuilder();
            _canvasList = new List<ConsoleCanvas>();

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

            _canvasList.ForEach(canvas => canvas.Draw(this)); //全て描画

            int left = Console.WindowLeft;
            int top = Console.WindowTop;

            Console.CursorVisible = false; //カーソルのちらつきを抑えるために見えなくする
            try
            {
                Console.SetCursorPosition(0, Console.CursorTop);

                Console.Write(_sb.ToString());

                Console.SetCursorPosition(left, top);
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
                _sb.Append('_', _w);
                _sb.Append('\n');
            }
        }
    }

    /// <summary>
    /// Consoleに文字などを描画するためのクラス
    /// </summary>
    public class ConsoleCanvas
    {
        /// <summary> x座標 </summary>
        public int X { get; set; }
        /// <summary> y座標 </summary>
        public int Y { get; set; }

        /// <summary> 描画する文字列 </summary>
        private List<string> _strList;

        /// <summary>
        /// コンソール
        /// </summary>
        public ConsoleCanvas(int x,int y)
        {
            X = x;
            Y = y;
            _strList = new List<string>();
        }

        /// <summary>
        /// 描画します
        /// </summary>
        /// <param name="manager">ConsoleCanvasManager</param>
        public void Draw(ConsoleCanvasManager manager)
        {
        }
    }

}
