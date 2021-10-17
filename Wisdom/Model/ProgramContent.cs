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

                ),
            new SpecialityBase(

                "15.02.14 Оснащение средствами автоматизации технологических процессов и производств (по отраслям)",
                new List<HoursList<String2>> {
                    new HoursList<String2>("ОК 1", "Выбирать способы решения задач профессиональной деятельности, применительно к различным контекстам.")
                    {
                        Values = new List<String2>
                        {
                            new String2("Умения:", ""),
                            new String2("Знания:", "")
                        }
                    },
                    new HoursList<String2>("ОК 2", "Осуществлять поиск, анализ и интерпретацию информации, необходимой для выполнения задач профессиональной деятельности.")
                    {
                        Values = new List<String2>
                        {
                            new String2("Умения:", ""),
                            new String2("Знания:", "")
                        }
                    },
                    new HoursList<String2>("ОК 3", "Планировать и реализовывать собственное профессиональное и личностное развитие.")
                    {
                        Values = new List<String2>
                        {
                            new String2("Умения:", ""),
                            new String2("Знания:", "")
                        }
                    },
                    new HoursList<String2>("ОК 4", "Работать в коллективе и команде, эффективно взаимодействовать с коллегами, руководством, клиентами.")
                    {
                        Values = new List<String2>
                        {
                            new String2("Умения:", ""),
                            new String2("Знания:", "")
                        }
                    },
                    new HoursList<String2>("ОК 5", "Осуществлять устную и письменную коммуникацию на государственном языке с учетом особенностей социального и культурного контекста.")
                    {
                        Values = new List<String2>
                        {
                            new String2("Умения:", ""),
                            new String2("Знания:", "")
                        }
                    },
                    new HoursList<String2>("ОК 6", "Проявлять гражданско-патриотическую позицию, демонстрировать осознанное поведение на основе традиционных общечеловеческих ценностей.")
                    {
                        Values = new List<String2>
                        {
                            new String2("Умения:", ""),
                            new String2("Знания:", "")
                        }
                    },
                    new HoursList<String2>("ОК 9", "Использовать информационные технологии в профессиональной деятельности.")
                    {
                        Values = new List<String2>
                        {
                            new String2("Умения:", ""),
                            new String2("Знания:", "")
                        }
                    },
                    new HoursList<String2>("ОК 10", "Пользоваться профессиональной документацией на государственном и иностранном языках.")
                    {
                        Values = new List<String2>
                        {
                            new String2("Умения:", ""),
                            new String2("Знания:", "")
                        }
                    }
                },

                new List<List<HoursList<String2>>>
                {
                    new List<HoursList<String2>> {
                        new HoursList<String2>("ПК 1.1", "Осуществлять анализ имеющихся решений для выбора программного обеспечения для создания и тестирования модели элементов систем автоматизации на основе технического задания.")
                        {
                            Values = new List<String2>
                            {
                                new String2("Практический опыт:", ""),
                                new String2("Умения:", ""),
                                new String2("Знания:", "")
                            }
                        },
                        new HoursList<String2>("ПК 1.2", "Разрабатывать виртуальную модель элементов систем автоматизации на основе выбранного программного обеспечения и технического задания.")
                        {
                            Values = new List<String2>
                            {
                                new String2("Практический опыт:", ""),
                                new String2("Умения:", ""),
                                new String2("Знания:", "")
                            }
                        },
                        new HoursList<String2>("ПК 1.4", "Формировать пакет технической документации на разработанную модель элементов систем автоматизации.")
                        {
                            Values = new List<String2>
                            {
                                new String2("Практический опыт:", ""),
                                new String2("Умения:", ""),
                                new String2("Знания:", "")
                            }
                        }
                    },

                    new List<HoursList<String2>> {
                        new HoursList<String2>("ПК 2.1", "Осуществлять выбор оборудования и элементной базы систем автоматизации в соответствии с заданием и требованием разработанной технической документации на модель элементов систем автоматизации.")
                        {
                            Values = new List<String2>
                            {
                                new String2("Практический опыт:", ""),
                                new String2("Умения:", ""),
                                new String2("Знания:", "")
                            }
                        },
                        new HoursList<String2>("ПК 2.2", "Осуществлять монтаж и наладку модели элементов систем автоматизации на основе разработанной технической документации.")
                        {
                            Values = new List<String2>
                            {
                                new String2("Практический опыт:", ""),
                                new String2("Умения:", ""),
                                new String2("Знания:", "")
                            }
                        },
                        new HoursList<String2>("ПК 2.3", "Проводить испытания модели элементов систем автоматизации в реальных условиях с целью подтверждения работоспособности и возможной оптимизации.")
                        {
                            Values = new List<String2>
                            {
                                new String2("Практический опыт:", ""),
                                new String2("Умения:", ""),
                                new String2("Знания:", "")
                            }
                        }
                    },

                    new List<HoursList<String2>> {
                        new HoursList<String2>("ПК 3.1", "Планировать работы по монтажу, наладке и техническому обслуживанию систем и средств автоматизации на основе организационно-распорядительных документов и требований технической документации.")
                        {
                            Values = new List<String2>
                            {
                                new String2("Практический опыт:", ""),
                                new String2("Умения:", ""),
                                new String2("Знания:", "")
                            }
                        },
                        new HoursList<String2>("ПК 3.2", "Организовывать материально-техническое обеспечение работ по монтажу, наладке и техническому обслуживанию систем и средств автоматизации.")
                        {
                            Values = new List<String2>
                            {
                                new String2("Практический опыт:", ""),
                                new String2("Умения:", ""),
                                new String2("Знания:", "")
                            }
                        },
                        new HoursList<String2>("ПК 3.3", "Разрабатывать инструкции и технологические карты выполнения работ для подчиненного персонала по монтажу, наладке и техническому обслуживанию систем и средств автоматизации.")
                        {
                            Values = new List<String2>
                            {
                                new String2("Практический опыт:", ""),
                                new String2("Умения:", ""),
                                new String2("Знания:", "")
                            }
                        },
                        new HoursList<String2>("ПК 3.4", "Организовывать выполнение производственных заданий подчиненным персоналом.")
                        {
                            Values = new List<String2>
                            {
                                new String2("Практический опыт:", ""),
                                new String2("Умения:", ""),
                                new String2("Знания:", "")
                            }
                        },
                        new HoursList<String2>("ПК 3.5", "Контролировать качество работ по монтажу, наладке и техническому обслуживанию систем и средств автоматизации, выполняемых подчиненным персоналом и соблюдение норм охраны труда и бережливого производства.")
                        {
                            Values = new List<String2>
                            {
                                new String2("Практический опыт:", ""),
                                new String2("Умения:", ""),
                                new String2("Знания:", "")
                            }
                        }
                    },

                    new List<HoursList<String2>> {
                        new HoursList<String2>("ПК 4.1", "Контролировать текущие параметры и фактические показатели работы систем автоматизации в соответствии с требованиями нормативно-технической документации для выявления возможных отклонений.")
                        {
                            Values = new List<String2>
                            {
                                new String2("Практический опыт:", ""),
                                new String2("Умения:", ""),
                                new String2("Знания:", "")
                            }
                        },
                        new HoursList<String2>("ПК 4.2", "Осуществлять диагностику причин возможных неисправностей и отказов систем для выбора методов и способов их устранения.")
                        {
                            Values = new List<String2>
                            {
                                new String2("Практический опыт:", ""),
                                new String2("Умения:", ""),
                                new String2("Знания:", "")
                            }
                        },
                        new HoursList<String2>("ПК 4.3", "Организовывать работы по устранению неполадок, отказов оборудования и ремонту систем в рамках своей компетенции.")
                        {
                            Values = new List<String2>
                            {
                                new String2("Практический опыт:", ""),
                                new String2("Умения:", ""),
                                new String2("Знания:", "")
                            }
                        }
                    }

                }

                )
        };

        public static readonly List<DisciplineBase>[] Disciplines = {
            new List<DisciplineBase>()
            {
                new DisciplineBase(
                    "ОГСЭ.01 Основы философии",
                    new HeaderHours("68", "58", "10", "", "25", "13", "", "8", ""),
                    new List<HoursList<LevelsList<HashList<String2>>>> {
                        new HoursList<LevelsList<HashList<String2>>>("Пример", "21")
                        {
                            Values = new List<LevelsList<HashList<String2>>>
                            {
                                new LevelsList<HashList<String2>>("Пример", "11", "ОК 01. ОК 02. ОК 03. ОК 04. ОК 05. ОК 06. ОК 09. ОК 10. ПК 1.1.-1.5. ПК 2.1- 2.3. ПК 3.1-3.5. ПК 4.1.- 4.3.", "1")
                                {
                                    Values = new List<HashList<String2>>()
                                    {
                                        new HashList<String2> ("255", new List<String2>() {
                                            new String2("Прохождение основ","5"),
                                            new String2("Изучение предмета","6")
                                        })
                                    }
                                },
                                new LevelsList<HashList<String2>>("Пример", "10", "ОК 01. ОК 02. ОК 03. ОК 04. ОК 05. ОК 06. ОК 09. ОК 10. ПК 1.1.-1.5. ПК 2.1- 2.3. ПК 3.1-3.5. ПК 4.1.- 4.3.", "2")
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
                )
        },
        new List<DisciplineBase>()
        {
            new DisciplineBase(
                "ОГСЭ.02 Технология разработки и защиты баз данных",
                new HeaderHours("68", "58", "10", "", "25", "13", "", "8", ""),
                new List<HoursList<LevelsList<HashList<String2>>>>{
                    new HoursList<LevelsList<HashList<String2>>>("Пример", "12")
                    {
                        Values = new List<LevelsList<HashList<String2>>>
                        {
                            new LevelsList<HashList<String2>>("Пример", "12", "ОК 01. ОК 02. ОК 03. ОК 04. ОК 05. ОК 06. ОК 09. ОК 10. ПК 1.1.-1.5. ПК 2.1- 2.3. ПК 3.1-3.5. ПК 4.1.- 4.3.", "1")
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
        },
        new List<DisciplineBase>()
        {
             new DisciplineBase(
                "ОГСЭ.03 Иностранный язык в профессиональной деятельности (английский язык)",
                new HeaderHours("176", "175", "1", "", "14", "161", "", "", ""),
                new List<HoursList<LevelsList<HashList<String2>>>>{
                    new HoursList<LevelsList<HashList<String2>>>("Из истории автоматизации. Historical Development of Automation", "32")
                    {
                        Values = new List<LevelsList<HashList<String2>>>
                        {
                            new LevelsList<HashList<String2>>("Механизация. Mechanization.", "10", "ОК 01. ОК 02. ОК 03. ОК 04. ОК 05. ОК 06. ОК 09. ОК 10. ПК 1.1.-1.5. ПК 2.1- 2.3. ПК 3.1-3.5. ПК 4.1.- 4.3.", "1")
                            {
                                Values = new List<HashList<String2>>()
                                {
                                    new HashList<String2> ("0", new List<String2>() {
                                        new String2("Введение.","3"),
                                        new String2("Лексика по теме «Механизация».","3"),
                                        new String2("Грамматика: активизация времен активного залога (времена групп Simple, Progressive, Perfect).", "4")
                                    })
                                }
                            },
                            new LevelsList<HashList<String2>>("Из истории роботов и гибких производственных систем. History of Robots and Flexible  Manufacturing Systems.", "11","ОК 01. ОК 02. ОК 03. ОК 04. ОК 05. ОК 06. ОК 09. ОК 10. ПК 1.1.-1.5. ПК 2.1- 2.3. ПК 3.1-3.5. ПК 4.1.- 4.3.", "2")
                            {
                                Values = new List<HashList<String2>>()
                                {
                                    new HashList<String2> ("0", new List<String2>() {
                                        new String2("Лексика по теме «Из истории роботов и гибких производственных систем».", "5"),
                                        new String2("Грамматика: активизация времен пассивного залога: времена групп  Simple, Progressive).",  "6")
                                    })
                                }
                            },
                            new LevelsList<HashList<String2>>("Автоматизация и общество. Automation and Society.", "11","ОК 01. ОК 02. ОК 03. ОК 04. ОК 05. ОК 06. ОК 09. ОК 10. ПК 1.1.-1.5. ПК 2.1- 2.3. ПК 3.1-3.5. ПК 4.1.- 4.3.", "2")
                            {
                                Values = new List<HashList<String2>>()
                                {
                                    new HashList<String2> ("0", new List<String2>() {
                                        new String2("Лексика по теме «Автоматизация и общество».", "5"),
                                        new String2("Грамматика: времена пассивного залога (времена группы Perfect).", "6")
                                    })
                                }
                            }
                        }
                    },
                    new HoursList<LevelsList<HashList<String2>>>("Основные понятия автоматизации. Main Definitions of Automation.",  "31")
                    {
                        Values = new List<LevelsList<HashList<String2>>>
                        {
                            new LevelsList<HashList<String2>>("Основные элементы автоматических систем. Basic Elements of Automation.", "10", "ОК 01. ОК 02. ОК 03. ОК 04. ОК 05. ОК 06. ОК 09. ОК 10. ПК 1.1.-1.5. ПК 2.1- 2.3. ПК 3.1-3.5. ПК 4.1.- 4.3.", "2")
                            {
                                Values = new List<HashList<String2>>()
                                {
                                    new HashList<String2> ("0", new List<String2>() {
                                        new String2("Лексика по теме «Основные элементы автоматических систем».", "5"),
                                        new String2("Грамматика: Словообразование. Основные английские префиксы и суффиксы.", "5")
                                    })
                                }
                            },
                            new LevelsList<HashList<String2>>("Контроль обратной связи и вероятностный контроль. Feedback and Stochastic Control.", "10","ОК 01. ОК 02. ОК 03. ОК 04. ОК 05. ОК 06. ОК 09. ОК 10. ПК 1.1.-1.5. ПК 2.1- 2.3. ПК 3.1-3.5. ПК 4.1.- 4.3.", "2")
                            {
                                Values = new List<HashList<String2>>()
                                {
                                    new HashList<String2> ("0", new List<String2>() {
                                        new String2("Лексика по теме «Контроль обратной связи и вероятностный контроль».", "5"),
                                        new String2("Грамматика: словообразование существительных и глаголов.", "5")
                                    })
                                }
                            },
                            new LevelsList<HashList<String2>>("Типы автоматизации. Types of Automation.", "11", "ОК 01. ОК 02. ОК 03. ОК 04. ОК 05. ОК 06. ОК 09. ОК 10. ПК 1.1.-1.5. ПК 2.1- 2.3. ПК 3.1-3.5. ПК 4.1.- 4.3.", "2")
                            {
                                Values = new List<HashList<String2>>()
                                {
                                    new HashList<String2> ("0", new List<String2>() {
                                        new String2("Лексика по теме «Типы автоматизации».", "5"),
                                        new String2("Грамматика: словообразование прилагательных и наречий.", "6")
                                    })
                                }
                            }
                        }
                    },
                    new HoursList<LevelsList<HashList<String2>>>("Автоматическое оборудование. Automation Equipment.",  "45")
                    {
                        Values = new List<LevelsList<HashList<String2>>>
                        {
                            new LevelsList<HashList<String2>>("ЧПУ типа CNC. CNC Machines.", "11", "ОК 01. ОК 02. ОК 03. ОК 04. ОК 05. ОК 06. ОК 09. ОК 10. ПК 1.1.-1.5. ПК 2.1- 2.3. ПК 3.1-3.5. ПК 4.1.- 4.3.", "2")
                            {
                                Values = new List<HashList<String2>>()
                                {
                                    new HashList<String2> ("0", new List<String2>() {
                                        new String2("Лексика по теме «ЧПУ типа CNC».", "5"),
                                        new String2("Грамматика: систематизация пройденного материала.", "6")
                                    })
                                }
                            },
                            new LevelsList<HashList<String2>>("Робототехника. Виды роботов. Robotics.Types of Robots.", "20", "ОК 01. ОК 02. ОК 03. ОК 04. ОК 05. ОК 06. ОК 09. ОК 10. ПК 1.1.-1.5. ПК 2.1- 2.3. ПК 3.1-3.5. ПК 4.1.- 4.3.", "2")
                            {
                                Values = new List<HashList<String2>>()
                                {
                                    new HashList<String2> ("0", new List<String2>() {
                                        new String2("Лексика по теме «Робототехника. Виды роботов»", "10"),
                                        new String2("Грамматика: предлоги места, времени и направления.", "10")
                                    })
                                }
                            },
                            new LevelsList<HashList<String2>>("Автоматизированная сервисная система. Material Handling System.", "7", "ОК 01. ОК 02. ОК 03. ОК 04. ОК 05. ОК 06. ОК 09. ОК 10. ПК 1.1.-1.5. ПК 2.1- 2.3. ПК 3.1-3.5. ПК 4.1.- 4.3.", "2")
                            {
                                Values = new List<HashList<String2>>()
                                {
                                    new HashList<String2> ("0", new List<String2>() {
                                        new String2("Лексика по теме «Автоматизированная сервисная система».", "3"),
                                        new String2("Грамматика: артикль.", "4")
                                    })
                                }
                            },
                            new LevelsList<HashList<String2>>("Автоматические производственные линии. Automated Production Lines.", "7", "ОК 01. ОК 02. ОК 03. ОК 04. ОК 05. ОК 06. ОК 09. ОК 10. ПК 1.1.-1.5. ПК 2.1- 2.3. ПК 3.1-3.5. ПК 4.1.- 4.3.", "2")
                            {
                                Values = new List<HashList<String2>>()
                                {
                                    new HashList<String2> ("0", new List<String2>() {
                                        new String2("Лексика по теме: « Автоматические производственные линии».", "3"),
                                        new String2("Грамматика: активизация пройденного грамматического материала.", "4")
                                    })
                                }
                            }
                        }
                    },
                    new HoursList<LevelsList<HashList<String2>>>("Гибкие производственные системы. Flexible Manufacturing Systems.",  "18")
                    {
                        Values = new List<LevelsList<HashList<String2>>>
                        {
                            new LevelsList<HashList<String2>>("Характерные особенности гибких производственных систем. Features of Flexible Manufacturing Systems.", "6", "ОК 01. ОК 02. ОК 03. ОК 04. ОК 05. ОК 06. ОК 09. ОК 10. ПК 1.1.-1.5. ПК 2.1- 2.3. ПК 3.1-3.5. ПК 4.1.- 4.3.", "2")
                            {
                                Values = new List<HashList<String2>>()
                                {
                                    new HashList<String2> ("0", new List<String2>() {
                                        new String2("Лексика по теме «Характерные особенности гибких производственных систем».", "3"),
                                        new String2("Грамматика: прямая и косвенная речь.", "3")
                                    })
                                }
                            },
                            new LevelsList<HashList<String2>>("Гибкие элементы системы. Flexible Cells.", "6", "ОК 01. ОК 02. ОК 03. ОК 04. ОК 05. ОК 06. ОК 09. ОК 10. ПК 1.1.-1.5. ПК 2.1- 2.3. ПК 3.1-3.5. ПК 4.1.- 4.3.", "2")
                            {
                                Values = new List<HashList<String2>>()
                                {
                                    new HashList<String2> ("0", new List<String2>() {
                                        new String2("Лексика по теме «Гибкие элементы систем».", "3"),
                                        new String2("Грамматика: прямая и косвенная речь. Согласование времен.", "3")
                                    })
                                }
                            },
                            new LevelsList<HashList<String2>>("Иерархический контроль. Hierarchial Control.", "6", "ОК 01. ОК 02. ОК 03. ОК 04. ОК 05. ОК 06. ОК 09. ОК 10. ПК 1.1.-1.5. ПК 2.1- 2.3. ПК 3.1-3.5. ПК 4.1.- 4.3.", "2")
                            {
                                Values = new List<HashList<String2>>()
                                {
                                    new HashList<String2> ("0", new List<String2>() {
                                        new String2("Лексика по теме: «Иерархический контроль».", "3"),
                                        new String2("Грамматика: отработка грамматических конструкций.", "3")
                                    })
                                }
                            }
                        }
                    },
                    new HoursList<LevelsList<HashList<String2>>>("Датчики. Sensing.",  "24")
                    {
                        Values = new List<LevelsList<HashList<String2>>>
                        {
                            new LevelsList<HashList<String2>>("Классификация датчиков. Classification of Sensors.", "12", "ОК 01. ОК 02. ОК 03. ОК 04. ОК 05. ОК 06. ОК 09. ОК 10. ПК 1.1.-1.5. ПК 2.1- 2.3. ПК 3.1-3.5. ПК 4.1.- 4.3.", "2")
                            {
                                Values = new List<HashList<String2>>()
                                {
                                    new HashList<String2> ("0", new List<String2>() {
                                        new String2("Лексика по теме «Классификация датчиков».", "6"),
                                        new String2("Грамматика: модальные глаголы.", "6")
                                    })
                                }
                            },
                            new LevelsList<HashList<String2>>("Датчики приближения и скольжения. Proximity and Slip Sensors.", "12", "ОК 01. ОК 02. ОК 03. ОК 04. ОК 05. ОК 06. ОК 09. ОК 10. ПК 1.1.-1.5. ПК 2.1- 2.3. ПК 3.1-3.5. ПК 4.1.- 4.3.", "2")
                            {
                                Values = new List<HashList<String2>>()
                                {
                                    new HashList<String2> ("0", new List<String2>() {
                                        new String2("Лексика по теме «Датчики приближения и скольжения».", "6"),
                                        new String2("Грамматика: модальные глаголы и их эквиваленты.", "6")
                                    })
                                }
                            }
                        }
                    },
                    new HoursList<LevelsList<HashList<String2>>>("Машинное программирование. Machine Programming.",  "14")
                    {
                        Values = new List<LevelsList<HashList<String2>>>
                        {
                            new LevelsList<HashList<String2>>("Содержание программы. Content of the Program.", "5", "ОК 01. ОК 02. ОК 03. ОК 04. ОК 05. ОК 06. ОК 09. ОК 10. ПК 1.1.-1.5. ПК 2.1- 2.3. ПК 3.1-3.5. ПК 4.1.- 4.3.", "2")
                            {
                                Values = new List<HashList<String2>>()
                                {
                                    new HashList<String2> ("0", new List<String2>() {
                                        new String2("Лексика по теме «Содержание программы».", "2"),
                                        new String2("Грамматика: условные предложения I, II, III  типа.", "3")
                                    })
                                }
                            },
                            new LevelsList<HashList<String2>>("Программирование на машинном уровне. Machine-Level Programming.", "5", "ОК 01. ОК 02. ОК 03. ОК 04. ОК 05. ОК 06. ОК 09. ОК 10. ПК 1.1.-1.5. ПК 2.1- 2.3. ПК 3.1-3.5. ПК 4.1.- 4.3.", "2")
                            {
                                Values = new List<HashList<String2>>()
                                {
                                    new HashList<String2> ("0", new List<String2>() {
                                        new String2("Лексика по теме «Программирование на машинном уровне».", "2"),
                                        new String2("Грамматика: условные предложения. Сослагательное наклонение после I wish.", "3")
                                    })
                                }
                            },
                            new LevelsList<HashList<String2>>("Программирование на уровне задач. Task-Level Programming.", "4", "ОК 01. ОК 02. ОК 03. ОК 04. ОК 05. ОК 06. ОК 09. ОК 10. ПК 1.1.-1.5. ПК 2.1- 2.3. ПК 3.1-3.5. ПК 4.1.- 4.3.", "2")
                            {
                                Values = new List<HashList<String2>>()
                                {
                                    new HashList<String2> ("0", new List<String2>() {
                                        new String2("Лексика по теме «Программирование на уровне задач».", "2"),
                                        new String2("Грамматика: неличные формы глагола. Инфинитив.", "2")
                                    })
                                }
                            }
                        }
                    },
                    new HoursList<LevelsList<HashList<String2>>>("Приводы в автоматических системах. Actuators in Automatic Systems.",  "12")
                    {
                        Values = new List<LevelsList<HashList<String2>>>
                        {
                            new LevelsList<HashList<String2>>("Электроприводы. Electric Actuators.", "4", "ОК 01. ОК 02. ОК 03. ОК 04. ОК 05. ОК 06. ОК 09. ОК 10. ПК 1.1.-1.5. ПК 2.1- 2.3. ПК 3.1-3.5. ПК 4.1.- 4.3.", "2")
                            {
                                Values = new List<HashList<String2>>()
                                {
                                    new HashList<String2> ("0", new List<String2>() {
                                        new String2("Лексика по теме «Электроприводы».", "2"),
                                        new String2("Грамматика: конструкции с инфинитивом: сложное дополнение, сложное подлежащее.", "2")
                                    })
                                }
                            },
                            new LevelsList<HashList<String2>>("Пневматические приводы (линейные и вращающиеся). Pneumatic Actuators (Linear and Rotary)", "4", "ОК 01. ОК 02. ОК 03. ОК 04. ОК 05. ОК 06. ОК 09. ОК 10. ПК 1.1.-1.5. ПК 2.1- 2.3. ПК 3.1-3.5. ПК 4.1.- 4.3.", "2")
                            {
                                Values = new List<HashList<String2>>()
                                {
                                    new HashList<String2> ("0", new List<String2>() {
                                        new String2("Лексика по теме «Пневматические приводы (линейные и вращающиеся»", "2"),
                                        new String2("Грамматика: неличные формы глагола. Причастие I, II.", "2")
                                    })
                                }
                            },
                            new LevelsList<HashList<String2>>("Приводы контура обратной связи. Feedback Loop Actuators.", "4", "ОК 01. ОК 02. ОК 03. ОК 04. ОК 05. ОК 06. ОК 09. ОК 10. ПК 1.1.-1.5. ПК 2.1- 2.3. ПК 3.1-3.5. ПК 4.1.- 4.3.", "2")
                            {
                                Values = new List<HashList<String2>>()
                                {
                                    new HashList<String2> ("0", new List<String2>() {
                                        new String2("Лексика по теме «Приводы контура обратной связи».", "1"),
                                        new String2("Грамматика: неличные формы глагола. Герундий.", "2")
                                    }),
                                    new HashList<String2> ("2", new List<String2>() {
                                        new String2("«подготовка презентации по теме».", "1")
                                    })
                                }
                            }
                        }
                    }

                },
                "общему гуманитарному и социально-экономическому циклу дисциплин учебного плана специальности 15.02.14 Оснащение средствами автоматизации технологических процессов и производств по отраслям, устанавливающих базовые знания, умения и навыки, необходимые в будущей профессиональной деятельности выпускника.",
                "",
                "",
                new List<HashList<string>>
                {
                    new HashList<string>("0", new List<string>() {
                        "	Английский язык для изучающих автоматику (В1–В2) : учеб. пособие для СПО / М. Ю. Рачков. — 2-е изд., испр. и доп. — М. : Издательство Юрайт, 2019. — 196 с. — (Серия : Профессиональное образование)",
                        "	Карпова, Т.А. English for Colleges = Английский язык для колледжей. Практикум + Приложение: тесты: учебно-практическое пособие / Карпова Т.А., Восковская А.С., Мельничук М.В. — Москва: КноРус, 2020. — 286 с. — (СПО). — ISBN 978-5-406-07527-2. — URL: https://book.ru/book/932751— Текст: электронный.",
                        "	Английский язык для технических направлений: учеб. пособие для СПО/ Н.Л. Байдикова, Е.С.Давиденко. - М: Издательство Юрайт, 2019. - 171 с. - (Серия: Профессиональное образование). - ISBN 978-5-534-10078-5 // [Электронная библиотечная система Юрайт] / - Режим доступа: http://www.biblio-online.ru/",
                        "	Английский язык. Грамматика: учебник и практикум для СПО / В.А.Гуреев.-М.: Издательство Юрайт, 2019. - 294 с. - (Серия: Профессиональное образование). ISBN 978-5-534-10481-3//[Электронная библиотечная система Юрайт] - Режим доступа: http://www.biblio-online.ru/",
                        "	Английский язык. Грамматика: Сборник упражнений / Ю.Б. Голицынский; [8-е. изд., испр.]. - Санкт-Петербург: КАРО, 2020. - 576 с."
                    }),
                    new HashList<string>("1", new List<string>() {
                        "	Грамматика английского языка. Grammar in levels elementary - pre-intermediate: учеб. пособие для СПО/ Л.В. Буренко, О.С. Тарасенко, Г.А. Краснощекова; под общ. ред. Г.А. Краснощековой. - М.: Издательство Юрайт, 2019. - 227с. - (Серия: Профессиональное образование). ISBN 978-5-9916-9261-8// Электронная библиотечная система Юрайт / http://www.biblio-online.ru/"
                    }),
                    new HashList<string>("2", new List<string>() {
                        "	Электронно-библиотечная система Znanium.com - Режим доступа: http://znanium.com",
                        "	Электронно-библиотечная система Юрайт http://www.biblio-online.ru/ - Режим доступа: http://www.biblio-online.ru/",
                        "	Сайт для изучающих английский язык, студентов, преподавателей и переводчиков - [Электронный ресурс] - Режим досутпа: http://study-english.info/"
                    })
                }
            )
        }
           
        };
    }
}
