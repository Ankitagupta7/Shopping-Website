<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="OrderDetail.aspx.cs" Inherits="Superomart.OrderDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container">
        <div class="row">
            <div id="page-wrapper">
                <div class="row">
                    <div class="col-lg-12">
                        <h1 class="page-header">Details List</h1>
                        <p style="line-height: 30px;">
                            Full Name : <asp:Label ID="full_name" runat="server" Text=""></asp:Label>
                        </p>
                        <p style="line-height: 30px;">
                            Email : <asp:Label ID="email" runat="server" Text=""></asp:Label>
                        </p>
                        <p style="line-height: 30px;">
                            Mobile : <asp:Label ID="mobile" runat="server" Text=""></asp:Label>
                        </p>
                        <p style="line-height: 30px;">
                            Address : <asp:Label ID="address" runat="server" Text=""></asp:Label>
                        </p>
                        <p style="line-height: 30px;">
                            Pincode : <asp:Label ID="pin" runat="server" Text=""></asp:Label>
                        </p>
                        <p style="line-height: 30px;">
                            Created On : <asp:Label ID="created_on" runat="server" Text=""></asp:Label>
                        </p>
                        <p style="line-height: 30px;">
                            Payment Status : <asp:Label ID="payment_status" runat="server" Text=""></asp:Label>
                        </p>
                    </div>
                    <!-- /.col-lg-12 -->
                </div>
                <!-- /.row -->
                <div class="row">
                    <div class="col-lg-12">
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                Product list
                            </div>
                            <!-- /.panel-heading -->
                            <div class="panel-body">
                                <div class="flot-chart">
                                    <div class="flot-chart-content" id="flot-line-chart">

                                        <asp:GridView ID="GridView1" CssClass="table table-hover" GridLines="None"  runat="server" AutoGenerateColumns="False" >
                                            <Columns>
                                                <asp:BoundField DataField="productID" HeaderText="productID" SortExpression="productID" />
                                                <asp:BoundField DataField="ProductName" HeaderText="ProductName" SortExpression="ProductName" />
                                                <asp:BoundField DataField="quantity" HeaderText="Quantity" SortExpression="quantity" />
                                                <asp:BoundField DataField="Amount" HeaderText="Amount" SortExpression="Amount" />
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
            <!-- /#page-wrapper -->
        </div>
    </div>
       
    <%--<script src="admin/assetsadmin/js/jquery.min.js"></script>
    <script src="admin/assetsadmin/js/bootstrap.min.js"></script>
    <script src="admin/assetsadmin/js/jquery.dataTables.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#ContentPlaceHolder1_GridView1').DataTable({
                "paging": true,
                "ordering": false,
                "info": false
            });
        });
    </script>--%>
</asp:Content>
