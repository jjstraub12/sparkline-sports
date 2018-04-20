using System;
using System.Collections.Generic;
using System.Configuration;


namespace WebApplication1.Classes
{
    public static class Variables
    {
        public static string mlb_con_string = ConfigurationManager.ConnectionStrings["conn_MLB"].ToString();
        public static string nba_con_string = ConfigurationManager.ConnectionStrings["conn_NBA"].ToString();
        public static string ncaam_con_string = ConfigurationManager.ConnectionStrings["conn_NCAAM"].ToString();
        public static string sparkline_con_string = ConfigurationManager.ConnectionStrings["conn_Sparkline"].ToString();
    }
}
