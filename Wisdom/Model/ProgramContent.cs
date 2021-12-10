using System.Collections.Generic;

namespace Wisdom.Model
{

    public static class ProgramContent
    {
        // Метаданные
        // Независимые от рабочих учебных программ
        public static string CollegeName = "";
        // Приказ
        public static String2 Order;
        // Директор и заместители
        public static string DirectorName;
        public static string SubDirectorName;
        public static string SubManagerName;

        // Зависимые от рабочих учебных программ (дисциплины)
        public static string[] MetaDataCollection = new string[3];

        // Выбранная специальность
        public static SpecialityBase SelectedSpeciality;

        // Данные специальности, которые может изменить пользователь
        // Название
        public static string ProfessionName = "";

        // Компетенции
        // Общая компетенция - знания и умения
        // Профессиональная также включает практический опыт
        public static List<HoursList<String2>> GeneralCompetetions;
        public static List<HoursList<String2>> ProfessionalCompetetions;

        // Выбранная дисциплина и ее информация по умолчанию
        public static DisciplineBase SelectedDiscipline;

        // Данные дисциплины, которые может изменить пользователь
        // Название
        public static string DisciplineName = "";
        // Уровни освоения (уровни компетенций)
        public static StringList StudyLevels = new StringList(" (", ")");
        // Источники литературы
        public static List<HashList<string>> SourcesControl = new List<HashList<string>>();

        // Классы
        // LevelsList — список с 3-мя заголовками, содержит название темы, часы, уровень освоения, список работ
        // HoursList — список с 2-мя заголовками, содержит название раздела, часы, список тем
        // HashList — список с заголовком, содержит название типа работ, список из имени под темы и отводимых часов
        // String2 — класс «Двойная строка», хранящий имя задачи и отводимые ей часы

        // Система вложенностей для тематического плана:
        //  Разделы -> Темы -> Работы -> Задачи
        public static List<HoursList<LevelsList<HashList<String2>>>>
            Plan = new List<HoursList<LevelsList<HashList<String2>>>>();

        // Приложение (доп. вопросы к экзаменам/д. зачетам)
        public static List<string> Applyment = new List<string>();

        // Общий подсчет часов (задается пользователем)
        public static string MaxHours = "-";
        public static string EduHours = "-";
        public static string SelfHours = "-";

        // Часы подсчитываемые по типам работ (задается пользователем)
        public static string[] HoursCollection = new string[7];

        // Типы значений
        // Используются для определения кол-ва полей
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
