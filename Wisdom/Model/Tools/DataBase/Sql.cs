using System.Collections.Generic;

namespace Wisdom.Model.Tools.DataBase
{
    public abstract class Sql : IDataViewer
    {
        #region Configuration Members
        public bool IndependentMode { get; set; }

        internal abstract void SetConfiguration(in string dbName, in string host);

        public abstract bool TestConnection(in string login, in string pass);

        internal abstract void Connect();
        #endregion

        public abstract void Procedure(in string name);

        #region WorkWithParameters Members
        public abstract void PassParameter(in string ParamName, in object newParam);

        public void PassParameters(Dictionary<string, object> parameters)
        {
            foreach (KeyValuePair<string, object> entry in parameters)
                PassParameter(entry.Key, entry.Value);
        }

        public abstract void ClearParameters();
        #endregion

        #region ProcedureExecuteOnly Members
        public abstract void OnlyExecute();

        public void ExecuteProcedure(string name)
        {
            Procedure(name);
            OnlyExecute();
        }
        #endregion

        #region ReadRecords Members
        public abstract List<object[]> ReadData();

        public abstract List<object> ReadData(in int column);

        public abstract List<object[]> ReadData(in byte StartValue, in byte EndValue);

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
        #endregion

        #region Data view methods
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

        public List<object[]> SourceTypes()
        {
            return GetRecords("get_source_types");
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

        public List<object[]> Levels()
        {
            return GetRecords("get_all_levels");
        }
        #endregion
    }
}