using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.Classes;

namespace WebApplication1.Pages.MLB
{
    public partial class Database : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                PopulateDropDownList();
                //ddl_Pitchers.Attributes["onChange"] = "ChangeLabelText();";
            }
        }

        protected void PopulateDropDownList()
        {
            ddl_Pitchers.DataSource = Function_Classes.get_from_sql("EXEC db_sp.get_pitcher_dropdown 2018", Variables.mlb_con_string, false);
            ddl_Pitchers.DataBind();
            ddl_Pitchers_SelectedIndexChanged(ddl_Pitchers, null);
        }

        protected void ddl_Pitchers_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbl_Selected.Text = ((DropDownList)sender).SelectedItem.Text;
            gv_PitcherInfo.DataSource = Function_Classes.get_from_sql("EXEC db_sp.get_pitcher_gamelog '" + ((DropDownList)sender).SelectedItem.Value + "', 2018", Variables.mlb_con_string, false);
            gv_PitcherInfo.DataBind();
        }

        //protected void txtSearch_TextChanged(object sender, EventArgs e)
        //{
        //    string helloworld = "POP A MOTHAFUCKA!";
        //}

        //public static List<string> GetPitcherList(string prefixText, int count)
        //{
        //    return AutoFillPitchers(prefixText);
        //}

        //private static List<string> AutoFillPitchers(string prefixText)
        //{
        //    DataTable dt = Function_Classes.get_from_sql("EXEC db_sp.get_pitcher_dropdown 2018", Variables.mlb_con_string, false);
        //    List<string> pitcherNames = new List<string>();
        //    foreach(DataRow dr in dt.Rows)
        //    {
        //        pitcherNames.Add(dr["displayName"].ToString());
        //    }
        //    return pitcherNames;
        //}
    }
}