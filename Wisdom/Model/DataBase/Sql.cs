using System;
using System.Collections.Generic;
using System.Text;
using static Wisdom.Customing.Converters;

namespace Wisdom.Model.DataBase
{
    public abstract class Sql
    {
        public abstract void PassParameter(in string ParamName, in object newParam);

        public void PassParameters(Dictionary<string, object> parameters)
        {
            foreach (KeyValuePair<string, object> entry in parameters)
                PassParameter(entry.Key, entry.Value);
        }

        public abstract void OnlyExecute();

        public abstract void Procedure(in string name);

        public void ExecuteProcedure(string name)
        {
            Procedure(name);
            OnlyExecute();
        }

        public abstract List<object[]> ReadData();

        public abstract List<object> ReadData(in int column);

        public abstract List<object[]> ReadData(in byte StartValue, in byte EndValue);

        public abstract void ClearParameters();

        public List<object[]> GetRecords(string name)
        {
            Procedure(name);
            List<object[]> records = ReadData();
            ClearParameters();
            return records;
        }

        public List<object[]> GetRecords(string name, string paramName, object value)
        {
            Procedure(name);
            PassParameter(paramName, value);
            List<object[]> records = ReadData();
            ClearParameters();
            return records;
        }

        public List<object[]> GetRecords(string name, Dictionary<string, object> parameters)
        {
            Procedure(name);
            PassParameters(parameters);
            List<object[]> records = ReadData();
            ClearParameters();
            return records;
        }

        public List<object[]> ProfessionalCompetetion(ulong value)
        {
            return GetRecords("get_professional_competetion", "comp_id", value);
        }

        public List<object[]> SpecialitiesList()
        {
            return GetRecords("get_specialities_full");
        }

        public List<object[]> GeneralCompetetions(uint value)
        {
            return GetRecords("get_speciality_general", "speciality_id", value);
        }

        public List<object[]> ProfessionalCompetetions(uint value)
        {
            return GetRecords("get_speciality_professional", "speciality_id", value);
        }

        private List<HoursList<String2>> SetGeneral(List<object[]> generalCompetetions)
        {
            List<HoursList<String2>> competetions = new List<HoursList<String2>>();
            for (int i = 0; i < generalCompetetions.Count; i++)
            {
                competetions.Add(new HoursList<String2>("ОК " +
                    generalCompetetions[i][1], generalCompetetions[i][2].ToString()));

                competetions[i].Values.Add(
                    new String2("Умения",
                    generalCompetetions[i][4].ToString()));
                competetions[i].Values.Add(
                    new String2("Знания",
                    generalCompetetions[i][3].ToString()));
            }
            return competetions;
        }

        private List<List<HoursList<String2>>> SetProfessional(List<object[]> professionalCompetetions)
        {
            List<List<HoursList<String2>>> competetions = new List<List<HoursList<String2>>>();
            int no1 = 0;
            for (int i = 0; i < professionalCompetetions.Count; i++)
            {
                int current = Ints(professionalCompetetions[i][1]);
                if (no1 < current)
                {
                    competetions.Add(new List<HoursList<String2>>());
                    no1 = current;
                }
                int recount = no1 - 1;
                competetions[recount]
                    .Add(new HoursList<String2>("ПК " + professionalCompetetions[i][1] + "."
                    + professionalCompetetions[i][2].ToString(),
                    professionalCompetetions[i][3].ToString()));

                int recount2 = competetions[recount].Count - 1;
                competetions[recount][recount2].Values.Add(
                    new String2("Практический опыт", professionalCompetetions[i][6].ToString()));
                competetions[recount][recount2].Values.Add(
                    new String2("Умения", professionalCompetetions[i][5].ToString()));
                competetions[recount][recount2].Values.Add(
                    new String2("Знания", professionalCompetetions[i][4].ToString()));
            }
            return competetions;
        }

        public SpecialityBase GetSpeciality(uint id, string name)
        {
            SpecialityBase speciality = new SpecialityBase(name);
            List<object[]> generalCompetetions = GeneralCompetetions(id);
            List<object[]> professionalCompetetions = ProfessionalCompetetions(id);
            speciality.GeneralCompetetions.AddRange(SetGeneral(generalCompetetions));
            speciality.ProfessionalCompetetions.AddRange(SetProfessional(professionalCompetetions));
            return speciality;
        }

        public List<object[]> DisciplinesList()
        {
            return GetRecords("get_disciplines_full");
        }

