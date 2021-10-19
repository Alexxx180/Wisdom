using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Text.RegularExpressions;
using static Wisdom.Customing.BlockTemplates;
using static Wisdom.Customing.Decorators;
using static Wisdom.Writers.ResultRenderer;
using static Wisdom.Binds.EasyBindings;
using static Wisdom.Writers.Content;
using static Wisdom.Customing.Converters;
using System.Diagnostics;
using static Wisdom.Customing.ResourceHelper;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Data;
using Wisdom.Binds;
using Microsoft.Win32;
using static Wisdom.Model.ProgramContent;
using System.Collections.Generic;
using Wisdom.Model;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using static Wisdom.Tests.TotalTest;
using System.Threading.Tasks;

namespace Wisdom.AutoGenerating
{
    public static class AutoWriter
    {
        public static List<HoursList<String2>> ExtractCompetetions(StackPanel panel,
            byte idNo, byte nameNo)
        {
            List<HoursList<String2>> list = new List<HoursList<String2>>();
            int cnt = panel.Children.Count - 1;
            for (byte i = 0; i < cnt; i++)
            {
                Grid element = panel.Children[i] as Grid;
                Label competetionNo = element.Children[idNo] as Label;
                TextBox competetionName = element.Children[nameNo] as TextBox;
                HoursList<String2> competetion = new HoursList<String2>
                    (competetionNo.Content.ToString(), competetionName.Text);
                for (int ii = nameNo + 1; ii < element.Children.Count; ii += 2)
                {
                    Label skillsName = element.Children[ii] as Label;
                    TextBox skillsDescription = element.Children[ii + 1] as TextBox;
                    competetion.Values.Add(new String2(skillsName.Content.ToString(),
                        skillsDescription.Text));
                }
                list.Add(competetion);
            }
            return list;
        }

        public static List<HoursList<String2>> ExtractCompetetions2(StackPanel panel,
            byte idNo, byte nameNo)
        {
            List<HoursList<String2>> list = new List<HoursList<String2>>();
            for (byte i = 0; i < panel.Children.Count - 1; i++)
            {
                Grid item = panel.Children[i] as Grid;
                StackPanel competetion = item.Children[2] as StackPanel;
                list.AddRange(ExtractCompetetions(competetion, idNo, nameNo));
            }
            return list;
        }


        public static List<List<string>> GetListFromElements3(StackPanel panel, byte rangeStart, byte rangeEnd)
        {
            List<List<string>> list = new List<List<string>>();
            int cnt = panel.Children.Count - 1;
            for (byte i = 0; i < cnt; i++)
            {
                list.Add(new List<string>());
                Grid element = panel.Children[i] as Grid;
                for (byte ii = rangeStart; ii < rangeEnd; ii++)
                {
                    TextBox box = element.Children[ii] as TextBox;
                    list[i].Add(box.Text);
                }
            }
            return list;
        }
        public static List<HashList<string>> GetSources(StackPanel list, byte index, byte index2)
        {
            List<HashList<string>> sources = new List<HashList<string>>();
            int cnt = list.Children.Count - 1;
            for (byte i = 0; i < cnt; i++)
            {
                Grid source = GridChild(list, i);
                sources.Add(GetSource(source, index, index2));
            }
            return sources;
        }

        public static HashList<string> GetSource(Grid grid, byte index, byte index2)
        {
            Label caption = Lab(grid, index);
            HashList<string> source = new HashList<string>(caption.Content.ToString());
            int optimum = index + 1;
            StackPanel sourceValues = Panel(grid, optimum);
            source.Values = GetSourceList(sourceValues, index2);
            return source;
        }
        public static List<string> GetSourceList(StackPanel sourceValues, byte index)
        {
            List<string> list = new List<string>();
            int cnt = sourceValues.Children.Count - 1;
            for (byte i = 0; i < cnt; i++)
            {
                Grid element = GridChild(sourceValues, i);
                TextBox box = Box(element, index);
                list.Add(box.Text);
            }
            return list;
        }

