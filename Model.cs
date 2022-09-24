using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Diagnostics;
using ControlMaterials.Total;
using ControlMaterials.Tables.ThemePlan;
using static UnitTests.Extractors;
using ControlMaterials.Total.Collections.Nodes;
using ControlMaterials.Tables.Hours;
using ControlMaterials.Tables.Tasks;

namespace UnitTests
{
    /// <summary>
    /// Model string assertion tests
    /// </summary>
    [TestClass]
    public class Model
    {
        [TestMethod]
        public void TestGeneralCompetetions()
        {
            Trace.WriteLine("General competetions check...");

            List<Competetion> competetions = new List<Competetion>();

            byte count = 10;
            for (byte i = 0; i < count; i++)
            {
                string totalNo = string.Format("{0:00}", i + 1);
                Competetion competetion = new Competetion
                {
                    Prefix = "ОК " + totalNo,
                    Name = "Общая компетенция",
                };
                competetion.Items.Add(new Task("Умения", "ОК-Умение"));
                competetion.Items.Add(new Task("Знания", "ОК-Знание"));
                competetions.Add(competetion);
            }

            Assert.AreEqual(GeneralAssertion, ExtractGeneral(competetions));
        }

        [TestMethod]
        public void TestProfessionalCompetetions()
        {
            Trace.WriteLine("Professional competetions check...");

            List<List<Competetion>> groups = new List<List<Competetion>>();

            byte count = 3;
            for (byte i = 0; i < count; i++)
            {
                List<Competetion> competetions = new List<Competetion>();

                for (byte ii = 0; ii < count; ii++)
                {
                    Competetion competetion = new Competetion
                    {
                        Prefix = $"ПК {i + 1}.{ii + 1}",
                        Name = "Профессиональная компетенция"
                    };
                    competetion.Items.Add(new Task("Практический опыт", "ОК-Практический опыт"));
                    competetion.Items.Add(new Task("Умения", "ОК-Умение"));
                    competetion.Items.Add(new Task("Знания", "ОК-Знание"));

                    competetions.Add(competetion);
                }

                groups.Add(competetions);
            }

            Assert.AreEqual(ProfessionalAssertion, ExtractProfessional(groups));
        }

        [TestMethod]
        public void TestThemePlan()
        {
            Trace.WriteLine("Theme plan check...");

            List<HoursNode<Theme>> plan = new List<HoursNode<Theme>>();

            byte count = 3;
            for (byte i = 0; i < count; i++)
            {
                byte topicHours = 0;

                HoursNode<Theme> topic = new HoursNode<Theme>(new Theme())
                {
                    Name = "Имя раздела"
                };

                for (byte ii = 0; ii < count; ii++)
                {
                    byte themeHours = 0;

                    Theme theme = new Theme
                    {
                        Name = "Любая тема",
                        Level = 2
                    };

                    ushort no = (ushort)(i + 1);
                    theme.GCompetetions.Add(new Competetion("ОК", no));

                    IndexNode<Competetion> pc = new
                        IndexNode<Competetion>(new Competetion())
                    {
                        No = no
                    };
                    pc.Add(new Competetion("ПК", (ushort)(ii + 1)));

                    theme.PCompetetions.Add(pc);

                    for (byte iii = 0; iii < count; iii++)
                    {
                        byte workHours = 0;

                        Work work = new Work
                        {
                            Name = "Любая работа"
                        };

                        for (byte iv = 0; iv < count; iv++)
                        {
                            byte taskHours = 10;

                            IndexedHour task = new IndexedHour("Задача", taskHours);
                            work.Add(task);

                            workHours += taskHours;
                        }

                        theme.Add(work);
                        themeHours += workHours;
                    }

                    theme.Hours = themeHours;
                    topic.Add(theme);
                    topicHours += themeHours;
                }

                topic.Hours = topicHours;
                plan.Add(topic);
            }

            Assert.AreEqual(ThemePlanAssertion, ExtractThemePlan(plan));
        }

        [TestMethod]
        public void TestMetaData()
        {
            Trace.WriteLine("Meta data check...");

            List<Task> metaData = new List<Task>();

            byte count = 10;
            for (byte i = 0; i < count; i++)
            {
                Task data = new Task("Курс ДО", "https://...");
                metaData.Add(data);
            }

            Assert.AreEqual(MetaDataAssertion, ExtractMetaData(metaData));
        }

