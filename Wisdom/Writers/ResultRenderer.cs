﻿using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;

namespace Wisdom.Writers
{
    public static class ResultRenderer
    {
        private static readonly GeneratedClass renderer = new GeneratedClass();

        public static void WriteDoc(string fileName)
        {
            try
            {
                if (File.Exists(fileName))
                    File.Delete(fileName);
                renderer.CreatePackage(fileName);
            }
            catch (IOException exception)
            {
                string message = "Файл открыт в другой программе или используется другим процессом. Дальнейшая запись в файл невозможна.\nПолное сообщение:\n";
                _ = MessageBox.Show(message + exception.Message);
            }
        }

        //Write document method used for tests
        public static void WriteDoc()
        {
            string testFile = @"TestResources\Output\Result.docx";
            string exutingDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            string fullName = $"{exutingDirectory}\\{testFile}";
            WriteDoc(fullName);
        }

        public static void CallWriter(string fileName)
        {
            SaveFileDialog dialog = new SaveFileDialog
            {
                FileName = fileName,
                Filter =
                "Документ Microsoft Word (*.docx)|*.docx|" +
                "Документ Word 97-2003 (*.doc)|*.doc|" +
                "Текст в формате RTF (*.rtf)|*.rtf"
            };
            if (dialog.ShowDialog().Value)
                WriteDoc(dialog.FileName);
        }
    }
}