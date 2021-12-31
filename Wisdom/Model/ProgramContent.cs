using System.Collections.Generic;

namespace Wisdom.Model
{

    public static class ProgramContent
    {
        // Метаданные
        public static List<string> MetaDataCollection = new List<string>();

        // Названия и ключи всех специальностей и сопутствующих им дисциплин
        public static ComboHeader DisciplineHead = new ComboHeader();
        public static ComboHeader SpecialityHead = new ComboHeader();

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
        public static List<string> HoursCollection = new List<string>();

        // Типы значений
        // Используются для определения кол-ва полей
        public static List<String2> MetaTypes;
        public static List<String2> HourTypes;
        public static List<String2> SourceTypes;
        public static Dictionary<string, int> SourceTypeKeys;

        public static void SetSourceTypeKeys()
        {
            SourceTypeKeys = new Dictionary<string, int>();
            for (byte i = 0; i < SourceTypes.Count; i++)
            {
                SourceTypeKeys.Add(SourceTypes[i].Name, i);
            }
        }

        public static ushort GetStudyHours(List<String2> hours)
        {
            ushort total = 0;
            for (byte i = 0; i < hours.Count; i++)
            {
                total += TryGetHours(hours[i].Value);
            }
            return total;
        }

        public static ushort GetStudyHours() => GetStudyHours(HourTypes);

        public static ushort TryGetHours(string name)
        {
            if (SelectedDiscipline.TotalHours.TryGetValue(name, out ushort max))
                return max;
            return 0;
        }
    }
}
