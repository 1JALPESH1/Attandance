using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Panel_Branch_BranchAddEdit : System.Web.UI.Page
{
    #region Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["BranchID"] != null)
            {
                LoadControl(Convert.ToInt32(Request.QueryString["BranchID"]));
                lblPageHeader.Text = "Branch Edit";
            }
            else
            {
                lblPageHeader.Text = "Branch Add";
            }
        }
    }
    #endregion Page_Load

    #region LoadControl
    private void LoadControl(Int32 BranchID)
    {
         using (SqlConnection objConnection = new SqlConnection(DatabaseConfig.ConnectionString))
        {
            using (SqlCommand objcmd = objConnection.CreateCommand())
            {
                try
                {
                    objConnection.Open();
                    objcmd.CommandType = CommandType.StoredProcedure;
                    objcmd.CommandText = "PR_Branch_SelectByPK";
                    objcmd.Parameters.AddWithValue("@BranchID", BranchID);
                    SqlDataReader objSDR = objcmd.ExecuteReader();
                    if (objSDR.HasRows == true)
                    {
                        while (objSDR.Read() == true)
                        {
                            if (!objSDR["BranchName"].Equals(DBNull.Value))
                            {
                                txtBranchName.Text = objSDR["BranchName"].ToString();
                            }
                        }
                    }

                    objConnection.Close();
                }
                catch (Exception ex)
                {
                    lblMessage.Text = ex.Message.ToString();
                }
                finally
                {
                    if (objConnection.State == ConnectionState.Open)
                    objConnection.Close();
                }
            }
        }
    }
    #endregion LoadControl

    #region btnSave_Click
    protected void btnSave_Click(object sender, EventArgs e)
    {

        SqlString strBranchName = SqlString.Null;
        SqlString strBranchCode = SqlString.Null;

        if (txtBranchName.Text.Trim() != "")
            strBranchName = txtBranchName.Text.Trim();

       using (SqlConnection objConnection = new SqlConnection(DatabaseConfig.ConnectionString))
        {
            using (SqlCommand objcmd = objConnection.CreateCommand())
            {
                try
                {

                    // objConnection.ConnectionString = ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString;
                    objConnection.Open();
                    objcmd.CommandType = CommandType.StoredProcedure;
                    objcmd.Parameters.AddWithValue("@BranchName", strBranchName);

                    if (Request.QueryString["BranchID"] == null)
                    {
                        objcmd.CommandText = "PR_Branch_Insert";
                        objcmd.Parameters.AddWithValue("@CreationDate", DateTime.Now);
                        objcmd.Parameters.AddWithValue("@UserID", Session["UserID"].ToString());


                    }
                    else
                    {
                        objcmd.CommandText = "PR_Branch_UpdateByPK";
                        objcmd.Parameters.AddWithValue("@BranchID", Request.QueryString["BranchID"].ToString());
                        objcmd.Parameters.AddWithValue("@UserID", Session["UserID"].ToString());
           
                    }

                    objcmd.ExecuteNonQuery();
                    objConnection.Close();
                }
                catch (Exception ex)
                {
                    lblMessage.Text = ex.Message.ToString();
                }
                finally
                {
                    if (objConnection.State == ConnectionState.Open)
                        objConnection.Close();
                }
            }
        }



        if (Request.QueryString["BranchID"] == null)
        {
            lblMessage.Text = "Data  Inserted Successfully........";
            txtBranchName.Text = "";
            txtBranchName.Focus();
            //lblMessage.Text = "";
        }
        else
        {
            Response.Redirect("~/Admin Panel/Branch/BranchList.aspx");
        }

    }

    #endregion btnSave_Click
}