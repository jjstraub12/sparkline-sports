using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;
using System.Reflection;
using System.Text.RegularExpressions;

namespace WebApplication1.Classes
{
    public static class Common_Classes
    {
        public static string Get_Empty(string value)
        {
            return value == null ? DBNull.Value.ToString() : value;
        }
        public static DataTable Get_DataTable<T>(IEnumerable<T> list)
        {
            Type type = typeof(T);
            var properties = type.GetProperties();
            DataTable dt = new DataTable();

            foreach (PropertyInfo info in properties)
            {
                dt.Columns.Add(new DataColumn(info.Name, Nullable.GetUnderlyingType(info.PropertyType) ?? info.PropertyType));
            }

            foreach (T entity in list)
            {
                object[] values = new object[properties.Length];
                for (int i = 0; i < properties.Length; i++)
                {
                    values[i] = properties[i].GetValue(entity);
                }

                dt.Rows.Add(values);
            }

            return dt;
        }

        public static string Get_Json(string url)
        {
            string json;
            using (WebClient client = new WebClient())
            {
                try
                {
                    json = client.DownloadString(url);
                }
                catch (Exception ex)
                {
                    json = ex.Message;
                    json = "";
                }
            }
            return json;
        }

        public static string Get_Between(string fullText, string firstString, string secondString, int occurrence = 1, string outin = "out")
        {
            int strStart = fullText.IndexOf(firstString);

            if (occurrence > 1)
            {
                for (int i = 1; i < occurrence; i++)
                {
                    strStart = fullText.IndexOf(firstString, strStart + 1);
                    if (strStart < 0)
                    {
                        occurrence = 0;
                    }
                }
            }

            if (strStart < 0)
                return "";
            else
            {
                int strStop = fullText.IndexOf(secondString, strStart + firstString.Length) + secondString.Length;
                if (strStop < secondString.Length)
                    return "";
                else
                {
                    if (outin == "out")
                        return fullText.Substring(strStart, strStop - strStart);
                    else
                        return fullText.Substring((strStart + firstString.Length), (strStop - secondString.Length) - (strStart + firstString.Length));
                }
            }
        }

