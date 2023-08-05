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

public partial class admin_DeleteDesign : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string designlist_id = Request.QueryString["designlist_id"].ToString();
        string qr = "Delete from [designlist] where designlist_id=" + designlist_id;
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        con.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = qr;
        cmd.Connection = con;
        cmd.ExecuteNonQuery();
        con.Close();
        Response.Redirect("Designs.aspx");
    }
}