        [TestMethod]
        public void TestHours()
        {
            Trace.WriteLine("Total hours count check...");

            List<Hour> hours = new List<Hour>();

            byte count = 10;
            for (byte i = 0; i < count; i++)
            {
                Hour hour = new Hour
                {
                    Name = "Любая работа",
                    Count = 30
                };
                hours.Add(hour);
            }

            Assert.AreEqual(HoursAssertion, ExtractHours(hours));
        }

        [TestMethod]
        public void TestSources()
        {
            Trace.WriteLine("Sources check...");

            List<Source> sources = new List<Source>();

            byte count = 3;
            for (byte i = 0; i < count; i++)
            {
                Source group = new Source
                {
                    Name = "Литература",
                };

                for (byte ii = 0; ii < count; ii++)
                {
                    group.Items.Add(new IndexedLabel("Пример источника"));
                }
                
                sources.Add(group);
            }

            Assert.AreEqual(SourcesAssertion, ExtractSources(sources));
        }

        [TestMethod]
        public void TestLevels()
        {
            Trace.WriteLine("Levels check...");

            List<Level> levels = new List<Level>();

            byte count = 3;
            for (byte i = 0; i < count; i++)
            {
                Level level = new Level
                {
                    No = (ushort)(i + 1),
                    Description =
                    {
                        Name = "Название уровня",
                        Data = "Описание уровня"
                    }
                };
                levels.Add(level);
            }

            Assert.AreEqual(LevelsAssertion, ExtractLevels(levels));
        }

        #region AssertionsData Members
        private const string GeneralAssertion =
            "Общие компетенции:" +
            "\n\nКоличество: 10" +
            "\n\nОК 01. Общая компетенция" +
            "\nУмения: ОК-Умение" +
            "\nЗнания: ОК-Знание" +
            "\n\nОК 02. Общая компетенция" +
            "\nУмения: ОК-Умение" +
            "\nЗнания: ОК-Знание" +
            "\n\nОК 03. Общая компетенция" +
            "\nУмения: ОК-Умение" +
            "\nЗнания: ОК-Знание" +
            "\n\nОК 04. Общая компетенция" +
            "\nУмения: ОК-Умение" +
            "\nЗнания: ОК-Знание" +
            "\n\nОК 05. Общая компетенция" +
            "\nУмения: ОК-Умение" +
            "\nЗнания: ОК-Знание" +
            "\n\nОК 06. Общая компетенция" +
            "\nУмения: ОК-Умение" +
            "\nЗнания: ОК-Знание" +
            "\n\nОК 07. Общая компетенция" +
            "\nУмения: ОК-Умение" +
            "\nЗнания: ОК-Знание" +
            "\n\nОК 08. Общая компетенция" +
            "\nУмения: ОК-Умение" +
            "\nЗнания: ОК-Знание" +
            "\n\nОК 09. Общая компетенция" +
            "\nУмения: ОК-Умение" +
            "\nЗнания: ОК-Знание" +
            "\n\nОК 10. Общая компетенция" +
            "\nУмения: ОК-Умение" +
            "\nЗнания: ОК-Знание";

