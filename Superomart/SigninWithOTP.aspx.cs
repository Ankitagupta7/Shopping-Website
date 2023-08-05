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
    public partial class SigninWithOTP : System.Web.UI.Page
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Closed)
                con.Open();
            SqlCommand checkemail = new SqlCommand("select email from [userinfo] where email = @email and is_active=1", con);
            checkemail.Parameters.AddWithValue("@email", email.Text);
            SqlDataReader read = checkemail.ExecuteReader();
            if (read.HasRows)
            {
                con.Close();
                if (con.State == ConnectionState.Closed)
                    con.Open();

                Random signinotp = new Random();
                int SigninOTP = signinotp.Next(1000, 9999);
                string mySigninOTP = SigninOTP.ToString();

                string qr = "update [userinfo] set signinotp='" + mySigninOTP + "', otp_created='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' where email='" + email.Text.ToString() + "'";
                SqlCommand cmd = new SqlCommand();
                //cmd.Parameters.AddWithValue("@otp_created", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                cmd.CommandText = qr;
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                con.Close();

                MailMessage mail = new MailMessage();
                mail.To.Add(email.Text.Trim());
                mail.From = new MailAddress("AKguptaankita15@gmail.com");
                mail.Subject = "Signin OTP from TestWeb, OTP Valid for 10min only";
                string emailBody = "";

                emailBody += "<div style='background:#FFFFFF; font-family:Arial,Helvetica,Verdana,sans-serif; font-size:14px; margin:0; padding:0;'>";
                emailBody += "<table cellspacing='0' cellpadding='0' border='0' width='100%' style='font-family:Arial,Helvetica,Verdana,sans-serif; font-size:14px;'>";
                emailBody += "<tbody>";
                emailBody += "<tr>";
                emailBody += "<td valign='top' style='font-family:Arial,Helvetica,Verdana,sans-serif; font-size:14px;background:#AF38EB;color:#fff;'>";
                emailBody += "<div style='width:100%;margin-left:auto;margin-right:auto;clear:both;background:#AF38EB;color:#fff;'>";
                emailBody += "<div style='float:left;width:100%;min-height:35px;font-size:26px;font-weight:bold;text-align:left'>";
                emailBody += "<div style='clear:both;width:100%;text-align:center;'>&nbsp;&nbsp;&nbsp;WELCOME TO</div>";
                emailBody += "<div style='clear:both;width:100%;text-align:center;font-size:11px;font-style:italic;'>&nbsp;&nbsp;&nbsp;&nbsp;Superomart!</div>";
                emailBody += "</div>";
                emailBody += "</div>";
                emailBody += "</td>";
                emailBody += "</tr>";
                emailBody += "</tbody>";
                emailBody += "</table>";
                emailBody += "<table cellspacing='0' cellpadding='0' border='0' width='100%' style='font-family:Arial,Helvetica,Verdana,sans-serif; font-size:14px;margin-left:auto;margin-right:auto;'>";
                emailBody += "<tbody>";
                emailBody += "<tr>";
                emailBody += "<td valign='top' colspan='2' style='width:600px;padding-left:20px;padding-right:20px;font-family:Arial,Helvetica,Verdana,sans-serif; font-size:14px;'>";
                emailBody += "<p style='font-family:Arial,Helvetica,Verdana,sans-serif; font-size:14px;padding-top:15px;line-height:22px;margin:0px;font-weight:bold;padding-bottom:5px'>Hello User,</p>";
                emailBody += "<p style='font-family:Arial,Helvetica,Verdana,sans-serif; font-size:14px;line-height:22px;color:rgb(41,41,41)'>Email: " + email.Text.ToString() + "</p>";
                emailBody += "<p style='font-family:Arial,Helvetica,Verdana,sans-serif; font-size:14px;line-height:22px;color:rgb(41,41,41)'>OTP: " + mySigninOTP + "</p>";
                emailBody += "<p><a href='" + "http://localhost:54485/SigninConfirmWithOTP.aspx?email=" + email.Text.Trim() + "'>Click here to Signin your account.</a></p>";
                emailBody += "<p style='font-family:Arial,Helvetica,Verdana,sans-serif; font-size:14px;line-height:22px;color:rgb(41,41,41)'>Thanks for reaching us.. We ll contact you ASAP.</p>";
                emailBody += "<p>&nbsp;</p><p style='font-family:Arial,Helvetica,Verdana,sans-serif; font-size:14px;line-height:22px;margin:0px'>If you have any additional queries, please feel free to reach out us at +91 6207718405 or drop us an email at <a href='akguptaankita15@gmail.com' style='text-decoration:none;font-style:normal;font-variant:normal;font-weight:normal;font-family:Arial,Helvetica,Verdana,sans-serif; font-size:14px;line-height:normal;color:rgb(162,49,35)' target='_blank'>akguptaankita15@gmail.com</a>. We are here to help you.</p>";
                emailBody += "<p>&nbsp;</p>";
                emailBody += "<p style='font-family:Arial,Helvetica,Verdana,sans-serif; font-size:14px;line-height:22px;margin:0px;font-weight:bold'>Best Regards,</p>";
                emailBody += "<p style='font-family:Arial,Helvetica,Verdana,sans-serif; font-size:14px;color:rgb(41,41,41);line-height:22px;margin:0px'>Support Team</p>";
                emailBody += "</td>";
                emailBody += "</tr>";
                emailBody += "</tbody>";
                emailBody += "</table>";
                emailBody += "</div>";

                mail.Body = emailBody;
                mail.IsBodyHtml = true;

                SmtpClient smtp = new SmtpClient();
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Host = "smtp.gmail.com"; //Or Your SMTP Server Address
                smtp.Credentials = new System.Net.NetworkCredential("AKguptaankita15@gmail.com", "qunomtiyolvecyqb");
                smtp.Send(mail);

                lblErrorMsg.Text = "OTP sent to your email address.";
                lblErrorMsg.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                /*con.Close();
                if (con.State == ConnectionState.Closed)
                    con.Open();
                string insertUsr = "insert into [userinfo] (first_name,last_name,email,password,mobile,is_active) values (@firstname,@lastname,@email_id,@pwd,@mob,@is_active)";
                SqlCommand insertCmd = new SqlCommand(insertUsr, con);
                //SqlCommand insertCmd = new SqlCommand("insert into[userinfo](first_name) values(@firstname)", con);
                insertCmd.Parameters.AddWithValue("@firstname", chirag.Text);
                insertCmd.Parameters.AddWithValue("@lastname", lname.Text);
                insertCmd.Parameters.AddWithValue("@email_id", email_address.Text);
                insertCmd.Parameters.AddWithValue("@pwd", MyEncrypt(password.Text));
                insertCmd.Parameters.AddWithValue("@mob", mobile.Text);
                insertCmd.Parameters.AddWithValue("@is_active", 0);
                insertCmd.ExecuteNonQuery();
                con.Close();

                Random rnd = new Random();
                int myRandomNo = rnd.Next(10000000, 99999999);
                string activation_code = myRandomNo.ToString();

                try
                {

                }
                catch (Exception ex)
                {
                    throw ex;
                    //msg = ex.Message;
                }*/


                lblErrorMsg.Text = "Your are not registered with us.";
                lblErrorMsg.ForeColor = System.Drawing.Color.Green;
            }

        }
        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }
        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }
        private string MyEncrypt(string returnText)
        {
            string EncryptionKey = "E5C2B81A3B2B2";
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
        /*private string MyDecrypt(string returnText)
        {
            string EncryptionKey = "E5C2B81A3B2B2";
            byte[] cipherBytes = Convert.FromBase64String(returnText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    returnText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return returnText;
        }*/
    
}
}