using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.Classes;

namespace WebApplication1.Pages
{
    public partial class Steve : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btn_starters_Click(object sender, EventArgs e)
        {
            DataTable dt = Function_Classes.get_from_sql("SELECT * FROM [dbo].[tbl_Todays_Games] ORDER BY time_game, away_team_href", Variables.mlb_con_string, true);
            ExportToExcel(dt, "TodaysStarters.xls");
        }
        protected void btn_xfip_Click(object sender, EventArgs e)
        {

        }
        public void ExportToExcel(DataTable dt, string filename)
        {
            string attachment = "attachment; filename=" + filename;
            Response.ClearContent();
            Response.AddHeader("content-disposition", attachment);
            Response.ContentType = "application/vnd.ms-excel";
            string tab = "";
            foreach (DataColumn dc in dt.Columns)
            {
                Response.Write(tab + dc.ColumnName);
                tab = "\t";
            }
            Response.Write("\n");
            int i;
            foreach (DataRow dr in dt.Rows)
            {
                tab = "";
                for (i = 0; i < dt.Columns.Count; i++)
                {
                    Response.Write(tab + dr[i].ToString());
                    tab = "\t";
                }
                Response.Write("\n");
            }
            Response.End();
        }
    }
}