        private const string ProfessionalAssertion =
            "Профессиональные компетенции:" +
            "\n\nКоличество: 3" +
            "\n\nПК 1.1. Профессиональная компетенция" +
            "\nПрактический опыт: ОК-Практический опыт" +
            "\nУмения: ОК-Умение" +
            "\nЗнания: ОК-Знание" +
            "\n\nПК 1.2. Профессиональная компетенция" +
            "\nПрактический опыт: ОК-Практический опыт" +
            "\nУмения: ОК-Умение" +
            "\nЗнания: ОК-Знание" +
            "\n\nПК 1.3. Профессиональная компетенция" +
            "\nПрактический опыт: ОК-Практический опыт" +
            "\nУмения: ОК-Умение" +
            "\nЗнания: ОК-Знание" +
            "\n\nПК 2.1. Профессиональная компетенция" +
            "\nПрактический опыт: ОК-Практический опыт" +
            "\nУмения: ОК-Умение" +
            "\nЗнания: ОК-Знание" +
            "\n\nПК 2.2. Профессиональная компетенция" +
            "\nПрактический опыт: ОК-Практический опыт" +
            "\nУмения: ОК-Умение" +
            "\nЗнания: ОК-Знание" +
            "\n\nПК 2.3. Профессиональная компетенция" +
            "\nПрактический опыт: ОК-Практический опыт" +
            "\nУмения: ОК-Умение" +
            "\nЗнания: ОК-Знание" +
            "\n\nПК 3.1. Профессиональная компетенция" +
            "\nПрактический опыт: ОК-Практический опыт" +
            "\nУмения: ОК-Умение" +
            "\nЗнания: ОК-Знание" +
            "\n\nПК 3.2. Профессиональная компетенция" +
            "\nПрактический опыт: ОК-Практический опыт" +
            "\nУмения: ОК-Умение" +
            "\nЗнания: ОК-Знание" +
            "\n\nПК 3.3. Профессиональная компетенция" +
            "\nПрактический опыт: ОК-Практический опыт" +
            "\nУмения: ОК-Умение" +
            "\nЗнания: ОК-Знание";

        private const string ThemePlanAssertion =
            "Тематический план:" +
            "\n\nКоличество: 3" +
            "\n\nРаздел 1: Имя раздела, часы: 14" +
            "\nТема 1: Любая тема, часы: 90, УК: 2, Компетенции: ОК 1. ПК 1.1" +
            "\nЛюбая работа" +
            "\nЗадача: 10" +
            "\nЗадача: 10" +
            "\nЗадача: 10" +
            "\nЛюбая работа" +
            "\nЗадача: 10" +
            "\nЗадача: 10" +
            "\nЗадача: 10" +
            "\nЛюбая работа" +
            "\nЗадача: 10" +
            "\nЗадача: 10" +
            "\nЗадача: 10" +
            "\nТема 2: Любая тема, часы: 90, УК: 2, Компетенции: ОК 1. ПК 1.2" +
            "\nЛюбая работа" +
            "\nЗадача: 10" +
            "\nЗадача: 10" +
            "\nЗадача: 10" +
            "\nЛюбая работа" +
            "\nЗадача: 10" +
            "\nЗадача: 10" +
            "\nЗадача: 10" +
            "\nЛюбая работа" +
            "\nЗадача: 10" +
            "\nЗадача: 10" +
            "\nЗадача: 10" +
            "\nТема 3: Любая тема, часы: 90, УК: 2, Компетенции: ОК 1. ПК 1.3" +
            "\nЛюбая работа" +
            "\nЗадача: 10" +
            "\nЗадача: 10" +
            "\nЗадача: 10" +
            "\nЛюбая работа" +
            "\nЗадача: 10" +
            "\nЗадача: 10" +
            "\nЗадача: 10" +
            "\nЛюбая работа" +
            "\nЗадача: 10" +
            "\nЗадача: 10" +
            "\nЗадача: 10" +
            "\n\nРаздел 2: Имя раздела, часы: 14" +
            "\nТема 1: Любая тема, часы: 90, УК: 2, Компетенции: ОК 2. ПК 2.1" +
            "\nЛюбая работа" +
            "\nЗадача: 10" +
            "\nЗадача: 10" +
            "\nЗадача: 10" +
            "\nЛюбая работа" +
            "\nЗадача: 10" +
            "\nЗадача: 10" +
            "\nЗадача: 10" +
            "\nЛюбая работа" +
            "\nЗадача: 10" +
            "\nЗадача: 10" +
            "\nЗадача: 10" +
            "\nТема 2: Любая тема, часы: 90, УК: 2, Компетенции: ОК 2. ПК 2.2" +
            "\nЛюбая работа" +
            "\nЗадача: 10" +
            "\nЗадача: 10" +
            "\nЗадача: 10" +
            "\nЛюбая работа" +
            "\nЗадача: 10" +
            "\nЗадача: 10" +
            "\nЗадача: 10" +
            "\nЛюбая работа" +
            "\nЗадача: 10" +
            "\nЗадача: 10" +
            "\nЗадача: 10" +
            "\nТема 3: Любая тема, часы: 90, УК: 2, Компетенции: ОК 2. ПК 2.3" +
            "\nЛюбая работа" +
            "\nЗадача: 10" +
            "\nЗадача: 10" +
            "\nЗадача: 10" +
            "\nЛюбая работа" +
            "\nЗадача: 10" +
            "\nЗадача: 10" +
            "\nЗадача: 10" +
            "\nЛюбая работа" +
            "\nЗадача: 10" +
            "\nЗадача: 10" +
            "\nЗадача: 10" +
            "\n\nРаздел 3: Имя раздела, часы: 14" +
            "\nТема 1: Любая тема, часы: 90, УК: 2, Компетенции: ОК 3. ПК 3.1" +
            "\nЛюбая работа" +
            "\nЗадача: 10" +
            "\nЗадача: 10" +
            "\nЗадача: 10" +
            "\nЛюбая работа" +
            "\nЗадача: 10" +
            "\nЗадача: 10" +
            "\nЗадача: 10" +
            "\nЛюбая работа" +
            "\nЗадача: 10" +
            "\nЗадача: 10" +
            "\nЗадача: 10" +
            "\nТема 2: Любая тема, часы: 90, УК: 2, Компетенции: ОК 3. ПК 3.2" +
            "\nЛюбая работа" +
            "\nЗадача: 10" +
            "\nЗадача: 10" +
            "\nЗадача: 10" +
            "\nЛюбая работа" +
            "\nЗадача: 10" +
            "\nЗадача: 10" +
            "\nЗадача: 10" +
            "\nЛюбая работа" +
            "\nЗадача: 10" +
            "\nЗадача: 10" +
            "\nЗадача: 10" +
            "\nТема 3: Любая тема, часы: 90, УК: 2, Компетенции: ОК 3. ПК 3.3" +
            "\nЛюбая работа" +
            "\nЗадача: 10" +
            "\nЗадача: 10" +
            "\nЗадача: 10" +
            "\nЛюбая работа" +
            "\nЗадача: 10" +
            "\nЗадача: 10" +
            "\nЗадача: 10" +
            "\nЛюбая работа" +
            "\nЗадача: 10" +
            "\nЗадача: 10" +
            "\nЗадача: 10";

