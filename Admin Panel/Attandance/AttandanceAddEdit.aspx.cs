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

public partial class Admin_Panel_Attandance_AttandanceAddEdit : System.Web.UI.Page
{
    #region Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            lblNote.Text = "* SELECT ABSENT STUDENTS * ";
            FillFacultyDropDownList(Convert.ToInt32(Session["UserID"]));
            // FillBranchDropDownList(Convert.ToInt32(Session["UserID"]));
            //FillSubjectDropDownList(Convert.ToInt32(Session["UserID"]));
            //FillStudentCheckBoxList(Convert.ToInt32(Session["UserID"]));
            if (Request.QueryString["AttandanceID"] != null)
            {
                // lblMessage.Text = "AttandanceID = " + Request.QueryString["AttandanceID"].ToString();
                LoadControls(Convert.ToInt32(Request.QueryString["AttandanceID"]));
                lblPageHeader.Text = "Attandance Edit";
                FillBranchDropDownList(Convert.ToInt32(Session["UserID"]));
                FillSubjectDropDownList(Convert.ToInt32(Session["UserID"]));
                FillStudentCheckBoxList(Convert.ToInt32(Session["UserID"]));

            }
            else
            {
                lblPageHeader.Text = "Attandance Add";
            }
        }
    }
    #endregion Page_Load

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
                    if (Request.QueryString["AttandanceID"] != null)
                    {

                    }
                    else
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

    #region FillSubjectDropDownList
    private void FillSubjectDropDownList(Int32 UserID)
    {
        using (SqlConnection objConnection = new SqlConnection(DatabaseConfig.ConnectionString))
        {
            using (SqlCommand objCmd = objConnection.CreateCommand())
            {
                try
                {
                    objConnection.Open();
                    objCmd.CommandType = CommandType.StoredProcedure;
                    objCmd.CommandText = "PR_FacultyWiseSubject_DropDownList";
                    objCmd.Parameters.AddWithValue("@FacultyID", Convert.ToString(ddlFaculty.SelectedValue));
                    objCmd.Parameters.AddWithValue("@UserID", UserID);

                    SqlDataReader objSDRSubject = objCmd.ExecuteReader();
                    ddlSubject.DataSource = objSDRSubject;
                    ddlSubject.DataTextField = "SubjectName";
                    ddlSubject.DataValueField = "SubjectID";
                    ddlSubject.DataBind();
                    if (Request.QueryString["AttandanceID"] != null)
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
    #endregion FillSubjectDropDownList

    #region FillStudentCheckBoxList
    private void FillStudentCheckBoxList(Int32 UserID)
    {
        using (SqlConnection objConnection = new SqlConnection(DatabaseConfig.ConnectionString))
        {
            using (SqlCommand objCmd = objConnection.CreateCommand())
            {
                try
                {
                    objConnection.Open();
                    objCmd.CommandType = CommandType.StoredProcedure;

                    objCmd.CommandText = "PR_Student_FillCheckBoxList";
                    objCmd.Parameters.AddWithValue("@BranchID", ddlBranch.SelectedValue);
                    objCmd.Parameters.AddWithValue("@UserID", UserID);
                    SqlDataReader objSDRStudent = objCmd.ExecuteReader();
                    cblStudent.DataSource = objSDRStudent;
                    cblStudent.DataValueField = "StudentID";
                    cblStudent.DataTextField = "StudentName";
                    cblStudent.DataBind();
                    if (Request.QueryString["AttandanceID"] != null)
                    {


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
    #endregion FillStudentCheckBoxList

    #region LoadControls
    private void LoadControls(Int32 AttandanceID)
    {
        using (SqlConnection objConnection = new SqlConnection(DatabaseConfig.ConnectionString))
        {
            using (SqlCommand objCmd = objConnection.CreateCommand())
            {
                try
                {
                    objConnection.Open();
                    objCmd.CommandType = CommandType.StoredProcedure;
                    objCmd.CommandText = "PR_Attandance_SelectByPK";
                    objCmd.Parameters.AddWithValue("@AttandanceID", Convert.ToInt32(AttandanceID));
                    SqlDataReader objSDR = objCmd.ExecuteReader();

                    if (objSDR.HasRows)
                    {
                        while (objSDR.Read())
                        {

                            if (!objSDR["AttandanceDate"].Equals(DBNull.Value))
                            {
                                txtAttandanceDate.Text = Convert.ToDateTime(objSDR["AttandanceDate"]).ToString("yyyy-MM-dd");
                            }
                            if (!objSDR["Semester"].Equals(DBNull.Value))
                            {
                                txtSemester.Text = objSDR["Semester"].ToString();
                            }
                            if (!objSDR["FacultyID"].Equals(DBNull.Value))
                            {
                                ddlFaculty.SelectedValue = objSDR["FacultyID"].ToString();
                            }
                            if (!objSDR["BranchID"].Equals(DBNull.Value))
                            {
                                ddlBranch.SelectedValue = objSDR["BranchID"].ToString();
                            }
                            if (!objSDR["SubjectID"].Equals(DBNull.Value))
                            {
                                ddlSubject.SelectedValue = objSDR["SubjectID"].ToString();
                            }
                        }
                    }
                    objSDR.Close();
                    
                    SqlCommand objcmd = objConnection.CreateCommand();
                    objcmd.CommandType = CommandType.StoredProcedure;

                    objcmd.CommandText = "PR_AttandanceDetail_SelectAllByAttandanceID";
                    objcmd.Parameters.AddWithValue("@AttandanceID", Convert.ToInt32(AttandanceID));
                    objcmd.Parameters.AddWithValue("@UserID", Session["UserID"].ToString());

                    // objcmd.Parameters.AddWithValue("@StudentID", li.Value);
                    SqlDataReader objSDRDetails = objcmd.ExecuteReader();
                    DataTable dt =new DataTable();
                    dt.Load(objSDRDetails);
                   // cblStudent.DataSource=dt;
                    //cblStudent.DataBind();
                    //if (ds.Tables[0].Rows.Count != 0)
                    //{
                    //    CheckBoxList1.DataSource = ds;
                    //    CheckBoxList1.DataTextField = "Clg_Name";
                    //    CheckBoxList1.DataValueField = "Clg_Name";
                    //    CheckBoxList1.DataBind();
                    //}
                    //int[] arr= new int[dt.Rows.Count];
                    //int i=0;
                    //foreach(DataRow _row in dt.Rows){
                    //    arr[i]=_row;
                    //}
                    if (dt.Rows.Count > 0)
                    {
                        //while (dt.Rows.Count > 0)
                        //{
                            foreach (ListItem li in cblStudent.Items)
                            {
                                if (Convert.ToInt32(objSDRDetails["PresentStatus"].ToString()) == 0)
                                {
                                    //objcmd.Parameters.AddWithValue("@PresentStatus", 1);
                                    li.Selected = false;
                                    cblStudent.SelectedValue = objSDRDetails["StudentID"].ToString();
                                }
                                else if (Convert.ToInt32(objSDRDetails["PresentStatus"].ToString()) == 1)
                                {
                                    cblStudent.SelectedValue = objSDRDetails["StudentID"].ToString();
                                    li.Selected = true;
                                    //objcmd.Parameters.AddWithValue("@PresentStatus", 0);
                                }
                            }
                        //}
                    }
                    objSDRDetails.Close();
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
    #endregion LoadControls

    #region btnSave_Click
    protected void btnSave_Click(object sender, EventArgs e)
    {
        SqlString strAttandanceDate = SqlString.Null;
        SqlString strSemester = SqlString.Null;
        SqlInt32 strFacultyID = SqlInt32.Null;
        SqlInt32 strBranchID = SqlInt32.Null;
        SqlInt32 strSubjectID = SqlInt32.Null;

        if (txtAttandanceDate.Text.Trim() != "")
            strAttandanceDate = txtAttandanceDate.Text.Trim();
        if (txtSemester.Text.Trim() != "")
            strSemester = txtSemester.Text.Trim();

        if (ddlFaculty.SelectedIndex > 0)
            strFacultyID = Convert.ToInt32(ddlFaculty.SelectedValue);
        if (ddlBranch.SelectedItem.Text.Trim() != "" && ddlBranch.SelectedValue != "0")
            strBranchID = Convert.ToInt32(ddlBranch.SelectedValue);
        if (ddlSubject.SelectedItem.Text.Trim() != "" && ddlSubject.SelectedValue != "0")
            strSubjectID = Convert.ToInt32(ddlSubject.SelectedValue);

        using (SqlConnection objConnection = new SqlConnection(DatabaseConfig.ConnectionString))
        {
            using (SqlCommand objCmd = objConnection.CreateCommand())
            {
                try
                {

                    #region AttandanceInsert
                    objConnection.Open();

                    objCmd.CommandType = CommandType.StoredProcedure;
                    objCmd.Parameters.AddWithValue("@AttandanceDate", strAttandanceDate);
                    objCmd.Parameters.AddWithValue("@Semester", strSemester);
                    objCmd.Parameters.AddWithValue("@FacultyID", strFacultyID);
                    objCmd.Parameters.AddWithValue("@BranchID", strBranchID);
                    objCmd.Parameters.AddWithValue("@SubjectID", strSubjectID);
                    objCmd.Parameters.AddWithValue("@Total", cblStudent.Items.Count);

                    int Present=0,Absent=0;
                     foreach (ListItem li in cblStudent.Items)
                     {
                         if (li.Selected == false)
                         {
                             Present++;
                         }
                         else
                         {
                             Absent++;
                         }

                     }
                     objCmd.Parameters.AddWithValue("@Present", Present);
                     objCmd.Parameters.AddWithValue("@Absent", Absent);


                    if (Request.QueryString["AttandanceID"] == null)
                    {
                        objCmd.CommandText = "PR_Attandance_Insert";
                        objCmd.Parameters.AddWithValue("@CreationDate", DateTime.Now);
                        objCmd.Parameters.AddWithValue("@UserID", Session["UserID"].ToString());
                        objCmd.Parameters.Add("@AttandanceID", SqlDbType.Int).Direction = ParameterDirection.Output;

                        lblMessage.Text = "Data Inserted Successfully....";

                        objCmd.ExecuteNonQuery();


                        int AttandanceID = Convert.ToInt32(objCmd.Parameters["@AttandanceID"].Value.ToString());
                        lbl2.Text = AttandanceID.ToString();
                        // objConnection.Close();


                        #region AttandanceDetail Insert
                        //objConnection.Open();

                        foreach (ListItem li in cblStudent.Items)
                        {
                            SqlCommand objcmd = objConnection.CreateCommand();

                            objcmd.CommandType = CommandType.StoredProcedure;
                            objcmd.CommandText = "[PR_AttandanceDetail_Insert]";

                            objcmd.Parameters.AddWithValue("@AttandanceID", AttandanceID);
                            objcmd.Parameters.AddWithValue("@UserID", Session["UserID"].ToString());
                            objcmd.Parameters.AddWithValue("@CreationDate", DateTime.Now);
                            objcmd.Parameters.AddWithValue("@StudentID", li.Value);

                            if (li.Selected == true)
                            {
                                objcmd.Parameters.AddWithValue("@PresentStatus", 0);
                                lblAbsentNumber.Text += (li.Value + "<br>");
                            }
                            else if (li.Selected == false)
                            {
                                objcmd.Parameters.AddWithValue("@PresentStatus", 1);
                                lblPresentNumber.Text += (li.Value + "<br>");
                            }

                            objcmd.ExecuteNonQuery();
                        }
                        objConnection.Close();
                        txtAttandanceDate.Text = "";
                        txtSemester.Text = "";
                        ddlFaculty.Items.Clear();
                        ddlBranch.Items.Clear();
                        ddlSubject.Items.Clear();
                        cblStudent.Items.Clear();
                        txtAttandanceDate.Focus();

                        #endregion AttandanceDetail Insert
                    }
                    else
                    {
                        objCmd.CommandText = "PR_Attandance_UpdateByPK";
                        objCmd.Parameters.AddWithValue("@AttandanceID", Request.QueryString["AttandanceID"].ToString());
                        objCmd.Parameters.AddWithValue("@UserID", Session["UserID"].ToString());
                    }

                    #endregion AttandanceInsert
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


    #endregion btnSave_Click

    #region ddlFaculty_SelectedIndexChanged
    protected void ddlFaculty_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Request.QueryString["AttandanceID"] == null)
        {
            FillBranchDropDownList(Convert.ToInt32(Session["UserID"]));
            FillSubjectDropDownList(Convert.ToInt32(Session["UserID"]));
        }
    }
    #endregion ddlFaculty_SelectedIndexChanged

    #region ddlBranch_SelectedIndexChanged
    protected void ddlBranch_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Request.QueryString["AttandanceID"] == null)
        {

            FillStudentCheckBoxList(Convert.ToInt32(Session["UserID"]));

        }
    }
    #endregion ddlBranch_SelectedIndexChanged
}