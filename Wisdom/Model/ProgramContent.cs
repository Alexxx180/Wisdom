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

        public static String2 Order;

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
        // Общая компетенция - знания и умения (+ практический опыт если профессиональная)
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

        // Form 6
        // Отношение дисциплины к ...
        public static string DisciplineRelation = "";
        // Путь проведения практической подготовки ...
        public static string WorkAround = "";
        // Курс дистанционного обучения ...
        public static string DistanceEducation = "";

        public static readonly SpecialityBase[] Specialities = {
            new SpecialityBase(
                "15.02.07 Автоматизация технологических процессов и производств (по отраслям)",
                new List<HoursList<String2>>(),
                new List<HoursList<String2>>()
                ),

            new SpecialityBase(
                "09.02.03 Программирование в компьютерных системах",
                new List<HoursList<String2>>(),
                new List<HoursList<String2>>()
                )
        };

        public static readonly DisciplineBase[] Disciplines = {
            new DisciplineBase(
                "ОГСЭ.01 Основы философии",
                new HeaderHours(),
                new List<HoursList<LevelsList<HashList<String2>>>>(),
                "Общеобязательному направлению",
                "Курс практики 1",
                "/1",
                new List<HashList<string>>()
            ),

            new DisciplineBase(
                "ОГСЭ.02 Технология разработки и защиты баз данных",
                new HeaderHours(),
                new List<HoursList<LevelsList<HashList<String2>>>>(),
                "Профессиональному направлению",
                "Курс практики 2",
                "/2",
                new List<HashList<string>>()
            )
        }; 
    }
}
