using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Collections;

namespace git_test
{
    public class MineTable : IEnumerable<MineRow>
    {
        /// <summary> 行 </summary>
        private readonly MineRow[] _rows;

        /// <summary> 列数 </summary>
        private readonly int _colCount;

        /// <summary> 列数 </summary>
        public int ColumnCount
        {
            get
            {
                return _colCount;
            }
        }

        /// <summary> 行数 </summary>
        public int RowCount
        {
            get
            {
                return _rows.Length;
            }
        }

        /// <summary>
        /// セルを取得します
        /// </summary>
        /// <param name="row">行番号</param>
        /// <returns>セル</returns>
        public MineRow this[int row]
        {
            get{
                return _rows[row];
            }
        }

        /// <summary>
        /// テーブルを作成します
        /// </summary>
        /// <param name="w"></param>
        /// <param name="h"></param>
        public MineTable(int w, int h)
        {
            _colCount = w;  //横幅の設定

            //セルの作成
            _rows = new MineRow[h];
            for (int i = 0; i < h; i++)
            {
                _rows[i] = new MineRow(this,i);
            }
        }

        public IEnumerator<MineRow> GetEnumerator()
        {
            foreach (var item in _rows)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