        public List<object[]> DisciplinesList(uint value)
        {
            return GetRecords("get_speciality_disciplines", "speciality_id", value);
        }

        public List<object[]> TotalHours(uint value)
        {
            return GetRecords("get_discipline_total_hours", "discipline_id", value);
        }

        public List<object[]> ThemePlan(uint value)
        {
            return GetRecords("get_theme_plan_by_discipline", "discipline_id", value);
        }

        public List<object[]> Themes(uint value)
        {
            return GetRecords("get_themes_by_section", "section_id", value);
        }

        public List<object[]> Works(uint value)
        {
            return GetRecords("get_work_by_theme", "theme_id", value);
        }

        public List<object[]> WorkTypes()
        {
            return GetRecords("get_work_types");
        }

        public List<object[]> Tasks(ulong value)
        {
            return GetRecords("get_task_by_work", "work_id", value);
        }

        public List<object[]> MetaData(uint value)
        {
            return GetRecords("get_discipline_meta_data", "discipline_id", value);
        }

        public List<object[]> MetaTypes()
        {
            return GetRecords("get_meta_types");
        }

        public List<object[]> Sources(uint value)
        {
            return GetRecords("get_discipline_sources", "discipline_id", value);
        }

        public List<object[]> DisciplineGeneralMastering(uint value)
        {
            return GetRecords("get_discipline_general_mastering", "discipline_id", value);
        }

        public List<object[]> DisciplineProfessionalMastering(uint value)
        {
            return GetRecords("get_discipline_professional_mastering", "discipline_id", value);
        }

        public List<object[]> ThemeGeneralMastering(uint value)
        {
            return GetRecords("get_theme_general_mastering_selection", "theme_id", value);
        }

        public List<object[]> ThemeProfessionalMastering(uint value)
        {
            return GetRecords("get_theme_professional_mastering_selection", "theme_id", value);
        }

        private Dictionary<string, string> SetMetaData(List<object[]> metaData)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            for (int i = 0; i < metaData.Count; i++)
            {
                object[] row = metaData[i];
                data.Add(
                    row[1].ToString(),
                    row[2].ToString()
                );
            }
            return data;
        }

        private Dictionary<string, ushort> SetTotalHours(List<object[]> totalWorkHours)
        {
            Dictionary<string, ushort> totalHours = new Dictionary<string, ushort>();
            for (int i = 0; i < totalWorkHours.Count; i++)
            {
                object[] row = totalWorkHours[i];
                string key = row[1].ToString();
                ushort hours = UShorts(row[2]);
                if (totalHours.ContainsKey(key))
                    totalHours[key] = UShorts(totalHours[key] + hours);
                else
                    totalHours.Add(key, hours);
            }
            return totalHours;
        }

        private List<HashList<string>> SetSources(List<object[]> sourcesList)
        {
            List<HashList<string>> sources = new List<HashList<string>>();
            int no = 0;
            for (int i = 0; i < sourcesList.Count; i++)
            {
                object[] row = sourcesList[i];
                int current = Ints(row[2]);
                if (no < current)
                {
                    sources.Add(new HashList<string>(row[2].ToString()));
                    no = current;
                }
                sources[no - 1].Values.Add(row[1].ToString());
            }
            return sources;
        }

        private List<HoursList<LevelsList<HashList<String2>>>> SetThemePlan(List<object[]> themePlan)
        {
            List<HoursList<LevelsList<HashList<String2>>>> plan =
                new List<HoursList<LevelsList<HashList<String2>>>>();
            for (int i = 0; i < themePlan.Count; i++)
            {
                object[] row = themePlan[i];
                HoursList<LevelsList<HashList<String2>>> section =
                    new HoursList<LevelsList<HashList<String2>>>(
                    row[2].ToString(), row[3].ToString());

                uint topicId = UInts(row[0]);
                List<object[]> themes = Themes(topicId);
                List<LevelsList<HashList<String2>>> topicThemes = SetPlanThemes(themes);
                section.Values.AddRange(topicThemes);
                plan.Add(section);
            }
            return plan;
        }

        private List<LevelsList<HashList<String2>>> SetPlanThemes(List<object[]> themes)
        {
            List<LevelsList<HashList<String2>>> topicSpace =
                new List<LevelsList<HashList<String2>>>();
            for (int ii = 0; ii < themes.Count; ii++)
            {
                object[] row = themes[ii];
                uint themeId = UInts(row[0]);
                string competetions = GetCompetetions(themeId);

                LevelsList<HashList<String2>> theme = new
                LevelsList<HashList<String2>>(
                row[2].ToString(),
                row[3].ToString(), competetions,
                row[4].ToString());
                
                List<object[]> works = Works(themeId);
                List<HashList<String2>> themeWorks = SetPlanWorks(works);
                theme.Values.AddRange(themeWorks);
                topicSpace.Add(theme);
            }
            return topicSpace;
        }

