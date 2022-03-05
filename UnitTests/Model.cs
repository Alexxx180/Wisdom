using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Diagnostics;
using Wisdom.Model;
using Wisdom.Model.ThemePlan;
using Wisdom.Customing;
using static UnitTests.Extractors;

namespace UnitTests
{
    [TestClass]
    public class Model
    {
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
        #endregion

        [TestMethod]
        public void TestGeneralCompetetions()
        {
            Trace.WriteLine("General competetions check...");

            List<Competetion> competetions = new List<Competetion>();

            byte count = 10;
            for (byte i = 0; i < count; i++)
            {
                Competetion competetion = new Competetion
                {
                    PrefixNo = "ОК " + (i + 1).ToGeneralNo(),
                    Name = "Общая компетенция",
                    Abilities = new List<Task>
                    {
                        new Task("Умения", "ОК-Умение"),
                        new Task("Знания", "ОК-Знание")
                    }
                };
                competetions.Add(competetion);
            }

            Assert.AreEqual(GeneralAssertion, ExtractGeneral(competetions));
        }

        [TestMethod]
        public void TestProfessionalCompetetions()
        {
            Trace.WriteLine("Professional competetions check...");

            List<List<Competetion>> groups = new List<List<Competetion>>();

            byte groupСount = 3;
            for (byte i = 0; i < groupСount; i++)
            {
                List<Competetion> competetions = new List<Competetion>();

                byte count = 3;
                for (byte ii = 0; ii < count; ii++)
                {
                    Competetion competetion = new Competetion
                    {
                        PrefixNo = $"ПК {i + 1}.{ii + 1}",
                        Name = "Профессиональная компетенция",
                        Abilities = new List<Task>
                        {
                            new Task("Практический опыт", "ОК-Практический опыт"),
                            new Task("Умения", "ОК-Умение"),
                            new Task("Знания", "ОК-Знание")
                        }
                    };
                    competetions.Add(competetion);
                }

                groups.Add(competetions);
            }

            Assert.AreEqual(ProfessionalAssertion, ExtractProfessional(groups));
        }
    }
}
