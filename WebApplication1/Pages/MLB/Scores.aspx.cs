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
    public partial class Scores : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                BindData();
        }
        protected void BindData()
        {
            try
            {
                string date_selected = get_date_string();
                lblDate.Text = Convert.ToDateTime(date_selected).ToString("D");

                DataTable dt = Function_Classes.get_from_sql("SELECT * FROM dbo.vw_Scores_Date WHERE date_game = '" + date_selected + "' ORDER BY game_ord", Variables.mlb_con_string, false);

                grdScores.DataSource = dt;
                grdScores.DataBind();
            }
            catch (Exception ex)
            {
                Function_Classes.write_error(ex, Page.AppRelativeVirtualPath.ToString());
            }
        }

        protected string get_date_string()
        {
            var date_selected = Request.QueryString["date"];
            if (date_selected == null)
                return DateTime.Now.ToString("MM/dd/yyyy");
            else
                return Convert.ToDateTime(date_selected).ToString("MM/dd/yyyy");
        }
    }
}