using Microsoft.VisualStudio.TestTools.UnitTesting;
using ControlMaterials.Tables.ThemePlan;

namespace UnitTests.Features.Numeration
{
    [TestClass]
    public class Auto
    {
        public Theme ThemeTemplate()
        {
            Theme theme = new Theme();
            theme.Option(0, 2);
            theme.Add();
            theme.Add();
            theme.Add();
            return theme;
        }

        [TestMethod]
        public void TestAutoNumerationOnSetEqualsOneTwoThree()
        {
            Theme theme = ThemeTemplate();
            Assert.AreEqual(0, theme[0].No);
            Assert.AreEqual(1, theme[1].No);
            Assert.AreEqual(2, theme[2].No);
        }

        [TestMethod]
        public void TestAutoNumerationOnChangeEqualsZero()
        {
            Theme theme = ThemeTemplate();
            theme[1].SetNumber(0);
            Assert.AreEqual(0, theme[0].No);
            Assert.AreEqual(1, theme[1].No);
            Assert.AreEqual(2, theme[2].No);
        }

        [TestMethod]
        public void TestAutoNumerationOnRemoveFirstEqualsZeroOne()
        {
            Theme theme = ThemeTemplate();
            theme.Remove(theme[0]);
            Assert.AreEqual(0, theme[0].No);
            Assert.AreEqual(1, theme[1].No);
        }

        [TestMethod]
        public void TestAutoNumerationOnRemoveSecondEqualsZeroOne()
        {
            Theme theme = ThemeTemplate();
            theme.Remove(theme[1]);
            Assert.AreEqual(0, theme[0].No);
            Assert.AreEqual(1, theme[1].No);
        }

        [TestMethod]
        public void TestAutoNumerationOnRemoveThirdEqualsZeroOne()
        {
            Theme theme = ThemeTemplate();
            theme.Remove(theme[2]);
            Assert.AreEqual(0, theme[0].No);
            Assert.AreEqual(1, theme[1].No);
        }

        [TestMethod]
        public void TestAutoNumerationOnAddEqualsZero()
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