        public static String2 GetString2(Grid grid, byte nameNo, byte hoursNo)
        {
            TextBox nameBox = Box(grid, nameNo);
            TextBox hoursBox = Box(grid, hoursNo);
            string name = nameBox.Text;
            string value = hoursBox.Text;
            String2 string2 = new String2(name, value);
            return string2;
        }
        //2, 3
        //DisciplinePlan - Grid - StackPanel - Grid - StackPanel - Grid - StackPanel
        //Раздел 1. - Тема 1.1. - Содержание - 1.; 2. ...
        public static List<String2> GetTasks(StackPanel panel, byte nameNo, byte hoursNo)
        {
            List<String2> list = new List<String2>();
            int cnt = panel.Children.Count - 1;
            for (byte i = 0; i < cnt; i++)
            {
                Grid element = GridChild(panel, i);
                list.Add(GetString2(element, nameNo, hoursNo));
            }
            return list;
        }
        //DisciplinePlan - Grid - StackPanel - Grid - StackPanel - Grid
        //Раздел 1. - Тема 1.1. - Практические работы/Контрольные работы...
        public static HashList<String2> GetTaskGroup(Grid grid, byte captionNo, byte nameNo, byte hoursNo)
        {
            HashList<String2> source;
            Label caption = Lab(grid, captionNo);
            if (caption == null)
            {
                caption = Lab(grid, 1);
                source = new HashList<String2>(caption.Content.ToString());
                TextBox name = Box(grid, 2);
                TextBox hours = Box(grid, 3);
                String2 str2 = new String2(name.Text, hours.Text);
                source.Values = new List<String2>();
                source.Values.Add(str2);
            }
            else
            {
                source = new HashList<String2>(caption.Content.ToString());
                StackPanel panel2 = Panel(grid, 4);
                source.Values = GetTasks(panel2, nameNo, hoursNo);
            }
            return source;
        }
        //0
        //DisciplinePlan - Grid - StackPanel - Grid - StackPanel - Grid
        //Раздел 1. - Тема 1.1. - Содержание 
        public static HashList<String2> GetMaterial(Grid grid, byte captionNo, byte nameNo, byte hoursNo)
        {
            HashList<String2> source;
            Label caption = Lab(grid, captionNo);
            source = new HashList<String2>(caption.Content.ToString());
            StackPanel panel2 = Panel(grid, 4);
            source.Values = GetTasks(panel2, nameNo, hoursNo);
            return source;
        }

        //2, 3
        //DisciplinePlan - Grid - StackPanel - Grid
        //Раздел 1. - Тема 1.1.
        public static LevelsList<HashList<String2>> GetHours(Grid grid, byte nameNo, byte hoursNo,
            byte competetionsNo, byte levelNo, byte contentCaptionNo, byte contentNameNo, byte contentHoursNo)
        { //byte index3, 
            TextBox caption = Box(grid, nameNo);
            TextBox hours = Box(grid, hoursNo);
            TextBox competetions = Box(grid, competetionsNo);
            ComboBox level = Cbx(grid, levelNo);
            LevelsList<HashList<String2>> source = new LevelsList<HashList<String2>>
                (caption.Text, hours.Text, competetions.Text, level.Text); // Exces
            int optimum = levelNo + 1;
            StackPanel panel2 = grid.Children[optimum] as StackPanel;
            int cnt = panel2.Children.Count - 1;
            Grid content = GridChild(panel2, 0);
            source.Values.Add(GetMaterial(content, contentCaptionNo, contentNameNo, contentHoursNo));
            for (byte i = 1; i < cnt; i++)
            {
                Grid tasks = GridChild(panel2, i);
                source.Values.Add(GetTaskGroup(tasks, 3, contentNameNo, contentHoursNo));
            }
            return source;
        }
        //2, 3
        //DisciplinePlan - Grid
        //Раздел 1.
        public static HoursList<LevelsList<HashList<String2>>> GetHours2(Grid grid, byte topicNameNo, byte topicHoursNo,
            byte themeNameNo, byte themeHoursNo, byte themeCompetetionsNo, byte themeLevelNo,
            byte contentCaptionNo, byte contentNameNo, byte contentHoursNo)
        { //byte index3, 
            TextBox caption = Box(grid, topicNameNo);
            TextBox hours = Box(grid, topicHoursNo);
            HoursList<LevelsList<HashList<String2>>> source = new HoursList<LevelsList<HashList<String2>>>(caption.Text, hours.Text);
            int optimum = topicHoursNo + 1;
            StackPanel panel2 = grid.Children[optimum] as StackPanel;
            int cnt = panel2.Children.Count - 1;
            for (byte i = 0; i < cnt; i++)
                source.Values.Add(GetHours(panel2.Children[i] as Grid, themeNameNo, themeHoursNo,
                    themeCompetetionsNo, themeLevelNo, contentCaptionNo, contentNameNo, contentHoursNo));
            return source;
        }
        //Topics| Themes      | Content
        //2, 3, | 2, 3, 4, 5, | 0, | 2, 3

        //2, 3, 2, 3, 4, 5, 0, 2, 3
        //DisciplinePlan
        public static List<HoursList<LevelsList<HashList<String2>>>> GetAbsoleteList(StackPanel panel, byte topicNameNo, byte topicHoursNo,
            byte themeNameNo, byte themeHoursNo, byte themeCompetetionsNo, byte themeLevelNo, byte contentCaptionNo, byte contentNameNo, byte contentHoursNo)
        {
            List<HoursList<LevelsList<HashList<String2>>>> source = new List<HoursList<LevelsList<HashList<String2>>>>();
            int cnt = panel.Children.Count - 1;
            for (byte i = 0; i < cnt; i++)
            {
                Grid grid = panel.Children[i] as Grid;
                source.Add(GetHours2(grid, topicNameNo, topicHoursNo, themeNameNo, themeHoursNo,
                    themeCompetetionsNo, themeLevelNo, contentCaptionNo, contentNameNo, contentHoursNo));
            }
            return source;
        }
    }
}
