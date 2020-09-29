using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

public partial class Admin_Panel_Login : System.Web.UI.Page
{
    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    #endregion Page Load

    #region Login
    protected void btnLogin_Click(object sender, EventArgs e)
    {

        SqlConnection objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["AttandanceConnectionString"].ConnectionString);
        objConnection.Open();
        SqlCommand objcmd = objConnection.CreateCommand();
        objcmd.CommandType = CommandType.StoredProcedure;
        objcmd.CommandText = "PR_MasterUser_SelectByUserNamePassword";
        objcmd.Parameters.AddWithValue("@UserName", txtUserName.Text.Trim());
        objcmd.Parameters.AddWithValue("@Password", txtPassword.Text.Trim());
        SqlDataReader objSDR = objcmd.ExecuteReader();

        DataTable dtUser = new DataTable();
        dtUser.Load(objSDR);
        objConnection.Close();
        if (dtUser.Rows.Count > 0) 
        {
            foreach (DataRow drUser in dtUser.Rows)
            {
                if (!drUser["UserID"].Equals(DBNull.Value))
                {
                    Session["UserID"] = drUser["UserID"].ToString();
                } 
                if ( !drUser["FullName"].Equals(DBNull.Value))
                {
                    Session["FullName"] = drUser["FullName"].ToString();
                } 
                break;
            }
            Response.Redirect("~/Admin Panel/Test.aspx");
        }
        else
        {
            lblMessage.Text = "you're Username  or  Password is Incorrect";
            lblMessage.ForeColor = Color.Red;
            txtUserName.Focus();
        }
    }
    #endregion Login
}