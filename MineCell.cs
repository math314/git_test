using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace git_test
{
    public class MineCell
    {
        /// <summary> セルが開かれたかどうか </summary>
        public bool IsOpened;

        /// <summary> 爆弾かどうか </summary>
        public bool IsBomb { get; set; }

        private readonly MineTable _parent;

        /// <summary>
        /// 行
        /// </summary>
        public int RowIndex { get; set; }
        /// <summary>
        /// 列
        /// </summary>
        public int ColumnIndex { get; set; }


        public MineCell(MineTable parent, int col, int row)
        {
            _parent = parent;
            RowIndex = row;
            ColumnIndex = col;
        }

        /// <summary>
        /// このセルを開く
        /// </summary>
        public void Open()
        {
            IsOpened = true;
        }

        public char ToChar()
        {
            if (IsOpened)
                return 'o';
            else
                return 'x';
        }

        public override string ToString()
        {
            return ToChar().ToString();
        }
    }
}
