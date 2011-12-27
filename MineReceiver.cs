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

            if (ck.Key == ConsoleKey.Enter)
            {
                _ctl.SelectCurrentCell();
            }
            else if(ck.Key == ConsoleKey.Escape)
            {

            }

            return true;
        }

    }
}
