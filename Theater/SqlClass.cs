using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace Theater
{
    class SqlClass
    {
        public static SQLiteConnection connection;
        public static List<string> Select(string Text)
        {
            List<string> results = new List<string>();
            SQLiteCommand command = new SQLiteCommand(Text, connection);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                    if (reader.IsDBNull(i))
                    {
                    
                    }
                     else
                    {
                        Console.WriteLine(reader.GetDataTypeName(i));
                        if (reader.GetDataTypeName(i) == "INTEGER")
                        {
                            Int64 number = reader.GetInt64(i);
                            results.Add(number.ToString());
                        }
                        else if (reader.GetDataTypeName(i) == "")
                        {

                        }
                        else
                        {
                            results.Add(reader.GetString(i));
                        }
                    }
            }
            reader.Close();
            command.Dispose();
            return results;
        }
        public static void Insert(string Text)
        {
            SQLiteCommand command = new SQLiteCommand(Text, connection);
            SQLiteDataReader reader = command.ExecuteReader();
            reader.Close();
            command.Dispose();
        }
    }
}
