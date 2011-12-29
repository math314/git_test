using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace git_test
{
    public class MineView
    {
        private readonly MineModel _model;

        /// <summary>
        /// マインスイーパのビュー
        /// </summary>
        /// <param name="model"></param>
        public MineView(MineModel model)
        {
            _model = model;
        }

        /// <summary>
        /// 現在のセルを状態を描画します
        /// </summary>
        public void Draw()
        {
            //カーソルの位置を最初に戻す
            Console.SetCursorPosition(0, 0);

            //セルをすべて表示
            for (int i = 0; i < _model.Table.RowCount; i++)
            {
                for (int j = 0; j < _model.Table.ColumnCount; j++)
                {
                    Console.Write(_model.Table[j, i].ToChar());
                }

                //次の行に移動する
                Console.Write('\n');
            }

            Console.SetCursorPosition(_model.Table.Current.ColumnIndex, _model.Table.Current.RowIndex);
        }
    }
}
