<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="SigninWithOTP.aspx.cs" Inherits="Superomart.SigninWithOTP" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Start Contact -->
     <div class="contact-box" style="padding-top:120px;" >
		<div class="container">
			<div class="row">
				<div class="col-lg-12">
					<div class="heading-title text-center">

							<img src="images/avtar.jpg" class="w-25 m-3 rounded-circle" />
							
							<h1 class="font-weight-bold">SigninWithOTP</h1>
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
									<asp:TextBox ID="email" runat="server" class="form-control" placeholder="Enter your Email" ></asp:TextBox>
									<asp:RegularExpressionValidator ID="regexEmailValid" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="email" ErrorMessage="Invalid Email Format"></asp:RegularExpressionValidator>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="email" ErrorMessage="Email is required" CssClass="requiredField" ForeColor="Red"></asp:RequiredFieldValidator>
								</div> 

								   <div class="col-md-12">
								        <div class="form-group">
							                 <asp:Button ID="Button1" runat="server" Text="Submit" CssClass="btn-success btn-block" OnClick="Button1_Click"  />
							      </div>
									 <div class="col-md-6" style="float:left;">
                                      <asp:HyperLink ID="HyperLink1" NavigateUrl="~/ForgotPassword.aspx" runat="server">Forgot Password?</asp:HyperLink>
                                 </div>
							</div>
                        </div>
					</div>
				</div>
		    </div>
		 </div>
				</div>
				
	 <!-- Contact End -->
</asp:Content>