        private const string MetaDataAssertion =
            "Метаданные:" +
            "\n\nКоличество: 10" +
            "\n\nКурс ДО: https://..." +
            "\nКурс ДО: https://..." +
            "\nКурс ДО: https://..." +
            "\nКурс ДО: https://..." +
            "\nКурс ДО: https://..." +
            "\nКурс ДО: https://..." +
            "\nКурс ДО: https://..." +
            "\nКурс ДО: https://..." +
            "\nКурс ДО: https://..." +
            "\nКурс ДО: https://...";

        private const string HoursAssertion =
            "Часы:" +
            "\n\nКоличество: 10" +
            "\n\nЛюбая работа: 30" +
            "\nЛюбая работа: 30" +
            "\nЛюбая работа: 30" +
            "\nЛюбая работа: 30" +
            "\nЛюбая работа: 30" +
            "\nЛюбая работа: 30" +
            "\nЛюбая работа: 30" +
            "\nЛюбая работа: 30" +
            "\nЛюбая работа: 30" +
            "\nЛюбая работа: 30";

        private const string SourcesAssertion =
            "Источники:" +
            "\n\nКоличество: 3" +
            "\n\nЛитература: " +
            "\n1. Пример источника" +
            "\n2. Пример источника" +
            "\n3. Пример источника" +
            "\n\nЛитература: " +
            "\n1. Пример источника" +
            "\n2. Пример источника" +
            "\n3. Пример источника" +
            "\n\nЛитература: " +
            "\n1. Пример источника" +
            "\n2. Пример источника" +
            "\n3. Пример источника";

        private const string LevelsAssertion =
            "Уровни компетенций:" +
            "\n\nКоличество: 3" +
            "\n\n1. - Название уровня (Описание уровня)" +
            "\n2. - Название уровня (Описание уровня)" +
            "\n3. - Название уровня (Описание уровня)";
        #endregion
    }
}
