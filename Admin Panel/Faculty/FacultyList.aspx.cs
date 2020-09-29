using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Panel_Faculty_FacultyList : System.Web.UI.Page
{
    #region Page_Load
    private int UserName;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] != null)
        {
            lblmsg.Text = "Welcome     to     " + Session[UserName].ToString();
        }

        if (!Page.IsPostBack)
        {
            if (Session["UserID"] != null)
            {
                FillFacultyGridView(Convert.ToInt32(Session["UserID"]));
            }
        }

    }
    #endregion Page_Load

    #region gvFaculty_RowCommand
    protected void gvFaculty_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteRecord" && e.CommandArgument != null)
        {
            DeleteFaculty(Convert.ToInt32(e.CommandArgument));
            FillFacultyGridView(Convert.ToInt32(Session["UserID"]));
        }

    }
    #endregion gvFaculty_RowCommand

    #region FillFacultyGridView
    private void FillFacultyGridView(Int32 UserID)
    {
         using (SqlConnection objConnection = new SqlConnection(DatabaseConfig.ConnectionString))
        {
            using (SqlCommand objcmd = objConnection.CreateCommand())
            {
                try
                {
                    objConnection.Open();
                    // lblMessage.Text ="Connection Is Now Open";
                    objcmd.CommandType = CommandType.StoredProcedure;
                    objcmd.CommandText = "PR_Faculty_SelectAllByUserID";
                    objcmd.Parameters.AddWithValue("@UserID", UserID.ToString());
                    SqlDataReader objSDR = objcmd.ExecuteReader();
                    gvFaculty.DataSource = objSDR;
                    gvFaculty.DataBind();
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
    #endregion FillFacultyGridView

    #region DeleteFaculty
    private void DeleteFaculty(Int32 FacultyID)
    {
        using (SqlConnection objConnection = new SqlConnection(DatabaseConfig.ConnectionString))
        {
            using (SqlCommand objcmd = objConnection.CreateCommand())
            {
                try
                {
                    objConnection.Open();
                    objcmd.CommandType = CommandType.StoredProcedure;
                    objcmd.CommandText = "PR_Faculty_DeleteByPK";
                    objcmd.Parameters.AddWithValue("@FacultyID", FacultyID);
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
    #endregion DeleteFaculty
}