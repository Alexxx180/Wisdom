using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Reflection;
using MySql.Data.MySqlClient;

namespace Wisdom.Model.DataBase
{
    public class MySQL : Sql
    {
        private const string PublishSource =
            @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = ";
        private const string PublishLocation =
            @"\Resources\Database\DesertRageGame.mdf; Integrated Security = True";
        public MySQL()
        {
            Con = ParentServerConnection();
        }
        
        public MySqlConnection NewConnection(string path)
        {
            return new MySqlConnection(path);
        }
        //[EN] Publishing experimental
        //[RU] Публикация-эксперимент
        public MySqlConnection PublishExperimentalConnection()
        {
            return NewConnection(PublishSource +
                Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)
                + PublishLocation);
        }
        //[EN] Server connection
        //[RU] Подключение через сервер (ПК создателя)
        public MySqlConnection ParentServerConnection()
        {
            string source = "SERVER=127.0.0.1;";
            string catalog = "DATABASE=prosperity;";
            string user = "UID=root;";
            string pass = "PASSWORD=;";
            return NewConnection(source + catalog + user + pass);
        }
        //[EN] Local connection
        //[RU] Подключение локально
        public MySqlConnection LocalConnection()
        {
            return NewConnection(PublishSource +
                Directory.GetParent(Environment.CurrentDirectory)
                .Parent.Parent.FullName + PublishLocation);
        }
        //[EN] Publishing local connection
        //[RU] Публикация с локальным подключением
        public MySqlConnection PublishLocalConnection()
        {
            return NewConnection(PublishSource +
                Environment.CurrentDirectory + PublishLocation);
        }

        public override void Procedure(in string name)
        {
            Cmd = new MySqlCommand(name, Con)
            {
                CommandType = CommandType.StoredProcedure
            };
        }

        public override void OnlyExecute()
        {
            Cmd.Connection.Open();
            _ = Cmd.ExecuteNonQuery();
            Cmd.Connection.Close();
        }

        public override List<object[]> ReadData()
        {
            Cmd.Connection.Open();
            DataReader = Cmd.ExecuteReader();
            List<object[]> table = new List<object[]>();
            if (DataReader.HasRows)
                while (DataReader.Read())
                {
                    object[] row = new object[DataReader.FieldCount];
                    for (int i = 0; i < DataReader.FieldCount; i++)
                        row[i] = DataReader.GetValue(i);
                    table.Add(row);
                }
            Cmd.Connection.Close();
            return table;
        }

        public override List<object> ReadData(in int column)
        {
            Cmd.Connection.Open();
            DataReader = Cmd.ExecuteReader();
            List<object> table = new List<object>();
            if (DataReader.HasRows)
                while (DataReader.Read())
                {
                    object cell = DataReader.GetValue(column);
                    table.Add(cell);
                }
            Cmd.Connection.Close();
            return table;
        }

        public override List<object[]> ReadData(in byte StartValue, in byte EndValue)
        {
            Cmd.Connection.Open();
            DataReader = Cmd.ExecuteReader();
            List<object[]> table = new List<object[]>();
            int count = EndValue - StartValue;
            if (DataReader.HasRows)
                while (DataReader.Read())
                {
                    object[] row = new object[count];
                    for (int i = 0, j = StartValue; j < EndValue; i++, j++)
                        row[i] = DataReader.GetValue(j);
                    table.Add(row);
                }
            Cmd.Connection.Close();
            return table;
        }

        public override void PassParameter(in string ParamName, in object newParam)
        {
            Dictionary<string, MySqlDbType> types = new Dictionary<string, MySqlDbType>()
            {
                { "Boolean", MySqlDbType.Bit }, { "UInt16", MySqlDbType.UInt16 }, //SqlDbType.SmallInt
                { "Byte", MySqlDbType.UByte }, { "String", MySqlDbType.VarChar }, //MySqlDbType.TinyInt
                { "UInt32", MySqlDbType.UInt32 }, { "UInt64", MySqlDbType.UInt64 }
            };
            Cmd.Parameters.Add(ParamName, types[newParam.GetType().Name]).Value = newParam;
        }

        public override void ClearParameters()
        {
            Cmd.Parameters.Clear();
        }

        public MySqlCommand Cmd { get; set; }
        public MySqlDataReader DataReader { get; set; }
        public MySqlConnection Con { get; set; }
    }
}
