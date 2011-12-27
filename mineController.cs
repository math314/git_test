﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace git_test
{
    public class MineController
    {
        private readonly MineModel _model;

        /// <summary>
        /// コントローラ作成
        /// </summary>
        /// <param name="model"></param>
        public MineController(MineModel model)
        {
            _model = model;
        }

        /// <summary>
        /// 現在のセルを選択する
        /// </summary>
        internal void SelectCurrentCell()
        {
        }
    }
}
