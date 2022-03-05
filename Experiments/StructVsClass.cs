using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using Wisdom.Model;
using Wisdom.Model.ThemePlan;
using static Experiments.ExperimentsHelper;

namespace Experiments
{
    /// <summary>
    /// Tests to check differences between
    /// struct and class performance
    /// </summary>
    [TestClass]
    public class StructVsClass
    {
        /// <summary>
        /// Struct results: 00:00:00.000
        /// Ticks: 14
        /// Class results: 00:00:00.000
        /// Ticks: 810
        /// 
        /// Struct performance
        /// 57.857 times faster
        /// </summary>
        [TestMethod]
        public void CreatingInstance()
        {
            Stopwatch stopWatch = new Stopwatch();

            stopWatch.Start();
            Task task = new Task();
            stopWatch.Stop();

            Trace.Write("Struct results: ");
            PrintTime(stopWatch.Elapsed);
            
            stopWatch.Start();
            Pair<string, string> pair = new
                Pair<string, string>();
            stopWatch.Stop();

            Trace.Write("Class results: ");
            PrintTime(stopWatch.Elapsed);
        }

        /// <summary>
        /// Struct state: 
        /// 义耱 - 1
        /// Struct results: 00:00:00.000
        /// Ticks: 310
        /// Class state: 
        /// 义耱 - 1
        /// Class results: 00:00:00.000
        /// Ticks: 537
        /// 
        /// Struct performance
        /// 1.732 times faster
        /// </summary>
        [TestMethod]
        public void AccessingFields()
        {
            Stopwatch stopWatch = new Stopwatch();

            Task task = new Task("义耱 - 1", "义耱 - 2");
            Trace.WriteLine("Struct state: ");
            stopWatch.Start();
            Trace.WriteLine(task.Name);
            stopWatch.Stop();

            Trace.Write("Struct results: ");
            PrintTime(stopWatch.Elapsed);

            Pair<string, string> pair = new
                Pair<string, string>("义耱 - 1", "义耱 - 2");
            Trace.WriteLine("Class state: ");
            stopWatch.Start();
            Trace.WriteLine(pair.Name);
            stopWatch.Stop();

            Trace.Write("Class results: ");
            PrintTime(stopWatch.Elapsed);
        }

        /// <summary>
        /// Struct results: 00:00:00.000
        /// Ticks: 0
        /// Class results: 00:00:00.000
        /// Ticks: 2
        /// 
        /// Struct performance
        /// has no enough weight
        /// </summary>
        [TestMethod]
        public void WritingToFields()
        {
            Stopwatch stopWatch = new Stopwatch();

            Task task = new Task();

            stopWatch.Start();
            task.Name = "义耱 - 1";
            stopWatch.Stop();

            Trace.Write("Struct results: ");
            PrintTime(stopWatch.Elapsed);

            Pair<string, string> pair = new
                Pair<string, string>("义耱 - 1", "义耱 - 2");

            stopWatch.Start();
            pair.Name = "义耱 - 2";
            stopWatch.Stop();

            Trace.Write("Class results: ");
            PrintTime(stopWatch.Elapsed);
        }

        /// <summary>
        /// Struct object passed
        /// Struct results: 00:00:00.000
        /// Ticks: 361
        /// Struct as input object passed
        /// Struct as reference results: 00:00:00.000
        /// Ticks: 600
        /// Class object passed
        /// Class results: 00:00:00.000
        /// Ticks: 822
        /// 
        /// Struct performance
        /// 2.277 times faster
        /// Struct as reference performance
        /// 1.37 times faster
        /// </summary>
        [TestMethod]
        public void PassAsParameters()
        {
            Stopwatch stopWatch = new Stopwatch();

            Task task = new Task();

            stopWatch.Start();
            PassStruct(task);
            stopWatch.Stop();

            Trace.Write("Struct results: ");
            PrintTime(stopWatch.Elapsed);

            stopWatch.Start();
            PassStructIn(task);
            stopWatch.Stop();

            Trace.Write("Struct as reference results: ");
            PrintTime(stopWatch.Elapsed);

            Pair<string, string> pair = new
                Pair<string, string>("义耱 - 1", "义耱 - 2");

            stopWatch.Start();
            PassClass(pair);
            stopWatch.Stop();

            Trace.Write("Class results: ");
            PrintTime(stopWatch.Elapsed);
        }

