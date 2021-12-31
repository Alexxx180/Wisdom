using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using static Wisdom.Customing.Converters;
using static Wisdom.Model.ProgramContent;

namespace Wisdom.Model.DataBase
{
    public static class Converters
    {
        public static void Connect(Sql connector)
        {
            _dataBase = connector;
        }

        private static string GeneralFormat(uint bottom, uint top)
        {
            return (bottom == top) ? " ОК " + bottom + "." :
                string.Format(" ОК {0:00}-{1:00}.", bottom, top);
        }

        private static string ProfessionalFormat(uint no, uint bottom, uint top)
        {
            return (bottom == top) ? " ПК " + bottom + "." :
                string.Format(" ПК {0:0}.{1:0}-{0:0}.{2:0}.", no, bottom, top);
        }

        private static string ConvertGeneral(List<object[]> general)
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

        private static string ConvertProfessional(List<object[]> professional)
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

        private static string GetCompetetions(uint id)
        {
            string competetions = "";
            List<object[]> general = _dataBase.ThemeGeneralMastering(id);
            List<object[]> professional = _dataBase.ThemeProfessionalMastering(id);
            competetions += ConvertGeneral(general) + " "
                + ConvertProfessional(professional);
            return competetions;
        }

        private static List<HoursList<LevelsList<HashList<String2>>>> SetThemePlan(List<object[]> themePlan)
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
                List<object[]> themes = _dataBase.Themes(topicId);
                List<LevelsList<HashList<String2>>> topicThemes = SetPlanThemes(themes);
                section.Values.AddRange(topicThemes);
                plan.Add(section);
            }
            return plan;
        }

        private static List<LevelsList<HashList<String2>>> SetPlanThemes(List<object[]> themes)
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

                List<object[]> works = _dataBase.Works(themeId);
                List<HashList<String2>> themeWorks = SetPlanWorks(works);
                theme.Values.AddRange(themeWorks);
                topicSpace.Add(theme);
            }
            return topicSpace;
        }

        private static List<HashList<String2>> SetPlanWorks(List<object[]> works)
        {
            
            List<HashList<String2>> themeSpace = new List<HashList<String2>>();
            for (int iii = 0; iii < works.Count; iii++)
            {
                object[] row = works[iii];
                HashList<String2> work = new
                HashList<String2>(row[1].ToString());

                uint workId = UInts(row[0]);
                List<object[]> tasks = _dataBase.Tasks(workId);
                List<String2> workTasks = SetPlanTasks(tasks);
                work.Values.AddRange(workTasks);
                themeSpace.Add(work);
            }
            return themeSpace;
        }

        private static List<String2> SetPlanTasks(List<object[]> tasks)
        {
            List<String2> workSpace = new List<String2>();
            for (int iv = 0; iv < tasks.Count; iv++)
            {
                object[] row = tasks[iv];
                string name = row[1].ToString();
                string hours = row[2].ToString();
                String2 task = new String2(name, hours);
                workSpace.Add(task);
            }
            return workSpace;
        }

        private static List<String2> SetTypeFields(List<object[]> types)
        {
            List<String2> fields = new List<String2>();
            for (byte i = 0; i < types.Count; i++)
            {
                object[] row = types[i];
                string id = row[0].ToString();
                string name = row[1].ToString();
                String2 type = new String2(id, name);
                fields.Add(type);
            }       
            return fields;
        }

        public static Dictionary<string, string> SetMetaData(List<object[]> metaData)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            for (int i = 0; i < metaData.Count; i++)
            {
                object[] row = metaData[i];
                string type = row[1].ToString();
                string value = row[2].ToString();
                data.Add(type, value);
            }
            return data;
        }

        private static Dictionary<string, ushort> SetTotalHours(List<object[]> totalWorkHours)
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

        private static List<HashList<string>> SetSources(List<object[]> sourcesList)
        {
            List<HashList<string>> sources = new List<HashList<string>>();
            int no = 0;
            for (int i = 0; i < sourcesList.Count; i++)
            {
                object[] row = sourcesList[i];
                string name = row[1].ToString();
                object type = row[2];
                int current = Ints(type);
                if (no < current)
                {
                    sources.Add(new HashList<string>(type.ToString()));
                    no = current;
                }
                sources[no - 1].Values.Add(name);
            }
            return sources;
        }

        private static List<HoursList<String2>> SetGeneral(List<object[]> generalCompetetions)
        {
            List<HoursList<String2>> competetions = new List<HoursList<String2>>();
            for (int i = 0; i < generalCompetetions.Count; i++)
            {
                object[] row = generalCompetetions[i];
                string no = row[1].ToString();
                string name = row[2].ToString();
                competetions.Add(new HoursList<String2>(no, name));

                string skills = row[4].ToString();
                string knowledge = row[3].ToString();
                competetions[i].Values.Add(new String2("Умения", skills));
                competetions[i].Values.Add(new String2("Знания", knowledge));
            }
            return competetions;
        }

        private static List<List<HoursList<String2>>> SetProfessional(List<object[]> professionalCompetetions)
        {
            List<List<HoursList<String2>>> competetions = new List<List<HoursList<String2>>>();
            int memoryNo = 0;
            for (int i = 0; i < professionalCompetetions.Count; i++)
            {
                int current = Ints(professionalCompetetions[i][1]);
                if (memoryNo < current)
                {
                    competetions.Add(new List<HoursList<String2>>());
                    memoryNo = current;
                }
                int recount = memoryNo - 1;

                object[] row = professionalCompetetions[i];
                string no1 = row[1].ToString();
                string no2 = row[2].ToString();
                string name = row[3].ToString();
                competetions[recount].Add(new HoursList<String2>($"ПК {no1}.{no2}", name));

                string experience = row[6].ToString();
                string skills = row[5].ToString();
                string knowledge = row[4].ToString();

                int recount2 = competetions[recount].Count - 1;
                HoursList<String2> skillsList = competetions[recount][recount2];
                skillsList.Values.Add(new String2("Практический опыт", experience));
                skillsList.Values.Add(new String2("Умения", skills));
                skillsList.Values.Add(new String2("Знания", knowledge));
            }
            return competetions;
        }

        private static void ConnectionMessage(string loadProblem, string exception)
        {
            string noLoad = "Не удалось загрузить: ";
            string message = "\nОшибка подключения. Вы можете продолжать работу.\n";
            string advice = "Свяжитесь с администратором насчет установления причины проблемы.\nПолное сообщение:\n";
            _ = MessageBox.Show(noLoad + loadProblem + message + advice + exception);
        }

        public static List<ComboBoxItem> SetSpecialitySelect()
        {
            SpecialityHead.keys.Clear();
            SpecialityHead.items.Clear();
            try
            {
                List<object[]> specialities = _dataBase.SpecialitiesList();
                for (byte i = 0; i < specialities.Count; i++)
                {
                    object[] row = specialities[i];
                    uint id = UInts(row[0]);
                    SpecialityHead.keys.Add(id);
                    SpecialityHead.items.Add(new ComboBoxItem
                    {
                        Content = row[1] + " " + row[2]
                    });
                }
            }
            catch (DbException exception)
            {
                string noLoad = "Заголовки спеицальностей";
                ConnectionMessage(noLoad, exception.Message);
            }
            return SpecialityHead.items;
        }

        public static SpecialityBase GetSpeciality(uint id, string name)
        {
            SpecialityBase speciality = new SpecialityBase(name);
            try
            {
                List<object[]> generalCompetetions = _dataBase.GeneralCompetetions(id);
                List<object[]> professionalCompetetions = _dataBase.ProfessionalCompetetions(id);
                speciality.GeneralCompetetions.AddRange(SetGeneral(generalCompetetions));
                speciality.ProfessionalCompetetions.AddRange(SetProfessional(professionalCompetetions));
            }
            catch (DbException exception)
            {
                string noLoad = "Выбранная специальность";
                ConnectionMessage(noLoad, exception.Message);
            }
            return speciality;
        }

        public static List<ComboBoxItem> SetDisciplineSelect(uint specialityId)
        {
            DisciplineHead.keys.Clear();
            DisciplineHead.items.Clear();
            try
            {
                List<object[]> disciplines = _dataBase.DisciplinesList(specialityId);
                for (byte i = 0; i < disciplines.Count; i++)
                {
                    object[] row = disciplines[i];
                    uint id = UInts(row[0]);
                    DisciplineHead.keys.Add(id);
                    DisciplineHead.items.Add(new ComboBoxItem
                    {
                        Content = row[1] + " " + row[2]
                    });
                }
            }
            catch (DbException exception)
            {
                string noLoad = "Заголовки дисциплин";
                ConnectionMessage(noLoad, exception.Message);
            }
            return DisciplineHead.items;
        }

        public static DisciplineBase GetDiscipline(uint id, string name)
        {
            DisciplineBase discipline = new DisciplineBase(name);
            discipline.GeneralCompetetions.Clear();
            discipline.ProfessionalCompetetions.Clear();
            discipline.Plan.Clear();
            discipline.Sources.Clear();
            try
            {
                List<object[]> totalHours = _dataBase.TotalHours(id);
                List<object[]> metaData = _dataBase.MetaData(id);
                List<object[]> sources = _dataBase.Sources(id);
                List<object[]> themePlan = _dataBase.ThemePlan(id);
                List<object[]> generalCompetetions = _dataBase.DisciplineGeneralMastering(id);
                List<object[]> professionalCompetetions = _dataBase.DisciplineProfessionalMastering(id);
                discipline.MetaData = SetMetaData(metaData);
                discipline.TotalHours = SetTotalHours(totalHours);

                discipline.Sources.AddRange(SetSources(sources));
                discipline.Plan.AddRange(SetThemePlan(themePlan));
                discipline.GeneralCompetetions.AddRange(SetGeneral(generalCompetetions));
                discipline.ProfessionalCompetetions.AddRange(SetProfessional(professionalCompetetions));
            }
            catch (DbException exception)
            {
                string noLoad = "Выбранная дисциплина";
                ConnectionMessage(noLoad, exception.Message);
            }
            return discipline;
        }

        public static List<String2> GetHourTypes()
        {
            List<String2> hourTypes = new List<String2>();
            try
            {
                List<object[]> types = _dataBase.WorkTypes();
                List<String2> result = SetTypeFields(types);
                hourTypes.AddRange(result);
            }
            catch (DbException exception)
            {
                string noLoad = "Типы работ тематического плана";
                ConnectionMessage(noLoad, exception.Message);
            }
            return hourTypes;
        }

        public static List<String2> GetMetaTypes()
        {
            List<String2> metaTypes = new List<String2>();
            try
            {
                List<object[]> types = _dataBase.MetaTypes();
                List<String2> result = SetTypeFields(types);
                metaTypes.AddRange(result);
            }
            catch (DbException exception)
            {
                string noLoad = "Типы метаданных";
                ConnectionMessage(noLoad, exception.Message);
            }
            return metaTypes;
        }

        public static List<String2> GetSourceTypes()
        {
            List<String2> sourceTypes = new List<String2>();
            try
            {
                List<object[]> types = _dataBase.SourceTypes();
                List<String2> result = SetTypeFields(types);
                sourceTypes.AddRange(result);
            }
            catch (DbException exception)
            {
                string noLoad = "Типы источников";
                ConnectionMessage(noLoad, exception.Message);
            }
            return sourceTypes;
        }

        public static List<String2> GetLevels()
        {
            List<String2> educationLevels = new List<String2>();
            try
            {
                List<object[]> levels = _dataBase.Levels();
                List<String2> result = SetPlanTasks(levels);
                educationLevels.AddRange(result);
            }
            catch (DbException exception)
            {
                string noLoad = "Типы уровней компетенций";
                ConnectionMessage(noLoad, exception.Message);
            }
            return educationLevels;
        }

        private static Sql _dataBase;
    }
}