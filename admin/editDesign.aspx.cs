using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class admin_editDesign : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string designlist_id = Request.QueryString["designlist_id"].ToString();
            string qr = "select * from [designlist] where designlist_id=" + designlist_id;
            con.Open();
            SqlCommand cmd = new SqlCommand(qr, con);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            con.Close();
            designlist_name.Text = ds.Tables[0].Rows[0]["designlist_name"].ToString();
            designlist_detail.Text = ds.Tables[0].Rows[0]["designlist_detail"].ToString(); 
            price.Text = ds.Tables[0].Rows[0]["price"].ToString();

            lblfarImg.Text = "<img width='50' height='50' src='designlistHandler.ashx?designlist_id=" + designlist_id + "' alt='' />";

        }
    }
    protected void updateProduct_Click(object sender, EventArgs e)
    {
        string designlist_id = Request.QueryString["designlist_id"].ToString();
        byte[] myphoto = FileUpload1.FileBytes;
        if (myphoto == null || myphoto.Length == 0)
        {
            string qr = "update [designlist] set designlist_name='" + designlist_name.Text.Trim() + "',designlist_detail='" + designlist_detail.Text.Trim() + "',price='" + price.Text.Trim() + "' where designlist_id=" + designlist_id;
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = qr;
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect("Designs.aspx");
        }
        else
        {
            string qr = "update [designlist] set designlist_name='" + designlist_name.Text.Trim() + "',designlist_detail='" + designlist_detail.Text.Trim() + "',price='" + price.Text.Trim() + "',photo=@ph where designlist_id=" + designlist_id;
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = qr;
            cmd.Parameters.AddWithValue("@ph", myphoto);
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect("Designs.aspx");
        }
    }
}