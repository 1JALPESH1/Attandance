using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Panel_Branch_BranchList : System.Web.UI.Page
{
    #region Page_Load
    private int UserName;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] != null)
        {
            lblmsg.Text = "Welcome     to     " + Session["UserName"].ToString();
        }

        if (!Page.IsPostBack)
        {
            if (Session["UserID"] != null)
            {
                FillBranchGridView(Convert.ToInt32(Session["UserID"]));
            }
        }

    }
    #endregion Page_Load

    #region gvBranch_RowCommand
    protected void gvBranch_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteRecord" && e.CommandArgument != null)
        {
            DeleteBranch(Convert.ToInt32(e.CommandArgument));
            FillBranchGridView(Convert.ToInt32(Session["UserID"]));
        }

    }
    #endregion gvBranch_RowCommand

    #region FillBranchGridView
    private void FillBranchGridView(Int32 UserID)
    {
         using (SqlConnection objConnection = new SqlConnection(DatabaseConfig.ConnectionString))
        {
            using (SqlCommand objcmd = objConnection.CreateCommand())
            {
                try
                {
                    objConnection.Open();
                    objcmd.CommandType = CommandType.StoredProcedure;
                    objcmd.CommandText = "PR_Branch_SelectAllByUserID";
                    objcmd.Parameters.AddWithValue("@UserID", UserID.ToString());
                    SqlDataReader objSDR = objcmd.ExecuteReader();
                    gvBranch.DataSource = objSDR;
                    gvBranch.DataBind();
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
    #endregion FillBranchGridView

    #region DeleteBranch
    private void DeleteBranch(Int32 BranchID)
    {
          using (SqlConnection objConnection = new SqlConnection(DatabaseConfig.ConnectionString))
        {
            using (SqlCommand objcmd = objConnection.CreateCommand())
            {
                try
                {
                  
                    objConnection.Open();
                    objcmd.CommandType = CommandType.StoredProcedure;
                    objcmd.CommandText = "PR_Branch_DeleteByPK";
                    objcmd.Parameters.AddWithValue("@BranchID", BranchID);
                    objcmd.ExecuteNonQuery();
                    objConnection.Close();
                }
                catch (Exception ex)
                {
                    lblMessage.Text = ex.Message.ToString();
                }
                finally
                {
                        objConnection.Close();
                }
            }
        }

    }
    #endregion DeleteBranch
}