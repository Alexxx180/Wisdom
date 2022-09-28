using System.Collections.Generic;
using ControlMaterials;
using ControlMaterials.Tables.ThemePlan;
using ControlMaterials.Tables;
using Wisdom.Customing;
using static Wisdom.Model.Tools.DataBase.Converters;
using ControlMaterials.Tables.Tasks;

namespace Wisdom.Model.Tools.DataBase
{
    public class ProgramData
    {
        public ProgramData(Sql connector)
        {
            _dataBase = connector;
        }

        public Pair<List<uint>, List<string>> ListSpecialities()
        {
            List<object[]> specialities = _dataBase.SpecialitiesList();
            return GetSpecialitySelect(specialities);
        }

        public Pair<List<uint>, List<string>> ListDisciplines(uint specialityId)
        {
            List<object[]> disciplines = _dataBase.DisciplinesList(specialityId);
            return GetDisciplineSelect(disciplines);
        }

        public SpecialityBase SpecialityData(uint id, string name)
        {
            List<object[]> generalCompetetions = _dataBase.GeneralCompetetions(id);
            List<object[]> professionalCompetetions = _dataBase.ProfessionalCompetetions(id);
            return GetSpeciality(name, generalCompetetions, professionalCompetetions);
        }

        public DisciplineBase DisciplineData(uint id, string name)
        {
            List<object[]> totalHours = _dataBase.TotalHours(id);
            List<object[]> metaData = _dataBase.MetaData(id);
            List<object[]> sources = _dataBase.Sources(id);
            List<object[]> themePlan = _dataBase.ThemePlan(id);
            List<object[]> generalCompetetions = _dataBase.DisciplineGeneralMastering(id);
            List<object[]> professionalCompetetions = _dataBase.DisciplineProfessionalMastering(id);
            return GetDiscipline(name, totalHours, metaData, GetThemePlan(themePlan),
                sources, generalCompetetions, professionalCompetetions);
        }

        public List<string> MetaTypesData()
        {
            List<object[]> types = _dataBase.MetaTypes();
            return GetSingle(types);
        }

        public List<string> WorkTypesData()
        {
            List<object[]> types = _dataBase.WorkTypes();
            return GetSingle(types);
        }

        public List<string> SourceTypesData()
        {
            List<object[]> types = _dataBase.SourceTypes();
            return GetSingle(types);
        }

        public List<Task> LevelsData()
        {
            List<object[]> levels = _dataBase.Levels();
            return GetTasks(levels);
        }

        private static string GetCompetetions(uint id)
        {
            string competetions = "";
            List<object[]> general = _dataBase.ThemeGeneralMastering(id);
            List<object[]> professional = _dataBase.ThemeProfessionalMastering(id);
            competetions += ConvertGeneral(general) + " " + ConvertProfessional(professional);
            return competetions;
        }

        private static List<HoursNode<Theme>> GetThemePlan(List<object[]> themePlan)
        {
            List<HoursNode<Theme>> plan = new List<HoursNode<Theme>>();
            for (int i = 0; i < themePlan.Count; i++)
            {
                object[] row = themePlan[i];

                uint topicId = row[0].ToUInt();
                List<object[]> themesData = _dataBase.Themes(topicId);
                List<Theme> themes = GetThemes(themesData);

                HoursNode<Theme> topic = new HoursNode<Theme>(new Theme())
                {
                    Name = row[2].ToString(),
                    //Hours = row[3].ToString(),
                    //Themes = themes
                };

                plan.Add(topic);
            }
            return plan;
        }

        private static List<Theme> GetThemes(List<object[]> themes)
        {
            List<Theme> group = new List<Theme>();
            for (int ii = 0; ii < themes.Count; ii++)
            {
                object[] row = themes[ii];

                uint themeId = row[0].ToUInt();
                List<object[]> worksData = _dataBase.Works(themeId);
                List<Work> works = GetWorks(worksData);

                string competetions = GetCompetetions(themeId);
                Theme theme = new Theme
                {
                    Name = row[2].ToString(),
                    //Hours = row[3].ToString(),
                    //Level = row[4].ToString(),
                    //Competetions = competetions,
                    //Works = works
                };

                group.Add(theme);
            }
            return group;
        }

        private static List<Work> GetWorks(List<object[]> works)
        {
            List<Work> group = new List<Work>();
            for (int iii = 0; iii < works.Count; iii++)
            {
                //object[] row = works[iii];

                //uint workId = row[0].ToUInt();
                //List<object[]> tasksData = _dataBase.Tasks(workId);
                //List<Task> tasks = GetTasks(tasksData);

                //Work work = new Work(row[1].ToString(), tasks);

                //group.Add(work);
            }
            return group;
        }

        private static List<Task> GetTasks(List<object[]> tasks)
        {
            List<Task> group = new List<Task>();
            for (int iv = 0; iv < tasks.Count; iv++)
            {
                object[] row = tasks[iv];

                string name = row[1].ToString();
                string hours = row[2].ToString();
                Task task = new Task(name, hours);

                group.Add(task);
            }
            return group;
        }

        private static List<string> GetSingle(List<object[]> tasks)
        {
            List<string> workSpace = new List<string>();
            for (int iv = 0; iv < tasks.Count; iv++)
            {
                object[] row = tasks[iv];
                workSpace.Add(row[1].ToString());
            }
            return workSpace;
        }

        private static IDataViewer _dataBase;
    }
}