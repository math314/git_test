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

        public void Draw()
        {
            Console.WriteLine("0%     50%     100%");
            string line = "+-------+-------+";
            Console.WriteLine(line);

            for (int i = 0; i < 100; i++)
            {
                Console.Write(new string('#',  i * line.Length / 100));
                Console.Write("\r");
                Thread.Sleep(30);
            }
        }
    }
}
