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
            if(!IsPostBack)
                txt_date.Text = DateTime.Now.ToString("MM/dd/yyyy");
        }
        protected void btn_starters_Click(object sender, EventArgs e)
        {
            DataTable dt = Function_Classes.get_from_sql("EXEC export.day_xfip '" + txt_date.Text + "'", Variables.mlb_con_string, true);
            string date_string = Convert.ToDateTime(txt_date.Text).ToString("yyyyMMdd");
            ExportToExcel(dt, "GameInfo_" + date_string + ".xls");
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
                    if (dr[i].ToString() == "\n\t")
                        dr[i] = "";
                    Response.Write(tab + dr[i].ToString());
                    tab = "\t";
                }
                Response.Write("\n");
            }
            Response.End();
        }
    }
}