namespace Wisdom.Model
{
    public class HeaderHours
    {
        public HeaderHours()
        {
            MaxHours = "-";
            EduHours = "-";
            SelfHours = "-";
            PracticePrepare = "-";
            Lections = "-";
            Practice = "-";
            LabWorks = "-";
            ControlWs = "-";
            CourseWs = "-";
        }
        public HeaderHours(string max, string edu, string self, string prepare,
            string lections, string practice, string labs, string controls, string courses)
        {
            MaxHours = max;
            EduHours = edu;
            SelfHours = self;
            PracticePrepare = prepare;
            Lections = lections;
            Practice = practice;
            LabWorks = labs;
            ControlWs = controls;
            CourseWs = courses;
        }
        // Общие часы
        public string MaxHours { get; set; }
        public string EduHours { get; set; }
        public string SelfHours { get; set; }

        // Form 2
        // Часы по типам работ
        public string PracticePrepare { get; set; }
        public string Lections { get; set; }
        public string Practice { get; set; }
        public string LabWorks  { get; set; }
        public string ControlWs  { get; set; }
        public string CourseWs  { get; set; }
    }
}
