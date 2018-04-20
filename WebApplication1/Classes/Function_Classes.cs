using System;
using System.Data;
using System.Data.SqlClient;
using System.Net;

namespace WebApplication1.Classes
{
    public static class Function_Classes
    {
        public static DataTable get_from_sql(string sql, string con, bool returnNull = true)
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(con))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();

                // create data adapter
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                // this will query your database and return the result to your datatable
                da.Fill(dt);
                conn.Close();
                da.Dispose();
            }

            if (dt.Rows.Count == 0 && returnNull)
                return null;
            else
                return dt;
        }

        public static void write_error(Exception ex, string path)
        {
            DataTable dt = get_from_sql("SELECT * FROM dbo.ErrorLog WHERE 1 = 2", Variables.sparkline_con_string, false);
            DataRow dr = dt.NewRow();
            dr["date_error"] = DateTime.Now;
            dr["app_virtual_path"] = path;
            dr["error_msg"] = ex.Message;
            dt.Rows.Add(dr);

            Common_Classes.update_database(dt, "dbo.ErrorLog", "DELETE FROM dbo.ErrorLog WHERE 1 = 2", Variables.sparkline_con_string);
        }
        public static void execute_sql(string sql, string con)
        {
            using (SqlConnection conn = new SqlConnection(con))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
        public static string get_string(string txt, string startSearch, string stopSearch, string inOut, int start = 0, int instance = 1, string after = null)
        {
            string newString = "";
            int txtStart;
            int txtStop;

            if (after == null)
                txtStop = start;
            else
                txtStop = txt.IndexOf(after, start);

            for (int c = 0; c < instance; c++)
            {
                if (txtStop > -1)
                {
                    txtStart = txt.IndexOf(startSearch, txtStop);

                    if (txtStart >= 0)
                    {
                        txtStop = txt.IndexOf(stopSearch, txtStart + startSearch.Length) + stopSearch.Length;
                        if (txtStop > stopSearch.Length)
                            newString = txt.Substring(txtStart, txtStop - txtStart);
                        else
                            return "";
                    }
                    else
                        return "";
                }
                else
                    return "";
            }

            if (inOut == "in")
            {
                newString = newString.Substring(startSearch.Length, newString.Length - startSearch.Length - stopSearch.Length);
            }

            return newString;
        }
        public static double? get_double(string txt, string startSearch, string stopSearch, string inOut, int start = 0, int instance = 1, string after = null, double returnEmpty = 999)
        {
            string newString = "";
            int txtStart;
            int txtStop;

            if (after == null)
                txtStop = start;
            else
                txtStop = txt.IndexOf(after, start);

            for (int c = 0; c < instance; c++)
            {
                txtStart = txt.IndexOf(startSearch, txtStop);
                if (txtStart > 0)
                {
                    txtStop = txt.IndexOf(stopSearch, txtStart + startSearch.Length) + stopSearch.Length;
                    if (txtStop > stopSearch.Length)
                        newString = txt.Substring(txtStart, txtStop - txtStart);
                    else
                        return returnEmpty;
                }
                else
                    return returnEmpty;
            }

            if (inOut == "in")
            {
                newString = newString.Substring(startSearch.Length, newString.Length - startSearch.Length - stopSearch.Length);
            }

            if (String.IsNullOrWhiteSpace(newString))
                return returnEmpty;
            else
                return Convert.ToDouble(newString);
        }
        public static string get_from_url(string url)
        {
            string text;
            using (WebClient client = new WebClient())
            {
                try
                {
                    text = client.DownloadString(url);
                }
                catch (Exception ex)
                {
                    execute_sql("INSERT INTO Sparkline_NCAAM.dbo.error_log VALUES (GETDATE(), '" + url + "', 'Error Retreiving URL')", Variables.ncaam_con_string);
                    return "";
                }
            }
            return text;
        }
        public static int count_string(string txt, string searchFor)
        {
            int cnt;
            int len1 = txt.Length;
            int len2 = txt.Replace(searchFor, "").Length;

            cnt = (len1 - len2) / searchFor.Length;
            return cnt;
        }
        public static string rmvChr(string txt)
        {
            return txt.Replace("&amp;", "&").Replace("&#x27;", "'");
        }
    }
}
