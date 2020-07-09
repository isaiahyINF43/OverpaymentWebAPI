using MentorshipWebAPI_001.Classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Text.Json;

namespace MentorshipWebAPI_001.Controllers
{
    public class ValuesController : ApiController
    {
        static List<String> strings = new List<String>()
        {
        };
        // GET api/values
        public IEnumerable<string> Get()
        {
            //return strings;
            strings.Clear();
            string selectQuery = @"SELECT * FROM OverPaymentDetail";
            //using (System.Data.SQLite.SQLiteConnection conn = new System.Data.SQLite.SQLiteConnection(@"Data Source=C:/Users/Isaiah Yu/SQLite Databases/Overpayment_WebAPI.db", true))
            using (System.Data.SQLite.SQLiteConnection conn = new System.Data.SQLite.SQLiteConnection(@"Data Source=C:\inetpub\wwwroot\overpayment_webapi\database\Overpayment_WebAPI.db", true))
            {
                using (System.Data.SQLite.SQLiteCommand com = new System.Data.SQLite.SQLiteCommand(conn))
                {
                    conn.Open();                             // Open the connection to the database

                    com.CommandText = selectQuery;     // Set CommandText to our query that will select all rows from the table
                    com.ExecuteNonQuery();                  // Execute the query

                    using (System.Data.SQLite.SQLiteDataReader reader = com.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            strings.Add(
                                "ID : " + reader["ID"].ToString() + 
                                "OverPaymentID : " + reader["OverPaymentID"].ToString() +
                                "MemberID : " + reader["MemberID"].ToString() +
                                "ClaimNumber : " + reader["ClaimNumber"].ToString() +
                                "BalanceAmt : " + reader["BalanceAmt"].ToString() +
                                "OverPaymentAmt : " + reader["OverPaymentAmt"].ToString() +
                                "CreateDate : " + reader["CreateDate"].ToString() +
                                "SysSrcSyncDate : " + reader["SysSrcSyncDate"].ToString() +
                                "LastUpdated : " + reader["LastUpdated"].ToString()
                                );     // Display the value of the key and value column for every row
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
        public void Post([FromBody]Object value)
        {
            //strings.Add(value);
            //OverPaymentDetailReceive overPaymentDetailReceive = System.Text.Json.JsonSerializer.Deserialize<OverPaymentDetailReceive>(value.ToString());
            OverPaymentDetailReceive overPaymentDetailReceive = JsonConvert.DeserializeObject<OverPaymentDetailReceive>(value.ToString());
            string insertNewRowQuery = @"INSERT INTO OverPaymentDetail (OverPaymentID, MemberID, ClaimNumber, BalanceAmt, OverPaymentAmt, CreateDate, SysSrcSyncDate, LastUpdated) Values (
                                        " + overPaymentDetailReceive.OverPaymentID +
                                        "," + overPaymentDetailReceive.MemberID +
                                        ",'" + overPaymentDetailReceive.ClaimNumber +
                                        "'," + overPaymentDetailReceive.BalanceAmt +
                                        "," + overPaymentDetailReceive.OverPaymentAmt +
                                        ",'" + overPaymentDetailReceive.CreateDate +
                                        "','" + overPaymentDetailReceive.SysSrcSyncDate +
                                        "','" + overPaymentDetailReceive.LastUpdated +
                                        "')";
            using (System.Data.SQLite.SQLiteConnection conn = new System.Data.SQLite.SQLiteConnection(@"Data Source = C:\inetpub\wwwroot\overpayment_webapi\database\Overpayment_WebAPI.db"))
            {
                using (System.Data.SQLite.SQLiteCommand com = new System.Data.SQLite.SQLiteCommand(conn))
                {
                    conn.Open();                             // Open the connection to the database

                    com.CommandText = insertNewRowQuery;     // Set CommandText to our query that will insert a row into the table
                    com.ExecuteNonQuery();                  // Execute the query

                    /*com.CommandText = "Select * FROM MyTable";      // Select all rows from our database table

                    using (System.Data.SQLite.SQLiteDataReader reader = com.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine(reader["Key"] + " : " + reader["Value"]);     // Display the value of the key and value column for every row
                        }
                    }*/
                    conn.Close();        // Close the connection to the database
                }
            }
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
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
