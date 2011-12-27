using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace git_test
{
    public class MineController
    {

        /// <summary> 縦方向のブロック数 </summary>
        public int VBlock;
        /// <summary> 横方向のブロック数 </summary>
        public int HBlock;

        public MineController()
        {
            VBlock = 10;
            HBlock = 15;
        }

        /// <summary>
        /// 描画時に呼び出されます
        /// </summary>
        /// <param name="size"></param>
        /// <param name="g"></param>
        public void OnPaint(SizeF size, Graphics g)
        {
            g.Clear(Color.White);

            for (int v = 0; v < VBlock; v++)
            {
                for (int h = 0; h < HBlock; h++)
                {
                    OnCellDraw(new RectangleF(size.Width * h / HBlock, size.Height * v / VBlock,
                        size.Width / HBlock, size.Height / VBlock),
                        g);
                }
            }
        }

        /// <summary>
        /// セルの描画
        /// </summary>
        /// <param name="loc"></param>
        /// <param name="size"></param>
        /// <param name="g"></param>
        private void OnCellDraw(RectangleF rect , Graphics g)
        {
            g.DrawRectangle(Pens.Aquamarine, Rectangle.Ceiling(rect));
            //g.FillRectangle(Brushes.Aqua, rect);
        }
    }
}
