using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace git_test
{
    public class MineModel
    {
        private MineTable _table;

        public MineModel()
        {
            _table = new MineTable(20, 30);
        }
    }
}
