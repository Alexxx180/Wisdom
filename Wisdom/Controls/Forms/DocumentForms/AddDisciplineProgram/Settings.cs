using System.Collections.Generic;

namespace Wisdom.Controls.Forms.DocumentForms.AddDisciplineProgram
{
    public class Settings : Preferences
    {
        public Settings()
        {
            Options = new Dictionary<string, int>();
        }

        public Dictionary<string, int> Options { get; set; }
    }
}