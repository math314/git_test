using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Drawing;

namespace git_test
{
    public class MineView : IDisposable
    {
        private readonly MineModel _model;

        private readonly ConsoleCanvasManager _conManager = new ConsoleCanvasManager();

        private readonly ConsoleCanvas _mineTableCanvas;

        private readonly ConsoleCanvas _mineTableInfoCanvas;

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

            _mineTableCanvas = new ConsoleCanvas(new Rectangle(1, 1, table.ColumnCount, table.RowCount));
            _mineTableInfoCanvas = new ConsoleCanvas(new Rectangle(table.ColumnCount + 10, 8, 10, table.RowCount));

            _conManager.AddCanvas(_mineTableCanvas);
            _conManager.AddCanvas(_mineTableInfoCanvas);
        }

        /// <summary>
        /// 現在のセルを状態を描画します
        /// </summary>
        public void Draw()
        {
            //カーソルの位置を設定する
            _conManager.SetCursor(
                _mineTableCanvas.Rect.X + _model.Current.ColumnIndex,
                _mineTableCanvas.Rect.Y + _model.Current.RowIndex);

            //セルの状態を描画する
            _mineTableCanvas.SB.Append(GetCells());
            //テーブルの情報を描画する
            _mineTableInfoCanvas.SB.Append(GetTableInfo());

            //全て描画
            _conManager.DrawAllCanvas();
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
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("cursor : col {0},row {1}", _model.Current.ColumnIndex, _model.Current.RowIndex);
            sb.Append("\n\n");
            sb.AppendFormat("Bomb : {0}",_model.BombSum - _model.FlagSum);

            if (!_model.IsGameStarted)
            {
                sb.Append("\n\n");
                sb.Append("Press Enter And Start Game");
            }

            return sb.ToString();
        }

        public void Dispose()
        {
            _conManager.Dispose();
        }
    }
}
