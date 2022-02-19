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
            StudyLevels = new List<Pair<string, string>>();
            MetaData = new List<Pair<string, string>>();
            Sources = new List<Pair<string, List<string>>>();
            Plan = new List<HoursList<LevelsList<HashList<Pair<string, string>>>>>();
        }

        private void SetHours()
        {
            MaxHours = "-";
            EduHours = "-";
            SelfHours = "-";
            Hours = new List<Pair<string, ushort>>();
        }

        // Данные специальности, которые может изменить пользователь
        // Название
        public string ProfessionName { get; set; }

        // Компетенции
        // Общая компетенция - знания и умения
        // Профессиональная также включает практический опыт
        public List<HoursList<Pair<string, string>>> GeneralCompetetions { get; set; }
        public List<List<HoursList<Pair<string, string>>>> ProfessionalCompetetions { get; set; }

        // Общий подсчет часов (задается пользователем)
        public string MaxHours { get; set; }
        public string EduHours { get; set; }
        public string SelfHours { get; set; }

        // Данные дисциплины, которые может изменить пользователь
        // Название, уровни компетенций, источники литературы
        public string DisciplineName { get; set; }
        public List<Pair<string, string>> StudyLevels { get; set; }
        public List<Pair<string, List<string>>> Sources { get; set; }

        // Метаданные и часы
        public List<Pair<string, string>> MetaData { get; set; }
        public List<Pair<string, ushort>> Hours { get; set; }

        // Система вложенностей для тематического плана:
        //  Разделы -> Темы -> Работы -> Задачи
        public List<HoursList<LevelsList<HashList<Pair<string, string>>>>> Plan { get; set; }

        // Приложение (доп. вопросы к экзаменам/д. зачетам)
        public List<string> Applyment { get; set; }
    }
}
