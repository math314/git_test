using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace git_test
{
    public class MineReceiver
    {

        /// <summary>
        /// 60FPSで入力を受け取る
        /// </summary>
        private readonly ConsoleInputReceiver _rcv = new ConsoleInputReceiver(1);
        private readonly MineController _ctl;

        public MineReceiver(MineController ctl)
        {
            _ctl = ctl;
            _rcv.Start();
        }

        /// <summary>
        /// 入力を受け取る
        /// </summary>
        /// <returns></returns>
        public bool Receive()
        {
            ConsoleKeyInfo? ck = _rcv.ReceiveKey();

            _ctl.StartFrame(ck.HasValue);

            if (ck.HasValue)
            {
                switch (ck.Value.Key)
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
            }

            _ctl.EndFrame();

            return true;
        }
    }

    /// <summary>
    /// コンソールの入力を受け取ります
    /// </summary>
    public class ConsoleInputReceiver
    {

        /// <summary> 時間計測用 </summary>
         private readonly Stopwatch _sw = new Stopwatch();

         /// <summary> 1秒に何回の入力を受け取るか </summary>
         private readonly int _FPS;

        /// <summary> 何フレーム経ったか </summary>
         private int _frameCount;

        /// <summary>
        /// コンソールからの入力を受け付けるクラス
        /// </summary>
        /// <param name="FPS">1秒に何回の入力を受け取るか</param>
        public ConsoleInputReceiver(int FPS)
        {
            _FPS = FPS;
        }

        /// <summary>
        /// 入力受け取りを開始します
        /// </summary>
        public void Start()
        {
            _sw.Restart();
            _frameCount = 0;
        }

        /// <summary>
        /// 入力受け取りを停止します
        /// </summary>
        public void Stop()
        {
            _sw.Reset();
        }

        /// <summary>
        /// 入力を受けとります
        /// </summary>
        /// <returns>一定時間以内に入力を受け取った場合はConsoleKeyInfoを、受け取れなかった場合はnull</returns>
        public ConsoleKeyInfo? ReceiveKey()
        {
            int sleepTime = GetSleepTime(); //sleepする時間を取得する
            if (sleepTime > 0)
                System.Threading.Thread.Sleep(sleepTime); //スリープする

            _frameCount++; //フレームカウントを増やす

            if (Console.KeyAvailable)
            {
                return Console.ReadKey(); //入力がある場合は入力を返す
            }
            else
            {
                return null;  //なければnull
            }
        }

        /// <summary>
        /// 次のフレームまでの待機時間を計算するメソッド
        /// </summary>
        /// <returns>次のフレームまでの時間</returns>
        private int GetSleepTime()
        {
            //1フレームあたりの秒数(s)
            double frameFrequency = 1 / (double)_FPS;

            double frameDiff = (frameFrequency * (_frameCount + 1)) -
                _sw.ElapsedTicks / (double)Stopwatch.Frequency;

            return (int)frameDiff;
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
