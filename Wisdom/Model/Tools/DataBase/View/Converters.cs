using Serilog;
using System.Collections.Generic;
using System.Data.Common;
using System.Windows;
using ControlMaterials;
using ControlMaterials.Tables;
using ControlMaterials.Tables.ThemePlan;
using static Wisdom.Customing.Converters;
using ControlMaterials.Tables.Tasks;
using ControlMaterials.Tables.Hours;

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
            uint bottom, top;
            bottom = top = row[1].ToUInt();

            for (int i = 1; i < general.Count; i++)
            {
                row = general[i];
                uint next = row[1].ToUInt();
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
                }
                top = next;
            }
            competetions += ProfessionalFormat(no, bottom, top);

            return competetions.Trim();
        }


        private static List<Task>
            SetTypeFields(List<object[]> types)
        {
            List<Task> fields = new
                List<Task>();

            for (byte i = 0; i < types.Count; i++)
            {
                object[] row = types[i];
                string id = row[0].ToString();
                string name = row[1].ToString();

                Task type = new
                    Task(id, name);
                fields.Add(type);
            }
            return fields;
        }

        public static List<Task>
            SetMetaData(List<object[]> metaData)
        {
            List<Task> data = new
                List<Task>();

            for (int i = 0; i < metaData.Count; i++)
            {
                object[] row = metaData[i];
                string type = row[1].ToString();
                string value = row[2].ToString();

                data.Add(new Task(type, value));
            }
            return data;
        }

        private static List<Hour>
            SetTotalHours(List<object[]> totalWorkHours)
        {
            List<Hour> data = new
                List<Hour>();

            for (int i = 0; i < totalWorkHours.Count; i++)
            {
                object[] row = totalWorkHours[i];
                string type = row[1].ToString();
                ushort value = row[2].ToUShort();

                data.Add(new Hour(type, value));
            }
            return data;
        }

        private static List<Source>
            SetSources(List<object[]> sourcesList)
        {
            List<Source> sources = new List<Source>();

            List<string> types = new List<string>();
            Dictionary<string, List<string>> sort = new
                Dictionary<string, List<string>>();

            for (int i = 0; i < sourcesList.Count; i++)
            {
                object[] row = sourcesList[i];
                string name = row[1].ToString();
                object type = row[2];
                string typeName = type.ToString();

                if (!sort.ContainsKey(typeName))
                {
                    types.Add(typeName);
                    sort.Add(typeName, new List<string>());
                }
                sort[typeName].Add(name);
            }

            //for (ushort i = 0; i < types.Count; i++)
            //{
            //    string typeName = types[i];
            //    List<string> sourceNames = sort[typeName];
            //    Source source = new Source(typeName, sourceNames);

            //    sources.Add(source);
            //}

            return sources;
        }

        private static List<Competetion> SetGeneral(List<object[]> generalCompetetions)
        {
            List<Competetion> competetions = new List<Competetion>();
            for (int i = 0; i < generalCompetetions.Count; i++)
            {
                object[] row = generalCompetetions[i];

                string no = row[1].ToString();
                string name = row[2].ToString();
                string skills = row[4].ToString();
                string knowledge = row[3].ToString();

                Competetion competetion = new Competetion
                {
                    Name = name,


                    //PrefixNo = no,
                    //Abilities = new List<Task>
                    //{
                    //    new Task("Умения", skills),
                    //    new Task("Знания", knowledge)
                    //}
                };

                competetions.Add(competetion);
            }
            return competetions;
        }

        private static List<List<Competetion>>
            SetProfessional(List<object[]> professionalCompetetions)
        {
            List<List<Competetion>> competetions = new List<List<Competetion>>();

            int memoryNo = 0;
            for (int i = 0; i < professionalCompetetions.Count; i++)
            {
                int current = professionalCompetetions[i][1].ToInt();
                if (memoryNo < current)
                {
                    competetions.Add(new List<Competetion>());
                    memoryNo = current;
                }
                int recount = memoryNo - 1;

                object[] row = professionalCompetetions[i];
                string no1 = row[1].ToString();
                string no2 = row[2].ToString();
                string name = row[3].ToString();
                string knowledge = row[4].ToString();
                string skills = row[5].ToString();
                string experience = row[6].ToString();

                Competetion competetion = new Competetion
                {
                    Name = name,


                    //PrefixNo = $"ПК {no1}.{no2}",
                    //Abilities = new List<Task>
                    //{
                    //    new Task("Практический опыт", experience),
                    //    new Task("Умения", skills),
                    //    new Task("Знания", knowledge)
                    //}
                };

                competetions[recount].Add(competetion);
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
            Pair<List<uint>, List<string>>
                specialitiesHead = new
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
                Log.Error("Exception on speciality head hooking from DB: " +
                    exception.Message);
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
                Log.Error("Exception on speciality base object hooking from DB: " +
                    exception.Message);
                string noLoad = "Выбранная специальность";
                ConnectionMessage(noLoad, exception.Message);
                
            }
            return speciality;
        }

        public static Pair<List<uint>, List<string>>
            GetDisciplineSelect(List<object[]> disciplines)
        {
            Pair<List<uint>, List<string>>
                disciplinesHead = new
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
                Log.Error("Exception on discipline head hooking from DB: " +
                    exception.Message);
                string noLoad = "Заголовки дисциплин";
                ConnectionMessage(noLoad, exception.Message);
            }
            return disciplinesHead;
        }

        public static DisciplineBase GetDiscipline(string name,
            List<object[]> totalHours, List<object[]> metaData,
            List<HoursNode<Theme>> themePlan,
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
                
                List<Hour> hours = SetTotalHours(totalHours);
                discipline.ClassHours.Clear();
                for (ushort i = 0; i < hours.Count; i++)
                {
                    Hour hour = hours[i];
                    if (hour.Name == "Самостоятельная работа")
                    {
                        discipline.SelfHours.Add(hour);
                    }
                    else
                    {
                        discipline.ClassHours.Add(hour);
                    }
                }

                //discipline.Sources.AddRange(SetSources(sources));
                discipline.Plan.AddRange(themePlan);
                discipline.GeneralCompetetions.AddRange(SetGeneral(generalCompetetions));
                discipline.ProfessionalCompetetions.AddRange(SetProfessional(professionalCompetetions));
            }
            catch (DbException exception)
            {
                Log.Error("Exception on discipline base object hooking from DB: " +
                    exception.Message);
                string noLoad = "Выбранная дисциплина";
                ConnectionMessage(noLoad, exception.Message);
            }
            return discipline;
        }

        public static List<Task> GetHourTypes(List<object[]> types)
        {
            List<Task> hourTypes = new List<Task>();
            try
            {
                List<Task> result = SetTypeFields(types);
                hourTypes.AddRange(result);
            }
            catch (DbException exception)
            {
                Log.Error("Exception on hour types object hooking from DB: " +
                    exception.Message);
                string noLoad = "Типы работ тематического плана";
                ConnectionMessage(noLoad, exception.Message);
            }
            return hourTypes;
        }

        public static List<Task> GetMetaTypes(List<object[]> types)
        {
            List<Task> metaTypes = new List<Task>();
            try
            {
                List<Task> result = SetTypeFields(types);
                metaTypes.AddRange(result);
            }
            catch (DbException exception)
            {
                Log.Error("Exception on meta types object hooking from DB: " +
                    exception.Message);
                string noLoad = "Типы метаданных";
                ConnectionMessage(noLoad, exception.Message);
            }
            return metaTypes;
        }

        public static List<Task> GetSourceTypes(List<object[]> types)
        {
            List<Task> sourceTypes = new List<Task>();
            try
            {
                List<Task> result = SetTypeFields(types);
                sourceTypes.AddRange(result);
            }
            catch (DbException exception)
            {
                Log.Error("Exception on source types object hooking from DB: " +
                    exception.Message);
                string noLoad = "Типы источников";
                ConnectionMessage(noLoad, exception.Message);
            }
            return sourceTypes;
        }
    }
}