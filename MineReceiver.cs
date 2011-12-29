using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
            ConsoleKeyInfo ck = Console.ReadKey(true);

            switch (ck.Key)
            {
                case ConsoleKey.Enter:
                    _ctl.OpenCurrentCell();　//現在のセルを選択状態にする
                    break;
                case ConsoleKey.Escape:
                    return false; //これ以上入力を受け取らない
                default:
                    break;
            }

            return true;
        }

    }
}
