using ControlMaterials.Tables.ThemePlan;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;

namespace UnitTests.Features.Count.Highlighting
{
    [TestClass]
    public class Off
    {
        private readonly Color neutral = Color.Transparent;

        public Theme ThemeTemplate()
        {
            Theme theme = new Theme();
            theme.Option(2, 0);
            theme.Add(new Work { Hours = 10 });
            theme.Add(new Work { Hours = 5 });
            theme.Add(new Work { Hours = 7 });
            return theme;
        }

        [TestMethod]
        public void TestHighlightOffTwentyTwoEqualsNeutral()
        {
            Theme theme = ThemeTemplate();
            Assert.AreEqual(neutral, theme.Color);
        }

        [TestMethod]
        public void TestHighlightOffTwelveOnSetEqualsNeutral()
        {
            Theme theme = ThemeTemplate();
            theme[0].SetHours(0);
            Assert.AreEqual(neutral, theme.Color);
        }

        [TestMethod]
        public void TestHighlightOffFifteenOnRemoveEqualsNeutral()
        {
            Theme theme = ThemeTemplate();
            theme.Remove(theme[2]);
            Assert.AreEqual(neutral, theme.Color);
        }

        [TestMethod]
        public void TestHighlightOffThirtyOnAddEqualsNeutral()
        {
            Theme theme = ThemeTemplate();
            theme.Add(new Work { Hours = 8 });
            Assert.AreEqual(neutral, theme.Color);
        }
    }
}
