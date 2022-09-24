using Microsoft.VisualStudio.TestTools.UnitTesting;
using ControlMaterials.Tables.ThemePlan;

namespace UnitTests.Features.Numeration
{
    [TestClass]
    public class Manual
    {
        public Theme ThemeTemplate()
        {
            Theme theme = new Theme();
            theme.Option(0, 0);
            theme.Add();
            theme.Add();
            theme.Add();
            return theme;
        }

        [TestMethod]
        public void TestManualNumerationOnSetEqualsZero()
        {
            Theme theme = ThemeTemplate();
            Assert.AreEqual(0, theme[0].No);
            Assert.AreEqual(0, theme[1].No);
            Assert.AreEqual(0, theme[2].No);
        }

        [TestMethod]
        public void TestManualNumerationOnChangeEqualsTwo()
        {
            Theme theme = ThemeTemplate();
            theme[1].SetNumber(2);
            Assert.AreEqual(0, theme[0].No);
            Assert.AreEqual(2, theme[1].No);
            Assert.AreEqual(0, theme[2].No);
        }

        [TestMethod]
        public void TestManualNumerationOnRemoveFirstEqualsZero()
        {
            Theme theme = ThemeTemplate();
            theme.Remove(theme[0]);
            Assert.AreEqual(0, theme[0].No);
            Assert.AreEqual(0, theme[1].No);
        }

        [TestMethod]
        public void TestManualNumerationOnRemoveSecondEqualsZero()
        {
            Theme theme = ThemeTemplate();
            theme.Remove(theme[1]);
            Assert.AreEqual(0, theme[0].No);
            Assert.AreEqual(0, theme[1].No);
        }

        [TestMethod]
        public void TestManualNumerationOnRemoveThirdEqualsZero()
        {
            Theme theme = ThemeTemplate();
            theme.Remove(theme[2]);
            Assert.AreEqual(0, theme[0].No);
            Assert.AreEqual(0, theme[1].No);
        }

        [TestMethod]
        public void TestManualNumerationOnAddEqualsZero()
        {
            Theme theme = ThemeTemplate();
            theme.Add();
            Assert.AreEqual(0, theme[0].No);
            Assert.AreEqual(0, theme[1].No);
            Assert.AreEqual(0, theme[2].No);
            Assert.AreEqual(0, theme[3].No);
        }
    }
}
