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

public partial class admin_addProduct : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void addProduct_Click(object sender, EventArgs e)
    {
        byte[] productPhoto = FileUpload1.FileBytes;
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        //con.Open();
        //String cmd = "select email from [user] where email =" + email_address.Text.Trim();
        //SqlCommand checkemail = new SqlCommand("select email from [user] where email =@email", con);
        //checkemail.Parameters.AddWithValue("@email", email_address.Text.Trim());
        //SqlDataReader read = checkemail.ExecuteReader();
        //if (read.HasRows)
        //{
        //    lblMsgReg.Text = "Email chirag Address is already exist. Please try with different email address.";
        //    lblMsgReg.ForeColor = System.Drawing.Color.Red;
        //    con.Close();
        //}
        //else
        //{
        //    con.Close();
            con.Open();
            string insertCmd = "insert into [products](product_name,price,photo ) values(@product_name,@myprice, @photo)";
            SqlCommand insertUser = new SqlCommand(insertCmd, con);
            insertUser.Parameters.AddWithValue("@product_name", product_name.Text);
            insertUser.Parameters.AddWithValue("@myprice", price.Text);
            insertUser.Parameters.AddWithValue("@photo", productPhoto);
            insertUser.ExecuteNonQuery();
            con.Close();
            Response.Redirect("products.aspx");
        //}
    }
}