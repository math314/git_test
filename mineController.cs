using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace git_test
{
    public class MineController
    {
        private readonly MineModel _model;

        private MineTable table
        {
            get { return _model.Table; }
        }

        /// <summary>
        /// コントローラ作成
        /// </summary>
        /// <param name="model"></param>
        public MineController(MineModel model)
        {
            _model = model;
        }

        /// <summary>
        /// 現在のセルを開く
        /// </summary>
        public void OpenCurrentCell()
        {
            table.Current.Open();    //現在のセルを開いた
        }

        /// <summary>
        /// カーソルを動かす
        /// </summary>
        /// <param name="moveDirection"></param>
        public void MoveCursor(MoveDirection moveDirection)
        {
            switch (moveDirection)
            {
                case MoveDirection.Up:
                    table.CurrentRowIdx = Math.Max(table.CurrentRowIdx - 1, 0);
                    break;
                case MoveDirection.Down:
                    table.CurrentRowIdx = Math.Min(table.CurrentRowIdx + 1, table.RowCount - 1);
                    break;
                case MoveDirection.Left:
                    table.CurrentColumnIdx = Math.Max(table.CurrentColumnIdx - 1, 0);
                    break;
                case MoveDirection.Right:
                    table.CurrentColumnIdx = Math.Min(table.CurrentColumnIdx + 1, table.ColumnCount - 1);
                    break;
                default:
                    break;
            }
        }
    }
}
