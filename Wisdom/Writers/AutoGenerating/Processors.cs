using System;
using System.IO;
using System.Text.Json;
using System.Windows;
using Wisdom.Controls.Forms.MainForm;

namespace Wisdom.Writers.AutoGenerating
{
    public static class Processors
    {
        public static string ProjectDirectory => Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
        public static string ConfigDirectory => ProjectDirectory + @"\Resources\Configuration\";

        private static void SaveMessage(string exception)
        {
            string noLoad = "Не удалось сохранить файл.";
            string message = "\nУбедитесь, что посторонние процессы не мешают операции.\n";
            string advice = "Свяжитесь с администратором насчет установления причины проблемы.\nПолное сообщение:\n";
            _ = MessageBox.Show(noLoad + message + advice + exception);
        }

        private static void LoadMessage(string exception)
        {
            string noLoad = "Не удалось загрузить файл.";
            string message = "\nУбедитесь, что файл не поврежден или отсутствует в целевой директории.\n";
            string advice = "Свяжитесь с администратором насчет установления причины проблемы.\nПолное сообщение:\n";
            _ = MessageBox.Show(noLoad + message + advice + exception);
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
    }
}