﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace git_test
{
    public class MineReceiver
    {

        private readonly MineController _ctl;

        public MineReceiver(MineController ctl)
        {
            _ctl = ctl;
        }

        /// <summary>
        /// 入力を受け取る
        /// </summary>
        /// <returns></returns>
        public bool Receive()
        {
            ConsoleKeyInfo ck = Console.ReadKey();
                
                _ctl.StartFrame();

                switch (ck.Key)
                {
                    case ConsoleKey.Enter:
                        _ctl.PressOpen();       //openキーを押された
                        break;
                    case ConsoleKey.F:
                        _ctl.TurnFlag();         //フラグを立てる
                        break;
                    case ConsoleKey.Spacebar:
                        _ctl.OpenAroundIfFlagsFilled(); //ボム数 = フラグ数 ---> 周りも開く
                        break;
                    case ConsoleKey.UpArrow:
                        _ctl.MoveCursor(MoveDirection.Up);
                        break;
                    case ConsoleKey.DownArrow:
                        _ctl.MoveCursor(MoveDirection.Down);
                        break;
                    case ConsoleKey.RightArrow:
                        _ctl.MoveCursor(MoveDirection.Right);
                        break;
                    case ConsoleKey.LeftArrow:
                        _ctl.MoveCursor(MoveDirection.Left);
                        break;
                    case ConsoleKey.Escape:
                        return false; //これ以上入力を受け取らない
                    default:
                        break;
                }

            _ctl.EndFrame();

            return true;
        }
    }

    public enum MoveDirection
    {
        Up,
        Down,
        Right,
        Left,
    }
}
