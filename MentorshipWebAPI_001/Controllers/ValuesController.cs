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
        public Object Get()
        {
            List<OverPaymentDetailResponse> overpaymentList = new List<OverPaymentDetailResponse>();
            strings.Clear();
            string selectQuery = @"SELECT * FROM OverPaymentDetail";
            try
            {
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

                                var debugg = reader["CreateDate"];
                                var debugg2 = Convert.ToDateTime(reader["CreateDate"]);
                                var debugg3 = DateTime.UtcNow;
                                var debugg4 = DateTime.UtcNow.ToString();
                                var debugg5 = System.Math.Round(Convert.ToDecimal(reader["OverpaymentAmt"]),2);
                                var debugg6 = decimal.Round(Convert.ToDecimal(reader["OverpaymentAmt"]), 2, MidpointRounding.AwayFromZero);
                                var debugg7 = String.Format("{0:0.00}", Convert.ToDecimal(reader["OverpaymentAmt"]));

                                //Console.WriteLine(debugg);

                                overpaymentList.Add(new OverPaymentDetailResponse()
                                {
                                    memberId = Convert.ToInt32(reader["MemberID"]),
                                    claimNumber = reader["ClaimNumber"].ToString(),
                                    balanceAmt = String.Format("{0:0.00}", Convert.ToDecimal(reader["BalanceAmt"])),
                                    overpaymentAmt = String.Format("{0:0.00}", Convert.ToDecimal(reader["OverpaymentAmt"])),
                                    createDate = Convert.ToDateTime(reader["CreateDate"]),
                                    updateDate = Convert.ToDateTime(reader["LastUpdated"]),
                                    amtPaid = String.Format("{0:0.00}", Convert.ToDecimal(reader["OverpaymentAmt"]) - Convert.ToDecimal(reader["BalanceAmt"])),
                                    daysLeftToPay = (int)(Convert.ToDateTime(reader["CreateDate"]).Subtract(DateTime.UtcNow).TotalDays + 90)
                                });
                            }
                        }
                        conn.Close();        // Close the connection to the database
                    }
                }
            } catch (Exception e)
            {
                Console.WriteLine("Data of error: " + e.Data);
                Console.WriteLine("Source of error: " + e.Source);
            }
            //return strings;
            //return JsonConvert.SerializeObject(overpaymentList, Newtonsoft.Json.Formatting.Indented);
            return overpaymentList;
        }

        // GET api/values/5
        public Object Get(int id)
        {
            List<OverPaymentDetailResponse> overpaymentList = new List<OverPaymentDetailResponse>();
            strings.Clear();
            string selectQuery = @"SELECT * FROM OverPaymentDetail WHERE MemberID = " + id;
            
            try
            {
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

                                /*var debugg = reader["CreateDate"];
                                var debugg2 = Convert.ToDateTime(reader["CreateDate"]);
                                var debugg3 = DateTime.UtcNow;
                                var debugg4 = DateTime.UtcNow.ToString();*/

                                //Console.WriteLine(debugg);

                                overpaymentList.Add(new OverPaymentDetailResponse()
                                {
                                    memberId = Convert.ToInt32(reader["MemberID"]),
                                    claimNumber = reader["ClaimNumber"].ToString(),
                                    balanceAmt = String.Format("{0:0.00}", Convert.ToDecimal(reader["BalanceAmt"])),
                                    overpaymentAmt = String.Format("{0:0.00}", Convert.ToDecimal(reader["OverpaymentAmt"])),
                                    createDate = Convert.ToDateTime(reader["CreateDate"]),
                                    updateDate = Convert.ToDateTime(reader["LastUpdated"]),
                                    amtPaid = String.Format("{0:0.00}", Convert.ToDecimal(reader["OverpaymentAmt"]) - Convert.ToDecimal(reader["BalanceAmt"])),
                                    daysLeftToPay = (int)(Convert.ToDateTime(reader["CreateDate"]).Subtract(DateTime.UtcNow).TotalDays + 90)
                                });
                            }
                        }
                        conn.Close();        // Close the connection to the database
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Data of error: " + e.Data);
                Console.WriteLine("Source of error: " + e.Source);
            }
            //return strings;
            //return JsonConvert.SerializeObject(overpaymentList, Newtonsoft.Json.Formatting.Indented);
            return overpaymentList;
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
        public bool Delete(string id)
        {
            //strings.RemoveAt(id);
            {
                bool deleted = false;
                //strings.Clear();
                string deleteQuery = @"DELETE FROM OverpaymentDetail WHERE ClaimNumber = '" + id + "'";

                try
                {
                    //using (System.Data.SQLite.SQLiteConnection conn = new System.Data.SQLite.SQLiteConnection(@"Data Source=C:/Users/Isaiah Yu/SQLite Databases/Overpayment_WebAPI.db", true))
                    using (System.Data.SQLite.SQLiteConnection conn = new System.Data.SQLite.SQLiteConnection(@"Data Source=C:\inetpub\wwwroot\overpayment_webapi\database\Overpayment_WebAPI.db", true))
                    {
                        using (System.Data.SQLite.SQLiteCommand com = new System.Data.SQLite.SQLiteCommand(conn))
                        {
                            conn.Open();                             // Open the connection to the database

                            com.CommandText = deleteQuery;     // Set CommandText to our query that will select all rows from the table
                            com.ExecuteNonQuery();                  // Execute the query
                            conn.Close();        // Close the connection to the database
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Data of error: " + e.Data);
                    Console.WriteLine("Source of error: " + e.Source);
                }
                //return strings;
                //return JsonConvert.SerializeObject(overpaymentList, Newtonsoft.Json.Formatting.Indented);
                deleted = true;
                return deleted;
            }
        }
    }
}
