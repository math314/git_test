using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace git_test
{
    public class MineModel
    {
        #region メンバ変数、プロパティ

        private MineTable _table;

        /// <summary>
        /// マインスイーパのテーブル
        /// </summary>
        public MineTable Table
        {
            get { return _table; }
        }

        /// <summary>
        /// 現在選択されているセルの列
        /// </summary>
        public int CurrentColumnIdx { get; set; }
        /// <summary>
        /// 現在選択されているセルの行
        /// </summary>
        public int CurrentRowIdx { get; set; }

        /// <summary>
        /// 現在のセル
        /// </summary>
        public MineCell Current
        {
            get
            {
                return _table[CurrentRowIdx][CurrentColumnIdx];
            }
        }

        /// <summary>
        /// ボムの合計数
        /// </summary>
        public int BombSum { get; set; }

        /// <summary>
        /// フラグの合計数
        /// </summary>
        public int FlagSum
        {
            get
            {
                return _table.Sum(row => row.Count(cell => cell.IsFlaged));
            }
        }

        /// <summary>
        /// ゲームが開始されているか
        /// </summary>
        public bool IsGameStarted { get; set; }

        /// <summary>
        /// ゲームの時間
        /// </summary>
        public int GameTime { get; set; }


        #endregion

        public MineModel()
        {
            _table = new MineTable(40, 20);
            BombSum = 60;
            IsGameStarted = false; 
        }
    }
}
