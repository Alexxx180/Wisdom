using System.Collections.Generic;

namespace Wisdom.Model
{
    public class DisciplineProgram
    {
        public DisciplineProgram()
        {
            ProfessionName = "";
            DisciplineName = "";
            SetHours();
            Applyment = new List<string>();
            StudyLevels = new StringList(" (", ")");
            MetaData = new Dictionary<string, string>();
            Sources = new List<HashList<string>>();
            Plan = new List<HoursList<LevelsList<HashList<String2>>>>();
        }

        private void SetHours()
        {
            MaxHours = "-";
            EduHours = "-";
            SelfHours = "-";
            Hours = new Dictionary<string, ushort>();
        }

        // Данные специальности, которые может изменить пользователь
        // Название
        public string ProfessionName { get; set; }

        // Компетенции
        // Общая компетенция - знания и умения
        // Профессиональная также включает практический опыт
        public List<HoursList<String2>> GeneralCompetetions { get; set; }
        public List<List<HoursList<String2>>> ProfessionalCompetetions { get; set; }

        // Общий подсчет часов (задается пользователем)
        public string MaxHours { get; set; }
        public string EduHours { get; set; }
        public string SelfHours { get; set; }

        // Данные дисциплины, которые может изменить пользователь
        // Название, уровни компетенций, источники литературы
        public string DisciplineName { get; set; }
        public StringList StudyLevels { get; set; }
        public List<HashList<string>> Sources { get; set; }

        // Метаданные и часы
        public Dictionary<string, string> MetaData { get; set; }
        public Dictionary<string, ushort> Hours { get; set; }

        // Система вложенностей для тематического плана:
        //  Разделы -> Темы -> Работы -> Задачи
        public List<HoursList<LevelsList<HashList<String2>>>> Plan { get; set; }

        // Приложение (доп. вопросы к экзаменам/д. зачетам)
        public List<string> Applyment { get; set; }

        public void AddHours(Dictionary<string, ushort> hours)
        {
            foreach(KeyValuePair<string, ushort> pair in hours)
                Hours.Add(pair.Key, pair.Value);
        }

        public void AddMetaData(Dictionary<string, string> hours)
        {
            foreach (KeyValuePair<string, string> pair in hours)
                MetaData.Add(pair.Key, pair.Value);
        }

        public ushort GetStudyHours()
        {
            ushort total = 0;
            foreach (KeyValuePair<string, ushort> pair in Hours)
                total += TryGetHours(pair.Key);
            return total;
        }

        public ushort TryGetHours(string name)
        {
            if (Hours.TryGetValue(name, out ushort max))
                return max;
            return 0;
        }
    }
}
