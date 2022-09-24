using ControlMaterials.Tables.ThemePlan;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.Features.Count
{
    [TestClass]
    public class Auto
    {
        public Theme ThemeTemplate()
        {
            Theme theme = new Theme();
            theme.Option(1, 1);
            theme.Add(new Work { Hours = 10 });
            theme.Add(new Work { Hours = 5 });
            theme.Add(new Work { Hours = 7 });
            return theme;
        }

        [TestMethod]
        public void TestAutoCountOnSetEqualsTwentyTwo()
        {
            Theme theme = ThemeTemplate();
            Assert.AreEqual(22, theme.Sum);
        }

        [TestMethod]
        public void TestAutoCountOnMinusEqualsTwelve()
        {
            Theme theme = ThemeTemplate();
            theme[0].SetHours(0);
            Assert.AreEqual(12, theme.Sum);
        }

        [TestMethod]
        public void TestAutoCountOnRemoveEqualsFifteen()
        {
            Theme theme = ThemeTemplate();
            theme.Remove(theme[2]);
            Assert.AreEqual(15, theme.Sum);
        }

        [TestMethod]
        public void TestAutoCountOnAddEqualsThirty()
        {
            Theme theme = ThemeTemplate();
            theme.Add(new Work { Hours = 8 });
            Assert.AreEqual(30, theme.Sum);
        }
    }
}
