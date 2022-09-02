﻿using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ControlMaterials.Tables
{
    public class Hour : NameLabel
    {
        public Hour(string name, ushort count)
        {
            Name = name;
            Count = count;
        }
        
        private ushort _count;
        public ushort Count
        {
            get => _count;
            set
            {
                _count = value;
                OnPropertyChanged();
            }
        }
    }
}