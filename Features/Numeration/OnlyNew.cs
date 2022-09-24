using Microsoft.VisualStudio.TestTools.UnitTesting;
using ControlMaterials.Tables.ThemePlan;

namespace UnitTests.Features.Numeration
{
    [TestClass]
    public class OnlyNew
    {
        public Theme ThemeTemplate()
        {
            Theme theme = new Theme();
            theme.Option(0, 1);
            theme.Add();
            theme.Add();
            theme.Add();
            return theme;
        }

        [TestMethod]
        public void TestOnlyNewNumerationOnSetEqualsZeroOneTwo()
        {
            Theme theme = ThemeTemplate();
            Assert.AreEqual(0, theme[0].No);
            Assert.AreEqual(1, theme[1].No);
            Assert.AreEqual(2, theme[2].No);
        }

        [TestMethod]
        public void TestOnlyNewNumerationOnChangeEqualsZero()
        {
            Theme theme = ThemeTemplate();
            theme[1].SetNumber(0);
            Assert.AreEqual(0, theme[0].No);
            Assert.AreEqual(0, theme[1].No);
            Assert.AreEqual(2, theme[2].No);
        }

        [TestMethod]
        public void TestOnlyNewNumerationOnRemoveFirstEqualsOneTwo()
        {
            Theme theme = ThemeTemplate();
            theme.Remove(theme[0]);
            Assert.AreEqual(1, theme[0].No);
            Assert.AreEqual(2, theme[1].No);
        }

        [TestMethod]
        public void TestOnlyNewNumerationOnRemoveSecondEqualsZeroTwo()
        {
            Theme theme = ThemeTemplate();
            theme.Remove(theme[1]);
            Assert.AreEqual(0, theme[0].No);
            Assert.AreEqual(2, theme[1].No);
        }

        [TestMethod]
        public void TestOnlyNewNumerationOnRemoveThirdEqualsZeroOne()
        {
            Theme theme = ThemeTemplate();
            theme.Remove(theme[2]);
            Assert.AreEqual(0, theme[0].No);
            Assert.AreEqual(1, theme[1].No);
        }

        [TestMethod]
        public void TestOnlyNewNumerationOnAddEqualsFour()
        {
            Theme theme = ThemeTemplate();
            theme.Add();
            Assert.AreEqual(0, theme[0].No);
            Assert.AreEqual(1, theme[1].No);
            Assert.AreEqual(2, theme[2].No);
            Assert.AreEqual(3, theme[3].No);
        }
    }
}
