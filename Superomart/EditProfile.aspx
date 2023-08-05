<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="EditProfile.aspx.cs" Inherits="Superomart.EditProfile" %>
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
						<h2>Update Profile</h2>
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
									 <asp:TextBox ID="first_name" runat="server" class="form-control" placeholder="enter your first name" ></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter Your First Name" ControlToValidate="first_name"></asp:RequiredFieldValidator>
                            </div>
							<div class="col-md-12">
                            <div class="form-group">
                                <asp:TextBox ID="last_name" runat="server" class="form-control" placeholder="enter your last name"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Enter Your last Name" ControlToValidate="last_name"></asp:RequiredFieldValidator>
                              </div>
							</div>
								<div class="col-md-12">
									<div class="form-group">
									 <asp:Label ID="email" runat="server" Text="Label"></asp:Label>
                            </div>
						  </div>
								<div class="col-md-12">
									<div class="form-group">
                                <asp:Image ID="Image1" runat="server" Height="30px" Width="30px" /><asp:FileUpload ID="FileUpload1" runat="server" />
                             </div>
						</div>
								<div class="col-md-12">
									<div class="form-group">
										<asp:Button ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click"  />
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
	</div>
</div>
</asp:Content>
