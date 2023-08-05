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
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;

namespace Superomart
{
    public partial class cart : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["email"] == null)
                {
                    Response.Redirect("Home.aspx");
                }
            }


            CalculateTotalAmount();
            if (!IsPostBack)
            {
                string user_id = Session["user_id"].ToString();
                string qr = "select * from [userinfo] where user_id=" + user_id;
                con.Open();
                SqlCommand cmd = new SqlCommand(qr, con);
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                ad.Fill(ds);
                con.Close();
                full_name.Text = ds.Tables[0].Rows[0]["first_name"].ToString() + " " + ds.Tables[0].Rows[0]["last_name"].ToString();
                mobile.Text = ds.Tables[0].Rows[0]["mobile"].ToString();
                email.Text = ds.Tables[0].Rows[0]["email"].ToString();
                pin.Text = ds.Tables[0].Rows[0]["pin"].ToString();
                country.Text = ds.Tables[0].Rows[0]["country"].ToString();
                state.Text = ds.Tables[0].Rows[0]["state"].ToString();
                city.Text = ds.Tables[0].Rows[0]["city"].ToString();

            }
            if (Session["email"] == null)
            {
                Response.Redirect("login.aspx");
            }
        }

        protected void btnCheckout_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int myRandomNo = rnd.Next(10000000, 99999999);
            string payment_id_final = myRandomNo.ToString();
            con.Open();
            string query = "insert into Orders (CustomerID, OrderDateTime, TotalAmount,full_name,address,email,mobile,pin,created_on,payment_id,payment_status) values (1, GETDATE() , " + Decimal.Parse(lblTotalAmount.Text) + ",@full_name,@address,@email,@mobile,@pin,@created_on,@payment_id,@payment_status); SELECT SCOPE_IDENTITY();";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@full_name", full_name.Text);
            cmd.Parameters.AddWithValue("@address", address.Text);
            cmd.Parameters.AddWithValue("@email", email.Text);
            cmd.Parameters.AddWithValue("@mobile", mobile.Text);
            cmd.Parameters.AddWithValue("@pin", pin.Text);
            cmd.Parameters.AddWithValue("@payment_id", payment_id_final);
            cmd.Parameters.AddWithValue("@payment_status", "Pending");
            cmd.Parameters.AddWithValue("@created_on", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            int OrderID = Convert.ToInt32(cmd.ExecuteScalar());

            query = "insert into OrderDetails (OrderID, ProductID, Quantity, Amount, ProductName) select " + OrderID + " AS OrderID, ProductID, Quantity, Amount,ProductName from Cart where CartID='" + Session.SessionID + "'";
            cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();

            query = "delete from Cart where CartID='" + Session.SessionID + "'";
            cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
            Response.Redirect("payment.aspx?payment_id=" + payment_id_final);
            //ClientScript.RegisterStartupScript(GetType(), "Popup", "successalert();", true);


            /*
            con.Open();
            string insertCmd = "insert into [order](full_name,address,email,mobile,pin,created_on) values(@full_name,@address,@email,@mobile,@pin,@created_on)";
            SqlCommand insertUser = new SqlCommand(insertCmd, con);
            insertUser.Parameters.AddWithValue("@full_name", full_name.Text);
            insertUser.Parameters.AddWithValue("@address", address.Text);
            insertUser.Parameters.AddWithValue("@email", email.Text);
            insertUser.Parameters.AddWithValue("@mobile", mobile.Text);
            insertUser.Parameters.AddWithValue("@pin", pin.Text);
            insertUser.Parameters.AddWithValue("@created_on", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            insertUser.ExecuteNonQuery();
            con.Close();

            string latest_order_id;
            con.Open();
            String cmdMy = "select MAX(order_id) from [order]";
            SqlCommand checkCmd = new SqlCommand(cmdMy, con);
            SqlDataReader read2 = checkCmd.ExecuteReader();
            if (read2.Read())
            {
                latest_order_id = read2.GetValue(0).ToString().Trim();
            }
            else
            {
                latest_order_id = "Null";
            }
            con.Close();

            for (int i = 0; i < GridView2.Rows.Count; i++)
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                String ID = GridView2.Rows[i].Cells[0].Text.ToString(); ;
                TextBox Tb = (TextBox)GridView2.Rows[i].FindControl("TextBoxCount");

                string insertCmdnew = "insert into [orderDetails](order_id,product_id,product_name,quantity,price,total_price) values(@order_id,@product_id,@product_name,@quantity,@price,@total_price)";
                SqlCommand insertProduct = new SqlCommand(insertCmdnew, con);
                insertProduct.Parameters.AddWithValue("@order_id", latest_order_id);
                insertProduct.Parameters.AddWithValue("@product_id", Cart_DataTable.Rows[i]["product_id"]);
                insertProduct.Parameters.AddWithValue("@product_name", Cart_DataTable.Rows[i]["product_name"]);
                insertProduct.Parameters.AddWithValue("@quantity", Cart_DataTable.Rows[i]["count"]);
                insertProduct.Parameters.AddWithValue("@price", Cart_DataTable.Rows[i]["price"]);
                insertProduct.Parameters.AddWithValue("@total_price", Cart_DataTable.Rows[i]["total"]);
                insertProduct.ExecuteNonQuery();
                con.Close();
            }
             */
        }

        private void CalculateTotalAmount()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select sum(Amount) from Cart where CartID='" + Session.SessionID + "'", con);
            lblTotalAmount.Text = cmd.ExecuteScalar().ToString();
            cmd.Dispose();
            con.Close();

        }

        protected void GridView1_RowUpdated(object sender, GridViewUpdatedEventArgs e)
        {
            CalculateTotalAmount();
        }

        protected void GridView1_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {
            CalculateTotalAmount();
        }
    }
}