        private string GetCompetetions(uint id)
        {
            string competetions = "";
            List<object[]> general = ThemeGeneralMastering(id);
            List<object[]> professional = ThemeProfessionalMastering(id);
            competetions += ConvertGeneral(general) + " "
                + ConvertProfessional(professional);
            return competetions;
        }

        private string GeneralFormat(uint bottom, uint top)
        { 
            return (bottom == top) ? " ОК " + bottom + "." :
                string.Format(" ОК {0:00}-{1:00}.", bottom, top);
        }

        private string ConvertGeneral(List<object[]> general)
        {
            string competetions = "";
            if (general.Count < 1)
                return competetions;
            object[] row = general[0];
            uint bottom = UInts(row[1]);
            uint top = UInts(row[1]);
            for (int i = 1; i < general.Count; i++)
            {
                row = general[i];
                uint next = UInts(row[1]);
                if (next - top >= 2)
                {
                    competetions += GeneralFormat(bottom, top);
                    bottom = next;
                    top = next;
                }
                else
                {
                    top = next;
                }
            }
            competetions += GeneralFormat(bottom, top);
            return competetions.Trim();
        }

        private string ProfessionalFormat(uint no, uint bottom, uint top)
        {
            return (bottom == top) ? " ПК " + bottom + "." :
                string.Format(" ПК {0:0}.{1:0}-{0:0}.{2:0}.", no, bottom, top);
        }

        private string ConvertProfessional(List<object[]> professional)
        {
            string competetions = "";
            if (professional.Count < 1)
                return competetions;
            object[] row = professional[0];
            uint no = UInts(row[2]);
            uint bottom = UInts(row[2]);
            uint top = UInts(row[2]);
            for (int i = 1; i < professional.Count; i++)
            {
                row = professional[i];
                uint nextNo = UInts(row[1]);
                uint next = UInts(row[2]);
                if (next - top >= 2 || nextNo != no)
                {
                    competetions += ProfessionalFormat(no, bottom, top);
                    no = nextNo;
                    bottom = next;
                    top = next;
                }
                else
                {
                    top = next;
                }
            }
            competetions += ProfessionalFormat(no, bottom, top);
            return competetions.Trim();
        }

        private List<HashList<String2>> SetPlanWorks(List<object[]> works)
        {
            List<HashList<String2>> themeSpace = new List<HashList<String2>>();
            for (int iii = 0; iii < works.Count; iii++)
            {
                object[] row = works[iii];
                HashList<String2> work = new
                HashList<String2>(row[1].ToString());

                uint workId = UInts(row[0]);
                List<object[]> tasks = Tasks(workId);
                List<String2> workTasks = SetPlanTasks(tasks);
                work.Values.AddRange(workTasks);
                themeSpace.Add(work);
            }
            return themeSpace;
        }

        private List<String2> SetPlanTasks(List<object[]> tasks)
        {
            List<String2> workSpace = new List<String2>();
            for (int iv = 0; iv < tasks.Count; iv++)
            {
                object[] row = tasks[iv];
                String2 task = new String2(
                    row[1].ToString(),
                    row[2].ToString());
                workSpace.Add(task);
            }
            return workSpace;
        }

        public DisciplineBase GetDiscipline(uint id, string name)
        {
            DisciplineBase discipline = new DisciplineBase(name);
            List<object[]> totalHours = TotalHours(id);
            List<object[]> metaData = MetaData(id);
            List<object[]> sources = Sources(id);
            List<object[]> themePlan = ThemePlan(id);
            List<object[]> generalCompetetions = DisciplineGeneralMastering(id);
            List<object[]> professionalCompetetions = DisciplineProfessionalMastering(id);
            discipline.MetaData = SetMetaData(metaData);
            discipline.TotalHours = SetTotalHours(totalHours);
            discipline.Sources = SetSources(sources);
            discipline.Plan = SetThemePlan(themePlan);
            discipline.GeneralCompetetions = SetGeneral(generalCompetetions);
            discipline.ProfessionalCompetetions = SetProfessional(professionalCompetetions);
            return discipline;
        }
    }
}
