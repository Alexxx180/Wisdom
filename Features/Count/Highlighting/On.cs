using ControlMaterials.Tables.ThemePlan;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;

namespace UnitTests.Features.Count.Highlighting
{
    [TestClass]
    public class On
    {
        private readonly Color violation = Color.FromArgb(255, 152, 99);
        private readonly Color neutral = Color.Transparent;
        private readonly Color conformity = Color.FromArgb(155, 252, 199);

        public Theme ThemeTemplate()
        {
            Theme theme = new Theme();
            theme.Option(2, 1);
            theme.SetTotal(22);
            theme.Add(new Work { Hours = 10 });
            theme.Add(new Work { Hours = 5 });
            theme.Add(new Work { Hours = 7 });
            return theme;
        }

        [TestMethod]
        public void TestHighlightOnTwentyTwoEqualsConformity()
        {
            Theme theme = ThemeTemplate();
            Assert.AreEqual(conformity, theme.Color);
        }

        [TestMethod]
        public void TestHighlightOnTwelveOnSetEqualsNeutral()
        {
            Theme theme = ThemeTemplate();
            theme[0].SetHours(0);
            Assert.AreEqual(neutral, theme.Color);
        }

        [TestMethod]
        public void TestHighlightOnFifteenOnRemoveEqualsNeutral()
        {
            Theme theme = ThemeTemplate();
            theme.Remove(theme[2]);
            Assert.AreEqual(neutral, theme.Color);
        }

        [TestMethod]
        public void TestHighlightOnThirtyOnAddEqualsViolation()
        {
            Theme theme = ThemeTemplate();
            theme.Add(new Work { Hours = 8 });
            Assert.AreEqual(violation, theme.Color);
        }
    }
}
