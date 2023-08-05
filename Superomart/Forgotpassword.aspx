<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Forgotpassword.aspx.cs" Inherits="Superomart.Forgotpassword" %>
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
						<h1><b>Forgot Password</b></h1>
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
									<asp:TextBox ID="email" runat="server" class="form-control" placeholder="Enter your Email" ></asp:TextBox>
								</div> 
							</div>
							<div class="col-md-12">
								<div class="submit-button text-center">
									<div class="clearfix">
										</div>
									<asp:Button ID="Button1" runat="server" Text="Submit" Cssclass="btn-success btn-block" OnClick="Button1_Click"  />
								</div>
							</div>
                            <div class="col-md-12">
                                <div class="col-md-6" style="float:left;">
                                    <asp:HyperLink ID="HyperLink1" NavigateUrl="~/SigninWithOTP.aspx" runat="server">Reset Password with OTP.</asp:HyperLink>
                                </div>
                            </div>
						</div>            
					<%--</form>--%>
				</div>
			</div>
		</div>
	<!-- End Contact -->
</asp:Content>
