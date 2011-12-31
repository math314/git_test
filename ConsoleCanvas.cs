using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;

namespace git_test
{
    /// <summary>
    /// Consoleに文字などを描画するためのクラス
    /// </summary>
    public class ConsoleCanvas
    {
        public Rectangle Rect { get; set; }

        private StringBuilder _sb;
        /// <summary> 描画する文字列 </summary>
        public StringBuilder SB { get { return _sb; } }

        public ConsoleCanvas(Rectangle rect)
        {
            Rect = rect;
            _sb = new StringBuilder();
        }

        /// <summary>
        /// 描画します
        /// </summary>
        /// <param name="manager">ConsoleCanvasManager</param>
        public void Draw(ConsoleCanvasManager manager)
        {
            var textHeightPairs = Enumerable.Zip(
                SB.ToString().Split('\n'),
                Enumerable.Range(Rect.Y,Rect.Height),
                (str,i) => new {text = str, h = i}
                );

            //縦幅だけ回す
            foreach (var textHeightPair in textHeightPairs)
            {
                manager.DrawString(Rect.X, textHeightPair.h, textHeightPair.text); //文字列を書きこむ
            } 
        }
    }

}
