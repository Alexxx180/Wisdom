using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Reflection;
using MySql.Data.MySqlClient;

namespace Wisdom.Model.Tools.DataBase
{
    public class MySQL : Sql
    {
        private string _dataBaseName;
        private string _hostName;

        public MySQL()
        {
            //Connection = ParentServerConnection();
        }
        
        public MySqlConnection NewConnection(string path)
        {
            return new MySqlConnection(path);
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

        internal override void SetConfiguration(in string dbName, in string host)
        {
            _dataBaseName = dbName;
            _hostName = host;
        }

        private static void ConnectionFault(string message)
        {
            //Log.Warning("Tried to connect to DB, no sucess: " + message);
            //
        }

        public override bool TestConnection(in string login, in string password)
        {
            MySqlConnection test = EnterConnection(login, password);
            try
            {
                test.Open();
                _connection = test;
            }
            catch (MySqlException dbException)
            {
                ConnectionFault(dbException.Message);
            }
            catch (InvalidOperationException operationException)
            {
                ConnectionFault(operationException.Message);
            }
            catch (Exception exception)
            {
                ConnectionFault(exception.Message);
            }
            finally
            {
                test.Close();
            }
            return _connection is null;
        }

        // Server connection
        private MySqlConnection EnterConnection
            (string login, string password)
        {
            //Log.Debug("Connecting to DB...");
            string source = "SERVER=" + _hostName + ";";
            string catalog = "DATABASE=" + _dataBaseName + ";";
            string user = "UID=" + login + ";";
            string pass = "PASSWORD=" + password + ";";
            return NewConnection(source + catalog + user + pass);
        }

        public override void Procedure(in string name)
        {
            Cmd = new MySqlCommand(name, _connection)
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
            {
                while (DataReader.Read())
                {
                    object[] row = new object[DataReader.FieldCount];
                    for (int i = 0; i < DataReader.FieldCount; i++)
                    {
                        row[i] = DataReader.GetValue(i);
                    }
                    table.Add(row);
                }
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
            {
                while (DataReader.Read())
                {
                    object cell = DataReader.GetValue(column);
                    table.Add(cell);
                }
            }
            Cmd.Connection.Close();
            return table;
        }

        public override List<object[]> ReadData(in byte start, in byte end)
        {
            Cmd.Connection.Open();
            DataReader = Cmd.ExecuteReader();
            List<object[]> table = new List<object[]>();
            int count = end - start;
            if (DataReader.HasRows)
            {
                while (DataReader.Read())
                {
                    object[] row = new object[count];
                    for (int i = 0, j = start; j < end; i++, j++)
                    {
                        row[i] = DataReader.GetValue(j);
                    }
                        
                    table.Add(row);
                }
            }
                
            Cmd.Connection.Close();
            return table;
        }

        public override void PassParameter(in string ParamName, in object newParam)
        {
            Dictionary<string, MySqlDbType> types = new Dictionary<string, MySqlDbType>()
            {
                { "Boolean", MySqlDbType.Bit }, { "UInt16", MySqlDbType.UInt16 },
                { "Byte", MySqlDbType.UByte }, { "String", MySqlDbType.VarChar },
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
        private MySqlConnection _connection { get; set; }
    }
}