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
        public HeaderHours(byte max, byte edu, byte self, byte prepare,
            byte lections, byte practice, byte labs, byte controls, byte courses)
        {
            MaxHours = max.ToString();
            EduHours = edu.ToString();
            SelfHours = self.ToString();
            PracticePrepare = prepare.ToString();
            Lections = lections.ToString();
            Practice = practice.ToString();
            LabWorks = labs.ToString();
            ControlWs = controls.ToString();
            CourseWs = courses.ToString();
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
