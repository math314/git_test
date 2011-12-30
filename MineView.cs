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
        /// MineTableの取得
        /// </summary>
        private MineTable table
        {
            get { return _model.Table; }
        }

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

            //セルの状態を描画する
            Console.Write(GetCells());

            //カーソルの位置を戻す
            Console.SetCursorPosition(table.Current.ColumnIndex, table.Current.RowIndex);
        }

        /// <summary>
        /// 現在のセルの状態を、文字列として取得します
        /// </summary>
        /// <returns></returns>
        private string GetCells()
        {
            StringBuilder sb = new StringBuilder(table.RowCount * ( table.ColumnCount + 1));

            //セルをすべて表示
            for (int i = 0; i < table.RowCount; i++)
            {
                for (int j = 0; j < table.ColumnCount; j++)
                {
                    sb.Append(table[i][j].ToChar());
                }

                //次の行に移動する
                sb.Append('\n');
            }

            return sb.ToString();
        }
    }
}
