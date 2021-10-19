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
            TextBox name, TextBox hours, TextBox competetions, out TableCell contentGroup)
        {
            Binding bindNo = FastBind(no, "Content");
            Binding bindName = FastBind(name, "Text");
            MultiBinding bindTheme = Multi(new SectionsConverter(), bindNo, bindName);
            Binding bindCompetetion = FastBind(competetions, "Text");
            Binding bindLevel = FastBind(hours, "Text");

            TableRow theme = new TableRow();
            TableCell themeName = UsualTableCell(TextCB(bindTheme));
            contentGroup = Span2TableCell();
            TableCell themeCompetetions = UsualTableCell(TextCenter(bindCompetetion));
            TableCell themeLevel = UsualTableCell(TextCenter(bindLevel));
            AddRCells(theme, themeName, contentGroup, themeCompetetions, themeLevel);
            return theme;
        }

        public static Table ContentPreviewTable(out TableRowGroup contentGroup)
        {
            Table content = UsualTable();
            AddTCols(content, 0.851, 0.149);
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
