<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasterAdmin.master" AutoEventWireup="true" CodeFile="addProduct.aspx.cs" Inherits="admin_addProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="page-wrapper">
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Add Product Profile</h1>
            </div>
            <!-- /.col-lg-12 -->
        </div>
        <!-- /.row -->
        <div class="row">
            <div class="col-lg-9 col-lg-offset-1">
                <div class="panel panel-default">
                    <div class="panel-heading">
                       Add Product Details
                    </div>
                    <!-- /.panel-heading -->
                    <div class="panel-body">
                        <div class="flot-chart">
                            <asp:Label ID="lblMsgReg" runat="server" Text=""></asp:Label>
                            <div class="form-group">
                              <label class="control-label col-sm-3" for="product_name">Product Name :</label>
                              <div class="col-sm-9">
                                <asp:TextBox ID="product_name" runat="server" name="product_name" placeholder="Product Name" class="form-control"></asp:TextBox>
                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="product_name" ErrorMessage="Enter your Product name" CssClass="text-danger"></asp:RequiredFieldValidator>
                              </div>
                            </div>
                            <div class="clearfix">&nbsp;</div>
                            <div class="form-group">
                              <label class="control-label col-sm-3" for="product_name">Price :</label>
                              <div class="col-sm-9">
                                <asp:TextBox ID="price" runat="server" name="price" placeholder="Price" class="form-control"></asp:TextBox>
                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="price" ErrorMessage="Enter your Price" CssClass="text-danger"></asp:RequiredFieldValidator>
                              </div>
                            </div>
                            <div class="clearfix">&nbsp;</div>
                            <div class="form-group">
                              <label class="control-label col-sm-3" for="photo">Photo :<asp:Label ID="lblfarImg" runat="server" Text=""></asp:Label></label>
                              <div class="col-sm-9">          
                                  <asp:FileUpload ID="FileUpload1" runat="server" />
                              </div>
                            </div>
                            <div class="clearfix">&nbsp;</div>
                            <div class="form-group">        
                              <div class="col-sm-offset-3 col-sm-9">
                                <asp:Button ID="addProduct" runat="server" Text="Add Product" CssClass="btn btn-primary" OnClick="addProduct_Click"  />
                              </div>
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
</asp:Content>

