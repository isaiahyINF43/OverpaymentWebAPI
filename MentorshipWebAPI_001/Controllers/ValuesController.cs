using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MentorshipWebAPI_001.Controllers
{
    public class ValuesController : ApiController
    {
        static List<String> strings = new List<String>()
        {
            "value0", "value1", "value2"
        };
        // GET api/values
        public IEnumerable<string> Get()
        {
            //return strings;
            string selectQuery = @"SELECT * FROM MyTable";
            using (System.Data.SQLite.SQLiteConnection conn = new System.Data.SQLite.SQLiteConnection("data source=C:/Users/Isaiah/Mentorship WebAPI SQLite DB Files/databaseFile2.db3"))
            {
                using (System.Data.SQLite.SQLiteCommand com = new System.Data.SQLite.SQLiteCommand(conn))
                {
                    conn.Open();                             // Open the connection to the database

                    com.CommandText = selectQuery;     // Set CommandText to our query that will select all rows from the table
                    com.ExecuteNonQuery();                  // Execute the query

                    using (System.Data.SQLite.SQLiteDataReader reader = com.ExecuteReader())
                    {
                        strings.Clear();
                        while (reader.Read())
                        {
                            strings.Add(reader["Key"] + " : " + reader["Value"]);     // Display the value of the key and value column for every row
                        }
                    }
                    conn.Close();        // Close the connection to the database
                }
            }
            return strings;
        }

        // GET api/values/5
        public string Get(int id)
        {
            return strings[id];
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
            //strings.Add(value);
            string insertNewRowQuery = @"INSERT INTO MyTable (Key,Value) Values ('key "
                                       + value + "', 'value " + value + "')";
            using (System.Data.SQLite.SQLiteConnection conn = new System.Data.SQLite.SQLiteConnection("data source=C:/Users/Isaiah/Mentorship WebAPI SQLite DB Files/databaseFile2.db3"))
            {
                using (System.Data.SQLite.SQLiteCommand com = new System.Data.SQLite.SQLiteCommand(conn))
                {
                    conn.Open();                             // Open the connection to the database

                    com.CommandText = insertNewRowQuery;     // Set CommandText to our query that will insert a row into the table
                    com.ExecuteNonQuery();                  // Execute the query

                    com.CommandText = "Select * FROM MyTable";      // Select all rows from our database table

                    using (System.Data.SQLite.SQLiteDataReader reader = com.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine(reader["Key"] + " : " + reader["Value"]);     // Display the value of the key and value column for every row
                        }
                    }
                    conn.Close();        // Close the connection to the database
                }
            }
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]Object value)
        {
            strings[id] = value;
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            strings.RemoveAt(id);
        }
    }
}
