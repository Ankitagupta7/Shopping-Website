<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="Superomart.Profile" %>
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
							<img src="images/avtar.jpg" class="w-25 m-3 rounded-circle" />
						<h1>My Profile</h1>
					</div>
				</div>
			</div>
		</div>
	</div>
			<div class="row">
				<div class="col-lg-12">
					<%--<form id="contactForm">--%>
						<div class="row">
                            <asp:Label ID="lblErrorMsg" runat="server" Text=""></asp:Label>
							<div class="col-md-12">
								<div class="form-group">
                                    First Name : <asp:Label ID="first_name" runat="server" Text=""></asp:Label>
								</div>                                 
							</div>
                            <div class="col-md-12">
								<div class="form-group">
                                    Last Name : <asp:Label ID="last_name" runat="server" Text=""></asp:Label>
								</div>                                 
							</div>
                            <div class="col-md-12">
								<div class="form-group">
                                    Photo : <asp:Label ID="lblfarImg" runat="server" Text=""></asp:Label>
								</div>                                 
							</div>
						</div>            
					<%--</form>--%>
				</div>
			</div>
		</div>
	</div>
	<!-- End Contact -->
</asp:Content>
