using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace git_test
{
    public class MineRow
    {
        private readonly MineTable _parent;
        private readonly int _rowIdx;

        /// <summary>
        /// 列のインデックス
        /// </summary>
        public int Index
        {
            get { return _rowIdx; }
        }

        private readonly MineCell[] _cells;

        /// <summary>
        /// セルを取得します
        /// </summary>
        /// <param name="col"></param>
        /// <returns></returns>
        public MineCell this[int col]
        {
            get { return _cells[col]; }
        }

        public MineRow(MineTable parent, int row)
        {
            _parent = parent;
            _rowIdx = row;

            //セルの作成
            _cells = new MineCell[parent.ColumnCount];
            for (int i = 0; i < _cells.Length; i++)
            {
                _cells[i] = new MineCell(this, i);
            }
        }
    }
}
