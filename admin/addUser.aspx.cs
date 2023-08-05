using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Net.Mail;
using System.Net;
using System.Security.Cryptography;

public partial class admin_addUser : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

    public void Bind_ddlCountry()
    {
        conn.Open();
        SqlCommand cmd = new SqlCommand("select Country,CountryId from Country", conn);
        SqlDataReader dr = cmd.ExecuteReader();
        ddlcountry.DataSource = dr;
        ddlcountry.Items.Clear();
        ddlcountry.Items.Add("--Please Select country--");
        ddlcountry.DataTextField = "Country";
        ddlcountry.DataValueField = "CountryId";
        ddlcountry.DataBind();
        conn.Close();
    }
    public void Bind_ddlState()
    {
        conn.Open();

        SqlCommand cmd = new SqlCommand("select State,StateID from countryState where CountryId='" + ddlcountry.SelectedValue + "'", conn);

        SqlDataReader dr = cmd.ExecuteReader();
        ddlstate.DataSource = dr;
        ddlstate.Items.Clear();
        ddlstate.Items.Add("--Please Select state--");
        ddlstate.DataTextField = "State";
        ddlstate.DataValueField = "StateID";
        ddlstate.DataBind();
        conn.Close();
    }
    public void Bind_ddlCity()
    {
        conn.Open();
        SqlCommand cmd = new SqlCommand("select * from stateCity where StateId ='" + ddlstate.SelectedValue + "'", conn);

        SqlDataReader dr = cmd.ExecuteReader();
        ddlcity.DataSource = dr;
        ddlcity.Items.Clear();
        ddlcity.Items.Add("--Please Select city--");
        ddlcity.DataTextField = "City";
        ddlcity.DataValueField = "CityID";
        ddlcity.DataBind();
        conn.Close();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Bind_ddlCountry();
        }
    }
    protected void ddlcountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        Bind_ddlState();
    }
    protected void ddlstate_SelectedIndexChanged(object sender, EventArgs e)
    {
        Bind_ddlCity();
    }
    protected void addUser_Click(object sender, EventArgs e)
    {
        string rbdtext;
        if (RadioButton1.Checked) { rbdtext = RadioButton1.Text; } else { rbdtext = RadioButton2.Text; }
        
        byte[] myphoto = FileUpload1.FileBytes;
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        con.Open();
        String cmd = "select email from [user] where email =" + email_address.Text.Trim();
        SqlCommand checkemail = new SqlCommand("select email from [userinfo] where email =@email", con);
        checkemail.Parameters.AddWithValue("@email", email_address.Text.Trim());
        SqlDataReader read = checkemail.ExecuteReader();
        if (read.HasRows)
        {
            lblMsgReg.Text = "Email Address is already exist. Please try with different email address.";
            lblMsgReg.ForeColor = System.Drawing.Color.Red;
            con.Close();
        }
        else
        {
            con.Close();
            con.Open();
            string insertCmd = "insert into [userinfo](first_name,last_name,email,password,mobile,address,photo,country,state,city,gender,created_on,dob) values(@first_name,@last_name,@email_address,@password,@mobile,@address,@photo,@country,@state,@city,@gender,@created_on,@dob)";
            SqlCommand insertUser = new SqlCommand(insertCmd, con);
            insertUser.Parameters.AddWithValue("@first_name", first_name.Text);
            insertUser.Parameters.AddWithValue("@last_name", last_name.Text);
            insertUser.Parameters.AddWithValue("@email_address", email_address.Text);
            insertUser.Parameters.AddWithValue("@password", MyEncrypt(password.Text));
            insertUser.Parameters.AddWithValue("@mobile", mobile.Text);
            insertUser.Parameters.AddWithValue("@address", address.Text);
            insertUser.Parameters.AddWithValue("@photo", myphoto);
            insertUser.Parameters.AddWithValue("@country", ddlcountry.SelectedValue);
            insertUser.Parameters.AddWithValue("@state", ddlstate.SelectedValue);
            insertUser.Parameters.AddWithValue("@city", ddlcity.SelectedValue); 
            insertUser.Parameters.AddWithValue("@gender", rbdtext); 
            insertUser.Parameters.AddWithValue("@dob", dob.Text);
            insertUser.Parameters.AddWithValue("@created_on", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            insertUser.ExecuteNonQuery();
            con.Close();
            Response.Redirect("user.aspx");
        }
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

    private string MyDecrypt(string cipherText)
    {
        string EncryptionKey = "E6C69AC9CCE39";
        byte[] cipherBytes = Convert.FromBase64String(cipherText);
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
                cipherText = Encoding.Unicode.GetString(ms.ToArray());
            }
        }
        return cipherText;
    }
}