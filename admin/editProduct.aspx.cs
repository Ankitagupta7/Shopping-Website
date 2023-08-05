using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class admin_editProduct : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string product_id = Request.QueryString["product_id"].ToString();
            string qr = "select * from [products] where product_id=" + product_id;
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(qr, con);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            con.Close();
            product_name.Text = ds.Tables[0].Rows[0]["product_name"].ToString();
            price.Text = ds.Tables[0].Rows[0]["price"].ToString();

            lblfarImg.Text = "<img width='50' height='50' src='productHandler.ashx?product_id=" + product_id + "' alt='' />";

        }
    }
    protected void updateProduct_Click(object sender, EventArgs e)
    {
        string product_id = Request.QueryString["product_id"].ToString();
        byte[] myphoto = FileUpload1.FileBytes;
        if (myphoto == null || myphoto.Length == 0)
        {
            string qr = "update [products] set product_name='" + product_name.Text.Trim() + "',price='" + price.Text.Trim() + "' where product_id=" + product_id;
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = qr;
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect("products.aspx");
        }
        else
        {
            string qr = "update [products] set product_name='" + product_name.Text.Trim() + "',price='" + price.Text.Trim() + "',photo=@ph where product_id=" + product_id;
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = qr;
            cmd.Parameters.AddWithValue("@ph", myphoto);
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect("products.aspx");
        }
    }
}