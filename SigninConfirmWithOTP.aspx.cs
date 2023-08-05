using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace Superomart
{
    public partial class SigninConfirmWithOTP : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["mart"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            string email = Request.QueryString["email"].ToString();
            Label1.Text = email.ToString();
            if (!IsPostBack)
            {
                if (Session["email"] != null)
                {
                    Response.Redirect("HOME.aspx");
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            if (con.State == ConnectionState.Closed)
                con.Open();

            string email = Request.QueryString["email"].ToString();

            string cmds = "select email,password,first_name,last_name,Signinotp from [userinfo] where email ='" + email.ToString() + "' and Signinotp = '" + otp.Text.ToString() + "'";
            SqlCommand checkemail = new SqlCommand(cmds, con);
            //checkemail.Parameters.AddWithValue("@otp", otp.Text);
            SqlDataReader read = checkemail.ExecuteReader();
            if (read.Read())
            {
                Session["email"] = read.GetValue(0).ToString().Trim();
                //Session["is_seller"] = '1';
                Session["first_name"] = read.GetValue(2).ToString().Trim();
                Session["last_name"] = read.GetValue(3).ToString().Trim();
                con.Close();
                Response.Redirect("Home.aspx");
            }
            else
            {
                lblErrorMsg.Text = "Invalid otp.";
                lblErrorMsg.ForeColor = System.Drawing.Color.Red;
                con.Close();
            }
        }


    }
}
