using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using Wisdom.Model;
using static Wisdom.Model.DataBase.Converters;

namespace Wisdom.Model.DataBase
{
    public class ProgramData
    {
        public ProgramData() : this(new MySQL())
        {
        }

        public ProgramData(Sql connector)
        {
            Connect(connector);
        }

        public List<ComboBoxItem> ListSpecialities()
        {
            return SetSpecialitySelect();
        }

        public List<ComboBoxItem> ListDisciplines(uint specialityId)
        {
            return SetDisciplineSelect(specialityId);
        }

        public SpecialityBase SpecialityData(uint id, string name)
        {
            return GetSpeciality(id, name);
        }

        public DisciplineBase DisciplineData(uint id, string name)
        {
            return GetDiscipline(id, name);
        }

        public List<String2> MetaTypesData()
        {
            return GetMetaTypes();
        }

        public List<String2> HourTypesData()
        {
            return GetHourTypes();
        }
    }
}
