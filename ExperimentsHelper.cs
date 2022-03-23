using System;
using System.Diagnostics;

namespace Experiments
{
    public static class ExperimentsHelper
    {
        public static void PrintTime(in TimeSpan time)
        {
            string elapsedTime = string.Format("{0:00}:{1:00}:{2:00}.{3:000}",
            time.Hours, time.Minutes, time.Seconds, time.Milliseconds);
            Trace.WriteLine(elapsedTime);
            Trace.Write("Ticks: ");
            Trace.WriteLine(time.Ticks);
        }
    }
}