        public static DataTable ConvertHTMLTablesToDataTable(string HTML)
        {
            DataTable dt = null;
            DataRow dr = null;
            //DataColumn dc = null;
            string TableExpression = "<table[^>]*>(.*?)</table>";
            string HeaderExpression = "<th[^>]*>(.*?)</th>";
            string RowExpression = "<tr[^>]*>(.*?)</tr>";
            string ColumnExpression = "<td[^>]*>(.*?)</td>";
            bool HeadersExist = false;
            int iCurrentColumn = 0;
            int iCurrentRow = 0;

            // Get a match for all the tables in the HTML    
            MatchCollection Tables = Regex.Matches(HTML, TableExpression, RegexOptions.Multiline | RegexOptions.Singleline | RegexOptions.IgnoreCase);

            // Loop through each table element    
            foreach (Match Table in Tables)
            {

                // Reset the current row counter and the header flag    
                iCurrentRow = 0;
                HeadersExist = false;

                // Add a new table to the DataSet    
                dt = new DataTable();

                // Create the relevant amount of columns for this table (use the headers if they exist, otherwise use default names)    
                if (Table.Value.Contains("<th"))
                {
                    // Set the HeadersExist flag    
                    HeadersExist = true;

                    // Get a match for all the rows in the table    
                    MatchCollection Headers = Regex.Matches(Table.Value, HeaderExpression, RegexOptions.Multiline | RegexOptions.Singleline | RegexOptions.IgnoreCase);

                    int hCnt = 0;
                    // Loop through each header element    
                    foreach (Match Header in Headers)
                    {
                        //dt.Columns.Add(Header.Groups(1).ToString);
                        dt.Columns.Add((Header.Groups[1].ToString() + "_" + hCnt.ToString()));
                        hCnt++;
                    }
                }
                else
                {
                    for (int iColumns = 1; iColumns <= Regex.Matches(Regex.Matches(Regex.Matches(Table.Value, TableExpression, RegexOptions.Multiline | RegexOptions.Singleline | RegexOptions.IgnoreCase)[0].ToString(), RowExpression, RegexOptions.Multiline | RegexOptions.Singleline | RegexOptions.IgnoreCase)[0].ToString(), ColumnExpression, RegexOptions.Multiline | RegexOptions.Singleline | RegexOptions.IgnoreCase).Count; iColumns++)
                    {
                        dt.Columns.Add("Column " + iColumns);
                    }
                }

                // Get a match for all the rows in the table    
                MatchCollection Rows = Regex.Matches(Table.Value, RowExpression, RegexOptions.Multiline | RegexOptions.Singleline | RegexOptions.IgnoreCase);

                // Loop through each row element    
                foreach (Match Row in Rows)
                {

                    // Only loop through the row if it isn't a header row    
                    if (!(iCurrentRow == 0 & HeadersExist == true))
                    {

                        // Create a new row and reset the current column counter    
                        dr = dt.NewRow();
                        iCurrentColumn = 0;

                        // Get a match for all the columns in the row    
                        MatchCollection Columns = Regex.Matches(Row.Value, ColumnExpression, RegexOptions.Multiline | RegexOptions.Singleline | RegexOptions.IgnoreCase);

                        // Loop through each column element    
                        foreach (Match Column in Columns)
                        {
                            DataColumnCollection columns = dt.Columns;
                            if (!columns.Contains("Column " + iCurrentColumn))
                            {
                                //Add Columns  
                                dt.Columns.Add("Column " + iCurrentColumn);
                            }
                            // Add the value to the DataRow    
                            dr[iCurrentColumn] = Column.Groups[1].ToString();
                            // Increase the current column    
                            iCurrentColumn += 1;

                        }
                        // Add the DataRow to the DataTable    
                        dt.Rows.Add(dr);
                    }
                    // Increase the current row counter    
                    iCurrentRow += 1;
                }
            }
            return (dt);
        }
        public static void update_database(DataTable dt, string table, string delete, string con_string)
        {
            if (dt != null)
            {
                try
                {
                    Function_Classes.execute_sql(delete, con_string);

                    using (var bulkCopy = new SqlBulkCopy(con_string, SqlBulkCopyOptions.KeepIdentity))
                    {
                        // my DataTable column names match my SQL Column names, so I simply made this loop. However if your column names don't match, just pass in which datatable name matches the SQL column name in Column Mappings
                        foreach (DataColumn col in dt.Columns)
                        {
                            bulkCopy.ColumnMappings.Add(col.ColumnName, col.ColumnName);
                        }

                        bulkCopy.BulkCopyTimeout = 600;
                        bulkCopy.DestinationTableName = table;
                        bulkCopy.WriteToServer(dt);
                    }
                }
                catch (Exception ex)
                {
                    Common_Classes.send_message(ex.InnerException.ToString() + ": " + delete);
                }
            }
        }

        public static void send_message(string message)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("SparklineSports@gmail.com");
                mail.To.Add("3179197979@txt.att.net");
                //mail.To.Add("8124839145@txt.att.net"); - CLEO
                mail.Subject = "Sparkline Message";
                mail.Body = message;

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("SparklineSports@gmail.com", "SAAdmin#123");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
            }
            catch (Exception exc)
            {
            }
        }

        public static string book_name(string book_id)
        {
            switch (book_id)
            {
                case "0":
                    return "Opener";
                case "19":
                    return "5Dimes";
                case "93":
                    return "Bookmaker";
                case "123":
                    return "Diamond Sportsbook";
                case "169":
                    return "Heritage";
                case "180":
                    return "Intertops";
                case "238":
                    return "Pinnacle Sports";
                case "1096":
                    return "BetOnline";
                case "1275":
                    return "JustBet";
                case "999991":
                    return "Sportsbetting";
                case "999996":
                    return "Bovada";
                default:
                    return "N/A";
            }
        }

        public class SingleOrArrayConverter<T> : JsonConverter
        {
            public override bool CanConvert(Type objectType)
            {
                return (objectType == typeof(List<T>));
            }

            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                JToken token = JToken.Load(reader);
                if (token.Type == JTokenType.Array)
                {
                    return token.ToObject<List<T>>();
                }
                return new List<T> { token.ToObject<T>() };
            }

            public override bool CanWrite
            {
                get { return false; }
            }

            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                throw new NotImplementedException();
            }
        }
    }
}