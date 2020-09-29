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

public partial class Admin_Panel_FacultyWiseSubject_FacultyWiseSubjectAddEdit : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

            FillFacultyDropDownList();
            if (Request.QueryString["FacultyWiseSubjectID"] != null)
            {
                LoadControls(Convert.ToInt32(Request.QueryString["FacultyWiseSubjectID"]));
                lblPageHeader.Text = "FacultyWiseSubject Edit";
                FillSubjectDropDownList();
            }
            else
            {
                lblPageHeader.Text = "FacultyWiseSubject Add";

            }


        }
    }
    #endregion Load Event

    #region Faculty FillDropDownList
    private void FillFacultyDropDownList()
    {
         using (SqlConnection objConnection = new SqlConnection(DatabaseConfig.ConnectionString))
        {
            using (SqlCommand objcmd = objConnection.CreateCommand())
            {
                try
                {
                    objConnection.Open();
                    objcmd.CommandType = CommandType.StoredProcedure;
                    objcmd.CommandText = "PR_Faculty_SelectDropDownList";
                    objcmd.Parameters.AddWithValue("@UserID", Session["UserID"].ToString());
                    SqlDataReader objSDRSubject = objcmd.ExecuteReader();
                    ddlFaculty.DataSource = objSDRSubject;
                    ddlFaculty.DataTextField = "FacultyName";
                    ddlFaculty.DataValueField = "FacultyID";
                    ddlFaculty.DataBind();
                    if (Request.QueryString["FacultyWiseSubjectID"] == null)
                    {
                        ddlFaculty.Items.Insert(0, "--- Select Faculty ---");
                        ddlFaculty.Items[0].Selected = true;
                        ddlFaculty.Items[0].Attributes["Disabled"] = "Disabled";
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
    #endregion Faculty FillDropDownList

    #region Subject FillDropDownList
    private void FillSubjectDropDownList()
    {
         using (SqlConnection objConnection = new SqlConnection(DatabaseConfig.ConnectionString))
        {
            using (SqlCommand objcmd = objConnection.CreateCommand())
            {
                try
                {
                    objConnection.Open();
                    objcmd.CommandType = CommandType.StoredProcedure;
                    objcmd.CommandText = "PR_Subject_SelectDropDownList";
                    objcmd.Parameters.AddWithValue("@UserID", Session["UserID"].ToString());
                    SqlDataReader objSDRSubject = objcmd.ExecuteReader();
                    ddlSubject.DataSource = objSDRSubject;
                    ddlSubject.DataTextField = "SubjectName";
                    ddlSubject.DataValueField = "SubjectID";
                    ddlSubject.DataBind();
                    if (Request.QueryString["FacultyWiseSubjectID"] != null)
                    {

                    }
                    else
                    {
                        ddlSubject.Items.Insert(0, "--- Select Subject ---");
                        ddlSubject.Items[0].Selected = true;
                        ddlSubject.Items[0].Attributes["Disabled"] = "Disabled";
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

    #endregion Subject FillDropDownList

    #region Load Controls
    private void LoadControls(Int32 FacultyWiseSubjectID)
    {
         using (SqlConnection objConnection = new SqlConnection(DatabaseConfig.ConnectionString))
        {
            using (SqlCommand objCmd = objConnection.CreateCommand())
            {
                try
                {
                    objConnection.Open();

                    objCmd.CommandType = CommandType.StoredProcedure;
                    objCmd.CommandText = "PR_FacultyWiseSubject_SelectByPK";
                    objCmd.Parameters.AddWithValue("@FacultyWiseSubjectID", FacultyWiseSubjectID);

                    SqlDataReader objSDR = objCmd.ExecuteReader();

                    if (objSDR.HasRows)
                    {
                        while (objSDR.Read())
                        {

                            if (!objSDR["SubjectID"].Equals(DBNull.Value))
                            {
                                ddlSubject.SelectedValue = objSDR["SubjectID"].ToString();
                            }
                            if (!objSDR["FacultyID"].Equals(DBNull.Value))
                            {
                                ddlFaculty.SelectedValue = objSDR["FacultyID"].ToString();
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
    #endregion Load Controls

    #region Button : Save
    protected void btnSave_Click(object sender, EventArgs e)
    {
        SqlInt32 strFacultyID = SqlInt32.Null;
        SqlInt32 strSubjectID = SqlInt32.Null;

        if (ddlFaculty.SelectedItem.Text.Trim() != "")
            strFacultyID = Convert.ToInt32(ddlFaculty.SelectedValue);

        if (ddlSubject.SelectedItem.Text.Trim() != "")
            strSubjectID = Convert.ToInt32(ddlSubject.SelectedValue);


        //Open the Connection
         using (SqlConnection objConnection = new SqlConnection(DatabaseConfig.ConnectionString))
        {
            using (SqlCommand objcmd = objConnection.CreateCommand())
            {
                try
                {
                         objConnection.Open();
                        SqlCommand objCmd = objConnection.CreateCommand();
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.Parameters.AddWithValue("@FacultyID", strFacultyID);
                        objCmd.Parameters.AddWithValue("@SubjectID", strSubjectID);


                        if (Request.QueryString["FacultyWiseSubjectID"] == null)
                        {
                            objCmd.CommandText = "PR_FacultyWiseSubject_Insert";
                            objCmd.Parameters.AddWithValue("@CreationDate", DateTime.Now);
                            objCmd.Parameters.AddWithValue("@UserID", Session["UserID"].ToString());
                        }
                        else
                        {
                            objCmd.CommandText = "PR_FacultyWiseSubject_UpdateByPK";
                            objCmd.Parameters.AddWithValue("@FacultyWiseSubjectID", Request.QueryString["FacultyWiseSubjectID"].ToString());
                            objCmd.Parameters.AddWithValue("@UserID", Session["UserID"].ToString());
                        }

                        objCmd.ExecuteNonQuery();
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
            if (Request.QueryString["FacultyWiseSubjectID"] == null)
            {
                lblMessage.Text = "Data Inserted Successfully....";

                ddlSubject.Items.Clear();


            }
            else
            {
                Response.Redirect("~/Admin Panel/FacultyWiseSubject/FacultyWiseSubjectList.aspx");
            }
    }
        
       
    #endregion Button : Save

    #region Faculty Index Changed
    protected void ddlFaculty_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillSubjectDropDownList();
    }
    #endregion Faculty Index Changed
}