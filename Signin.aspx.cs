using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;

namespace Superomart
{
    public partial class Signin : System.Web.UI.Page
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
            }


        }

        protected void SigninButton_Click(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Closed)
                con.Open();
            string cmds = "select email,password,first_name,last_name from [userinfo] where email ='" + email.Text + "' and password = '" + MyEncrypt(password.Text) + "'";
            SqlCommand checkemail = new SqlCommand(cmds, con);
            checkemail.Parameters.AddWithValue("@email", email.Text);
            SqlDataReader read = checkemail.ExecuteReader();
            if (read.Read())
            {
                con.Close();
                if (con.State == ConnectionState.Closed)
                    con.Open();
                string isActivecheck = "select email,password,first_name,last_name,user_id from [userinfo] where email ='" + email.Text + "' and password = '" + MyEncrypt(password.Text) + "' and is_active=1";
                SqlCommand Activecheckcheckemail = new SqlCommand(isActivecheck, con);
                Activecheckcheckemail.Parameters.AddWithValue("@email", email.Text);
                SqlDataReader readIsActive = Activecheckcheckemail.ExecuteReader();
                if (readIsActive.Read())
                {
                    Session["email"] = readIsActive.GetValue(0).ToString().Trim();
                    Session["first_name"] = readIsActive.GetValue(2).ToString().Trim();
                    Session["last_name"] = readIsActive.GetValue(3).ToString().Trim();
                    Session["user_id"] = readIsActive.GetValue(4).ToString().Trim();

                    con.Close();
                    Response.Redirect("Home.aspx");
                }
                else
                {
                    lblErrorMsg.Text = "Your account is not activated, please check your email for activation link.";
                    lblErrorMsg.ForeColor = System.Drawing.Color.Red;
                    con.Close();
                }
            }
            else
            {
                lblErrorMsg.Text = "Invalid login Credentials.";
                lblErrorMsg.ForeColor = System.Drawing.Color.Red;
                con.Close();
            }
        }
        private string MyEncrypt(string returnText)
        {
            string EncryptionKey = "E6C69AC9CCE39";
            byte[] clearBytes = Encoding.Unicode.GetBytes(returnText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    returnText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return returnText;

        }
    }

}
    
