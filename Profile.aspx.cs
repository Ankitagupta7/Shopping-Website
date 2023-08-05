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
    public partial class Profile : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["mart"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["email"] == null)
                {
                    Response.Redirect("Signin.aspx");
                }
                if (con.State == ConnectionState.Closed)
                    con.Open();
                string getUserinfo = "select first_name,last_name, email, photo from [userinfo] where email ='" + Session["email"] + "'";
                SqlCommand usrCmd = new SqlCommand(getUserinfo, con);

                SqlDataAdapter ad = new SqlDataAdapter(usrCmd);
                DataSet ds = new DataSet();
                ad.Fill(ds);
                con.Close();
                first_name.Text = ds.Tables[0].Rows[0]["first_name"].ToString();
                last_name.Text = ds.Tables[0].Rows[0]["last_name"].ToString();
                lblfarImg.Text = "<img width='50' height='50' src='photoHandler.ashx?user_id=" + Session["user_id"] + "' alt='' />";

                //SqlDataReader readIsActive = usrCmd.ExecuteReader();
                //first_name.Text = readIsActive.GetValue(0).ToString().Trim();
                con.Close();

            }
        }
    }
}
        