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
        /// カーソルを動かす
        /// </summary>
        /// <param name="moveDirection"></param>
        public void MoveCursor(MoveDirection moveDirection)
        {
            switch (moveDirection)
            {
                case MoveDirection.Up:
                    _model.CurrentRowIdx = Math.Max(_model.CurrentRowIdx - 1, 0);
                    break;
                case MoveDirection.Down:
                    _model.CurrentRowIdx = Math.Min(_model.CurrentRowIdx + 1, table.RowCount - 1);
                    break;
                case MoveDirection.Left:
                    _model.CurrentColumnIdx = Math.Max(_model.CurrentColumnIdx - 1, 0);
                    break;
                case MoveDirection.Right:
                    _model.CurrentColumnIdx = Math.Min(_model.CurrentColumnIdx + 1, table.ColumnCount - 1);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// フラグを反転させる
        /// </summary>
        public void TurnFlag()
        {
            _model.Current.TurnFlag();
        }

        /// <summary>
        /// 自身が開かれていて、周りのフラグが十分に立てられている時(周りのボム数 = 周りのフラグ数)に
        /// 周りのセルを全て開きます
        /// </summary>
        public void OpenAroundIfFlagsFilled()
        {
            _model.Current.OpenAroundIfFlagsFilled();
        }

        public void PressOpen()
        {
            if (_model.IsGameStarted) //ゲーム中なら
            {
                OpenCurrentCell();　//現在のセルを選択状態にする
            }
            else
            {
                GameStart();        //ゲームの開始
            }
        }

        /// <summary>
        /// ゲームを開始する
        /// </summary>
        private void GameStart()
        {
            LayBombs(); //ボムを配置する

            _model.GameTime = 0;         //ゲーム時間の初期化を行う
            _model.IsGameStarted = true; //ゲーム開始フラグを立てる
        }

        /// <summary>
        /// ボムを配置する
        /// </summary>
        private void LayBombs()
        {
            table.Reset();

            if (_model.BombSum > _model.Table.ColumnCount * _model.Table.RowCount)
                throw new Exception("ボムの量が多すぎます");

            Random rand = new Random(); //乱数生成器
            for (int i = 0; i < _model.BombSum; i++)
            {
                int row = rand.Next(table.RowCount);
                int col = rand.Next(table.ColumnCount);
                MineCell cell = table[row][col];

                while (cell.IsBomb) //もしボムなら
                    cell = cell.NextCell(); //次のセルを取得

                table[row][col].IsBomb = true; // ボムを設定する
            }
        }

        /// <summary>
        /// 現在のセルを開く
        /// </summary>
        private void OpenCurrentCell()
        {
            var current = _model.Current;

            if (current.IsOpened) //既に開かれていたら
                return; //何もせず帰る

            current.Open();    //現在のセルを開く
        }

        /// <summary>
        /// フレームの開始
        /// </summary>
        public void StartFrame()
        {
            StartFrame(true);
        }

        /// <summary>
        /// フレームの開始
        /// </summary>
        /// <param name="hasInput"></param>
        public void StartFrame(bool hasInput)
        {

        }

        /// <summary>
        /// フレームの終了
        /// </summary>
        public void EndFrame()
        {
        }

    }
}
