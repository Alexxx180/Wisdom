using DocumentFormat.OpenXml.Wordprocessing;
using System.Collections.Generic;
using Wisdom.Model.Documents;
using Wisdom.Model.Tables;
using Wisdom.Model.Tables.ThemePlan;
using Wisdom.Customing;
using static Wisdom.Writers.Markup.Decorators;

namespace Wisdom.Writers.Markup
{
    public static class DisciplineProgramMarkup
    {
        private static readonly ushort[] ThemePlanSizes = { 2235, 425, 3544, 992, 1559, 992 };
        private static readonly ushort[] CompetetionSizes = { 1565, 3298, 4482 };

        private static readonly ushort PlanMerged1to2 = (ThemePlanSizes[1] + ThemePlanSizes[2]).ToUShort();
        private static readonly ushort PlanMerged0to2 = (ThemePlanSizes[0] + PlanMerged1to2).ToUShort();

        public static List<Paragraph> Literature(List<Source> sources)
        {
            List<Paragraph> proccessedSources = new List<Paragraph>();
            for (byte i = 0; i < sources.Count; i++)
            {
                Source source = sources[i];
                List<Paragraph> paragraphs = NumberList
                    (source.Descriptions, ". ");

                Run chunk = RunBase(source.Name, Bold());
                Paragraph header = ParagraphBase(Both(), chunk);

                proccessedSources.Add(header);
                proccessedSources.AddRange(paragraphs);
            }
            return proccessedSources;
        }

        #region Competetions Members
        public static List<TableRow> CompetetionsTableRows(DisciplineProgram program)
        {
            List<TableRow> rows = new List<TableRow>();

            List<Competetion>
                generalCompetetions = program.GeneralCompetetions;
            for (byte i = 0; i < program.GeneralCompetetions.Count; i++)
            {
                Competetion general = generalCompetetions[i];
                List<TableRow> row = CompetetionBase(
                    general.PrefixNo,
                    general.Name,
                    general.Abilities
                    );
                rows.AddRange(row);
            }

            List<List<Competetion>>
                professionalCompetetions = program.ProfessionalCompetetions;
            for (byte i = 0; i < program.ProfessionalCompetetions.Count; i++)
            {
                List<Competetion> professionalGroup = professionalCompetetions[i];
                for (byte ii = 0; ii < professionalGroup.Count; ii++)
                {
                    Competetion professional = professionalGroup[ii];
                    List<TableRow> row = CompetetionBase(
                        professional.PrefixNo,
                        professional.Name,
                        professional.Abilities
                        );
                    rows.AddRange(row);
                }
            }

            return rows;
        }

        public static Table CompetetionsTable(DisciplineProgram program)
        {
            string[] columns = {
                "Код компетенции",
                "Формулировка компетенции",
                "Знания, умения, практический опыт"
            };

            Table table3 = TablePreset(CompetetionSizes, AutoTableWidth());

            TableRow tableRow23 = TableRowBase(CustomizeableSection(
                SectionBase(Center(), RunBase(columns[0]), CompetetionSizes[0]),
                SectionBase(Center(), RunBase(columns[1]), CompetetionSizes[1]),
                SectionBase(Center(), RunBase(columns[2]), CompetetionSizes[2])
                ));

            table3.Append(tableRow23);
            table3.Append(CompetetionsTableRows(program));

            return table3;
        }

        public static List<TableRow> CompetetionBase(string id, string name, List<Task> skills)
        {
            List<TableRow> rows = new List<TableRow>();

            List<Paragraph> skillsParagraphs = new List<Paragraph>();
            for (byte i = 0; i < skills.Count; i++)
            {
                Task skill = skills[i];

                Run skillsName = RunBase(skill.Name + " ", Bold());
                Run description = RunBase(skill.Hours);

                skillsParagraphs.Add(ParagraphBase(Left(), skillsName, description));
            }

            TableCell[] cells = CompetetionsTemplate(
                ParagraphBase(Left(), RunBase(id)),
                ParagraphBase(Left(), RunBase(name)),
                skillsParagraphs[0], MergeRestart(),
                MergeRestart());

            TableRow tableRow = TableRowBase(cells);

            rows.Add(tableRow);

            for (byte i = 1; i < skillsParagraphs.Count; i++)
            {
                TableCell[] cells3 =
                    CompetetionsTemplate(ParagraphBase(Left()),
                    ParagraphBase(Left()), skillsParagraphs[i],
                    new VerticalMerge(), new VerticalMerge());

                TableRow tableRow2 = TableRowBase(cells3);
                rows.Add(tableRow2);
            }
            return rows;
        }

