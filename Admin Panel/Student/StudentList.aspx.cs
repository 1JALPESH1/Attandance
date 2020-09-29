using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Panel_Student_StudentList : System.Web.UI.Page
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
                FillStudentGridView(Convert.ToInt32(Session["UserID"]));
            }
        }

    }
    #endregion Page_Load

    #region gvStudent_RowCommand
    protected void gvStudent_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteRecord" && e.CommandArgument != null)
        {
            DeleteStudent(Convert.ToInt32(e.CommandArgument));
            FillStudentGridView(Convert.ToInt32(Session["UserID"]));
        }

    }
    #endregion gvStudent_RowCommand

    #region FillStudentGridView
    private void FillStudentGridView(Int32 UserID)
    {
          using (SqlConnection objConnection = new SqlConnection(DatabaseConfig.ConnectionString))
        {
            using (SqlCommand objcmd = objConnection.CreateCommand())
            {
                try
                {
                    objConnection.Open();
                    objcmd.CommandType = CommandType.StoredProcedure;
                    objcmd.CommandText = "PR_Student_SelectAllByUserID";
                    objcmd.Parameters.AddWithValue("@UserID", UserID.ToString());
                    SqlDataReader objSDR = objcmd.ExecuteReader();
                    gvStudent.DataSource = objSDR;
                    gvStudent.DataBind();
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
    #endregion FillStudentGridView

    #region DeleteStudent
    private void DeleteStudent(Int32 StudentID)
    {
          using (SqlConnection objConnection = new SqlConnection(DatabaseConfig.ConnectionString))
        {
            using (SqlCommand objcmd = objConnection.CreateCommand())
            {
                try
                {
                    objConnection.Open();
                    objcmd.CommandType = CommandType.StoredProcedure;
                    objcmd.CommandText = "PR_Student_DeleteByPK";
                    objcmd.Parameters.AddWithValue("@StudentID", StudentID);
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
    #endregion DeleteStudent
}