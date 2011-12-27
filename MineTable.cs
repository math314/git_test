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

        public MineTable(int w,int h)
        {
            _cells = new MineCell[w][];
        }
    }
}
