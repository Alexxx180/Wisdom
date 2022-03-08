using System;
using System.IO;
using System.Text.Json;
using System.Windows;
using Microsoft.Win32;
using Wisdom.Controls.Forms;
using Wisdom.Controls.Forms.DocumentForms.AddDisciplineProgram;

namespace Wisdom.Writers.AutoGenerating
{
    public static class Processors
    {
        public static string ProjectDirectory => Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
        public static string ConfigDirectory => ProjectDirectory + @"\Resources\Configuration\";
        public static string SettingsDirectory = ConfigDirectory + @"Settings\";

        private static void SaveMessage(string exception)
        {
            string noLoad = "Не удалось сохранить файл.";
            string message = "\nУбедитесь, что посторонние процессы не мешают операции.\n";
            string advice = "Свяжитесь с администратором насчет установления причины проблемы.\nПолное сообщение:\n";
            _ = MessageBox.Show(noLoad + message + advice + exception);
        }

        internal static void LoadMessage(string exception)
        {
            string noLoad = "Сбой загрузки.";
            string message = "\nУбедитесь, что файлы не повреждены или отсутствуют в целевой директории.\n";
            string advice = "Свяжитесь с администратором насчет установления причины проблемы.\nПолное сообщение:\n";
            _ = MessageBox.Show(noLoad + message + advice + exception);
        }

        internal static void WriteMessage(string exception)
        {
            string message = "Файл открыт в другой " +
                    "программе или используется другим " +
                    "процессом. Дальнейшая запись в файл" +
                    " невозможна.\nПолное сообщение:\n";
            _ = MessageBox.Show(message + exception);
        }

        public static OpenFileDialog
            CallManager(string filter, string fileName)
        {
            return new OpenFileDialog
            {
                FileName = fileName,
                Filter = filter
            };
        }

        public static SaveFileDialog
            CallWriter(string filter, string fileName)
        {
            return new SaveFileDialog
            {
                FileName = fileName,
                Filter = filter
            };
        }

        public static System.Windows.Forms.FolderBrowserDialog
            CallLocator(string description)
        {
            return new System.Windows.Forms.FolderBrowserDialog
            {
                Description = description,
                UseDescriptionForTitle = true,
                SelectedPath = Environment.GetFolderPath(
                    Environment.SpecialFolder.DesktopDirectory)
                    + Path.DirectorySeparatorChar,
                ShowNewFolderButton = true
            };
        }

        public static void Save(string path, byte[] bytes)
        {
            try
            {
                File.WriteAllBytes(path, bytes);
            }
            catch (IOException exception)
            {
                SaveMessage(exception.Message);
            }
        }

        public static T ReadJson<T>(string path)
        {
            T deserilizeable = default;
            try
            {
                byte[] fileBytes = File.ReadAllBytes(path);
                Utf8JsonReader utf8Reader = new Utf8JsonReader(fileBytes);
                deserilizeable = JsonSerializer.Deserialize<T>(ref utf8Reader);
            }
            catch (JsonException exception)
            {
                LoadMessage(exception.Message);
            }
            catch (ArgumentException exception)
            {
                LoadMessage(exception.Message);
            }
            catch (FileNotFoundException exception)
            {
                LoadMessage(exception.Message);
            }
            catch (IOException exception)
            {
                LoadMessage(exception.Message);
            }
            return deserilizeable;
        }

        private static void ProcessJsonAny<T>(string path, T serilizeable)
        {
            byte[] jsonUtf8Bytes = JsonSerializer.SerializeToUtf8Bytes(serilizeable);
            Save(path, jsonUtf8Bytes);
        }

        public static void ProcessJson(string path, Model.Documents.DisciplineProgram program)
        {
            ProcessJsonAny(path, program);
        }

        public static void ProcessJson(string path, Preferences program)
        {
            ProcessJsonAny(path, program);
        }

        public static void ProcessJson(string path, Settings program)
        {
            ProcessJsonAny(path, program);
        }
    }
}