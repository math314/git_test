using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace git_test
{
    public class MineRow : IEnumerable<MineCell>
    {
        private readonly MineTable _parent;
        private readonly int _rowIdx;

        /// <summary>
        /// 列のインデックス
        /// </summary>
        public int RowIndex
        {
            get { return _rowIdx; }
        }

        /// <summary>
        /// 親のテーブル
        /// </summary>
        public MineTable Table
        {
            get { return _parent; }
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

        public IEnumerator<MineCell> GetEnumerator()
        {
            foreach (var item in _cells)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public override string ToString()
        {
            return string.Format("Row :{0} {1}", _rowIdx,
                new string(_cells.Select(cell => cell.ToChar()).ToArray())
                );   
        }
    }
}
