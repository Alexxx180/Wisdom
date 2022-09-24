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
                    Prefix = "�� " + totalNo,
                    Name = "����� �����������",
                };
                competetion.Items.Add(new Task("������", "��-������"));
                competetion.Items.Add(new Task("������", "��-������"));
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
                        Prefix = $"�� {i + 1}.{ii + 1}",
                        Name = "���������������� �����������"
                    };
                    competetion.Items.Add(new Task("������������ ����", "��-������������ ����"));
                    competetion.Items.Add(new Task("������", "��-������"));
                    competetion.Items.Add(new Task("������", "��-������"));

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
                    Name = "��� �������"
                };

                for (byte ii = 0; ii < count; ii++)
                {
                    byte themeHours = 0;

                    Theme theme = new Theme
                    {
                        Name = "����� ����",
                        Level = 2
                    };

                    ushort no = (ushort)(i + 1);
                    theme.GCompetetions.Add(new Competetion("��", no));

                    IndexNode<Competetion> pc = new
                        IndexNode<Competetion>(new Competetion())
                    {
                        No = no
                    };
                    pc.Add(new Competetion("��", (ushort)(ii + 1)));

                    theme.PCompetetions.Add(pc);

                    for (byte iii = 0; iii < count; iii++)
                    {
                        byte workHours = 0;

                        Work work = new Work
                        {
                            Name = "����� ������"
                        };

                        for (byte iv = 0; iv < count; iv++)
                        {
                            byte taskHours = 10;

                            IndexedHour task = new IndexedHour("������", taskHours);
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
                Task data = new Task("���� ��", "https://...");
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
                    Name = "����� ������",
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
                    Name = "����������",
                };

                for (byte ii = 0; ii < count; ii++)
                {
                    group.Items.Add(new IndexedLabel("������ ���������"));
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
                        Name = "�������� ������",
                        Data = "�������� ������"
                    }
                };
                levels.Add(level);
            }

            Assert.AreEqual(LevelsAssertion, ExtractLevels(levels));
        }

        #region AssertionsData Members
        private const string GeneralAssertion =
            "����� �����������:" +
            "\n\n����������: 10" +
            "\n\n�� 01. ����� �����������" +
            "\n������: ��-������" +
            "\n������: ��-������" +
            "\n\n�� 02. ����� �����������" +
            "\n������: ��-������" +
            "\n������: ��-������" +
            "\n\n�� 03. ����� �����������" +
            "\n������: ��-������" +
            "\n������: ��-������" +
            "\n\n�� 04. ����� �����������" +
            "\n������: ��-������" +
            "\n������: ��-������" +
            "\n\n�� 05. ����� �����������" +
            "\n������: ��-������" +
            "\n������: ��-������" +
            "\n\n�� 06. ����� �����������" +
            "\n������: ��-������" +
            "\n������: ��-������" +
            "\n\n�� 07. ����� �����������" +
            "\n������: ��-������" +
            "\n������: ��-������" +
            "\n\n�� 08. ����� �����������" +
            "\n������: ��-������" +
            "\n������: ��-������" +
            "\n\n�� 09. ����� �����������" +
            "\n������: ��-������" +
            "\n������: ��-������" +
            "\n\n�� 10. ����� �����������" +
            "\n������: ��-������" +
            "\n������: ��-������";

        private const string ProfessionalAssertion =
            "���������������� �����������:" +
            "\n\n����������: 3" +
            "\n\n�� 1.1. ���������������� �����������" +
            "\n������������ ����: ��-������������ ����" +
            "\n������: ��-������" +
            "\n������: ��-������" +
            "\n\n�� 1.2. ���������������� �����������" +
            "\n������������ ����: ��-������������ ����" +
            "\n������: ��-������" +
            "\n������: ��-������" +
            "\n\n�� 1.3. ���������������� �����������" +
            "\n������������ ����: ��-������������ ����" +
            "\n������: ��-������" +
            "\n������: ��-������" +
            "\n\n�� 2.1. ���������������� �����������" +
            "\n������������ ����: ��-������������ ����" +
            "\n������: ��-������" +
            "\n������: ��-������" +
            "\n\n�� 2.2. ���������������� �����������" +
            "\n������������ ����: ��-������������ ����" +
            "\n������: ��-������" +
            "\n������: ��-������" +
            "\n\n�� 2.3. ���������������� �����������" +
            "\n������������ ����: ��-������������ ����" +
            "\n������: ��-������" +
            "\n������: ��-������" +
            "\n\n�� 3.1. ���������������� �����������" +
            "\n������������ ����: ��-������������ ����" +
            "\n������: ��-������" +
            "\n������: ��-������" +
            "\n\n�� 3.2. ���������������� �����������" +
            "\n������������ ����: ��-������������ ����" +
            "\n������: ��-������" +
            "\n������: ��-������" +
            "\n\n�� 3.3. ���������������� �����������" +
            "\n������������ ����: ��-������������ ����" +
            "\n������: ��-������" +
            "\n������: ��-������";

        private const string ThemePlanAssertion =
            "������������ ����:" +
            "\n\n����������: 3" +
            "\n\n������ 1: ��� �������, ����: 14" +
            "\n���� 1: ����� ����, ����: 90, ��: 2, �����������: �� 1. �� 1.1" +
            "\n����� ������" +
            "\n������: 10" +
            "\n������: 10" +
            "\n������: 10" +
            "\n����� ������" +
            "\n������: 10" +
            "\n������: 10" +
            "\n������: 10" +
            "\n����� ������" +
            "\n������: 10" +
            "\n������: 10" +
            "\n������: 10" +
            "\n���� 2: ����� ����, ����: 90, ��: 2, �����������: �� 1. �� 1.2" +
            "\n����� ������" +
            "\n������: 10" +
            "\n������: 10" +
            "\n������: 10" +
            "\n����� ������" +
            "\n������: 10" +
            "\n������: 10" +
            "\n������: 10" +
            "\n����� ������" +
            "\n������: 10" +
            "\n������: 10" +
            "\n������: 10" +
            "\n���� 3: ����� ����, ����: 90, ��: 2, �����������: �� 1. �� 1.3" +
            "\n����� ������" +
            "\n������: 10" +
            "\n������: 10" +
            "\n������: 10" +
            "\n����� ������" +
            "\n������: 10" +
            "\n������: 10" +
            "\n������: 10" +
            "\n����� ������" +
            "\n������: 10" +
            "\n������: 10" +
            "\n������: 10" +
            "\n\n������ 2: ��� �������, ����: 14" +
            "\n���� 1: ����� ����, ����: 90, ��: 2, �����������: �� 2. �� 2.1" +
            "\n����� ������" +
            "\n������: 10" +
            "\n������: 10" +
            "\n������: 10" +
            "\n����� ������" +
            "\n������: 10" +
            "\n������: 10" +
            "\n������: 10" +
            "\n����� ������" +
            "\n������: 10" +
            "\n������: 10" +
            "\n������: 10" +
            "\n���� 2: ����� ����, ����: 90, ��: 2, �����������: �� 2. �� 2.2" +
            "\n����� ������" +
            "\n������: 10" +
            "\n������: 10" +
            "\n������: 10" +
            "\n����� ������" +
            "\n������: 10" +
            "\n������: 10" +
            "\n������: 10" +
            "\n����� ������" +
            "\n������: 10" +
            "\n������: 10" +
            "\n������: 10" +
            "\n���� 3: ����� ����, ����: 90, ��: 2, �����������: �� 2. �� 2.3" +
            "\n����� ������" +
            "\n������: 10" +
            "\n������: 10" +
            "\n������: 10" +
            "\n����� ������" +
            "\n������: 10" +
            "\n������: 10" +
            "\n������: 10" +
            "\n����� ������" +
            "\n������: 10" +
            "\n������: 10" +
            "\n������: 10" +
            "\n\n������ 3: ��� �������, ����: 14" +
            "\n���� 1: ����� ����, ����: 90, ��: 2, �����������: �� 3. �� 3.1" +
            "\n����� ������" +
            "\n������: 10" +
            "\n������: 10" +
            "\n������: 10" +
            "\n����� ������" +
            "\n������: 10" +
            "\n������: 10" +
            "\n������: 10" +
            "\n����� ������" +
            "\n������: 10" +
            "\n������: 10" +
            "\n������: 10" +
            "\n���� 2: ����� ����, ����: 90, ��: 2, �����������: �� 3. �� 3.2" +
            "\n����� ������" +
            "\n������: 10" +
            "\n������: 10" +
            "\n������: 10" +
            "\n����� ������" +
            "\n������: 10" +
            "\n������: 10" +
            "\n������: 10" +
            "\n����� ������" +
            "\n������: 10" +
            "\n������: 10" +
            "\n������: 10" +
            "\n���� 3: ����� ����, ����: 90, ��: 2, �����������: �� 3. �� 3.3" +
            "\n����� ������" +
            "\n������: 10" +
            "\n������: 10" +
            "\n������: 10" +
            "\n����� ������" +
            "\n������: 10" +
            "\n������: 10" +
            "\n������: 10" +
            "\n����� ������" +
            "\n������: 10" +
            "\n������: 10" +
            "\n������: 10";

        private const string MetaDataAssertion =
            "����������:" +
            "\n\n����������: 10" +
            "\n\n���� ��: https://..." +
            "\n���� ��: https://..." +
            "\n���� ��: https://..." +
            "\n���� ��: https://..." +
            "\n���� ��: https://..." +
            "\n���� ��: https://..." +
            "\n���� ��: https://..." +
            "\n���� ��: https://..." +
            "\n���� ��: https://..." +
            "\n���� ��: https://...";

        private const string HoursAssertion =
            "����:" +
            "\n\n����������: 10" +
            "\n\n����� ������: 30" +
            "\n����� ������: 30" +
            "\n����� ������: 30" +
            "\n����� ������: 30" +
            "\n����� ������: 30" +
            "\n����� ������: 30" +
            "\n����� ������: 30" +
            "\n����� ������: 30" +
            "\n����� ������: 30" +
            "\n����� ������: 30";

        private const string SourcesAssertion =
            "���������:" +
            "\n\n����������: 3" +
            "\n\n����������: " +
            "\n1. ������ ���������" +
            "\n2. ������ ���������" +
            "\n3. ������ ���������" +
            "\n\n����������: " +
            "\n1. ������ ���������" +
            "\n2. ������ ���������" +
            "\n3. ������ ���������" +
            "\n\n����������: " +
            "\n1. ������ ���������" +
            "\n2. ������ ���������" +
            "\n3. ������ ���������";

        private const string LevelsAssertion =
            "������ �����������:" +
            "\n\n����������: 3" +
            "\n\n1. - �������� ������ (�������� ������)" +
            "\n2. - �������� ������ (�������� ������)" +
            "\n3. - �������� ������ (�������� ������)";
        #endregion
    }
}