        /// <summary>
        /// Pass objects as parameters
        /// with filled name field
        /// 
        /// Struct object passed
        /// Struct results: 00:00:00.000
        /// Ticks: 349
        /// Struct as input object passed
        /// Struct as reference results: 00:00:00.000
        /// Ticks: 585
        /// Class object passed
        /// Class results: 00:00:00.000
        /// Ticks: 807
        /// 
        /// Struct performance
        /// 2.277 times faster
        /// Struct as reference performance
        /// 1.37 times faster
        /// </summary>
        [TestMethod]
        public void PassAsParametersWithData()
        {
            Stopwatch stopWatch = new Stopwatch();

            Task task = new Task
            {
                Name = "义耱 义耱 义耱 义耱 义耱 义耱 义耱 义耱 义耱 义耱 " +
                "义耱 义耱 义耱 义耱 义耱 义耱 义耱 义耱 义耱 义耱 " +
                "义耱 义耱 义耱 义耱 义耱 义耱 义耱 义耱 义耱 义耱 " +
                "义耱 义耱 义耱 义耱 义耱 义耱 义耱 义耱 义耱 义耱 " +
                "义耱 义耱 义耱 义耱 义耱 义耱 义耱 义耱 义耱 义耱 " +
                "义耱 义耱 义耱 义耱 义耱 义耱 义耱 义耱 义耱 义耱 " +
                "义耱 义耱 义耱 义耱 义耱 义耱 义耱 义耱 义耱 义耱 " +
                "义耱 义耱 义耱 义耱 义耱 义耱 义耱 义耱 义耱 义耱 " +
                "义耱 义耱 义耱 义耱 义耱 义耱 义耱 义耱 义耱 义耱 " +
                "义耱 义耱 义耱 义耱 义耱 义耱 义耱 义耱 义耱 义耱 ",
                Hours = "65535"
            };

            stopWatch.Start();
            PassStruct(task);
            stopWatch.Stop();

            Trace.Write("Struct results: ");
            PrintTime(stopWatch.Elapsed);

            stopWatch.Start();
            PassStructIn(task);
            stopWatch.Stop();

            Trace.Write("Struct as reference results: ");
            PrintTime(stopWatch.Elapsed);

            Pair<string, string> pair = new Pair<string, string>
            {
                Name = "义耱 义耱 义耱 义耱 义耱 义耱 义耱 义耱 义耱 义耱 " +
                "义耱 义耱 义耱 义耱 义耱 义耱 义耱 义耱 义耱 义耱 " +
                "义耱 义耱 义耱 义耱 义耱 义耱 义耱 义耱 义耱 义耱 " +
                "义耱 义耱 义耱 义耱 义耱 义耱 义耱 义耱 义耱 义耱 " +
                "义耱 义耱 义耱 义耱 义耱 义耱 义耱 义耱 义耱 义耱 " +
                "义耱 义耱 义耱 义耱 义耱 义耱 义耱 义耱 义耱 义耱 " +
                "义耱 义耱 义耱 义耱 义耱 义耱 义耱 义耱 义耱 义耱 " +
                "义耱 义耱 义耱 义耱 义耱 义耱 义耱 义耱 义耱 义耱 " +
                "义耱 义耱 义耱 义耱 义耱 义耱 义耱 义耱 义耱 义耱 " +
                "义耱 义耱 义耱 义耱 义耱 义耱 义耱 义耱 义耱 义耱 ",
                Value = "65535"
            };

            stopWatch.Start();
            PassClass(pair);
            stopWatch.Stop();

            Trace.Write("Class results: ");
            PrintTime(stopWatch.Elapsed);
        }

        /// <summary>
        /// Pass class object as parameter
        /// 
        /// Parent will be affected:
        /// it will pass reference
        /// </summary>
        private void PassClass(Pair<string, string> pair)
        {
            Trace.WriteLine("Class object passed");
        }

        /// <summary>
        /// Pass struct object as parameter
        /// 
        /// Parent won't be affected:
        /// it will just copy object
        /// </summary>
        private void PassStruct(Task task)
        {
            Trace.WriteLine("Struct object passed");
        }

        /// <summary>
        /// Pass struct object as
        /// input (reference) parameter
        /// </summary>
        private void PassStructIn(in Task task)
        {
            Trace.WriteLine("Struct as input object passed");
        }
    }
}