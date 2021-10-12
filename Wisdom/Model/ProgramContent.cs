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
                new List<HoursList<String2>> {
                    new HoursList<String2>("ОК 1", "Общая компетенция №1.1")
                    {
                        Values = new List<String2>
                        {
                            new String2("Умения:", "Умение 1.1"),
                            new String2("Знания:", "Знание 1.1")
                        }
                    },
                    new HoursList<String2>("ОК 2", "Общая компетенция №1.2")
                    {
                        Values = new List<String2>
                        {
                            new String2("Умения:", "Умение 1.2"),
                            new String2("Знания:", "Знание 1.2")
                        }
                    }
                },
                new List<List<HoursList<String2>>>
                {
                    new List<HoursList<String2>> {
                        new HoursList<String2>("ПК 1.1", "Профессиональная компетенция №1.1")
                        {
                            Values = new List<String2>
                            {
                                new String2("Практический опыт:", "Опыт 1.1"),
                                new String2("Умения:", "Умение 1.1"),
                                new String2("Знания:", "Знание 1.1")
                            }
                        },
                        new HoursList<String2>("ПК 1.2", "Профессиональная компетенция №1.2")
                        {
                            Values = new List<String2>
                            {
                                new String2("Практический опыт:", "Опыт 1.2"),
                                new String2("Умения:", "Умение 1.2"),
                                new String2("Знания:", "Знание 1.2")
                            }
                        }
                    },
                    new List<HoursList<String2>> {
                        new HoursList<String2>("ПК 1.1", "Профессиональная компетенция №1.1")
                        {
                            Values = new List<String2>
                            {
                                new String2("Практический опыт:", "Опыт 1.1"),
                                new String2("Умения:", "Умение 1.1"),
                                new String2("Знания:", "Знание 1.1")
                            }
                        },
                        new HoursList<String2>("ПК 1.2", "Профессиональная компетенция №1.2")
                        {
                            Values = new List<String2>
                            {
                                new String2("Практический опыт:", "Опыт 1.2"),
                                new String2("Умения:", "Умение 1.2"),
                                new String2("Знания:", "Знание 1.2")
                            }
                        }
                    }
                }

                ),

            new SpecialityBase(
                "09.02.03 Программирование в компьютерных системах",
                new List<HoursList<String2>> {
                    new HoursList<String2>("ОК+1", "Общая компетенция №2.1")
                    {
                        Values = new List<String2>
                        {
                            new String2("Умения:", "Умение 2.1"),
                            new String2("Знания:", "Знание 2.1")
                        }
                    },
                    new HoursList<String2>("ОК+2", "Общая компетенция №2.2")
                    {
                        Values = new List<String2>
                        {
                            new String2("Умения:", "Умение 2.2"),
                            new String2("Знания:", "Знание 2.2")
                        }
                    }
                },
                new List<List<HoursList<String2>>>
                {
                    new List<HoursList<String2>> {
                        new HoursList<String2>("ПК 2.1", "Профессиональная компетенция №2.1")
                        {
                            Values = new List<String2>
                            {
                                new String2("Практический опыт:", "Опыт 2.1"),
                                new String2("Умения:", "Умение 2.1"),
                                new String2("Знания:", "Знание 2.1")
                            }
                        },
                        new HoursList<String2>("ПК 2.2", "Профессиональная компетенция №2.2")
                        {
                            Values = new List<String2>
                            {
                                new String2("Практический опыт:", "Опыт 2.2"),
                                new String2("Умения:", "Умение 2.2"),
                                new String2("Знания:", "Знание 2.2")
                            }
                        }
                    }
                }

                )
        };

        public static readonly DisciplineBase[] Disciplines = {
            new DisciplineBase(
                "ОГСЭ.01 Основы философии",
                new HeaderHours("68", "58", "10", "", "25", "13", "", "8", ""),
                new List<HoursList<LevelsList<HashList<String2>>>> {
                    new HoursList<LevelsList<HashList<String2>>>("Пример", "21")
                    {
                        Values = new List<LevelsList<HashList<String2>>>
                        {
                            new LevelsList<HashList<String2>>("Пример", "11", "1")
                            {
                                Values = new List<HashList<String2>>()
                                {
                                    new HashList<String2> ("255", new List<String2>() {
                                        new String2("Прохождение основ","5"),
                                        new String2("Изучение предмета","6")
                                    })
                                }
                            },
                            new LevelsList<HashList<String2>>("Пример", "10", "2")
                            {
                                Values = new List<HashList<String2>>()
                                {
                                    new HashList<String2> ("255", new List<String2>() {
                                        new String2("Обучение азам","5")
                                    }),
                                    new HashList<String2> ("0", new List<String2>() {
                                        new String2("Кто есть Я?","5")
                                    })
                                }
                            }
                        }
                    }
                },
                "Общеобязательному направлению",
                "Курс практики 1",
                "/1",
                new List<HashList<string>>
                {
                    new HashList<string>("0", new List<string>() {
                        "Пример источника",
                        "Пример источника 2",
                        "Пример источника 3",
                        "Пример источника 4",
                    })
                }
            ),

            new DisciplineBase(
                "ОГСЭ.02 Технология разработки и защиты баз данных",
                new HeaderHours("68", "58", "10", "", "25", "13", "", "8", ""),
                new List<HoursList<LevelsList<HashList<String2>>>>{
                    new HoursList<LevelsList<HashList<String2>>>("Пример", "12")
                    {
                        Values = new List<LevelsList<HashList<String2>>>
                        {
                            new LevelsList<HashList<String2>>("Пример", "12", "1")
                            {
                                Values = new List<HashList<String2>>()
                                {
                                    new HashList<String2> ("255", new List<String2>() {
                                        new String2("Изучение предмета","12")
                                    })
                                }
                            }
                        }
                    }
                },
                "Профессиональному направлению",
                "Курс практики 2",
                "/2",
                new List<HashList<string>>
                {
                    new HashList<string>("0", new List<string>() {
                        "Пример источника 5",
                        "Пример источника 6",
                        "Пример источника 7",
                        "Пример источника 8",
                    })
                }
            )
        };
    }
}
