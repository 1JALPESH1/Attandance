using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Panel_SignUp : System.Web.UI.Page
{
    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

        }
    }
    #endregion Page Load


    #region SignUp
    protected void btnSignUp_Click(object sender, EventArgs e)
    {
        #region Server Side Validation

        SqlString strErrorMassege = "";
        if (txtUserName.Text.Trim() == "")
        {
            strErrorMassege += " - Enter UserName <br/> ";
        }
        if (txtPassword.Text.Trim() == "")
        {
            strErrorMassege += " - Enter Password <br/> ";
        }
        if (strErrorMassege != "")
        {
            lblMessage.Text = strErrorMassege.ToString();
            lblMessage.ForeColor = Color.Red;
            return;
        }
        #endregion Server Side Validation
        SqlConnection objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["AttandanceConnectionString"].ConnectionString);
        SqlCommand objCmd = objConnection.CreateCommand();
        objCmd.CommandType = CommandType.StoredProcedure;
        objCmd.CommandText = "PR_MasterUser_CheckByUserName";
        objCmd.Parameters.AddWithValue("@UserName", txtUserName.Text.Trim());
        SqlDataAdapter sda = new SqlDataAdapter(objCmd);
        DataTable dtUser = new DataTable();
        sda.Fill(dtUser);

        objConnection.Open();

        objConnection.Close();
        if (dtUser != null && dtUser.Rows.Count > 0)
        {
            lblMessage.Text = "User Name " + txtUserName.Text.Trim() + " Is Already Exsist";
            lblMessage.ForeColor = Color.Red;
            txtUserName.Text = "";
            txtFullName.Text = "";
            txtPassword.Text = "";
            txtAddress.Text = "";
            txtEmailAddress.Text = "";
            txtMobileNo.Text = "";

            txtUserName.Focus();
        }
        else
        {

            SqlString strUserName = SqlString.Null;
            SqlString strPassword = SqlString.Null;
            SqlString strAddress = SqlString.Null;
            SqlString strFullName = SqlString.Null;
            SqlString strEmailAddress = SqlString.Null;
            SqlString strMobileNo = SqlString.Null;
            SqlInt32 strCountryID = SqlInt32.Null;
            SqlInt32 strStateID = SqlInt32.Null;
            SqlInt32 strCityID = SqlInt32.Null;
            SqlInt32 strContactCategoryID = SqlInt32.Null;

            if (txtUserName.Text.Trim() != "")
                strUserName = txtUserName.Text.Trim();
            if (txtPassword.Text.Trim() != "")
                strPassword = txtPassword.Text.Trim();
            if (txtAddress.Text.Trim() != "")
                strAddress = txtAddress.Text.Trim();
            if (txtFullName.Text.Trim() != "")
                strFullName = txtFullName.Text.Trim();
            if (txtEmailAddress.Text.Trim() != "")
                strEmailAddress = txtEmailAddress.Text.Trim();
            if (txtMobileNo.Text.Trim() != "")
                strMobileNo = txtMobileNo.Text.Trim();

            //Open the Connection
            SqlConnection objconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["AttandanceConnectionString"].ConnectionString);
            objconnection.Open();
            try
            {
                SqlCommand objcmd = objconnection.CreateCommand();
                objcmd.CommandType = CommandType.StoredProcedure;
                objcmd.CommandText = "PR_MasterUser_Insert";
                objcmd.Parameters.AddWithValue("@UserName", strUserName);
                objcmd.Parameters.AddWithValue("@Password", strPassword);
                objcmd.Parameters.AddWithValue("@FullName", strFullName);
                objcmd.Parameters.AddWithValue("@Address", strAddress);
                objcmd.Parameters.AddWithValue("@EmailID", strEmailAddress);
                objcmd.Parameters.AddWithValue("@MobileNo", strMobileNo);
                objcmd.Parameters.AddWithValue("@CreationDate", DateTime.Now);

                objcmd.ExecuteNonQuery();
                objconnection.Close();

                LoginUser();
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
                lblMessage.ForeColor = Color.Red;
            }
            finally
            {
                objconnection.Close();
                objConnection.Close();
            }
        }
    }
    #endregion SignUp


    #region LoginUser
    private void LoginUser()
    {

        SqlConnection objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["AttandanceConnectionString"].ConnectionString);
        SqlCommand objcmd = objConnection.CreateCommand();
        objcmd.CommandType = CommandType.StoredProcedure;
        objcmd.CommandText = "PR_MasterUser_SelectByUserNamePassword";
        objcmd.Parameters.AddWithValue("@username", txtUserName.Text);
        objcmd.Parameters.AddWithValue("@password", txtPassword.Text);

        SqlDataAdapter sda = new SqlDataAdapter(objcmd);
        DataTable dtUser = new DataTable();
        sda.Fill(dtUser);

        objConnection.Open();

        objConnection.Close();

        if (dtUser != null && dtUser.Rows.Count > 0)
        {
            foreach (DataRow drUser in dtUser.Rows)
            {
                if (!drUser["UserID"].Equals(DBNull.Value))
                    Session["UserID"] = drUser["UserID"].ToString();

                if (!drUser["UserName"].Equals(DBNull.Value))
                    Session["UserName"] = drUser["UserName"].ToString();

                break;
            }

            Response.Redirect("~/Admin Panel/Login.aspx");
        }
        else
        {

        }
    }
    #endregion LoginUser
}





