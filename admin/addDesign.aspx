﻿<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasterAdmin.master" AutoEventWireup="true" CodeFile="addDesign.aspx.cs" Inherits="admin_addDesign" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="page-wrapper">
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Add Design</h1>
            </div>
            <!-- /.col-lg-12 -->
        </div>
        <!-- /.row -->
        <div class="row">
            <div class="col-lg-9 col-lg-offset-1">
                <div class="panel panel-default">
                    <div class="panel-heading">
                       Add Design Details
                    </div>
                    <!-- /.panel-heading -->
                    <div class="panel-body">
                        <div class="flot-chart">
                            <asp:Label ID="lblMsgReg" runat="server" Text=""></asp:Label>
                            <div class="form-group">
                              <label class="control-label col-sm-3" for="designlist_name">Design Name :</label>
                              <div class="col-sm-9">
                                <asp:TextBox ID="designlist_name" runat="server" name="designlist_name" placeholder="design Name" class="form-control"></asp:TextBox>
                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="designlist_name" ErrorMessage="Enter your design name" CssClass="text-danger"></asp:RequiredFieldValidator>
                              </div>
                            </div>
                            <div class="clearfix">&nbsp;</div>
                            <div class="form-group">
                              <label class="control-label col-sm-3" for="designlist_detail">Design Details :</label>
                              <div class="col-sm-9">
                                <asp:TextBox ID="designlist_detail" runat="server" name="designlist_detail" placeholder="design Details" class="form-control"></asp:TextBox>
                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="designlist_detail" ErrorMessage="Enter your design details" CssClass="text-danger"></asp:RequiredFieldValidator>
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
                                <asp:Button ID="addDesign" runat="server" Text="Add Design" CssClass="btn btn-primary" OnClick="addDesign_Click"  />
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

