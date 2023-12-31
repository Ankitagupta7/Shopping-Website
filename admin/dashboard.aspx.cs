﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
public partial class admin_dashboard : System.Web.UI.Page
{
    string str;
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conString"].ConnectionString);
    SqlCommand com;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["admin_email_address"] == null)
        {
            Response.Redirect("admin.aspx");
        }
        try
        {
            if (con.State == ConnectionState.Closed)
            con.Open();
            SqlCommand cmd = new SqlCommand("Select count(*) as totalusers from [userinfo] ", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            if (dt != null && dt.Rows.Count > 0)
            {
                lblTotalCount.Text = dt.Rows[0]["totalusers"].ToString();
            }
        }
        catch { }

        try
        {
            if (con.State == ConnectionState.Closed)
            con.Open();
            SqlCommand cmd = new SqlCommand("Select count(*) as totallec from [designlist] ", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            if (dt != null && dt.Rows.Count > 0)
            {
                lblTotalLecCount.Text = dt.Rows[0]["totallec"].ToString();
            }
        }
        catch { }

        try
        {
            if (con.State == ConnectionState.Closed)
            con.Open();
            SqlCommand cmd = new SqlCommand("Select count(*) as totalftlr from [orders] ", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            if (dt != null && dt.Rows.Count > 0)
            {
                lblTotalftlsrCount.Text = dt.Rows[0]["totalftlr"].ToString();
            }
        }
        catch { }
    }
}