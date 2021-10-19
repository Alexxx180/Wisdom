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
    public static class AutoFiller
    {
        //public static void SetPlan(int no)
        //{
        //    Grid nextTopic = GridChild(DisciplinePlan, 0);
        //    List<HoursList<LevelsList<HashList<String2>>>> planTopic = Disciplines[SpecNo][no].Plan;
        //    SetTopics(planTopic, nextTopic);
        //}

        ////Topics
        //public static void SetTopics(List<HoursList<LevelsList<HashList<String2>>>> planTopic,
        //    Grid nextTopic)
        //{
        //    TextBox topicName = Box(nextTopic, 2);
        //    TextBox topicHours = Box(nextTopic, 3);

        //    for (byte i = 0; i < planTopic.Count; i++)
        //    {
        //        topicName.Text = planTopic[i].Name;
        //        topicHours.Text = planTopic[i].Hours;
        //        TopicAdd2(nextTopic);

        //        Grid topic = GridChild(DisciplinePlan, i);
        //        StackPanel nextThemeGroup = Panel(topic, 4);
        //        HoursList<LevelsList<HashList<String2>>> topicTheme = planTopic[i];
        //        SetTheme(topicTheme, nextThemeGroup);
        //    }
        //}
        ////Themes
        //public static void SetTheme(HoursList<LevelsList<HashList<String2>>> topicTheme, StackPanel nextThemeGroup)
        //{
        //    Grid nextTheme = GridChild(nextThemeGroup, 0);
        //    TextBox nextThemeName = Box(nextTheme, 2);
        //    TextBox nextThemeHours = Box(nextTheme, 3);
        //    TextBox nextThemeCompetetions = Box(nextTheme, 4);
        //    ComboBox nextThemeLevel = Cbx(nextTheme, 5);

        //    for (byte ii = 0; ii < topicTheme.Values.Count; ii++)
        //    {
        //        nextThemeName.Text = topicTheme.Values[ii].Name;
        //        nextThemeHours.Text = topicTheme.Values[ii].Hours;
        //        nextThemeLevel.Text = topicTheme.Values[ii].Level;
        //        nextThemeCompetetions.Text = topicTheme.Values[ii].Competetions;
        //        ThemeAdd(nextTheme);

        //        Grid theme = GridChild(nextThemeGroup, ii);
        //        StackPanel nextTasksGroup = Panel(theme, 6);
        //        LevelsList<HashList<String2>> themeContent = topicTheme.Values[ii];
        //        SetThemeContent(themeContent, nextTasksGroup);
        //    }
        //}

        ////Content
        //public static void SetThemeContent(LevelsList<HashList<String2>> themeContent,
        //    StackPanel nextTasksGroup)
        //{
        //    TraceChildren(nextTasksGroup);
        //    Grid nextTasks = GridChild(nextTasksGroup, 1);
        //    Button nextTasksAdd = Btn(nextTasks, 0);
        //    ComboBox nextTasksType = Cbx(nextTasks, 1);
        //    CheckBox nextTasksMultiplier = Chx(nextTasks, 2);

        //    for (byte iii = 0; iii < themeContent.Values.Count; iii++)
        //    {
        //        Trace.WriteLine("Content info/tasks: " + iii);
        //        HashList<String2> contentTasks = themeContent.Values[iii];
        //        if (themeContent.Values[iii].Name == "255")
        //        {
        //            SetMaterial(contentTasks, nextTasksGroup);
        //            return;
        //        }

        //        bool isLastTask = themeContent.Values[iii].Values.Count <= 1;
        //        nextTasksType.SelectedIndex = Ints(themeContent.Values[iii].Name);
        //        nextTasksMultiplier.IsChecked = !isLastTask;
        //        Button deleteAddedTasks = NewTypeContentTasks(nextTasksAdd);

        //        if (isLastTask)
        //            SetTask(contentTasks, deleteAddedTasks);
        //        else
        //            SetTasksGroup(contentTasks, deleteAddedTasks);
        //    }
        //}

        ////Content material
        //public static void SetMaterial(HashList<String2> contentTasks, StackPanel nextTasksGroup)
        //{
        //    Grid content = GridChild(nextTasksGroup, 0);
        //    StackPanel contentStack = Panel(content, 4);

        //    Grid nextContent = GridChild(contentStack, 0);
        //    Button nextContentAdd = Btn(nextContent, 0);
        //    TextBox nextContentName = Box(nextContent, 2);
        //    TextBox nextContentHours = Box(nextContent, 3);

        //    for (byte iv = 0; iv < contentTasks.Values.Count; iv++)
        //    {
        //        nextContentName.Text = contentTasks.Values[iv].Name;
        //        nextContentHours.Text = contentTasks.Values[iv].Value;
        //        TableContent(nextContentAdd).Click += AnyDeleteAuto;
        //    }
        //}

        ////Content single task
        //public static void SetTask(HashList<String2> contentTasks, Button deleteAddedTasks)
        //{
        //    Grid nextTask = Parent(deleteAddedTasks);
        //    TextBox nextTaskName = Box(nextTask, 2);
        //    TextBox nextTaskHours = Box(nextTask, 3);
        //    nextTaskName.Text = contentTasks.Values[0].Name;
        //    nextTaskHours.Text = contentTasks.Values[0].Value;
        //}

        ////Content tasks group
        //public static void SetTasksGroup(HashList<String2> contentTasks, Button deleteAddedTasks)
        //{
        //    Grid task = Parent(deleteAddedTasks);
        //    StackPanel taskStack = Panel(task, 4);

        //    Grid nextTask = GridChild(taskStack, 0);
        //    Button nextTaskAdd = Btn(nextTask, 0);
        //    TextBox nextTaskName = Box(nextTask, 2);
        //    TextBox nextTaskHours = Box(nextTask, 3);

        //    for (byte iv = 0; iv < contentTasks.Values.Count; iv++)
        //    {
        //        nextTaskName.Text = contentTasks.Values[iv].Name;
        //        nextTaskHours.Text = contentTasks.Values[iv].Value;
        //        TableContent(nextTaskAdd).Click += AnyDeleteAuto;
        //    }
        //}

        //public static void SetSources(int no)
        //{
        //    DeleteAllSources();
        //    Grid next = GridChild(EducationSources, 0);
        //    Button add = Btn(next, 0);
        //    ComboBox box = Cbx(next, 1);
        //    DisciplineBase profDiscipline = Disciplines[SpecNo][no];
        //    for (byte i = 0; i < profDiscipline.Sources.Count; i++)
        //    {
        //        box.SelectedIndex = Ints(profDiscipline.Sources[i].Name);
        //        ParagraphText(add, out Button delete2, out Button add2);
        //        add2.Click += AddSource;
        //        delete2.Click += DeleteSources;

        //        Grid subNext = GridChild(EducationSources, i);
        //        StackPanel profComps = Panel(subNext, 2);
        //        Grid subSubNext = GridChild(profComps, 0);

        //        Button subAdd = Btn(subSubNext, 0);
        //        TextBox name = Box(subSubNext, 2);

        //        HashList<string> disciplineSources = Disciplines[SpecNo][no].Sources[i];
        //        for (byte ii = 0; ii < disciplineSources.Values.Count; ii++)
        //        {
        //            name.Text = disciplineSources.Values[ii];
        //            Source(subAdd).Click += DeleteSource;
        //        }
        //    }
        //}
    }
}
