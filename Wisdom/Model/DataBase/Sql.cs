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

        public SpecialityBase GetSpeciality(uint id, string name)
        {
            SpecialityBase speciality = new SpecialityBase(name);
            List<object[]> generalCompetetions = GeneralCompetetions(id);
            List<object[]> professionalCompetetions = ProfessionalCompetetions(id);
            for (int i = 0; i < generalCompetetions.Count; i++)
            {
                speciality.GeneralCompetetions.Add(new HoursList<String2>("ОК " +
                    generalCompetetions[i][1], generalCompetetions[i][2].ToString()));

                speciality.GeneralCompetetions[i].Values.Add(
                    new String2("Умения", generalCompetetions[i][4].ToString()));
                speciality.GeneralCompetetions[i].Values.Add(
                    new String2("Знания", generalCompetetions[i][3].ToString()));
            }
            int no1 = 0;
            for (int i = 0; i < professionalCompetetions.Count; i++)
            {
                int current = Ints(professionalCompetetions[i][1]);
                if (no1 < current)
                {
                    speciality.ProfessionalCompetetions.Add(new List<HoursList<String2>>());
                    no1 = current;
                }
                int recount = no1 - 1;
                speciality.ProfessionalCompetetions[recount]
                    .Add(new HoursList<String2>("ПК " + professionalCompetetions[i][1] + "."
                    + professionalCompetetions[i][2].ToString(),
                    professionalCompetetions[i][3].ToString()));

                int recount2 = speciality.ProfessionalCompetetions[recount].Count - 1;
                speciality.ProfessionalCompetetions[recount][recount2].Values.Add(
                    new String2("Практический опыт", professionalCompetetions[i][6].ToString()));
                speciality.ProfessionalCompetetions[recount][recount2].Values.Add(
                    new String2("Умения", professionalCompetetions[i][5].ToString()));
                speciality.ProfessionalCompetetions[recount][recount2].Values.Add(
                    new String2("Знания", professionalCompetetions[i][4].ToString()));
            }
            return speciality;
        }

        public List<object[]> DisciplinesList()
        {
            return GetRecords("get_disciplines_full");
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

        public List<object[]> Tasks(ulong value)
        {
            return GetRecords("get_task_by_work", "work_id", value);
        }

        public List<object[]> MetaData(uint value)
        {
            return GetRecords("get_discipline_meta_data", "discipline_id", value);
        }

        public List<object[]> Sources(uint value)
        {
            return GetRecords("get_discipline_sources", "discipline_id", value);
        }

        public DisciplineBase GetDiscipline(uint id, string name)
        {
            DisciplineBase discipline = new DisciplineBase(name);
            List<object[]> totalHours = TotalHours(id);
            List<object[]> metaData = MetaData(id);
            List<object[]> sources = Sources(id);

            for (int i = 0; i < metaData.Count; i++)
            {
                discipline.MetaData.Add(new String2(
                    metaData[i][1].ToString(),
                    metaData[i][2].ToString()));
            }
            int no = 0;
            for (int i = 0; i < sources.Count; i++)
            {
                int current = Ints(sources[i][2]);
                if (no < current)
                {
                    discipline.Sources.Add(new HashList<string>(sources[i][2].ToString()));
                    no = current;
                }
                discipline.Sources[no - 1].Values.Add(sources[i][1].ToString());
            }
            for (int i = 0; i < totalHours.Count; i++)
            {
                discipline.TotalHours.Add(
                    totalHours[i][1].ToString(),
                    UShorts(totalHours[i][2]));
            }


            List<object[]> themePlan = ThemePlan(id);
            for (int i = 0; i < themePlan.Count; i++)
            {
                HoursList<LevelsList<HashList<String2>>> section = new
                    HoursList<LevelsList<HashList<String2>>>(
                    themePlan[i][2].ToString(), themePlan[i][3].ToString());

                List<object[]> themes = Themes(UInts(themePlan[i][0]));
                for (int ii = 0; ii < themes.Count; ii++)
                {
                    LevelsList<HashList<String2>> theme = new
                    LevelsList<HashList<String2>>(
                    themes[ii][2].ToString(), themes[ii][3].ToString(), "",
                    themes[ii][4].ToString());

                    List<object[]> works = Works(UInts(themes[ii][0]));
                    for (int iii = 0; iii < works.Count; iii++)
                    {
                        HashList<String2> work = new
                        HashList<String2>(works[iii][1].ToString());

                        List<object[]> tasks = Tasks(UInts(works[iii][0]));
                        for (int iv = 0; iv < tasks.Count; iv++)
                        {
                            String2 task = new String2(
                                tasks[iv][1].ToString(),
                                tasks[iv][2].ToString());
                            work.Values.Add(task);
                        }
                        theme.Values.Add(work);
                    }
                    section.Values.Add(theme);
                }
                discipline.Plan.Add(section);
            }

            return discipline;
        }
    }
}
