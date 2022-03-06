using System.Collections.Generic;
using System.Text;
using Wisdom.Model;
using Wisdom.Model.Tables;
using Wisdom.Model.Tables.ThemePlan;

namespace UnitTests
{
    /// <summary>
    /// Text extracting methods
    /// </summary>
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

        public static string ExtractThemePlan(List<Topic> topics)
        {
            StringBuilder planText = new StringBuilder("Тематический план:\n\n");
            planText.Append("Количество: " + topics.Count);
            for (byte i = 0; i < topics.Count; i++)
            {
                Topic topic = topics[i];
                planText.Append("\n\nРаздел");
                planText.Append(" " + (i + 1) + ": ");
                planText.Append(topic.Name + ", часы: ");
                planText.Append(topic.Hours);
                for (byte ii = 0; ii < topic.Themes.Count; ii++)
                {
                    Theme theme = topic.Themes[ii];
                    planText.Append($"\nТема {ii + 1}: {theme.Name}, часы: {theme.Hours},");
                    planText.Append($" УК: {theme.Level}, Компетенции: {theme.Competetions}");
                    for (byte iii = 0; iii < theme.Works.Count; iii++)
                    {
                        Work work = theme.Works[iii];
                        planText.Append($"\n{work.Type}");
                        for (byte iv = 0; iv < work.Tasks.Count; iv++)
                        {
                            Task task = work.Tasks[iv];
                            planText.Append($"\n{task.Name}: {task.Hours}");
                        }
                    }
                }
            }
            return planText.ToString();
        }

        public static string ExtractMetaData(List<Task> tasks)
        {
            StringBuilder metaDataText = new StringBuilder("Метаданные:\n\n");
            metaDataText.Append($"Количество: {tasks.Count}\n");
            foreach (Task pair in tasks)
            {
                metaDataText.Append($"\n{pair.Name}: {pair.Hours}");
            }
            return metaDataText.ToString();
        }

        public static string ExtractHours(List<Hour> hours)
        {
            StringBuilder metaDataText = new StringBuilder("Часы:\n\n");
            metaDataText.Append($"Количество: {hours.Count}\n");
            foreach (Hour hour in hours)
            {
                metaDataText.Append($"\n{hour.Name}: {hour.Count}");
            }
            return metaDataText.ToString();
        }

        public static string ExtractSources(List<Source> sources)
        {
            StringBuilder metaDataText = new StringBuilder("Источники:\n\n");
            metaDataText.Append("Количество: " + sources.Count);
            foreach (Source group in sources)
            {
                metaDataText.Append($"\n\n{group.Name}: ");
                List<string> values = group.Descriptions;
                for (byte i = 0; i < values.Count; i++)
                {
                    metaDataText.Append($"\n{i + 1}. {values[i]}");
                }
            }
            return metaDataText.ToString();
        }

        public static string ExtractLevels(List<Task> levels)
        {
            StringBuilder metaDataText = new StringBuilder("Уровни компетенций:\n\n");
            metaDataText.Append("Количество: " + levels.Count + "\n");
            for (byte i = 0; i < levels.Count; i++)
            {
                Task level = levels[i];
                metaDataText.Append($"\n{i + 1}. - {level.Name} ({level.Hours})");
            }
            return metaDataText.ToString();
        }
    }
}