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

public partial class Admin_Panel_Subject_SubjectAddEdit : System.Web.UI.Page
{
    #region Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["SubjectID"] != null)
            {
                LoadControl(Convert.ToInt32(Request.QueryString["SubjectID"]));
                lblPageHeader.Text = "Subject Edit";
            }
            else
            {
                lblPageHeader.Text = "Subject Add";
            }
        }
    }
    #endregion Page_Load

    #region LoadControl
    private void LoadControl(Int32 SubjectID)
    {
        using (SqlConnection objConnection = new SqlConnection(DatabaseConfig.ConnectionString))
        {
            using (SqlCommand objcmd = objConnection.CreateCommand())
            {
                try
                {
                    objConnection.Open();
                    objcmd.CommandType = CommandType.StoredProcedure;
                    objcmd.CommandText = "PR_Subject_SelectByPK";
                    objcmd.Parameters.AddWithValue("@SubjectID", SubjectID);

                    SqlDataReader objSDR = objcmd.ExecuteReader();
                    if (objSDR.HasRows == true)
                    {
                        while (objSDR.Read() == true)
                        {
                            if (!objSDR["SubjectName"].Equals(DBNull.Value))
                            {
                                txtSubjectName.Text = objSDR["SubjectName"].ToString();

                            }
                            if (!objSDR["SubjectCode"].Equals(DBNull.Value))
                            {
                                txtSubjectCode.Text = objSDR["SubjectCode"].ToString();
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

        SqlString strSubjectName = SqlString.Null;
        SqlString strSubjectCode = SqlString.Null;

        if (txtSubjectName.Text.Trim() != "")
            strSubjectName = txtSubjectName.Text.Trim();

        if (txtSubjectCode.Text.Trim() != "")
            strSubjectCode = txtSubjectCode.Text.Trim();

        using (SqlConnection objConnection = new SqlConnection(DatabaseConfig.ConnectionString))
        {
            using (SqlCommand objcmd = objConnection.CreateCommand())
            {
                try
                {
                    // objConnection.ConnectionString = ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString;
                    objConnection.Open();
                    objcmd.CommandType = CommandType.StoredProcedure;
                    objcmd.Parameters.AddWithValue("@SubjectName", strSubjectName);
                    objcmd.Parameters.AddWithValue("@SubjectCode", strSubjectCode);

                    if (Request.QueryString["SubjectID"] == null)
                    {
                        objcmd.CommandText = "PR_Subject_Insert";
                        objcmd.Parameters.AddWithValue("@CreationDate", DateTime.Now);
                        objcmd.Parameters.AddWithValue("@UserID", Session["UserID"].ToString());


                    }
                    else
                    {
                        objcmd.CommandText = "PR_Subject_UpdateByPK";
                        objcmd.Parameters.AddWithValue("@SubjectID", Request.QueryString["SubjectID"].ToString());
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



        if (Request.QueryString["SubjectID"] == null)
        {
            lblMessage.Text = "Data  Inserted Successfully........";
            txtSubjectName.Text = "";
            txtSubjectCode.Text = "";
            txtSubjectName.Focus();
            //lblMessage.Text = "";
        }
        else
        {
            Response.Redirect("~/Admin Panel/Subject/SubjectList.aspx");
         }

    }

   
    #endregion btnSave_Click
}