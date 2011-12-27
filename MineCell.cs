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
        private readonly Point _point;

        public MineCell(MineTable parent, int col, int row)
        {
            _parent = parent;
            _point = new Point(col, row);
        }
    }
}
