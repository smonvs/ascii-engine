using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ASCIIEngine.Core
{
    public static class FrameMetrics
    {

        public static int FramesPerSecond { get; private set; }
        public static float FrameTime { get; private set; }
        public static float CalcTime { get; private set; }
        public static float DeltaTime { get; private set; }

        private const float TARGET_FRAMERATE = 30f;
        private const float TARGET_FRAMETIME = (1.0f / TARGET_FRAMERATE) * 1000;

        private static Stopwatch _stopwatch;
        private static int _frameCount;
        private static float _accumulatedTime;

        static FrameMetrics()
        {

            FramesPerSecond = 0;
            FrameTime = 0f;
            CalcTime = 0f;
            DeltaTime = 0f;

            _stopwatch = new Stopwatch();
            _frameCount = 0;
            _accumulatedTime = 0f;

            _stopwatch.Start();

        }

        internal static void UpdateMetrics()
        {

            TimeSpan elapsedTime = _stopwatch.Elapsed;

            CalcTime = (float)elapsedTime.TotalMilliseconds;

            float remainingFrameTime = Math.Max(0, TARGET_FRAMETIME - CalcTime);
            
            if (remainingFrameTime > 0)
            {
                Thread.Sleep((int)remainingFrameTime);
            }

            FrameTime = CalcTime + remainingFrameTime;
            DeltaTime = FrameTime / 1000.0f;

            _accumulatedTime += CalcTime + remainingFrameTime;
            _frameCount++;

            if (_accumulatedTime >= 1000)
            {
                FramesPerSecond = _frameCount;
                _frameCount = 0;
                _accumulatedTime -= 1000;
            }

            _stopwatch.Restart();

            //Console.WriteLine($"fps: {FramesPerSecond} | calc time: {(int)CalcTime} ms | frame time: {(int)FrameTime} ms | delta time: {DeltaTime}");
        }

    }
}
