using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using System.Text;

namespace Experiments
{
    /// <summary>
    /// Tests to check differences between
    /// string and StringBuilder performance
    /// </summary>
    [TestClass]
    public class StringVsStringBuilder
    {
        private const byte Count = 16;

        /// <summary>
        /// Advice: the most effective way
        /// to use string - one assignment
        /// with few concats to unify texts
        /// 
        /// 00:00:13.535
        /// Ticks: 135356109
        /// </summary>
        [TestMethod]
        public void StringConcatSpeedTest()
        {
            Stopwatch stopWatch = new Stopwatch();

            stopWatch.Start();
            string text = "Тематический план";
            for (byte i = 0; i < Count; i++)
            {
                text += "\n\nРаздел " + i + ".";
                for (byte ii = 0; ii < Count; ii++)
                {
                    text += "\n\nТема " + i + "." + ii;
                    for (byte iii = 0; iii < Count; iii++)
                    {
                        text += "\n\nРабота " + iii;
                        for (byte iv = 0; iv < Count; iv++)
                        {
                            text += "\nЗадача " + iv;
                        }
                    }
                }
            }
            stopWatch.Stop();

            ExperimentsHelper.PrintTime(stopWatch.Elapsed);
        }

        /// <summary>
        /// Advice: the most effective way
        /// to use builder - loop concats
        /// of text chunks
        /// 
        /// 00:00:00.002
        /// Ticks: 23025
        /// </summary>
        [TestMethod]
        public void StringBuilderSpeedTest()
        {
            Stopwatch stopWatch = new Stopwatch();

            stopWatch.Start();
            StringBuilder builder = new StringBuilder("Тематический план");
            for (byte i = 0; i < Count; i++)
            {
                builder.Append("\n\nРаздел " + i + ".");
                for (byte ii = 0; ii < Count; ii++)
                {
                    builder.Append("\n\nТема " + i + ".");
                    for (byte iii = 0; iii < Count; iii++)
                    {
                        builder.Append("\n\nРабота " + iii);
                        for (byte iv = 0; iv < Count; iv++)
                        {
                            builder.Append("\nЗадача " + iv);
                        }
                    }
                }
            }
            stopWatch.Stop();

            ExperimentsHelper.PrintTime(stopWatch.Elapsed);
        }
    }
}