using ControlMaterials.Tables.ThemePlan;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.Features.Count
{
    [TestClass]
    public class Manual
    {
        public Theme ThemeTemplate()
        {
            Theme theme = new Theme();
            theme.Option(1, 0);
            theme.Add(new Work { Hours = 10 });
            theme.Add(new Work { Hours = 5 });
            theme.Add(new Work { Hours = 7 });
            return theme;
        }

        [TestMethod]
        public void TestManualCountOnSetEqualsZero()
        {
            Theme theme = ThemeTemplate();
            Assert.AreEqual(0, theme.Sum);
        }

        [TestMethod]
        public void TestManualCountOnChangeEqualsZero()
        {
            Theme theme = ThemeTemplate();
            theme[0].SetHours(0);
            Assert.AreEqual(0, theme.Sum);
        }

        [TestMethod]
        public void TestManualCountOnRemoveEqualsZero()
        {
            Theme theme = ThemeTemplate();
            theme.Remove(theme[2]);
            Assert.AreEqual(0, theme.Sum);
        }

        [TestMethod]
        public void TestManualCountOnAddEqualsZero()
        {
            Theme theme = ThemeTemplate();
            theme.Add(new Work { Hours = 8 });
            Assert.AreEqual(0, theme.Sum);
        }
    }
}
