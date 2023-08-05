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

public partial class admin_addDesign : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void addDesign_Click(object sender, EventArgs e)
    {
        byte[] designlistPhoto = FileUpload1.FileBytes;
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        con.Open();
        string insertCmd = "insert into [designlist](designlist_name,designlist_detail,price,photo ) values(@designlist_name,@designlist_detail,@myprice, @photo)";
        SqlCommand insertUser = new SqlCommand(insertCmd, con);
        insertUser.Parameters.AddWithValue("@designlist_name", designlist_name.Text); 
        insertUser.Parameters.AddWithValue("@designlist_detail", designlist_detail.Text); 
        insertUser.Parameters.AddWithValue("@myprice", price.Text);
        insertUser.Parameters.AddWithValue("@photo", designlistPhoto);
        insertUser.ExecuteNonQuery();
        con.Close();
        Response.Redirect("Designs.aspx");
        //}
    }
}