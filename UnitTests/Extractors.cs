using System.Collections.Generic;
using System.Text;
using Wisdom.Model;
using Wisdom.Model.ThemePlan;

namespace UnitTests
{
    public static class Extractors
    {
        private static string ExtractCompetetions(List<Competetion> competetions)
        {
            StringBuilder competetionsText = new StringBuilder();
            foreach (Competetion competetion in competetions)
            {
                competetionsText.Append("\n\n" + competetion.PrefixNo + ". " + competetion.Name);
                foreach (Task pair in competetion.Abilities)
                {
                    competetionsText.Append("\n" + pair.Name + ": " + pair.Hours);
                }
            }
            return competetionsText.ToString();
        }

        public static string ExtractGeneral(List<Competetion> competetions)
        {
            StringBuilder competetionsText = new StringBuilder("Общие компетенции:\n\n");
            competetionsText.Append("Количество: " + competetions.Count);
            competetionsText.Append(ExtractCompetetions(competetions));
            return competetionsText.ToString();
        }

        public static string ExtractProfessional(List<List<Competetion>> competetions)
        {
            StringBuilder competetionsText = new StringBuilder("Профессиональные компетенции:\n\n");
            competetionsText.Append("Количество: " + competetions.Count);
            foreach(List<Competetion> group in competetions)
            {
                competetionsText.Append(ExtractCompetetions(group));
            }
            return competetionsText.ToString();
        }
    }
}