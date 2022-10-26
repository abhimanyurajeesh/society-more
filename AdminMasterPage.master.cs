﻿using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing;

public partial class AdminMasterPage : System.Web.UI.MasterPage
{
    SqlCommand com;
    string str;
    SqlCommand cmd;
    SqlConnection con;
    String CS = ConfigurationManager.ConnectionStrings["MyDatabaseConnectionString"].ConnectionString;
    SqlDataReader rdr;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Mail"] != null)
        {
            lblUserName.Text = Session["Name"].ToString();
            BindImageRptr();
        }
        else
        {
            Response.Redirect("LoginPage.aspx");
        }
    }

    private void BindImageRptr()
    {
        String CS = ConfigurationManager.ConnectionStrings["MyDatabaseConnectionString"].ConnectionString;
        using (SqlConnection con = new SqlConnection(CS))
        {
            using (SqlCommand cmd = new SqlCommand("select * from UserTable Where Id='" + Session["Id"].ToString() + "'", con))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {

                    DataTable dtBrands = new DataTable();
                    sda.Fill(dtBrands);
                    RepeaterImage.DataSource = dtBrands;
                    RepeaterImage.DataBind();
                }

            }
        }
    }
}
