using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using static Wisdom.Customing.BlockTemplates;
using static Wisdom.Binds.EasyBindings;
using Wisdom.Binds;

namespace Wisdom.Writers
{
    public static class Preview
    {
        public static TableRow ThemePreviewRow(Label no,
            TextBox name, TextBox hours, out TableCell contentsCell)
        {
            Binding bindThemeNo = FastBind(no, "Content");
            Binding bindThemeName = FastBind(name, "Text");
            MultiBinding bindTheme = Multi(new SectionsConverter(), bindThemeNo, bindThemeName);
            Binding bindLevel = FastBind(hours, "Text");

            TableRow newTheme = new TableRow();
            TableCell themeNameCell = UsualTableCell(TextCB(bindTheme));
            contentsCell = Span2TableCell();
            TableCell themeLevelCell = UsualTableCell(TextCenter(bindLevel));
            AddRCells(newTheme, themeNameCell, contentsCell, themeLevelCell);
            return newTheme;
        }

        public static Table ContentPreviewTable(out TableRowGroup contentGroup)
        {
            Table content = UsualTable();
            AddTCols(content, 0.848, 0.152);
            contentGroup = new TableRowGroup();
            TableRow caption = new TableRow();
            TableCell name = UsualTableCell(Text("Содержание учебного материала"));
            TableCell empty = UsualTableCell();
            AddRCells(caption, name, empty);
            contentGroup.Rows.Add(caption);
            content.RowGroups.Add(contentGroup);
            return content;
        }
        public static TableRow TasksPreviewRow(out TableCell task)
        {
            TableRow tasks = new TableRow();
            task = Span2TableCell();
            AddRCells(tasks, task);
            return tasks;
        }
        public static TableRowGroup TaskPreviewGroup(TableCell task)
        {
            Table taskTable = UsualTable();
            AddTCols(taskTable, 0.048, 0.8, 0.152);
            task.Blocks.Add(taskTable);
            TableRowGroup taskGroup = new TableRowGroup();
            taskTable.RowGroups.Add(taskGroup);
            return taskGroup;
        }

    }
}
