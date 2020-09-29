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

public partial class Admin_Panel_Faculty_FacultyAddEdit : System.Web.UI.Page
{
    #region Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["FacultyID"] != null)
            {
                LoadControl(Convert.ToInt32(Request.QueryString["FacultyID"]));
                lblPageHeader.Text = "Faculty Edit";
            }
            else
            {
                lblPageHeader.Text = "Faculty Add";
            }
        }
    }
    #endregion Page_Load

    #region LoadControl
    private void LoadControl(Int32 FacultyID)
    {
          using (SqlConnection objConnection = new SqlConnection(DatabaseConfig.ConnectionString))
        {
            using (SqlCommand objcmd = objConnection.CreateCommand())
            {
                try
                {
                    objConnection.Open();
                    objcmd.CommandType = CommandType.StoredProcedure;
                    objcmd.CommandText = "PR_Faculty_SelectByPK";
                    objcmd.Parameters.AddWithValue("@FacultyID", FacultyID);

                    SqlDataReader objSDR = objcmd.ExecuteReader();
                    if (objSDR.HasRows == true)
                    {
                        while (objSDR.Read() == true)
                        {
                            if (!objSDR["FacultyName"].Equals(DBNull.Value))
                            {
                                txtFacultyName.Text = objSDR["FacultyName"].ToString();
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

        SqlString strFacultyName = SqlString.Null;
        SqlString strFacultyCode = SqlString.Null;

        if (txtFacultyName.Text.Trim() != "")
            strFacultyName = txtFacultyName.Text.Trim();


        using (SqlConnection objConnection = new SqlConnection(DatabaseConfig.ConnectionString))
        {
            using (SqlCommand objcmd = objConnection.CreateCommand())
            {
                try
                {
                    // objConnection.ConnectionString = ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString;
                    objConnection.Open();
                    objcmd.CommandType = CommandType.StoredProcedure;
                    objcmd.Parameters.AddWithValue("@FacultyName", strFacultyName);

                    if (Request.QueryString["FacultyID"] == null)
                    {
                        objcmd.CommandText = "PR_Faculty_Insert";
                        objcmd.Parameters.AddWithValue("@CreationDate", DateTime.Now);
                        objcmd.Parameters.AddWithValue("@UserID", Session["UserID"].ToString());


                    }
                    else
                    {
                        objcmd.CommandText = "PR_Faculty_UpdateByPK";
                        objcmd.Parameters.AddWithValue("@FacultyID", Request.QueryString["FacultyID"].ToString());
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



        if (Request.QueryString["FacultyID"] == null)
        {
            lblMessage.Text = "Data  Inserted Successfully........";
            txtFacultyName.Text = "";
            txtFacultyName.Focus();
            //lblMessage.Text = "";
        }
        else
        {
            Response.Redirect("~/Admin Panel/Faculty/FacultyList.aspx");
        }

    }

    public int UserName { get; set; }
    #endregion btnSave_Click
}