        private static TableCell[] CompetetionsTemplate(
            Paragraph cell1, Paragraph cell2, Paragraph cell3,
            VerticalMerge merge, VerticalMerge merge2)
        {
            return new TableCell[] {
                TableCellBase(cell1, CompetetionSizes[0], merge),
                TableCellBase(cell2, CompetetionSizes[1], merge2),
                TableCellBase(cell3, CompetetionSizes[2]),
            };
        }
        #endregion

        #region ThemePlan Members
        public static List<TableRow> PlanTableRows(DisciplineProgram program)
        {
            List<TableRow> rows = new List<TableRow>();

            List<Topic> topics = program.Plan;
            for (byte i = 0; i < topics.Count; i++)
            {
                Topic topic = topics[i];

                string topicHeader = $"Раздел {i + 1}. {topic.Name}";
                rows.Add(Topic(topicHeader, topic.Hours));

                List<Theme> themes = topic.Themes;
                for (byte ii = 0; ii < themes.Count; ii++)
                {
                    Theme theme = themes[ii];

                    string themeHeader = $"Тема {i + 1}.{ii + 1}. {theme.Name}";
                    rows.AddRange(Theme(themeHeader, theme.Hours,
                        theme.Competetions, theme.Level, theme.Works));
                }
            }

            return rows;
        }

        public static TableCell[] ThemePlanTop(string no,
            string name, string hours, string learned, string levels)
        {
            return CustomizeableSection(
                SectionBase(Center(), RunBase(no), ThemePlanSizes[0]),
                SectionBase(Center(), RunBase(name), PlanMerged1to2, GridSpan(2)),
                SectionBase(Center(), RunBase(hours), ThemePlanSizes[3]),
                SectionBase(Center(), RunBase(learned), ThemePlanSizes[4]),
                SectionBase(Center(), RunBase(levels), ThemePlanSizes[5])
                );
        }

        public static TableCell[] ThemePlanBottom(Justification justify, Run text)
        {
            return CustomizeableSection(
                SectionBase(justify, text, PlanMerged0to2, GridSpan(3)),
                SectionBase(Center(), RunBase("*"), ThemePlanSizes[3]),
                SectionBase(Center(), RunBase(), ThemePlanSizes[4]),
                SectionBase(Center(), RunBase(), ThemePlanSizes[5])
                );
        }

        public static Table ThemePlanTable(DisciplineProgram program)
        {
            string[] columns = {
                "Наименование разделов и тем",
                "Содержание учебного материала, лабораторные работы и практические занятия, самостоятельная работа обучающихся, курсовая работа (проект)",
                "Количество часов",
                "Коды компетенций, формированию которых способствует элемент программы",
                "Уровни освоения"
            };
            
            string width = ThemePlanSizes.Sum().ToString();
            Table table5 = TablePreset(ThemePlanSizes,
                TableWidth(width), FixedLayout());

            TableRow top1 = TableRowBase(ThemePlanTop(columns[0],
                columns[1], columns[2], columns[3], columns[4]));

            TableRow top2 = TableRowBase
                (ThemePlanTop("1", "2", "3", "4", "5"));

            string work1 = "Примерная тематика курсовой работы (проекта)";
            TableRow bottom1 = TableRowBase(ThemePlanBottom(Left(), RunBase(work1)));

            string work2 = "Самостоятельная работа обучающихся над курсовой работой (проектом)";
            TableRow bottom2 = TableRowBase(ThemePlanBottom(Left(), RunBase(work2)));

            TableRow bottom3 = TableRowBase(ThemePlanBottom(Right(), RunBase("Всего:", Bold())));

            table5.Append(top1);
            table5.Append(top2);
            table5.Append(PlanTableRows(program));
            table5.Append(bottom1);
            table5.Append(bottom2);
            table5.Append(bottom3);

            return table5;
        }

