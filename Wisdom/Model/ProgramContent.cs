﻿using System.Collections.Generic;

namespace Wisdom.Model
{

    public static class ProgramContent
    {
        //Form 1
        //Названия дисциплины/специальности
        public static string DisciplineName = "";
        public static string ProfessionName = "";

        //Общие часы
        public static string MaxHours = "-";
        public static string EduHours = "-";
        public static string SelfHours = "-";

        //Form 2
        //Часы по типам работ
        public static string Lections = "-";
        public static string Practice = "-";
        public static string LabWorks = "-";
        public static string ControlWs = "-";
        public static string CourseWs = "-";

        //Компетенции
        /*
         Вопрос такого плана:
            Нужно ли делать для компетенций что-то наподобие
         Компетенция - знания и умения или там по-другому надо
         */
        public static List<string> ShallKnow = new List<string>();
        public static List<string> ShallCan = new List<string>();
        public static List<string> TotalCompetetion = new List<string>();

        //Классы
        //HoursList — содержит название раздела/темы, часы/уровень освоения, список тем/типов работ
        //HashList — содержит название типа работ, список из имени под темы и отводимых часов
        //String2 — класс «двойной строки», хранящий имя под темы и отводимые ей часы

        //Form 3
        // «Сложная» система вложенностей:
        //Разделы -> Темы -> Типы работ
        //public static List< HoursList< HoursList< HashList<String2> > >
        public static List<HoursList<HoursList<HashList<String2>>>>
            Plan = new List<HoursList<HoursList<HashList<String2>>>>();
        //Уровни освоения (ныне уровни компетенций)
        public static StringList StudyLevels = new StringList(" (", ")");
        //Form 4
        public static List<string> EducationControl = new List<string>();
        public static List<string> MarkControl = new List<string>();
        public static List<HashList<string>> SourcesControl = new List<HashList<string>>();
        //Form 5
        //Приложение (доп. вопросы к экзаменам/д. зачетам)
        public static List<string> Applyment = new List<string>();
    }
}
