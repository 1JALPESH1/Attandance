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

public partial class Admin_Panel_Student_StudentAddEdit : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillBranchDropDownList(Convert.ToInt32(Session["UserID"]));
            if (Request.QueryString["StudentID"] != null)
            {
                LoadControls(Convert.ToInt32(Request.QueryString["StudentID"]));
                lblPageHeader.Text = "Student Edit";
                FillBranchDropDownList(Convert.ToInt32(Session["UserID"]));
            }
            else
            {
                lblPageHeader.Text = "Student Add";

            }

        }
    }
    #endregion Load Event

    #region Branch FillDropDownList
    private void FillBranchDropDownList(Int32 UserID)
    {
        using (SqlConnection objConnection = new SqlConnection(DatabaseConfig.ConnectionString))
        {
            using (SqlCommand objCmd = objConnection.CreateCommand())
            {
                try
                {
                    objConnection.Open();
                    objCmd.CommandType = CommandType.StoredProcedure;
                    objCmd.CommandText = "PR_Branch_SelectDropDownList";
                    objCmd.Parameters.AddWithValue("@UserID", UserID);
                    SqlDataReader objSDRBranch = objCmd.ExecuteReader();
                    ddlBranch.DataSource = objSDRBranch;
                    ddlBranch.DataTextField = "BranchName";
                    ddlBranch.DataValueField = "BranchID";
                    ddlBranch.DataBind();
                    if (Request.QueryString["StudentID"] == null)
                    {
                        ddlBranch.Items.Insert(0, "--- Select Branch ---");
                        ddlBranch.Items[0].Selected = true;
                        ddlBranch.Items[0].Attributes["Disabled"] = "Disabled";
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
    #endregion Branch FillDropDownList


    #region Load Controls
    private void LoadControls(Int32 StudentID)
    {
        using (SqlConnection objConnection = new SqlConnection(DatabaseConfig.ConnectionString))
        {
            using (SqlCommand objCmd = objConnection.CreateCommand())
            {
                try
                {
                    objConnection.Open();
                    objCmd.CommandType = CommandType.StoredProcedure;
                    objCmd.CommandText = "PR_Student_SelectByPK";
                    objCmd.Parameters.AddWithValue("@StudentID", StudentID);

                    SqlDataReader objSDR = objCmd.ExecuteReader();

                    if (objSDR.HasRows)
                    {
                        while (objSDR.Read())
                        {
                            if (!objSDR["StudentName"].Equals(DBNull.Value))
                            {
                                txtStudentName.Text = objSDR["StudentName"].ToString();
                            }
                            if (!objSDR["EnrollmentNo"].Equals(DBNull.Value))
                            {
                                txtEnrollmentNo.Text = objSDR["EnrollmentNo"].ToString();
                            }

                            if (!objSDR["BranchID"].Equals(DBNull.Value) && ddlBranch.SelectedValue != "0")
                            {
                                ddlBranch.SelectedValue = objSDR["BranchID"].ToString();
                            }
                            if (!objSDR["Semester"].Equals(DBNull.Value))
                            {
                                txtSemester.Text = objSDR["Semester"].ToString();
                            }
                            if (!objSDR["BatchNo"].Equals(DBNull.Value))
                            {
                                txtBatchNo.Text = objSDR["BatchNo"].ToString();
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

        SqlString strStudentName = SqlString.Null;
        SqlString strEnrollmentNo = SqlString.Null;
        SqlInt32 strBranchID = SqlInt32.Null;
        SqlString strSemester = SqlString.Null;
        SqlString strBatchNo = SqlString.Null;

        if (txtStudentName.Text.Trim() != "")
            strStudentName = txtStudentName.Text.Trim();
        if (txtEnrollmentNo.Text.Trim() != "")
            strEnrollmentNo = txtEnrollmentNo.Text.Trim();
        if (ddlBranch.SelectedItem.Text.Trim() != "")
            strBranchID = Convert.ToInt32(ddlBranch.SelectedValue);
        if (txtSemester.Text.Trim() != "")
            strSemester = txtSemester.Text.Trim();
        if (txtBatchNo.Text.Trim() != "")
            strBatchNo = txtBatchNo.Text.Trim();


        //Open the Connection
        using (SqlConnection objConnection = new SqlConnection(DatabaseConfig.ConnectionString))
        {
            using (SqlCommand objCmd = objConnection.CreateCommand())
            {
                try
                {
                    objConnection.Open();
                    objCmd.CommandType = CommandType.StoredProcedure;
                    objCmd.Parameters.AddWithValue("@StudentName", strStudentName);
                    objCmd.Parameters.AddWithValue("@EnrollmentNo", strEnrollmentNo);
                    objCmd.Parameters.AddWithValue("@BranchID", strBranchID);
                    objCmd.Parameters.AddWithValue("@Semester", strSemester);
                    objCmd.Parameters.AddWithValue("@BatchNo", strBatchNo);



                    if (Request.QueryString["StudentID"] == null)
                    {
                        objCmd.CommandText = "PR_Student_Insert";
                        objCmd.Parameters.AddWithValue("@CreationDate", DateTime.Now);
                        objCmd.Parameters.AddWithValue("@UserID", Session["UserID"].ToString());

                    }
                    else
                    {
                        objCmd.CommandText = "PR_Student_UpdateByPK";
                        objCmd.Parameters.AddWithValue("@StudentID", Request.QueryString["StudentID"].ToString());
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

        if (Request.QueryString["StudentID"] == null)
        {
            lblMessage.Text = "Data Inserted Successfully....";
            txtStudentName.Text = "";
            txtEnrollmentNo.Text = "";
            txtSemester.Text = "";
            txtBatchNo.Text = "";

            txtStudentName.Focus();
        }
        else
        {
            Response.Redirect("~/Admin Panel/Student/StudentList.aspx");
        }

    #endregion Button : Save

    }
}   
