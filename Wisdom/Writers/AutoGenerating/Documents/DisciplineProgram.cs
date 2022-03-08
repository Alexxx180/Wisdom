using System.Collections.Generic;
using DocumentFormat.OpenXml.Wordprocessing;
using Wisdom.Model;
using Wisdom.Model.Tables.ThemePlan;
using Wisdom.Model.Tables;
using static Wisdom.Writers.AutoGenerating.AutoFiller;
using static Wisdom.Writers.Markup.DisciplineProgramMarkup;

namespace Wisdom.Writers.AutoGenerating.Documents
{
    public class DisciplineProgram : EducationalProgram<Model.Documents.DisciplineProgram>
    {
        public static readonly string ProgramPreferences = "DisciplineProgram.json";

        public DisciplineProgram(Controls.Forms.DocumentForms.AddDisciplineProgram.Settings presets)
        {
            Processing = presets ?? new Controls.Forms.DocumentForms.AddDisciplineProgram.Settings();
        }

        public Controls.Forms.DocumentForms.AddDisciplineProgram.Settings Processing { get; set; }

        public static readonly Pair<string, string>[]
            Expressions = new Pair<string, string>[]
            {
                new Pair<string, string>("Название дисциплины", "#DISCIPLINE"),
                new Pair<string, string>("Название специальности", "#SPECIALITY"),
                new Pair<string, string>("Максимальная нагрузка", "#MAX-HOURS"),
                new Pair<string, string>("Аудиторная нагрузка", "#AUD-HOURS"),
                new Pair<string, string>("Метаданные (Группа)", "#META-"),
                new Pair<string, string>("Общие часы (Группа)", "#HOURS-")
            };

        public static string MetaData(Task task)
        {
            return task.Hours;
        }

        public static string Hours(Hour hour)
        {
            return hour.Count.ToString();
        }

        protected override void FastProcessing(
            IEnumerable<Paragraph> paragraphs,
            IEnumerable<TableCell> cells,
            Model.Documents.DisciplineProgram program
            )
        {
            Dictionary<string, int> options = Processing.Options;

            string discipline = Expressions[0].Value;
            CustomizeableProcessing(paragraphs, cells,
                options[discipline], discipline, program.Name);

            string speciality = Expressions[1].Value;
            CustomizeableProcessing(paragraphs, cells,
                options[speciality], speciality, program.ProfessionName);

            string max = Expressions[2].Value;
            CustomizeableProcessing(paragraphs, cells,
                options[max], max, program.MaxHours);

            string auditory = Expressions[3].Value;
            CustomizeableProcessing(paragraphs, cells,
                options[auditory], auditory, program.EduHours);

            string meta = Expressions[4].Value;
            CustomizeableProcessing(paragraphs, cells,
                options[meta], meta, program.MetaData, MetaData);

            string hours = Expressions[5].Value;
            CustomizeableProcessing(paragraphs, cells,
                options[hours], hours, program.Hours, Hours);
        }

        protected override void DetailProcessing(
            IEnumerable<Paragraph> paragraphs,
            Model.Documents.DisciplineProgram program)
        {
            string competetions = "#COMPETETIONS";
            ReplaceInParagraphs(paragraphs, competetions, CompetetionsTable(program));

            string themePlan = "#THEME-PLAN";
            ReplaceInParagraphs(paragraphs, themePlan, ThemePlanTable(program));

            string sources = "#SOURCES";
            ReplaceInParagraphs(paragraphs, sources, Literature(program.Sources));
        }
    }
}