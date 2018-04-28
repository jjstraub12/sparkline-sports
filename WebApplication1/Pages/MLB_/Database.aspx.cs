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
            string pitcher_id = ((DropDownList)sender).SelectedItem.Value.ToString();
            lbl_Selected.Text = ((DropDownList)sender).SelectedItem.Text;
            gv_PitcherInfo.DataSource = Function_Classes.get_from_sql("EXEC db_sp.get_pitcher_gamelog '" + pitcher_id + "', 2018", Variables.mlb_con_string, false);
            gv_PitcherInfo.DataBind();

            ch_ReleasePoint.Series[0].XValueMember = "x0";
            ch_ReleasePoint.Series[0].YValueMembers = "z0";
            ch_ReleasePoint.DataSource = Function_Classes.get_from_sql("EXEC db_sp.get_pitcher_pitches 2018, 456501", Variables.mlb_con_string, false);
            ch_ReleasePoint.DataBind();
        }
    }
}