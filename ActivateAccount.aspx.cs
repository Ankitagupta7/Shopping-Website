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
    public partial class ActivateAccount : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["mart"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["email"] != null)
                {
                    Response.Redirect("Home.aspx");
                }
                string activation_code = Request.QueryString["activation_code"].ToString();
                string email_id = Request.QueryString["email"].ToString();
                string email = Base64Decode(email_id);

                if (con.State == ConnectionState.Closed)
                    con.Open();
                string cmds = "select email,activation_code from [userinfo] where email ='" + email.ToString() + "' and activation_code = '" + activation_code.ToString() + "' and is_active=0 and activation_code !=''";
                SqlCommand checkemail = new SqlCommand(cmds, con);
                SqlDataReader read = checkemail.ExecuteReader();
                if (read.Read())
                {
                    con.Close();
                    string qr = "update [userinfo] set is_active=1, activation_code='' where email ='" + email.ToString() + "'";
                    con.Open();
                    SqlCommand updateUserCmd = new SqlCommand(qr, con);
                    updateUserCmd.ExecuteNonQuery();
                    con.Close();
                    Response.Redirect("SigninWithOTP.aspx");
                }
                else
                {
                    lblErrorMsg.Text = "Link is expired.";
                    lblErrorMsg.ForeColor = System.Drawing.Color.Red;
                    con.Close();
                }
            }
        }
        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }
    }

}
    

        