using System;
using System.Collections.Generic;
using System.Linq;

namespace git_test
{
    static class Program
    {
        static int Main(string[] args)
        {
            MineModel model = new MineModel();
            MineView view = new MineView(model);
            MineController ctl = new MineController(model);
            MineReceiver receiver = new MineReceiver(ctl);
            do
            {
                view.Draw();
            }
            while (receiver.Receive()); // 入力を受け取れる間はループする

            return 0;
        }
    }
}
