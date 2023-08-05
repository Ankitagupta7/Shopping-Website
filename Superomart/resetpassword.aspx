<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="resetpassword.aspx.cs" Inherits="Superomart.resetpassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Start Contact -->
     <div class="contact-box" style="padding-top:120px;" >
		<div class="container">
			<div class="row">
				<div class="col-lg-12">
					<div class="heading-title text-center">

						<div class="row w-screen d-flex justify-content-center">
						<div class="col-md-6 d-flex justify-content-center flex-column align-items-center w-100 p-3">
							<img src="images/avtar.png" class="w-25 m-3 rounded-circle" />
							
							<h1 class="font-weight-bold">Reset Password</h1>
						</div>
							</div>
						</div>
						</div>
				</div>
			</div>
			<div class="row">
				<div class="col-lg-6 offset-lg-3">
				
					<%--<form id="contactForm">--%>
						<div class="row">
                            <asp:Label ID="lblErrorMsg" runat="server" Text=""></asp:Label>
							<div class="col-md-12">
								<div class="form-group">
									<asp:TextBox ID="password" runat="server" class="form-control" placeholder="Enter your Password" TextMode="Password" ></asp:TextBox>
									 <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="password" ErrorMessage="Password is required" CssClass="requiredField" ForeColor="Red"></asp:RequiredFieldValidator>
								</div> 
							</div>
							<div class="col-md-12">
								<div class="form-group">
									<asp:TextBox ID="confirm_password" runat="server" class="form-control" placeholder="Enter your  Confirm Password"  TextMode="Password"></asp:TextBox>
									<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="cpassword" ErrorMessage="Confirm Password is required" CssClass="requiredField" ForeColor="Red"></asp:RequiredFieldValidator>
                                 <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="password" ControlToValidate="cpassword" ErrorMessage="Password and confirm password should be same." CssClass="requiredField" ForeColor="Red"></asp:CompareValidator>
								</div> 
							</div>
							<div class="col-md-12">
								<div class="submit-button text-center">
									<asp:Button ID="Button1" runat="server" Text="Submit" Cssclass="btn-success btn-block" OnClick="Button1_Click"  />
									</div>
								</div>
							</div>
					</div>
				</div>
		 </div>
</asp:Content>
