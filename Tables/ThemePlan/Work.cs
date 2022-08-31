﻿using System.Collections.Generic;

namespace ControlMaterials.Tables.ThemePlan
{
    public class Work
    {
        public Work()
        {

        }

        public Work(string type, List<Task> tasks)
        {
            Type = type;
            Tasks = tasks;
        }

        public Work(string type, Task task)
        {
            Type = type;
            Tasks = new List<Task>
            {
                task
            };
        }

        public string Type { get; set; }
        public List<Task> Tasks { get; set; }
    }
}