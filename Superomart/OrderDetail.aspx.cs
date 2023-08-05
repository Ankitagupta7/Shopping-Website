using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Superomart
{
    public partial class OrderDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.PreRender += new EventHandler(GridView1_PreRender);
            bind();

            if (!IsPostBack)
            {
                string order_id = Request.QueryString["orderID"].ToString();
                string qr = "select * from [orders] where orderID=" + order_id;
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conString"].ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand(qr, con);
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                ad.Fill(ds);
                con.Close();
                full_name.Text = ds.Tables[0].Rows[0]["full_name"].ToString();
                email.Text = ds.Tables[0].Rows[0]["email"].ToString();
                mobile.Text = ds.Tables[0].Rows[0]["mobile"].ToString();
                address.Text = ds.Tables[0].Rows[0]["address"].ToString();
                pin.Text = ds.Tables[0].Rows[0]["pin"].ToString();
                created_on.Text = ds.Tables[0].Rows[0]["created_on"].ToString();
                payment_status.Text = ds.Tables[0].Rows[0]["payment_status"].ToString();

                //lblfarImg.Text = "<img width='50' height='50' src='userHandler.ashx?user_id=" + user_id + "' alt='' />";

            }
        }
        public void bind()
        {
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["conString"].ConnectionString);

            con.Open();
            string order_id = Request.QueryString["orderID"].ToString();
            String cmd = "select * from [orderDetails] where orderID=" + order_id;

            SqlCommand login = new SqlCommand(cmd, con);
            SqlDataAdapter ad = new SqlDataAdapter(login);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            con.Close();
            GridView1.DataSource = ds.Tables[0];
            GridView1.DataBind();


        }
        protected void GridView1_PreRender(object sender, EventArgs e)
        {
            if (GridView1.Rows.Count > 0)
            {
                GridView1.UseAccessibleHeader = true;
                GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }
    }

}
