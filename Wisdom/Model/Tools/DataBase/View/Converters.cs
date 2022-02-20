using System.Collections.Generic;
using System.Data.Common;
using System.Windows;
using static Wisdom.Customing.Converters;

namespace Wisdom.Model.Tools.DataBase
{
    public static class Converters
    {
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

        internal static string ConvertGeneral(List<object[]> general)
        {
            string competetions = "";
            if (general.Count < 1)
                return competetions;
            object[] row = general[0];
            uint bottom = row[1].ToUInt();
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

        internal static string ConvertProfessional(List<object[]> professional)
        {
            string competetions = "";
            if (professional.Count < 1)
                return competetions;
            object[] row = professional[0];
            uint no, bottom, top;
            top = bottom = no = row[2].ToUInt();
            for (int i = 1; i < professional.Count; i++)
            {
                row = professional[i];
                uint nextNo = row[1].ToUInt();
                uint next = row[2].ToUInt();
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


        private static List<Pair<string, string>> SetTypeFields(List<object[]> types)
        {
            List<Pair<string, string>> fields = new List<Pair<string, string>>();
            for (byte i = 0; i < types.Count; i++)
            {
                object[] row = types[i];
                string id = row[0].ToString();
                string name = row[1].ToString();
                Pair<string, string> type = new Pair<string, string>(id, name);
                fields.Add(type);
            }       
            return fields;
        }

        public static List<Pair<string, string>> SetMetaData(List<object[]> metaData)
        {
            return GetPair<string>(metaData);
        }

        private static List<Pair<string, ushort>> SetTotalHours(List<object[]> totalWorkHours)
        {
            return GetPair<ushort>(totalWorkHours);
        }

        private static List<Pair<string, T>> GetPair<T>(List<object[]> rows)
        {
            List<Pair<string, T>> data = new List<Pair<string, T>>();
            for (int i = 0; i < rows.Count; i++)
            {
                object[] row = rows[i];
                string type = row[1].ToString();
                T value = (T)row[2];
                data.Add(new Pair<string, T>(type, value));
            }
            return data;
        }

        private static List<Pair<string, List<string>>> SetSources(List<object[]> sourcesList)
        {
            List<Pair<string, List<string>>> sources = new
                List<Pair<string, List<string>>>();
            int no = 0;
            for (int i = 0; i < sourcesList.Count; i++)
            {
                object[] row = sourcesList[i];
                string name = row[1].ToString();
                object type = row[2];
                int current = Ints(type);
                if (no < current)
                {
                    sources.Add(new Pair<string, List<string>>
                        (type.ToString(), new List<string>()));
                    no = current;
                }
                sources[no - 1].Value.Add(name);
            }
            return sources;
        }

        private static List<HoursList<Pair<string, string>>> SetGeneral(List<object[]> generalCompetetions)
        {
            List<HoursList<Pair<string, string>>> competetions = new List<HoursList<Pair<string, string>>>();
            for (int i = 0; i < generalCompetetions.Count; i++)
            {
                object[] row = generalCompetetions[i];
                string no = row[1].ToString();
                string name = row[2].ToString();
                competetions.Add(new HoursList<Pair<string, string>>(no, name));

                string skills = row[4].ToString();
                string knowledge = row[3].ToString();
                competetions[i].Values.Add(new Pair<string, string>("Умения", skills));
                competetions[i].Values.Add(new Pair<string, string>("Знания", knowledge));
            }
            return competetions;
        }

        private static List<List<HoursList<Pair<string, string>>>> SetProfessional(List<object[]> professionalCompetetions)
        {
            List<List<HoursList<Pair<string, string>>>> competetions = new List<List<HoursList<Pair<string, string>>>>();
            int memoryNo = 0;
            for (int i = 0; i < professionalCompetetions.Count; i++)
            {
                int current = Ints(professionalCompetetions[i][1]);
                if (memoryNo < current)
                {
                    competetions.Add(new List<HoursList<Pair<string, string>>>());
                    memoryNo = current;
                }
                int recount = memoryNo - 1;

                object[] row = professionalCompetetions[i];
                string no1 = row[1].ToString();
                string no2 = row[2].ToString();
                string name = row[3].ToString();
                competetions[recount].Add(new HoursList<Pair<string, string>>($"ПК {no1}.{no2}", name));

                string experience = row[6].ToString();
                string skills = row[5].ToString();
                string knowledge = row[4].ToString();

                int recount2 = competetions[recount].Count - 1;
                HoursList<Pair<string, string>> skillsList = competetions[recount][recount2];
                skillsList.Values.Add(new Pair<string, string>("Практический опыт", experience));
                skillsList.Values.Add(new Pair<string, string>("Умения", skills));
                skillsList.Values.Add(new Pair<string, string>("Знания", knowledge));
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

        public static Pair<List<uint>, List<string>>
            GetSpecialitySelect(List<object[]> specialities)
        {
            Pair<List<uint>, List<string>> specialitiesHead = new
                Pair<List<uint>, List<string>>(
                    new List<uint>(), new List<string>()
                );
            try
            {
                for (byte i = 0; i < specialities.Count; i++)
                {
                    object[] row = specialities[i];
                    uint id = row[0].ToUInt();
                    specialitiesHead.Name.Add(id);
                    specialitiesHead.Value.Add(row[1] + " " + row[2]);
                }
            }
            catch (DbException exception)
            {
                string noLoad = "Заголовки спеицальностей";
                ConnectionMessage(noLoad, exception.Message);
            }
            return specialitiesHead;
        }

        public static SpecialityBase GetSpeciality(string name,
            List<object[]> general, List<object[]> professional)
        {
            SpecialityBase speciality = new SpecialityBase(name);
            try
            {
                speciality.GeneralCompetetions.AddRange(SetGeneral(general));
                speciality.ProfessionalCompetetions.AddRange(SetProfessional(professional));
            }
            catch (DbException exception)
            {
                string noLoad = "Выбранная специальность";
                ConnectionMessage(noLoad, exception.Message);
            }
            return speciality;
        }

        public static Pair<List<uint>, List<string>>
            GetDisciplineSelect(List<object[]> disciplines)
        {
            Pair<List<uint>, List<string>> disciplinesHead = new
                Pair<List<uint>, List<string>>(
                    new List<uint>(), new List<string>()
                );
            try
            {
                for (byte i = 0; i < disciplines.Count; i++)
                {
                    object[] row = disciplines[i];
                    uint id = row[0].ToUInt();
                    disciplinesHead.Name.Add(id);
                    disciplinesHead.Value.Add(row[1] + " " + row[2]);
                }
            }
            catch (DbException exception)
            {
                string noLoad = "Заголовки дисциплин";
                ConnectionMessage(noLoad, exception.Message);
            }
            return disciplinesHead;
        }

        public static DisciplineBase GetDiscipline(string name,
            List<object[]> totalHours, List<object[]> metaData,
            List<HoursList<LevelsList<HashList<Pair<string, string>>>>> themePlan,
            List<object[]> sources, List<object[]> generalCompetetions, 
            List<object[]> professionalCompetetions)
        {
            DisciplineBase discipline = new DisciplineBase(name);
            discipline.GeneralCompetetions.Clear();
            discipline.ProfessionalCompetetions.Clear();
            discipline.Plan.Clear();
            discipline.Sources.Clear();
            try
            {
                discipline.MetaData = SetMetaData(metaData);
                discipline.TotalHours = SetTotalHours(totalHours);

                discipline.Sources.AddRange(SetSources(sources));
                discipline.Plan.AddRange(themePlan);
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

        public static List<Pair<string, string>> GetHourTypes(List<object[]> types)
        {
            List<Pair<string, string>> hourTypes = new List<Pair<string, string>>();
            try
            {
                List<Pair<string, string>> result = SetTypeFields(types);
                hourTypes.AddRange(result);
            }
            catch (DbException exception)
            {
                string noLoad = "Типы работ тематического плана";
                ConnectionMessage(noLoad, exception.Message);
            }
            return hourTypes;
        }

        public static List<Pair<string, string>> GetMetaTypes(List<object[]> types)
        {
            List<Pair<string, string>> metaTypes = new List<Pair<string, string>>();
            try
            {
                List<Pair<string, string>> result = SetTypeFields(types);
                metaTypes.AddRange(result);
            }
            catch (DbException exception)
            {
                string noLoad = "Типы метаданных";
                ConnectionMessage(noLoad, exception.Message);
            }
            return metaTypes;
        }

        public static List<Pair<string, string>> GetSourceTypes(List<object[]> types)
        {
            List<Pair<string, string>> sourceTypes = new List<Pair<string, string>>();
            try
            {
                List<Pair<string, string>> result = SetTypeFields(types);
                sourceTypes.AddRange(result);
            }
            catch (DbException exception)
            {
                string noLoad = "Типы источников";
                ConnectionMessage(noLoad, exception.Message);
            }
            return sourceTypes;
        }
    }
}