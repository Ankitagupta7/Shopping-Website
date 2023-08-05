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

public partial class payment : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conString"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string payment_id = Request.QueryString["payment_id"].ToString();
            string qr = "select * from [booking] where payment_id=" + payment_id;
            con.Open();
            SqlCommand cmd = new SqlCommand(qr, con);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            con.Close();
            name.Text = ds.Tables[0].Rows[0]["name"].ToString();
            email.Text = ds.Tables[0].Rows[0]["email"].ToString();
            title.Text = ds.Tables[0].Rows[0]["title"].ToString();
            //last_name.Text = ds.Tables[0].Rows[0]["last_name"].ToString();
            //hotel.Text = ds.Tables[0].Rows[0]["hotel"].ToString();
            //days.Text = ds.Tables[0].Rows[0]["days"].ToString();
            //date.Text = ds.Tables[0].Rows[0]["dob"].ToString();
            //total_cost.Text = ds.Tables[0].Rows[0]["amount"].ToString();
            amount_total.Text = ds.Tables[0].Rows[0]["price"].ToString();
            amount.Text = ds.Tables[0].Rows[0]["price"].ToString();
        }
    }

    protected void paymentSubmit_Click(object sender, EventArgs e)
    {
        con.Open();
        SqlCommand checkemail = new SqlCommand("select card_id from [card] where cc_name =@cc_name and cc_number=@cc_number", con);
        checkemail.Parameters.AddWithValue("@cc_name", cc_name.Text.Trim());
        checkemail.Parameters.AddWithValue("@cc_number", cc_number.Text.Trim());
        SqlDataReader read = checkemail.ExecuteReader();
        if (read.HasRows)
        {
            con.Close();
            string payment_id = Request.QueryString["payment_id"].ToString();
            string qr = "update [booking] set card_id='" + cc_number.Text.Trim() + "',payment_status='complete',payment_on='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' where payment_id=" + payment_id;
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = qr;
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect("myBookings.aspx");
        }
        else
        {
            lblCaptchaMsg.Text = "Please provide correct card details.";
            lblCaptchaMsg.ForeColor = System.Drawing.Color.Red;
            con.Close();
        }
    }
}