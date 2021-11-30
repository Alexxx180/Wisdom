using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Wisdom.Model
{
    public class Sql
    {
        private const string PublishSource =
            @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = ";
        private const string PublishLocation =
            @"\Resources\Database\DesertRageGame.mdf; Integrated Security = True";
        public Sql()
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
                Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName
                + PublishLocation);
        }
        //[EN] Publishing local connection
        //[RU] Публикация с локальным подключением
        public MySqlConnection PublishLocalConnection()
        {
            return NewConnection(PublishSource +
                Environment.CurrentDirectory + PublishLocation);
        }
        private void NewStoredProcedureBuild(in string ProcedureName)
        {
            Cmd = new MySqlCommand(ProcedureName, Con) {
                CommandType = CommandType.StoredProcedure
            };
        }
        private void NewExecuteNonQueryBuild()
        {
            Cmd.Connection.Open();
            _ = Cmd.ExecuteNonQuery();
            Cmd.Connection.Close();
        }
        private List<string> NewSqlDataReaderBuild(List<string> logins)
        {
            Cmd.Connection.Open();
            DataReader = Cmd.ExecuteReader();
            if (DataReader.HasRows)
                while (DataReader.Read())
                    logins.Add(DataReader.GetValue(0).ToString());
            Cmd.Connection.Close();
            return logins;
        }
        private string NewSqlDataReaderBuild(string Selected, in byte Column)
        {
            Cmd.Connection.Open();
            DataReader = Cmd.ExecuteReader();
            if (DataReader.HasRows)
                while (DataReader.Read())
                    Selected = DataReader.GetValue(Column).ToString();
            Cmd.Connection.Close();
            return Selected;
        }
        private string NewSqlDataReaderBuild(in byte Column)
        {
            string uo = "0";
            Cmd.Connection.Open();
            DataReader = Cmd.ExecuteReader();
            if (DataReader.HasRows)
                while (DataReader.Read())
                    uo = DataReader.GetValue(Column).ToString();
            Cmd.Connection.Close();
            return uo;
        }
        private object[] NewSqlDataReaderBuild(object[] Values, in byte StartValue, in byte EndValue)
        {
            Cmd.Connection.Open();
            DataReader = Cmd.ExecuteReader();
            if (DataReader.HasRows)
                while (DataReader.Read())
                    for (byte i = StartValue; i < EndValue; i++)
                        Values[i - StartValue] = DataReader.GetValue(i);
            Cmd.Connection.Close();
            return Values;
        }



        private List<object[]> ReadData()
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




        private byte[] NewSqlDataReaderBuild(byte[] Values, in byte StartValue, in byte EndValue)
        {
            Cmd.Connection.Open();
            DataReader = Cmd.ExecuteReader();
            if (DataReader.HasRows)
                while (DataReader.Read())
                    for (byte i = StartValue; i < EndValue; i++)
                        Values[i - StartValue] = Convert.ToByte(DataReader.GetValue(i));
            Cmd.Connection.Close();
            return Values;
        }

        private void AddProcedureParameter(in string ParamName, in object newParam)
        {
            Dictionary<string, MySqlDbType> types = new Dictionary<string, MySqlDbType>()
            {
                { "Boolean", MySqlDbType.Bit }, { "UInt16", MySqlDbType.UInt16 }, //SqlDbType.SmallInt
                { "Byte", MySqlDbType.UByte }, { "String", MySqlDbType.VarChar }, //MySqlDbType.TinyInt
                { "UInt32", MySqlDbType.UInt32 }, { "UInt64", MySqlDbType.UInt64 }
            };
            Cmd.Parameters.Add(ParamName, types[newParam.GetType().Name]).Value = newParam;
        }
        private void AddProcedureParametersX(in string[] paramNames, in object[] newParams)
        {
            for (byte i = 0; i < paramNames.Length; i++)
                AddProcedureParameter(paramNames[i], newParams[i]);
        }

        public void GetRecords()
        {
            NewStoredProcedureBuild("get_professional_competetion");
            AddProcedureParameter("id", Convert.ToUInt32(1));
            List<object[]> records = ReadData();
            for (int i = 0; i < records.Count; i++)
                for (int ii = 0; ii < records[i].Length; ii++)
                    Trace.WriteLine(records[i][ii]);
            Cmd.Parameters.Clear();
        }
        public void DeselectAllPlayers()
        {


            NewStoredProcedureBuild("DeselectPlayers");
            NewExecuteNonQueryBuild();
            Cmd.Parameters.Clear();
        }
        public void NewPlayer(in string NewPlayerLogin)
        {
            NewStoredProcedureBuild("AddNewProfile");
            AddProcedureParameter("@LOGIN", NewPlayerLogin);
            NewExecuteNonQueryBuild();
            Cmd.Parameters.Clear();
        }
        public void DeletePlayer(in string ExistingPlayerLogin)
        {
            NewStoredProcedureBuild("DeleteProfile");
            AddProcedureParameter("@LOGIN", ExistingPlayerLogin);
            NewExecuteNonQueryBuild();
            Cmd.Parameters.Clear();
        }
        public object[] CheckPlayerBag(in string PlayerLogin, in object[] Items)
        {
            NewStoredProcedureBuild("CheckBAG");
            AddProcedureParameter("@LOGIN", PlayerLogin);
            return NewSqlDataReaderBuild(Items, 2, 11);
        }
        public byte[] CheckPlayerEquip(in string PlayerLogin, in byte[] Equip)
        {
            NewStoredProcedureBuild("CheckEquip");
            AddProcedureParameter("@LOGIN", PlayerLogin);
            return NewSqlDataReaderBuild(Equip, 2, 10);
        }
        public object[] GetPlayerRecord(in string PlayerLogin, in object[] RecordValues)
        {
            NewStoredProcedureBuild("CheckPlayer");
            AddProcedureParameter("@LOGIN", PlayerLogin);
            return NewSqlDataReaderBuild(RecordValues, 1, 8);
        }
        public object[] GetPlayerStats(in string PlayerLogin, in object[] Params)
        {
            NewStoredProcedureBuild("CheckParams");
            AddProcedureParameter("@LOGIN", PlayerLogin);
            return NewSqlDataReaderBuild(Params, 1, 7);
        }
        public byte[] GetPlayerSettings(in string PlayerLogin, in byte[] Settings)
        {
            NewStoredProcedureBuild("CheckSettings");
            AddProcedureParameter("@LOGIN", PlayerLogin);
            return NewSqlDataReaderBuild(Settings, 2, 8);
        }
        public void SavePlayerBag(in string[] Parameters, in object[] Items)
        {
            NewStoredProcedureBuild("GetNewItemsBag");
            AddProcedureParametersX(Parameters, Items);
            NewExecuteNonQueryBuild();
        }
        public void SavePlayerEquip(in string[] Parameters, in object[] Equipment)
        {
            NewStoredProcedureBuild("GetNewEquip");
            AddProcedureParametersX(Parameters, Equipment);
            NewExecuteNonQueryBuild();
        }
        public void SavePlayerStats(in string[] Parameters, in object[] Stats)
        {
            NewStoredProcedureBuild("GetNewParams");
            AddProcedureParametersX(Parameters, Stats);
            NewExecuteNonQueryBuild();
        }
        public void SavePlayerSettings(in string[] Parameters, in object[] Settings)
        {
            NewStoredProcedureBuild("GetNewSettings");
            AddProcedureParametersX(Parameters, Settings);
            NewExecuteNonQueryBuild();
        }
        public void NewGameStart(in string PlayerLogin)
        {
            NewStoredProcedureBuild("NewGameStart");
            AddProcedureParameter("@LOGIN", PlayerLogin);
            NewExecuteNonQueryBuild();
        }

        public MySqlCommand Cmd { get; set; }
        public MySqlDataReader DataReader { get; set; }
        public MySqlConnection Con { get; set; }
    }
}
