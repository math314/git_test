using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace git_test
{
    public class MineModel
    {
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


        public MineModel()
        {
            _table = new MineTable(40, 20);
            BombSum = 60;
        }
    }
}
