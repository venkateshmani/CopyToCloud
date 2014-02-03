using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.SQLite;

using C2CWindowsDesktopClient.Exceptions;

namespace C2CWindowsDesktopClient.Controllers
{
    public class DatabaseManager
    {
        public DatabaseManager(string dropBoxPath)
        {
            DropBoxPath = dropBoxPath;
        }

        #region Properties

            private string m_connectionString = string.Empty;
            public readonly string DataBaseName = "Clipboard.db";
            public readonly string AppFolderName = "CloudClipboardApp";
            public string DropBoxPath
            {
                get;
                private set;
            }

            public string ConnectionString
            {
                get
                {
                    return "Data Source=" + DataBasePath + ";Version=3;";
                }
            }

            public string DataBasePath
            {
                get
                {
                    return Path.Combine(AppFolderPath, DataBaseName);
                }
            }

            public string AppFolderPath
            {
                get
                {
                    return Path.Combine(DropBoxPath, AppFolderName);
                }
            }

            public bool IsInstalled
            {
                get
                {
                    if (File.Exists(DataBasePath))
                    {
                        return true;
                    }

                    return false;
                }
            }

        #endregion 

        #region DatabaseCreation

            public void CreateClipboardDataBase()
            {
                if (!Directory.Exists(DropBoxPath))
                    throw new DropBoxNotInstalledException();

                if (!Directory.Exists(AppFolderPath))
                    Directory.CreateDirectory(AppFolderPath);

                //Create Database
                SQLiteConnection.CreateFile(DataBasePath);
            
                //Open Connection
                SQLiteConnection connection = new SQLiteConnection(ConnectionString);
                connection.Open();

                //Create Table
                string sqlToCreateNewTable = "CREATE TABLE [TextContent] ( [ID] INTEGER DEFAULT '0' NOT NULL PRIMARY KEY AUTOINCREMENT,[Content] TEXT  NOT NULL,[TimeStamp] TIMESTAMP DEFAULT CURRENT_TIMESTAMP NULL);";
                SQLiteCommand command = new SQLiteCommand(sqlToCreateNewTable, connection);
                command.ExecuteNonQuery();
                
                //Close the connection
                connection.Close();
            }

          

        #endregion 

        #region Insert

            public void InsertClipboardText(string text)
            {
                //Open Connection
                SQLiteConnection connection = new SQLiteConnection(ConnectionString);
                connection.Open();

                //Create Table
                string sqlToInsertLatestClipboard = "INSERT into TextContent (Content) values ('" + text + "')";
                SQLiteCommand command = new SQLiteCommand(sqlToInsertLatestClipboard, connection);
                command.ExecuteNonQuery();

                //Close the connection
                connection.Close();
            }

        #endregion 
    }
}
