<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Ragister.aspx.cs" Inherits="Superomart.Ragister" %>
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
							
							<h1 class="font-weight-bold">Register</h1>
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
                                    <asp:TextBox ID="first_name" runat="server" class="form-control" placeholder="Enter your first_name" ></asp:TextBox>
									<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="first_name" ErrorMessage="first_name is required" CssClass="requiredField" ForeColor="Red"></asp:RequiredFieldValidator>
								</div>                                 
							</div>
                            <div class="col-md-12">
								<div class="form-group">
                                    <asp:TextBox ID="last_name" runat="server" class="form-control" placeholder="Enter your last_name" ></asp:TextBox>
									<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="last_name" ErrorMessage="last_name is required" CssClass="requiredField" ForeColor="Red"></asp:RequiredFieldValidator>
								</div>                                 
							</div>
							<div class="col-md-12">
								<div class="form-group">
									<asp:TextBox ID="email" runat="server" class="form-control" placeholder="Enter your Email" ></asp:TextBox>
									<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="email" ErrorMessage="Email is required" CssClass="requiredField" ForeColor="Red"></asp:RequiredFieldValidator>
								</div> 
							</div>
							<div class="col-md-12">
								<div class="form-group">
									<asp:TextBox ID="Contact" runat="server" class="form-control" placeholder="Enter your Contact" ></asp:TextBox>
									<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="Contact" ErrorMessage="Contact is required" CssClass="requiredField" ForeColor="Red"></asp:RequiredFieldValidator>
								</div> 
								</div>
							<div class="col-md-12">
								<div class="form-group">
									<asp:TextBox ID="City" runat="server" class="form-control" placeholder="Enter your City" ></asp:TextBox>
									<asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="City" ErrorMessage="City is required" CssClass="requiredField" ForeColor="Red"></asp:RequiredFieldValidator>
								</div> 
									</div> 
									<div class="col-md-12">
								<div class="form-group">
									<asp:TextBox ID="Address" runat="server" class="form-control" placeholder="Enter your Address" ></asp:TextBox>
									<asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="Address" ErrorMessage="Address is required" CssClass="requiredField" ForeColor="Red"></asp:RequiredFieldValidator>
								</div> 
								</div>
							<div class="col-md-12">
								<div class="form-group">
									<asp:TextBox ID="password" runat="server" class="form-control" placeholder="Enter your Password" TextMode="Password" ></asp:TextBox>
									 <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="password" ErrorMessage="Password is required" CssClass="requiredField" ForeColor="Red"></asp:RequiredFieldValidator>
								</div> 
							</div>
							<div class="col-md-12">
								<div class="form-group">
									<asp:TextBox ID="confirm_password" runat="server" class="form-control" placeholder="Enter your Confirm Password"  TextMode="Password"></asp:TextBox>
									<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="confirm_password" ErrorMessage="Confirm Password is required" CssClass="requiredField" ForeColor="Red"></asp:RequiredFieldValidator>
                               
									<asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="password" ControlToValidate="confirm_password" ErrorMessage="Password and confirm password should be same." CssClass="requiredField" ForeColor="Red"></asp:CompareValidator>
								</div> 
							</div>
                            <div class="col-md-12">
								<div class="form-group">
                                    <asp:RadioButton ID="male" runat="server" Text="Male" groupName="gender" Checked="true" />
                                    <asp:RadioButton ID="female" runat="server" Text="Female" groupName="gender"/>
                                </div> 
							</div>

                            
                            <div class="col-md-12">
								<div class="form-group">
                                    <asp:FileUpload ID="FileUpload1" runat="server" />
                                </div> 
							</div>
                            
							<div class="col-md-12">
								<div class="form-group">
									<asp:Image ID="captchaImage" runat="server" Height="40px" Width="150px" ImageUrl="~/Captcha.aspx" />
                                      <asp:TextBox ID="captchaCode" runat="server" placeholder="Enter your Captcha*" class="contact-input" ></asp:TextBox>
									<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="captchaCode" ErrorMessage="Captcha* is required" CssClass="requiredField" ForeColor="Red"></asp:RequiredFieldValidator>
								</div> 
							</div>
							
							<div class="col-md-12">
								<div class="submit-button text-center">
									<asp:Button ID="Button1" runat="server" Text="Register" Cssclass="btn-success btn-block" OnClick="Button1_Click"   />
									<p> <a href="signin.aspx" class="text-primary">Already have an account? sign in</a></p>
									<div class="clearfix"></div> 
									
									<br />
									<br />
								</div>
							</div>
						</div>            
					<%--</form>--%>
				</div>
			</div>
		</div>
	
	<!-- End Contact -->
</asp:Content>
