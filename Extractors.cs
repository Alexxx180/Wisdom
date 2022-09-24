using System.Collections.Generic;
using System.Text;
using ControlMaterials.Tables.Hours;
using ControlMaterials.Tables.Tasks;
using ControlMaterials.Tables.ThemePlan;

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
                competetionsText.Append("\n\n" + competetion.Prefix + ". " + competetion.Name);
                foreach (Task pair in competetion.Items)
                {
                    competetionsText.Append("\n" + pair.Name + ": " + pair.Data);
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

        public static string ExtractThemePlan(List<HoursNode<Theme>> topics)
        {
            StringBuilder planText = new StringBuilder("Тематический план:\n\n");
            planText.Append("Количество: " + topics.Count);
            for (byte i = 0; i < topics.Count; i++)
            {
                HoursNode<Theme> topic = topics[i];
                planText.Append("\n\nРаздел");
                planText.Append(" " + (i + 1) + ": ");
                planText.Append(topic.Name + ", часы: ");
                planText.Append(topic.Hours);
                for (byte ii = 0; ii < topic.Count; ii++)
                {
                    Theme theme = topic[ii];
                    planText.Append($"\nТема {ii + 1}: {theme.Name}, часы: {theme.Hours},");

                    string gcompetetions = $"{theme.GCompetetions[0].Prefix} {theme.GCompetetions[0].No}";
                    string pcompetetions = $"{theme.PCompetetions[0][0].Prefix} {theme.PCompetetions[0].No}.{theme.PCompetetions[0][0].No}";

                    planText.Append($" УК: {theme.Level}, Компетенции: {gcompetetions}. {pcompetetions}");
                    for (byte iii = 0; iii < theme.Count; iii++)
                    {
                        Work work = theme[iii];
                        planText.Append($"\n{work.Name}");
                        for (byte iv = 0; iv < work.Count; iv++)
                        {
                            IndexedHour task = work[iv];
                            planText.Append($"\n{task.Name}: {task.Count}");
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
                metaDataText.Append($"\n{pair.Name}: {pair.Data}");
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
                for (byte i = 0; i < group.Items.Count; i++)
                {
                    metaDataText.Append($"\n{i + 1}. {group.Items[i].Name}");
                }
            }
            return metaDataText.ToString();
        }

        public static string ExtractLevels(List<Level> levels)
        {
            StringBuilder metaDataText = new StringBuilder("Уровни компетенций:\n\n");
            metaDataText.Append("Количество: " + levels.Count + "\n");
            for (byte i = 0; i < levels.Count; i++)
            {
                Level level = levels[i];
                metaDataText.Append($"\n{level.No}. - {level.Description.Name} ({level.Description.Data})");
            }
            return metaDataText.ToString();
        }
    }
}