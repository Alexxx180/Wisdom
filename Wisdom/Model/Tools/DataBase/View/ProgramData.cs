using System.Collections.Generic;
using System.Windows.Controls;
using static System.Convert;
using static Wisdom.Model.Tools.DataBase.Converters;

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
            return GetDiscipline(name, totalHours, metaData, SetThemePlan(themePlan),
                sources, generalCompetetions, professionalCompetetions);
        }

        public List<Pair<string, string>> MetaTypesData()
        {
            List<object[]> types = _dataBase.MetaTypes();
            return GetMetaTypes(types);
        }

        public List<Pair<string, string>> HourTypesData()
        {
            List<object[]> types = _dataBase.WorkTypes();
            return GetHourTypes(types);
        }

        public List<Pair<string, string>> SourceTypesData()
        {
            List<object[]> types = _dataBase.SourceTypes();
            return GetSourceTypes(types);
        }

        public List<Pair<string, string>> LevelsData()
        {
            List<object[]> levels = _dataBase.Levels();
            return SetPlanTasks(levels);
        }

        private static string GetCompetetions(uint id)
        {
            string competetions = "";
            List<object[]> general = _dataBase.ThemeGeneralMastering(id);
            List<object[]> professional = _dataBase.ThemeProfessionalMastering(id);
            competetions += ConvertGeneral(general) + " " + ConvertProfessional(professional);
            return competetions;
        }

        private static List<HoursList<LevelsList<HashList<Pair<string, string>>>>> SetThemePlan(List<object[]> themePlan)
        {
            List<HoursList<LevelsList<HashList<Pair<string, string>>>>> plan =
                new List<HoursList<LevelsList<HashList<Pair<string, string>>>>>();
            for (int i = 0; i < themePlan.Count; i++)
            {
                object[] row = themePlan[i];
                HoursList<LevelsList<HashList<Pair<string, string>>>> section =
                    new HoursList<LevelsList<HashList<Pair<string, string>>>>(
                    row[2].ToString(), row[3].ToString());

                uint topicId = ToUInt32(row[0]);
                List<object[]> themes = _dataBase.Themes(topicId);
                List<LevelsList<HashList<Pair<string, string>>>> topicThemes = SetPlanThemes(themes);
                section.Values.AddRange(topicThemes);
                plan.Add(section);
            }
            return plan;
        }

        private static List<LevelsList<HashList<Pair<string, string>>>> SetPlanThemes(List<object[]> themes)
        {
            List<LevelsList<HashList<Pair<string, string>>>> topicSpace =
                new List<LevelsList<HashList<Pair<string, string>>>>();
            for (int ii = 0; ii < themes.Count; ii++)
            {
                object[] row = themes[ii];
                uint themeId = ToUInt32(row[0]);
                string competetions = GetCompetetions(themeId);

                LevelsList<HashList<Pair<string, string>>> theme = new
                LevelsList<HashList<Pair<string, string>>>(
                row[2].ToString(),
                row[3].ToString(), competetions,
                row[4].ToString());

                List<object[]> works = _dataBase.Works(themeId);
                List<HashList<Pair<string, string>>> themeWorks = SetPlanWorks(works);
                theme.Values.AddRange(themeWorks);
                topicSpace.Add(theme);
            }
            return topicSpace;
        }

        private static List<HashList<Pair<string, string>>> SetPlanWorks(List<object[]> works)
        {

            List<HashList<Pair<string, string>>> themeSpace = new List<HashList<Pair<string, string>>>();
            for (int iii = 0; iii < works.Count; iii++)
            {
                object[] row = works[iii];
                HashList<Pair<string, string>> work = new
                HashList<Pair<string, string>>(row[1].ToString());

                uint workId = ToUInt32(row[0]);
                List<object[]> tasks = _dataBase.Tasks(workId);
                List<Pair<string, string>> workTasks = SetPlanTasks(tasks);
                work.Values.AddRange(workTasks);
                themeSpace.Add(work);
            }
            return themeSpace;
        }

        private static List<Pair<string, string>> SetPlanTasks(List<object[]> tasks)
        {
            List<Pair<string, string>> workSpace = new List<Pair<string, string>>();
            for (int iv = 0; iv < tasks.Count; iv++)
            {
                object[] row = tasks[iv];
                string name = row[1].ToString();
                string hours = row[2].ToString();
                Pair<string, string> task = new Pair<string, string>(name, hours);
                workSpace.Add(task);
            }
            return workSpace;
        }

        private static IDataViewer _dataBase;
    }
}