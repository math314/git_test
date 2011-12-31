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

        private readonly ConsoleCanvasManager _conManager = new ConsoleCanvasManager();

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
            _conManager.DrawAllCanvas();

            //Console.CursorVisible = false; //カーソルのちらつきを抑えるために見えなくする

            //try
            //{
            //    //カーソルの位置を最初に戻す
            //    Console.SetCursorPosition(0, 0);

            //    //セルの状態を描画する
            //    Console.Write(GetCells());

            //    Console.WriteLine("");

            //    //テーブルの情報を描画する
            //    Console.Write(GetTableInfo());

            //    //カーソルの位置を戻す
            //    Console.SetCursorPosition(_model.Current.ColumnIndex, _model.Current.RowIndex);
            //}
            //finally
            //{
            //    Console.CursorVisible = true; //カーソルを見えるように戻す
            //}
        }

        /// <summary>
        /// 現在のセルの状態を、文字列として取得します
        /// </summary>
        /// <returns></returns>
        private string GetCells()
        {
            StringBuilder sb = new StringBuilder(table.RowCount * ( table.ColumnCount + 1));

            foreach (var row in table)
            {
                foreach (var cell in row)
                {
                    sb.Append(cell.ToChar());
                }

                //次の行に移動する
                sb.Append('\n');
            }

            return sb.ToString();
        }

        private string GetTableInfo()
        {
            return string.Format("cursor : col {0},row {1}", _model.Current.ColumnIndex, _model.Current.RowIndex)
                .PadRight(30);
        }
    }
}
