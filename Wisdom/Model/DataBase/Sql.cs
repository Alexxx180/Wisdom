﻿using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using static Wisdom.Customing.Converters;
using static Wisdom.Model.ProgramContent;
using static Wisdom.Model.DataBase.Converters;

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
    }
}
