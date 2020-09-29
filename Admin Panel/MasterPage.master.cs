using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Panel_MasterPage : System.Web.UI.MasterPage
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Session["UserID"] == null)
            {
                Response.Redirect("~/Admin Panel/Login.aspx");
            }
            if (Session["FullName"] != null)
            {
                lblUserName.Text = "Hiii..." + Session["FullName"].ToString();
            }
        }
    }
    #endregion Load Event

    #region Button Logout
    protected void lbLogout_Click(object sender, EventArgs e)
    {
        Session.Clear();
        Response.Redirect("~/Admin Panel/Login.aspx");
    }
    #endregion Button Logout
}