        public static TableRow Topic(string title, string hours)
        {
            return TableRowBase(CustomizeableSection(
                SectionBase(Left(), RunBase(title, Bold()), ThemePlanSizes[0]),
                SectionBase(Center(), RunBase(), PlanMerged1to2, GridSpan(2)),
                SectionBase(Center(), RunBase(), ThemePlanSizes[3]),
                SectionBase(Center(), RunBase(hours), ThemePlanSizes[4]),
                SectionBase(Center(), RunBase(), ThemePlanSizes[5])
                ));
        }

        public static List<TableRow> Theme(string title, string hours,
            string competetions, string level, List<Work> data)
        {
            List<TableRow> themeContents = new List<TableRow>();

            TableCell[] columns =
                ThemeTemplate(RunBase(title, Bold()),
                RunBase(data[0].Type), RunBase(hours),
                RunBase(competetions), RunBase(level));

            TableRow headerRow = TableRowBase(columns);

            themeContents.Add(headerRow);
            List<Task> startTasks = data[0].Tasks;
            for (byte ii = 0; ii < startTasks.Count; ii++)
            {
                Task task = startTasks[ii];
                themeContents.Add(ThemeContentFew(
                    ii + 1, task.Name, task.Hours));
            }

            for (ushort i = 1; i < data.Count; i++)
            {
                Work work = data[i];
                List<Task> tasks = work.Tasks;
                if (tasks.Count <= 1)
                {
                    Task task = tasks[0];
                    themeContents.Add(ThemeContentSingle
                        ($"{work.Type} {task.Name}", task.Hours));
                    continue;
                }

                TableCell[] cells = ThemeTemplate(
                    RunBase(), RunBase(work.Type, Bold()),
                    RunBase(), RunBase(), RunBase());

                TableRow subHeaderRow = TableRowBase(cells);

                themeContents.Add(subHeaderRow);
                for (byte ii = 0; ii < tasks.Count; ii++)
                {
                    Task task = tasks[ii];
                    themeContents.Add(ThemeContentFew(
                        ii + 1, task.Name, task.Hours));
                }
            }

            return themeContents;
        }

        private static TableRow ThemeContentSingle(string name, string hours)
        {
            return TableRowBase(ThemeTemplate(RunBase(),
                RunBase(name), RunBase(hours), RunBase(), RunBase()));
        }

        private static TableRow ThemeContentFew(int no, string name, string hours)
        {
            return TableRowBase(CustomizeableSection(
                SectionBase(Center(), RunBase(), ThemePlanSizes[0]),
                SectionBase(Center(), RunBase(no.ToString()), ThemePlanSizes[1]),
                SectionBase(Both(), RunBase(name), ThemePlanSizes[2]),
                SectionBase(Center(), RunBase(hours), ThemePlanSizes[3]),
                SectionBase(Center(), RunBase(), ThemePlanSizes[4]),
                SectionBase(Center(), RunBase(), ThemePlanSizes[5])
                ));
        }

        private static TableCell[] ThemeTemplate(Run no, Run name,
            Run hours, Run competetions, Run level)
        {
            return CustomizeableSection(
                SectionBase(Center(), no, ThemePlanSizes[0]),
                SectionBase(Both(), name, PlanMerged1to2, GridSpan(2)),
                SectionBase(Center(), hours, ThemePlanSizes[3]),
                SectionBase(Center(), competetions, ThemePlanSizes[4]),
                SectionBase(Center(), level, ThemePlanSizes[5])
                );
        }
        #endregion
    }
}