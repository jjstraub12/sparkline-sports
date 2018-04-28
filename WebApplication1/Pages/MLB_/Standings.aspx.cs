using System;
using System.Data;
using System.Web.UI.WebControls;
using WebApplication1.Classes;

namespace WebApplication1.Pages.MLB
{
    public partial class Standings : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
                BindData();
        }

        protected void BindData()
        {
            try
            { 
                DataTable dt = Function_Classes.get_from_sql("SELECT * FROM dbo.vw_Standings_Current WHERE season = 2018 ORDER BY lg_name, div_rnk", Variables.mlb_con_string, false);

                CreateGridView(dt, "AL East", pnl_al);
                CreateGridView(dt, "AL Central", pnl_al);
                CreateGridView(dt, "AL West", pnl_al);

                CreateGridView(dt, "NL East", pnl_nl);
                CreateGridView(dt, "NL Central", pnl_nl);
                CreateGridView(dt, "NL West", pnl_nl);
            }
            catch(Exception ex)
            {
                Function_Classes.write_error(ex, Page.AppRelativeVirtualPath.ToString());
            }
        }

        protected void CreateGridView(DataTable dt, string division, Panel panel)
        {
            GridView gv = new GridView();
            gv.AutoGenerateColumns = false;

            DataTable dt_div = FilterToDivision(dt, division);

            gv.Columns.Add(CommonClass.img_path("img_path", "img"));
            gv.Columns.Add(CommonClass.bound_field("team_name", division, "team_name"));
            gv.Columns.Add(CommonClass.bound_field("W", "W", "all_columns"));
            gv.Columns.Add(CommonClass.bound_field("L", "L", "all_columns"));
            gv.Columns.Add(CommonClass.bound_field("win_loss_perc", "W %", "all_columns", "{0:0.000}"));
            gv.Columns.Add(CommonClass.bound_field("games_back", "GB", "all_columns", "{0:0.0}"));
            gv.Columns.Add(CommonClass.bound_field("home", "HOME", "all_columns"));
            gv.Columns.Add(CommonClass.bound_field("road", "ROAD", "all_columns"));
            gv.Columns.Add(CommonClass.bound_field("last_game", "HOME", "next_last"));
            gv.Columns.Add(CommonClass.bound_field("next_game", "ROAD", "next_last"));

            gv.DataSource = dt_div;
            gv.DataBind();
            gv.CssClass = "grid";
            gv.AlternatingRowStyle.CssClass = "alt";
            
            panel.Controls.Add(gv);
        }

        protected DataTable FilterToDivision(DataTable dt, string division)
        {
            DataView dv1 = dt.DefaultView;
            dv1.RowFilter = "lg_name = '" + division + "'";
            DataTable dt_new = dv1.ToTable();
            return dt_new;
        }
    }
}