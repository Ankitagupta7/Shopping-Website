<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="Superomart.cart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 
    <%--<style>
        hr.new {
  border-top: 3px solid red;
  width:100%;
}

    </style>
    <script src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>
    <style>
        /* Remove the navbar's default rounded borders and increase the bottom margin */
        .navbar {
            margin-bottom: 50px;
            border-radius: 0;
        }

        /* Remove the jumbotron's default bottom margin */
        .jumbotron {
            margin-bottom: 0;
        }

        /* Add a gray background color and some padding to the footer */
        footer {
            background-color: #f2f2f2;
            padding: 25px;
        }
    </style>
    <script>
        function successalert() {
            swal({
                title: 'Thank You!',
                text: 'Your Order has been placed successfully.',
                type: 'success'
            }).then(() => {
                window.location.href = "myOrders.aspx";
            });
        }
    </script>--%>
    
<section class="banner-bottom-wthree py-lg-5 py-md-5 py-3" style="padding-top:6rem !important;">
    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <div class="container-fluid1">
					<div class="card shadow mb-1">
						<div class="card-header py-3">
							<h6 class="m-0 font-weight-bold text-primary">Cart Details</h6>
						</div>
						<div class="card-body">
							<div class="container1" >
								<div class="row">
                                    <div>
                                        <asp:GridView ID="GridView1" CssClass="table table-hover table-responsive" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="SqlDataSource1" OnRowUpdated="GridView1_RowUpdated" OnRowDeleted="GridView1_RowDeleted">
                                            <Columns>
                                                <asp:CommandField ShowDeleteButton="True" ShowEditButton="false" />
                                                <asp:BoundField DataField="ProductName" HeaderText="ProductName" SortExpression="ProductName" />
                                                <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" Visible="false" SortExpression="ID" />
                                                <asp:BoundField DataField="ProductID" HeaderText="ProductID" ReadOnly="true" SortExpression="ProductID" />
                                                <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity" />
                                                <asp:BoundField DataField="Price" HeaderText="Price" ReadOnly="true" SortExpression="Price" />
                                                <asp:BoundField DataField="Amount" HeaderText="Amount" ReadOnly="true" SortExpression="Amount" />
                                                <asp:BoundField DataField="CartID" HeaderText="CartID" SortExpression="CartID" />
                                            </Columns>
                                        </asp:GridView>

                                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:conString %>" DeleteCommand="DELETE FROM [Cart] WHERE [ID] = @ID"
                                            InsertCommand="INSERT INTO [Cart] ([ProductID], [Quantity], [Price], [Amount], [CartID]) VALUES (@ProductID, @Quantity, @Price, @Amount, @CartID)"
                                            SelectCommand="SELECT * FROM [Cart] WHERE ([CartID] = @CartID)"
                                            UpdateCommand="UPDATE [Cart] SET [Quantity] = @Quantity, [Amount] = @Quantity*Price WHERE [ID] = @ID">
                                            <DeleteParameters>
                                                <asp:Parameter Name="ID" Type="Int32" />
                                            </DeleteParameters>
                                            <InsertParameters>
                                                <asp:Parameter Name="ProductID" Type="Int32" />
                                                <asp:Parameter Name="Quantity" Type="Int32" />
                                                <asp:Parameter Name="Price" Type="Decimal" />
                                                <asp:Parameter Name="Amount" Type="Decimal" />
                                                <asp:Parameter Name="CartID" Type="String" />
                                            </InsertParameters>
                                            <SelectParameters>
                                                <asp:SessionParameter Name="CartID" SessionField="CartID" Type="String" />
                                            </SelectParameters>
                                            <UpdateParameters>
                                                <asp:Parameter Name="ProductID" Type="Int32" />
                                                <asp:Parameter Name="Quantity" Type="Int32" />
                                                <asp:Parameter Name="Price" Type="Decimal" />
                                                <asp:Parameter Name="Amount" Type="Decimal" />
                                                <asp:Parameter Name="CartID" Type="String" />
                                                <asp:Parameter Name="ID" Type="Int32" />
                                            </UpdateParameters>
                                        </asp:SqlDataSource>
                                        <div class="row">
                                            <div class="text-right col-md-12">
                                                Total Amount: &#8377;
                                                <asp:Label ID="lblTotalAmount" runat="server" Text="Label"></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-12">
            <div class="container-fluid1">
				<div class="card shadow mb-1">
					<div class="card-header py-3">
						<h6 class="m-0 font-weight-bold text-primary">Address Details</h6>
					</div>
					<div class="card-body">
						<div class="container1">
							<div class="row">
                                <div class="col-md-12">
            <a href="myorders.aspx"><h2 class="form-control">Go to My Orders....</h2></a> 
            <hr class="new" />
            <h2>Place Order for the Product Now</h2> 
            <hr class="new" />
                
            <asp:Label ID="lblMsgReg" runat="server" Text=""></asp:Label>
            <div class="form-group">
                <label class="control-label col-sm-3" for="full_name">Full Name :</label>
                <div class="col-sm-9">
                <asp:TextBox ID="full_name" runat="server" class="form-control" placeHolder="Enter your full Name"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="full_name" ErrorMessage="Enter your full name" CssClass="text-danger"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="form-group">
                <label class="control-label col-sm-3" for="email">Email :</label>
                <div class="col-sm-9">
                <asp:TextBox ID="email" runat="server" class="form-control" placeHolder="Enter your email"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="email" ErrorMessage="Enter your email" CssClass="text-danger"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="form-group">
                <label class="control-label col-sm-3" for="mobile">Mobile :</label>
                <div class="col-sm-9">
                <asp:TextBox ID="mobile" runat="server" class="form-control" placeHolder="Enter your mobile" MaxLength="10"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="mobile" ErrorMessage="Enter your mobile" CssClass="text-danger"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="mobile" ErrorMessage="Number only" ValidationExpression="[0-9]{10}"></asp:RegularExpressionValidator>
                </div>
            </div>
            <div class="form-group">
                <label class="control-label col-sm-3" for="address">Address :</label>
                <div class="col-sm-9">
                    <asp:TextBox ID="address" class="form-control" TextMode="MultiLine" placeHolder="Enter your Address" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="address" ErrorMessage="Enter your address" CssClass="text-danger"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="form-group">
                <label class="control-label col-sm-3" for="pin">Pin :</label>
                <div class="col-sm-9">
                <asp:TextBox ID="pin" runat="server" class="form-control" placeHolder="Enter your pin" MaxLength="6" ></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="pin" ErrorMessage="Enter your pin" CssClass="text-danger"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="form-group">
                <label class="control-label col-sm-3" for="country">Country :</label>
                <div class="col-sm-9">
                <asp:TextBox ID="country" runat="server" class="form-control" placeHolder="Enter your country"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="country" ErrorMessage="Enter your country" CssClass="text-danger"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="form-group">
                <label class="control-label col-sm-3" for="state">State :</label>
                <div class="col-sm-9">
                <asp:TextBox ID="state" runat="server" class="form-control" placeHolder="Enter your state"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="state" ErrorMessage="Enter your state" CssClass="text-danger"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="form-group">
                <label class="control-label col-sm-3" for="city">City :</label>
                <div class="col-sm-9">
                <asp:TextBox ID="city" runat="server" class="form-control" placeHolder="Enter your city"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="city" ErrorMessage="Enter your city" CssClass="text-danger"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="form-group">
                <div class="col-sm-9 col-sm-offset-3">
                    <asp:Button ID="btnCheckout" runat="server" class="btn btn-primary form-control"  Text="Place Order" OnClick="btnCheckout_Click" /><br />
                </div>
            </div>
        </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            </div>
        </div>
    </div>
</section>
</asp:Content>
