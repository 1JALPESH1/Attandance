using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Panel_Subject_SubjectList : System.Web.UI.Page
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
                FillSubjectGridView(Convert.ToInt32(Session["UserID"]));
            }
        }

    }
    #endregion Page_Load

    #region gvSubject_RowCommand
    protected void gvSubject_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteRecord" && e.CommandArgument != null)
        {
            DeleteSubject(Convert.ToInt32(e.CommandArgument));
            FillSubjectGridView(Convert.ToInt32(Session["UserID"]));
        }

    }
    #endregion gvSubject_RowCommand

    #region FillSubjectGridView
    private void FillSubjectGridView(Int32 UserID)
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
                    objcmd.CommandText = "PR_Subject_SelectAllByUserID";
                    objcmd.Parameters.AddWithValue("@UserID", UserID.ToString());
                    SqlDataReader objSDR = objcmd.ExecuteReader();
                    gvSubject.DataSource = objSDR;
                    gvSubject.DataBind();
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
    #endregion FillSubjectGridView

    #region DeleteSubject
    private void DeleteSubject(Int32 SubjectID)
    {
          using (SqlConnection objConnection = new SqlConnection(DatabaseConfig.ConnectionString))
        {
            using (SqlCommand objcmd = objConnection.CreateCommand())
            {
                try
                {
                    objConnection.Open();
                    objcmd.CommandType = CommandType.StoredProcedure;
                    objcmd.CommandText = "PR_Subject_DeleteByPK";
                    objcmd.Parameters.AddWithValue("@SubjectID", SubjectID);
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
    #endregion DeleteSubject

}