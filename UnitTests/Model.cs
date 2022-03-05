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
                    PrefixNo = "�� " + (i + 1).ToGeneralNo(),
                    Name = "����� �����������",
                    Abilities = new List<Task>
                    {
                        new Task("������", "��-������"),
                        new Task("������", "��-������")
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

            byte group�ount = 3;
            for (byte i = 0; i < group�ount; i++)
            {
                List<Competetion> competetions = new List<Competetion>();

                byte count = 3;
                for (byte ii = 0; ii < count; ii++)
                {
                    Competetion competetion = new Competetion
                    {
                        PrefixNo = $"�� {i + 1}.{ii + 1}",
                        Name = "���������������� �����������",
                        Abilities = new List<Task>
                        {
                            new Task("������������ ����", "��-������������ ����"),
                            new Task("������", "��-������"),
                            new Task("������", "��-������")
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
