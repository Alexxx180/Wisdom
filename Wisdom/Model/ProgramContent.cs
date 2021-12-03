using System.Collections.Generic;

namespace Wisdom.Model
{

    public static class ProgramContent
    {
        // Form 1
        // Названия колледжа/дисциплины/специальности|приказ
        public static string CollegeName = "";
        public static string DisciplineName = "";
        public static string ProfessionName = "";
        public static string[] MetaDataCollection = new string[3];
        public static string[] HoursCollection = new string[7];

        //Прочие изменяемые данные - приказ, лица...
        public static String2 Order;
        public static string DirectorName;
        public static string SubDirectorName;
        public static string SubManagerName;

        // Общие часы
        public static string MaxHours = "-";
        public static string EduHours = "-";
        public static string SelfHours = "-";

        // Form 2
        // Часы по типам работ
        public static string PracticePrepare = "-";
        public static string Lections = "-";
        public static string Practice = "-";
        public static string LabWorks = "-";
        public static string ControlWs = "-";
        public static string CourseWs = "-";

        // Компетенции
        // Общая компетенция - знания и умения
        // Профессиональная также включает практический опыт
        public static List<HoursList<String2>> GeneralCompetetions;
        public static List<HoursList<String2>> ProfessionalCompetetions;

        // Классы
        // LevelsList — содержит название темы, часы, уровень освоения, список типов работ
        // HoursList — содержит название раздела, часы, список тем
        // HashList — содержит название типа работ, список из имени под темы и отводимых часов
        // String2 — класс «двойной строки», хранящий имя под темы и отводимые ей часы

        // Form 3
        // «Сложная» система вложенностей:
        //  Разделы -> Темы -> Типы работ
        public static List<HoursList<LevelsList<HashList<String2>>>>
            Plan = new List<HoursList<LevelsList<HashList<String2>>>>();
        // Уровни освоения (ныне уровни компетенций)
        public static StringList StudyLevels = new StringList(" (", ")");
        // Form 4
        //public static List<string> EducationControl = new List<string>();
        //public static List<string> MarkControl = new List<string>();
        public static List<HashList<string>> SourcesControl = new List<HashList<string>>();
        // Form 5
        // Приложение (доп. вопросы к экзаменам/д. зачетам)
        public static List<string> Applyment = new List<string>();

        public static SpecialityBase SelectedSpeciality;
        public static DisciplineBase SelectedDiscipline;

        public static List<String2> MetaTypes;
        public static List<String2> HourTypes;

        public static ushort GetStudyHours()
        {
            ushort total = 0;
            string[] keys = {
                "Содержание",
                "Практические занятия",
                "Контрольная работа",
                "Лабораторная работа",
                "Практическая подготовка",
                "Курсовая работа"
            };
            for (byte i = 0; i < keys.Length; i++)
            {
                total += TryGetHours(keys[i]);
            }
            return total;
        }

        public static ushort TryGetHours(string name)
        {
            if (SelectedDiscipline.TotalHours.TryGetValue(name, out ushort max))
                return max;
            return 0;
        }

        public static Dictionary<string, int> WorkTypes = new Dictionary<string, int>()
        {
            { "Содержание", 0 },
            { "Лабораторная работа", 1 },
            { "Практические занятия", 2 },
            { "Контрольная работа", 3 },
            { "Практическая подготовка", 4 },
            { "Курсовая работа", 5 },
            { "Самостоятельная работа", 6 },
        };
    }
}
