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

        public MineModel()
        {
            _table = new MineTable(40, 20);
        }
    }
}
