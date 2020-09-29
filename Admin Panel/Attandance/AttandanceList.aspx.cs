using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Panel_Attandance_AttandanceList : System.Web.UI.Page
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
            FillFacultyDropDownList(Convert.ToInt32(Session["UserID"]));

            if (Session["UserID"] != null)
            {
                FillAttandanceGridView(Convert.ToInt32(Session["UserID"]));
            }
        }
    }
    #endregion Page_Load

    #region gvAttandance_RowCommand
    protected void gvAttandance_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteRecord" && e.CommandArgument != null)
        {
            DeleteAttandance(Convert.ToInt32(e.CommandArgument));
            FillAttandanceGridView(Convert.ToInt32(Session["UserID"]));
        }

    }
    #endregion gvAttandance_RowCommand



    #region FillAttandanceGridView
    private void FillAttandanceGridView(Int32 UserID)
    {
        using (SqlConnection objConnection = new SqlConnection(DatabaseConfig.ConnectionString))
        {
            using (SqlCommand objcmd = objConnection.CreateCommand())
            {
                try
                {
                    objConnection.Open();
                    objcmd.CommandType = CommandType.StoredProcedure;
                    objcmd.CommandText = "PR_Attandance_SelectAllByUserID";
                    objcmd.Parameters.AddWithValue("@UserID", UserID.ToString());
                    //objcmd.CommandText = "PR_Attandance_SelectAllByAttandanceDate";
                    //objcmd.Parameters.AddWithValue("@AttandanceDate", Convert.ToDateTime(txtAttandanceDate.Text));
                    SqlDataReader objSDR = objcmd.ExecuteReader();
                    gvAttandance.DataSource = objSDR;
                    gvAttandance.DataBind();
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

    #endregion FillAttandanceGridView

    #region DeleteAttandance
    private void DeleteAttandance(Int32 AttandanceID)
    {
        using (SqlConnection objConnection = new SqlConnection(DatabaseConfig.ConnectionString))
        {
            using (SqlCommand objcmd = objConnection.CreateCommand())
            {
                try
                {
                    objConnection.Open();
                    objcmd.CommandType = CommandType.StoredProcedure;
                    objcmd.CommandText = "PR_Attandance_DeleteByPK";
                    objcmd.Parameters.AddWithValue("@AttandanceID", AttandanceID);
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
    #endregion DeleteAttandance

    #region btnSearch_Click
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        using (SqlConnection objConnection = new SqlConnection(DatabaseConfig.ConnectionString))
        {
            using (SqlCommand objCmd = objConnection.CreateCommand())
            {
                try
                {
                    objConnection.Open();
                    objCmd.CommandType = CommandType.StoredProcedure;
                    //objCmd.CommandText = "[PR_Attandance_SearchByAttandanceDate]";
                    //objCmd.Parameters.AddWithValue("@AttandanceDate", Convert.ToDateTime(txtAttandanceDate.Text.Trim()));
                    objCmd.CommandText = "[PR_Attandance_SearchByFacultyName]";
                    objCmd.Parameters.AddWithValue("@FacultyID", Convert.ToString(ddlFaculty.SelectedValue));
                    SqlDataReader objSDR = objCmd.ExecuteReader();
                    gvAttandance.DataSource = objSDR;
                    gvAttandance.DataBind();
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
    #endregion btnSearch_Click

    #region Faculty FillDropDownList
    private void FillFacultyDropDownList(Int32 UserID)
    {
        using (SqlConnection objConnection = new SqlConnection(DatabaseConfig.ConnectionString))
        {
            using (SqlCommand objCmd = objConnection.CreateCommand())
            {
                try
                {
                    objConnection.Open();
                    objCmd.CommandType = CommandType.StoredProcedure;
                    objCmd.CommandText = "PR_Faculty_SelectDropDownList";
                    objCmd.Parameters.AddWithValue("@UserID", UserID);
                    SqlDataReader objSDRBranch = objCmd.ExecuteReader();
                    ddlFaculty.DataSource = objSDRBranch;
                    ddlFaculty.DataTextField = "FacultyName";
                    ddlFaculty.DataValueField = "FacultyID";
                    ddlFaculty.DataBind();
                    ddlFaculty.Items.Insert(0, "--- Select Faculty ---");
                    ddlFaculty.Items[0].Selected = true;
                    ddlFaculty.Items[0].Attributes["Disabled"] = "Disabled";
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
    #endregion Faculty FillDropDownList

}






