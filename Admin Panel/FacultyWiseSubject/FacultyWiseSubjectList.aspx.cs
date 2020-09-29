using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Panel_FacultyWiseSubject_FacultyWiseSubjectList : System.Web.UI.Page
{
    #region Page_Load
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
                FillFacultyWiseSubjectGridView(Convert.ToInt32(Session["UserID"]));
            }
        }

    }
    #endregion Page_Load

    #region gvFacultyWiseSubject_RowCommand
    protected void gvFacultyWiseSubject_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteRecord" && e.CommandArgument != null)
        {
            DeleteFacultyWiseSubject(Convert.ToInt32(e.CommandArgument));
            FillFacultyWiseSubjectGridView(Convert.ToInt32(Session["UserID"]));
        }

    }
    #endregion gvFacultyWiseSubject_RowCommand

    #region FillFacultyWiseSubjectGridView
    private void FillFacultyWiseSubjectGridView(Int32 UserID)
    {
        using (SqlConnection objConnection = new SqlConnection(DatabaseConfig.ConnectionString))
        {
            using (SqlCommand objcmd = objConnection.CreateCommand())
            {
                try
                {
                    objConnection.Open();
                    objcmd.CommandType = CommandType.StoredProcedure;
                    objcmd.CommandText = "PR_FacultyWiseSubject_SelectAllByUserID";
                    objcmd.Parameters.AddWithValue("@UserID", UserID.ToString());
                    SqlDataReader objSDR = objcmd.ExecuteReader();
                    gvFacultyWiseSubject.DataSource = objSDR;
                    gvFacultyWiseSubject.DataBind();
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
    #endregion FillFacultyWiseSubjectGridView

    #region DeleteFacultyWiseSubject
    private void DeleteFacultyWiseSubject(Int32 FacultyWiseSubjectID)
    {
        using (SqlConnection objConnection = new SqlConnection(DatabaseConfig.ConnectionString))
        {
            using (SqlCommand objcmd = objConnection.CreateCommand())
            {
                try
                {
                    objConnection.Open();
                    objcmd.CommandType = CommandType.StoredProcedure;
                    objcmd.CommandText = "PR_FacultyWiseSubject_DeleteByPK";
                    objcmd.Parameters.AddWithValue("@FacultyWiseSubjectID", FacultyWiseSubjectID);
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
    #endregion DeleteFacultyWiseSubject
}