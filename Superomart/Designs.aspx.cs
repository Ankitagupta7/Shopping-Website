using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;

namespace Superomart
{
    public partial class Designs : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conString"].ConnectionString);
        DataTable Cart_DataTable = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                Bind();
        }
        public void Bind()
        {
            int pageNo = Request.QueryString["pn"] == null ? 1 : Convert.ToInt32(Request.QueryString["pn"]);
            int pageSize = 9;
            string category = "Design".ToString();

            SqlConnection conn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            DataSet dataSet = new DataSet();

            conn.ConnectionString = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;

            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[dbo].[sp_GetProductByCustomPagingdesignlist]";

            cmd.Parameters.AddWithValue("@PageNo", pageNo);
            cmd.Parameters.AddWithValue("@pageSize", pageSize);
            cmd.Parameters.AddWithValue("@category", category);

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            sqlDataAdapter.SelectCommand = cmd;

            try
            {
                sqlDataAdapter.Fill(dataSet);
                if (dataSet.Tables[0].Rows.Count > 0)
                {
                    CreateTable(dataSet.Tables[0]);

                    Literal1.Text += "<div class='row'>";
                    con.Open();
                    SqlCommand cmd2 = new SqlCommand("select * from designlist", con);
                    //SqlCommand cmd2 = new SqlCommand('SELECT* FROM (SELECT ROW_NUMBER() OVER(ORDER BY pet_id DESC) AS ''RowNum'', *FROM products WHERE 1 = 1) a WHERE a.RowNum BETWEEN ('+CAST(@pageNo AS NVARCHAR(5))+' - 1) * '+CAST(@pageSize AS NVARCHAR(5))+' + 1 AND('+CAST(@pageNo AS NVARCHAR(5))+' * '+CAST(@pageSize AS NVARCHAR(5))+')";
                    //SqlCommand cmd2 = new SqlCommand();
                    cmd2.CommandType = CommandType.StoredProcedure;
                    cmd2.CommandText = "[dbo].[sp_GetProductByCustomPagingdesignlist]";
                    cmd2.Parameters.AddWithValue("@PageNo", pageNo);
                    cmd2.Parameters.AddWithValue("@pageSize", pageSize);
                    cmd2.Parameters.AddWithValue("@category", category);
                    SqlDataReader dr = cmd2.ExecuteReader();

                    while (dr.Read())
                    {
                        Literal1.Text += "<div class='col-sm-4'>";
                        Literal1.Text += "<div class='panel panel-primary' style='padding: 10px; margin: 10px; border: 1px solid #dadada;box-shadow:0 .15rem 1.75rem 0 rgba(58,59,69,.15) !important;border-radius: 5px;'>";
                        Literal1.Text += "<div class='panel-heading text-center'>" + (string)dr["designlist_name"] + "</div>";
                        Literal1.Text += "<div class='panel-body' style='padding: 20px;'>";
                        Literal1.Text += "<img src='admin/designlistHandler.ashx?designlist_id=" + (int)dr["designlist_id"] + "' class='img-responsive' style='width:100%' alt='Image'>";
                        Literal1.Text += "</div>";
                        Literal1.Text += "<div class='panel-footer'>&#8377;" + (string)dr["price"] + "&nbsp;";
                        Literal1.Text += "<a href='designlistDetails.aspx?designlist_id=" + (int)dr["designlist_id"] + "' class='pull-right btn btn-primary' style='margin-top: -7px;float:right;'>Buy Now</a></div>";
                        Literal1.Text += "</div>";
                        Literal1.Text += "</div>";
                    }

                    dr.Close();
                    cmd.Dispose();
                    con.Close();
                    Literal1.Text += "</div>";
                    pagingDiv.InnerHtml = Set_Paging(pageNo, pageSize, Convert.ToInt32(dataSet.Tables[1].Rows[0]["Total"]), "activeLink", "HealthCare.aspx", "disableLink");
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
            finally
            {
            }
        }

        public void CreateTable(DataTable dataTable)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<table><tbody><tr>");

            foreach (DataColumn column in dataTable.Columns)
                sb.Append("<th>" + column.ColumnName + "</th>");

            sb.Append("</tr>");

            foreach (DataRow row in dataTable.Rows)
            {
                sb.Append("<tr>");
                foreach (DataColumn column in dataTable.Columns)
                {
                    sb.Append("<th>" + row[column] + "</th>");
                }
                sb.Append("</tr>");
            }
            sb.Append("</tbody></table>");
            //myGrid.InnerHtml = sb.ToString();
        }

        public string Set_Paging(Int32 PageNumber, int PageSize, Int64 TotalRecords, string ClassName, string PageUrl, string DisableClassName)
        {
            string ReturnValue = "";
            try
            {
                Int64 TotalPages = Convert.ToInt64(Math.Ceiling((double)TotalRecords / PageSize));
                if (PageNumber > 1)
                {
                    if (PageNumber == 2)
                        ReturnValue = ReturnValue + "<a href='" + PageUrl.Trim() + "?pn=" + Convert.ToString(PageNumber - 1) + "' class='" + ClassName + "'>Previous</a>&nbsp;&nbsp;&nbsp;";
                    else
                    {
                        ReturnValue = ReturnValue + "<a href='" + PageUrl.Trim();
                        if (PageUrl.Contains("?"))
                            ReturnValue = ReturnValue + "&";
                        else
                            ReturnValue = ReturnValue + "?";
                        ReturnValue = ReturnValue + "pn=" + Convert.ToString(PageNumber - 1) + "' class='" + ClassName + "'>Previous</a>&nbsp;&nbsp;&nbsp;";
                    }
                }
                else
                    ReturnValue = ReturnValue + "<span class='" + DisableClassName + "'>Previous</span>&nbsp;&nbsp;&nbsp;";
                if ((PageNumber - 3) > 1)
                    ReturnValue = ReturnValue + "<a href='" + PageUrl.Trim() + "' class='" + ClassName + "'>1</a>&nbsp;.....&nbsp;|&nbsp;";
                for (int i = PageNumber - 3; i <= PageNumber; i++)
                    if (i >= 1)
                    {
                        if (PageNumber != i)
                        {
                            ReturnValue = ReturnValue + "<a href='" + PageUrl.Trim();
                            if (PageUrl.Contains("?"))
                                ReturnValue = ReturnValue + "&";
                            else
                                ReturnValue = ReturnValue + "?";
                            ReturnValue = ReturnValue + "pn=" + i.ToString() + "' class='" + ClassName + "'>" + i.ToString() + "</a>&nbsp;|&nbsp;";
                        }
                        else
                        {
                            ReturnValue = ReturnValue + "<span style='font-weight:bold;'>" + i + "</span>&nbsp;|&nbsp;";
                        }
                    }
                for (int i = PageNumber + 1; i <= PageNumber + 3; i++)
                    if (i <= TotalPages)
                    {
                        if (PageNumber != i)
                        {
                            ReturnValue = ReturnValue + "<a href='" + PageUrl.Trim();
                            if (PageUrl.Contains("?"))
                                ReturnValue = ReturnValue + "&";
                            else
                                ReturnValue = ReturnValue + "?";
                            ReturnValue = ReturnValue + "pn=" + i.ToString() + "' class='" + ClassName + "'>" + i.ToString() + "</a>&nbsp;|&nbsp;";
                        }
                        else
                        {
                            ReturnValue = ReturnValue + "<span style='font-weight:bold;'>" + i + "</span>&nbsp;|&nbsp;";
                        }
                    }
                if ((PageNumber + 3) < TotalPages)
                {
                    ReturnValue = ReturnValue + ".....&nbsp;<a href='" + PageUrl.Trim();
                    if (PageUrl.Contains("?"))
                        ReturnValue = ReturnValue + "&";
                    else
                        ReturnValue = ReturnValue + "?";
                    ReturnValue = ReturnValue + "pn=" + TotalPages.ToString() + "' class='" + ClassName + "'>" + TotalPages.ToString() + "</a>";
                }
                if (PageNumber < TotalPages)
                {
                    ReturnValue = ReturnValue + "&nbsp;&nbsp;&nbsp;<a href='" + PageUrl.Trim();
                    if (PageUrl.Contains("?"))
                        ReturnValue = ReturnValue + "&";
                    else
                        ReturnValue = ReturnValue + "?";
                    ReturnValue = ReturnValue + "pn=" + Convert.ToString(PageNumber + 1) + "' class='" + ClassName + "'>Next</a>";
                }
                else
                    ReturnValue = ReturnValue + "&nbsp;&nbsp;&nbsp;<span class='" + DisableClassName + "'>Next</span>";
            }
            catch (Exception )
            {
            }
            return (ReturnValue);
        }

    }
}

    
