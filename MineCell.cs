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
        public bool IsOpened { get; set; }

        /// <summary> 爆弾かどうか </summary>
        public bool IsBomb { get; set; }

        /// <summary> フラグが立てられているかどうか </summary>
        public bool IsFlaged { get; set; }

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

        /// <summary>
        /// セルを作成します
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="col"></param>
        public MineCell(MineRow parent, int col)
        {
            _parent = parent;
            _index = col;

            Reset(); //リセットを行う
        }

        /// <summary>
        /// リセット
        /// </summary>
        public void Reset()
        {
            IsBomb = false;
            IsOpened = false;
            IsFlaged = false;
        }

        /// <summary>
        /// このセルを開く
        /// </summary>
        public void Open()
        {
            if (IsOpened || IsFlaged)
                return; //開けなかった

            IsOpened = true;  //開く
            IsFlaged = false; //旗を念のため下ろしておく

            if (IsBomb)
                return; //ボムだったら帰る

            if (CountAroundBombs() == 0) //ボムがなかったら
            {
                foreach (var cell in EnumerateAroundCells())
                    cell.Open(); //周りのセルも開く
            }
        }

        /// <summary>
        /// 旗マークを反転させる
        /// </summary>
        public void TurnFlag()
        {
            if (IsOpened)
                return; //開かれていたらフラグは立てない

            IsFlaged = !IsFlaged; //フラグの反転
        }

        /// <summary>
        /// 次のセルを取得する
        /// </summary>
        /// <returns></returns>
        public MineCell NextCell()
        {
            if (ColumnIndex >= Table.ColumnCount - 1)
                return (RowIndex < Table.RowCount - 1) ? Table[RowIndex][0] : Table[0][0];
            else
                return Table[RowIndex][ColumnIndex + 1];
        }

        /// <summary>
        /// 現在のセルの状態を、文字として取得します
        /// </summary>
        /// <returns></returns>
        public char ToChar()
        {
            if (IsOpened)
            {
                if (IsBomb)
                    return '*'; //ボムだった

                int bombCount = CountAroundBombs();
                if (bombCount == 0)
                    return '.'; //周りにボムがなかった！
                else
                    return bombCount.ToString()[0]; //ボムの数を返す
            }
            else
            {
                if (IsFlaged)
                    return 'F'; //フラグが立てられている
                else
                    return 'x';
            }
        }

        /// <summary>
        /// まわりのボム数を数える
        /// </summary>
        public int CountAroundBombs()
        {
            return EnumerateAroundCells().Count(cell => cell.IsBomb);
        }

        /// <summary>
        /// 周りのボムを列挙します
        /// </summary>
        public virtual IEnumerable<MineCell> EnumerateAroundCells()
        {
            //上のセル
            if (RowIndex > 0)
            {
                if (ColumnIndex > 0)
                    yield return Table[RowIndex - 1][ColumnIndex - 1];
                yield return Table[RowIndex - 1][ColumnIndex];
                if (ColumnIndex < Table.ColumnCount - 1)
                    yield return Table[RowIndex - 1][ColumnIndex + 1];
            }

            //同じ列のセル
            if (ColumnIndex > 0)
                yield return Table[RowIndex][ColumnIndex - 1];
            if (ColumnIndex < Table.ColumnCount - 1)
                yield return Table[RowIndex][ColumnIndex + 1];

            //下のセル
            if (RowIndex < Table.RowCount - 1)
            {
                if (ColumnIndex > 0)
                    yield return Table[RowIndex + 1][ColumnIndex - 1];
                yield return Table[RowIndex + 1][ColumnIndex];
                if (ColumnIndex < Table.ColumnCount - 1)
                    yield return Table[RowIndex + 1][ColumnIndex + 1];
            }
        }

        /// <summary>
        /// ToStringのoverride
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("({0},{1}) : {2}", ColumnIndex, RowIndex, ToChar());
        }

        /// <summary>
        /// 自身が開かれていて、周りのフラグが十分に立てられている時(周りのボム数 = 周りのフラグ数)に
        /// 周りのセルを全て開きます
        /// </summary>
        public void OpenAroundIfFlagsFilled()
        {
            if (!IsOpened)
                return; //開かれていない

            if (CountAroundBombs() == EnumerateAroundCells().Count(cell => cell.IsFlaged)) //ボム数 = フラグ数
            {
                foreach (var cell in EnumerateAroundCells())
                    cell.Open(); //周りのセルも開く
            }
        }

    }
}
