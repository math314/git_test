using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace git_test
{
    public class MineCell
    {
        #region メンバ変数、プロパティ

        /// <summary> セルが開かれたかどうか </summary>
        public bool IsOpened;

        /// <summary> 爆弾かどうか </summary>
        public bool IsBomb { get; set; }

        private readonly MineRow _parent;

        /// <summary>
        /// このセルの所属している列
        /// </summary>
        public MineRow OwningRow
        {
            get { return _parent; }
        }

        /// <summary>
        /// このセルの所属しているテーブル
        /// </summary>
        public MineTable Table
        {
            get { return _parent.Table; }
        }

        /// <summary>
        /// 行
        /// </summary>
        public int RowIndex
        {
            get { return _parent.RowIndex; }
        }

        private readonly int _index;

        /// <summary>
        /// 列
        /// </summary>
        public int ColumnIndex
        {
            get { return _index; }
        }

        #endregion

        public MineCell(MineRow parent, int col)
        {
            _parent = parent;
            _index = col;
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
            {
                if (IsBomb)
                    return '*'; //ボムだった

                int bombCount = CountAroundBombs() ;
                if (bombCount == 0)
                    return '.'; //周りにボムがなかった！
                else
                    return bombCount.ToString()[0]; //ボムの数を返す
            }
            else
            {
                return 'x';
            }
        }

        /// <summary>
        /// まわりのボム数を数える
        /// </summary>
        private int CountAroundBombs()
        {
            return EnumerateAroundCells().Count(cell => cell.IsBomb);
        }

        /// <summary>
        /// 周りのボムを列挙します
        /// </summary>
        protected virtual IEnumerable<MineCell> EnumerateAroundCells()
        {
            //上のセル
            if (RowIndex > 0)
            {
                if (ColumnIndex > 0)
                    yield return Table[RowIndex - 1][ColumnIndex - 1];
                yield return Table[RowIndex - 1][ColumnIndex];
                if (ColumnIndex < Table.RowCount - 1)
                    yield return Table[RowIndex - 1][ColumnIndex + 1];
            }

            //同じ列のセル
            if (ColumnIndex > 0)
                yield return Table[RowIndex][ColumnIndex - 1];
            if (ColumnIndex < Table.RowCount - 1)
                yield return Table[RowIndex][ColumnIndex + 1];

            //下のセル
            if (RowIndex < Table.RowCount - 1)
            {
                if (ColumnIndex > 0)
                    yield return Table[RowIndex + 1][ColumnIndex - 1];
                yield return Table[RowIndex + 1][ColumnIndex];
                if (ColumnIndex < Table.RowCount - 1)
                    yield return Table[RowIndex + 1][ColumnIndex + 1];
            }
        }

        public override string ToString()
        {
            return ToChar().ToString();
        }
    }
}
