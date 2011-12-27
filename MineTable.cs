using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace git_test
{
    public class MineTable
    {
        /// <summary> マス </summary>
        MineCell[][] _cells;

        /// <summary> 列数 </summary>
        public int ColumnCount
        {
            get
            {
                return _cells.Length;
            }
        }

        /// <summary> 行数 </summary>
        public int RowCount
        {
            get
            {
                return _cells[0].Length;
            }
        }

        /// <summary>
        /// セルを取得します
        /// </summary>
        /// <param name="x">x座標</param>
        /// <param name="y">y座標</param>
        /// <returns>セル</returns>
        public MineCell this[int x,int y]
        {
            get{
                return _cells[x][y];
            }
        }

        /// <summary>
        /// テーブルを作成します
        /// </summary>
        /// <param name="w"></param>
        /// <param name="h"></param>
        public MineTable(int w,int h)
        {
            //セルの作成
            _cells = new MineCell[w][];
            for (int i = 0; i < w; i++)
            {
                _cells[i] = new MineCell[h];
                for (int j = 0; j < h; j++)
                    _cells[i][j] = new MineCell(this, i, j);
            }
        }
    }
}
