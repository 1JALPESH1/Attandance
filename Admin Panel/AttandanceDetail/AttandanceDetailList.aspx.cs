using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Panel_AttandanceDetail_AttandanceDetailList : System.Web.UI.Page
{
    #region Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] != null)
        {
            lblMessage.Text = "Welcome     to     " + Session["UserName"].ToString();
        }

        if (!Page.IsPostBack)
        {
            if (Session["UserID"] != null && Request.QueryString["AttandanceID"] != null)
            {
                FillAttandanceDetailGridView(Convert.ToInt32(Request.QueryString["AttandanceID"]), Convert.ToInt32(Session["UserID"]));
            }
        }
    }
    #endregion Page_Load



    #region FillAttandanceDetailGridView
    private void FillAttandanceDetailGridView(Int32 AttandanceID,Int32 UserID)
    {
        using (SqlConnection objConnection = new SqlConnection(DatabaseConfig.ConnectionString))
        {
            using (SqlCommand objcmd = objConnection.CreateCommand())
            {
                objConnection.Open();
                try
                {
                    
                    objcmd.CommandType = CommandType.StoredProcedure;
                    objcmd.CommandText = "PR_AttandanceDetail_SelectAllByAttandanceID";
                    objcmd.Parameters.AddWithValue("@UserID", UserID);
                    objcmd.Parameters.AddWithValue("@AttandanceID", AttandanceID);

                    SqlDataReader objSDR = objcmd.ExecuteReader();
                    gvAttandanceDetail.DataSource = objSDR;
                    gvAttandanceDetail.DataBind();
                    
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
    #endregion FillAttandanceDetailGridView


}