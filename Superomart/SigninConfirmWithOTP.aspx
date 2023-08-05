<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="SigninConfirmWithOTP.aspx.cs" Inherits="Superomart.SigninConfirmWithOTP" %>
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
							<img src="images/avtar.jpg" class="w-50 m-3 rounded-circle" />
							
						
							
							<h2 class="font-weight-bold">SigninConfirmWithOTP</h2>
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
						 <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
						 <div class="col-md-12">
							<div class="form-group">
								<asp:TextBox ID="otp" runat="server" class="form-control" Placeholder="Enter OTP" MaxLength="10"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="otp" ErrorMessage="OTP is required" CssClass="requiredField" ForeColor="Red"></asp:RequiredFieldValidator>
                              </div> 
						 </div> 

						 <div class="col-md-12">
						  <div class="form-group">
							           <asp:Button ID="Button1" runat="server" Text="Submit" CssClass="btn-success btn-block" OnClick="Button1_Click"    />
							     </div>
						   </div>
					   </div>
                  </div>
			</div>
	    </div>
	</div>
</asp:Content>
