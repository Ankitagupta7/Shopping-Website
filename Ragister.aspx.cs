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
    public partial class Ragister : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["mart"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            { //do something 
            }


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (captchaCode.Text.ToLower() == Session["sessionCaptcha"].ToString())
            {
                //email unique
                //if (con.State == ConnectionState.Closed)
                con.Open();
                SqlCommand checkemail = new SqlCommand("select email from [userinfo] where email = @email", con);
                checkemail.Parameters.AddWithValue("@email", email.Text);
                SqlDataReader read = checkemail.ExecuteReader();
                if (read.HasRows)
                {
                    lblErrorMsg.Text = "Email Address is already exist.. Please try with different email address.";
                    lblErrorMsg.ForeColor = System.Drawing.Color.Red;
                    con.Close();
                }
                else
                {
                    con.Close();

                    string rbdtext;
                    if (male.Checked) { rbdtext = male.Text; } else { rbdtext = female.Text; }
                    byte[] mypic = FileUpload1.FileBytes;

                    Random rnd = new Random();
                    int myRandomNo = rnd.Next(10000000, 99999999);
                    string activation_code = myRandomNo.ToString();


                    con.Open();
                    string insertUsr = "insert into [userinfo] (first_name,last_name,email,Contact,City,Address,password,gender,is_active,photo,created_on,activation_code,activation_code_time) values (@first_name,@last_name,@email,@Contact,@City,@Address,@password,@gender,@is_active,@photo,@created_on,@activation_code,@activation_code_time)";
                    SqlCommand insertCmd = new SqlCommand(insertUsr, con);
                    insertCmd.Parameters.AddWithValue("@first_name", first_name.Text);
                    insertCmd.Parameters.AddWithValue("@last_name", last_name.Text);
                    insertCmd.Parameters.AddWithValue("@email", email.Text);
                    insertCmd.Parameters.AddWithValue("@Contact", Contact.Text);
                    insertCmd.Parameters.AddWithValue("@City", City.Text);
                    insertCmd.Parameters.AddWithValue("@Address", Address.Text);
                    insertCmd.Parameters.AddWithValue("@password", MyEncrypt(password.Text));
                    insertCmd.Parameters.AddWithValue("@gender", rbdtext);
                    insertCmd.Parameters.AddWithValue("@photo", mypic);
                    insertCmd.Parameters.AddWithValue("@created_on", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    insertCmd.Parameters.AddWithValue("@activation_code", activation_code);
                    insertCmd.Parameters.AddWithValue("@activation_code_time", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    insertCmd.Parameters.AddWithValue("@is_active", 0);
                    insertCmd.ExecuteNonQuery();
                    con.Close();
                    //try
                    //{
                    MailMessage mail = new MailMessage();
                    mail.To.Add(email.Text.Trim());
                    mail.From = new MailAddress("AKguptaankita15@gmail.com");
                    mail.Subject = "Thankyou for registering with us.";
                    string emailBody = "";

                    emailBody += "<div style='background:#FFFFFF; font-family:Arial,Helvetica,Verdana,sans-serif; font-size:14px; margin:0; padding:0;'>";
                    emailBody += "<table cellspacing='0' cellpadding='0' border='0' width='100%' style='font-family:Arial,Helvetica,Verdana,sans-serif; font-size:14px;'>";
                    emailBody += "<tbody>";
                    emailBody += "<tr>";
                    emailBody += "<td valign='top' style='font-family:Arial,Helvetica,Verdana,sans-serif; font-size:14px;background:#AF38EB;color:#fff;'>";
                    emailBody += "<div style='width:100%;margin-left:auto;margin-right:auto;clear:both;background:#7ECC49;color:#fff;'>";
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
                    emailBody += "<td valign='top' colspan='2' style='width:100%;padding-left:20px;padding-right:20px;font-family:Arial,Helvetica,Verdana,sans-serif; font-size:14px;'>";
                    emailBody += "<p style='font-family:Arial,Helvetica,Verdana,sans-serif; font-size:14px;padding-top:15px;line-height:22px;margin:0px;font-weight:bold;padding-bottom:5px'>Hi " + first_name.Text + ",</p>";
                    emailBody += "<p style='font-family:Arial,Helvetica,Verdana,sans-serif; font-size:14px;line-height:22px;color:rgb(41,41,41)'>Email: " + email.Text + " </p>";
                    emailBody += "<p style='font-family:Arial,Helvetica,Verdana,sans-serif; font-size:14px;line-height:22px;color:rgb(41,41,41)'>Mobile: " + Contact.Text + " </p>";
                    emailBody += "<p><a href='" + "http://localhost:54485/ActivateAccount.aspx?activation_code=" + activation_code + "&email=" + Base64Encode(email.Text.Trim()) + "'>Click here to activate your account.</a></p>";
                    emailBody += "<p style='font-family:Arial,Helvetica,Verdana,sans-serif; font-size:14px;line-height:22px;color:rgb(41,41,41)'>Thanks for reaching us.. We ll contact you ASAP.</p>";
                    emailBody += "<p>&nbsp;</p><p style='font-family:Arial,Helvetica,Verdana,sans-serif; font-size:14px;line-height:22px;margin:0px'>If you have any additional queries, please feel free to reach out us at +916207718405 or drop us an email at <a href='akguptaankita15@gmail.com' style='text-decoration:none;font-style:normal;font-variant:normal;font-weight:normal;font-family:Arial,Helvetica,Verdana,sans-serif; font-size:14px;line-height:normal;color:rgb(162,49,35)' target='_blank'>akguptaankita15@gmail.com</a>. We are here to help you.</p>";
                    emailBody += "<p>&nbsp;</p>";
                    emailBody += "<p style='font-family:Arial,Helvetica,Verdana,sans-serif; font-size:14px;line-height:22px;margin:0px;font-weight:bold'>Support Team</p>";
                    emailBody += "<p style='font-family:Arial,Helvetica,Verdana,sans-serif; font-size:14px;color:rgb(41,41,41);line-height:22px;margin:0px'>Ankita Gupta Suchi Pragya</p>";
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
                    smtp.UseDefaultCredentials = true;
                    smtp.Host = "smtp.gmail.com"; //Or Your SMTP Server Address
                    smtp.Credentials = new System.Net.NetworkCredential("AKguptaankita15@gmail.com", "AK15gupta");
                    smtp.Send(mail);
                    //}

                    //  catch (Exception ex)
                    // {
                    //throw ex;
                    //    //msg = ex.Message;
                    // }

                    lblErrorMsg.Text = "Your are registered successfully.";
                    lblErrorMsg.ForeColor = System.Drawing.Color.Green;
                }
            }
            else
            {
                lblErrorMsg.Text = "Please enter correct captcha code.";
                lblErrorMsg.ForeColor = System.Drawing.Color.Red;
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

        private string MyEncrypt(string clearText)
        {
            string EncryptionKey = "E6C69AC9CCE39";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
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
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }

        //private string MyDecrypt(string cipherText)
        //{
        //    string EncryptionKey = "E6C69AC9CCE39";
        //    byte[] cipherBytes = Convert.FromBase64String(cipherText);
        //    using (Aes encryptor = Aes.Create())
        //    {
        //        Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
        //        encryptor.Key = pdb.GetBytes(32);
        //        encryptor.IV = pdb.GetBytes(16);
        //        using (MemoryStream ms = new MemoryStream())
        //        {
        //            using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
        //            {
        //                cs.Write(cipherBytes, 0, cipherBytes.Length);
        //                cs.Close();
        //            }
        //            cipherText = Encoding.Unicode.GetString(ms.ToArray());
        //        }
        //    }
        //    return cipherText;
        //}

    }
}
