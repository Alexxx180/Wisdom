using System;
using System.Collections.Generic;
using System.Text;

namespace Wisdom.Model
{
    public static class ProgramContent
    {
        //Form 1
        public static string DisciplineName = "";
        public static string ProfessionName = "";

        public static string MaxHours = "-";
        public static string EduHours = "-";
        public static string SelfHours = "-";

        //Form 2
        public static string Lections = "-";
        public static string Practice = "-";
        public static string LabWorks = "-";
        public static string ControlWs = "-";
        public static string CourseWs = "-";

        public static List<string> ShallKnow = new List<string>();
        public static List<string> ShallCan = new List<string>();
        public static List<string> TotalCompetetion = new List<string>();

        //Form 3

        //Сложная система вложенностей:
        //Разделы -> Темы -> Типы работ
        public static List<HashList<HashList<string>>> Plan = new List<HashList<HashList<string>>>();

        public static StringList StudyLevels = new StringList(" (", ")");

        //Form 4
        public static List<string> EducationControl = new List<string>();
        public static List<string> MarkControl = new List<string>();
        public static List<HashList<string>> SourcesControl = new List<HashList<string>>();

        //Form 5
        public static List<string> Applyment = new List<string>();
    }
}
