<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="myOrders.aspx.cs" Inherits="Superomart.myOrders" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" >
        <div class="row">
            <div id="page-wrapper">
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Orders List</h1>
            </div>
            <!-- /.col-lg-12 -->
        </div>
        <!-- /.row -->
        <div class="row">
            <div class="col-lg-12">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        Orders
                        <%--<asp:HyperLink ID="addfarmer" runat="server" style="float:right;" NavigateUrl="~/admin/OrderDetails.aspx" CssClass="btn" ></asp:HyperLink>--%>
                    </div>
                    <!-- /.panel-heading -->
                    <div class="panel-body">
                        <div class="flot-chart">
                            <div class="flot-chart-content" id="flot-line-chart">

                                <asp:GridView ID="GridView1" CssClass="table table-hover" GridLines="None"  runat="server" AutoGenerateColumns="False" >
                                    <Columns>
                                        <asp:BoundField DataField="orderID" HeaderText="orderID" SortExpression="orderID" />
                                        <asp:BoundField DataField="full_name" HeaderText="Full Name" SortExpression="full_name" />
                                        <asp:BoundField DataField="address" HeaderText="Address" SortExpression="Address" />
                                        <asp:BoundField DataField="email" HeaderText="Email" SortExpression="email" />
                                        <asp:BoundField DataField="mobile" HeaderText="Mobile" SortExpression="mobile" />
                                        <asp:BoundField DataField="pin" HeaderText="Pincode" SortExpression="pin" />
                                        <asp:BoundField DataField="created_on" HeaderText="Created On" SortExpression="created_on" />
                                        <asp:BoundField DataField="card_id" HeaderText="card_id" SortExpression="card_id" />
                                        <asp:BoundField DataField="payment_id" HeaderText="payment_id" SortExpression="payment_id" />
                                        <asp:BoundField DataField="payment_status" HeaderText="payment_status" SortExpression="payment_status" />
                                        <asp:BoundField DataField="payment_on" HeaderText="payment_on" SortExpression="payment_on" />
                                        <asp:TemplateField HeaderText="Detail">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# String.Format("~/OrderDetail.aspx?orderID={0}",Eval("orderID")) %>'>Detail</asp:HyperLink>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        
                                        <%--<asp:TemplateField HeaderText="Edit">
                                            <ItemTemplate>
                                                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# String.Format("~/admin/editUser.aspx?user_id={0}",Eval("user_id")) %>'>Edit</asp:HyperLink>
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                    <!-- /.panel-body -->
                </div>
                <!-- /.panel -->
            </div>
        </div>
            <!-- /.row -->
    </div>
        </div>
    </div>
          
    <!-- /#page-wrapper -->
    <%--<script src="assetsadmin/js/jquery.min.js"></script>
    <script src="assetsadmin/js/bootstrap.min.js"></script>
    <script src="assetsadmin/js/jquery.dataTables.min.js"></script>--%>
    <%--<script type="text/javascript">
        $(document).ready(function () {
            $('#ContentPlaceHolder1_GridView1').DataTable({
                "paging": true,
                "ordering": false,
                "info": false
            });
        });
    </script>--%>
</asp:Content>
