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

        public int CurrentColumnIdx { get; set; }
        public int CurrentRowIdx { get; set; }

        /// <summary>
        /// 現在のセル
        /// </summary>
        public MineCell Current
        {
            get
            {
                return this[CurrentColumnIdx, CurrentRowIdx];
            }
        }

        /// <summary>
        /// セルを取得します
        /// </summary>
        /// <param name="col">列</param>
        /// <param name="row">行</param>
        /// <returns>セル</returns>
        public MineCell this[int col,int row]
        {
            get{
                return _cells[col][row];
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
