<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="designlistDetails.aspx.cs" Inherits="Superomart.designlistDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
                title: 'Cart!',
                text: 'Design added to cart.',
                type: 'success'
            }).then(() => {
                window.location.href = "cart.aspx";
            });
        }
    </script>
    <br />
    <%--<form id="form1" runat="server">--%>
    <div class="container">

            <div class="row">
                <div class="col-md-3">
                    <%--<asp:Image ID="Image1" CssClass="img-responsive" runat="server" />--%>
                    <asp:Label ID="lblfarImg" runat="server" Text=""></asp:Label>
                </div>

                <div class="col-md-5">
                    Design ID:
                    <asp:Label ID="lblProductID" runat="server" Text="Label"></asp:Label>
                    <br />
                    Design Name:
                    <asp:Label ID="lblProductName" runat="server" Text="Label"></asp:Label>
                    <br />
                    Design Price: &#8377;
                    <asp:Label ID="lblProductPrice" runat="server" Text="Label"></asp:Label>
                    <br />
                    Design Details: 
                    <asp:Label ID="lblServicesDetails" runat="server" Text="Label"></asp:Label>
                    <br />
                    Quantity:
                    <asp:TextBox ID="txtQuantity" CssClass="form-control" AutoPostBack="true" Text="1" runat="server" OnTextChanged="txtQuantity_TextChanged"></asp:TextBox>
                    <br />
                    Amount: &#8377;
                    <asp:Label ID="lblAmount" runat="server" Text="Label"></asp:Label>
                    <br />
                    <asp:Button ID="btnAddToCart" CssClass="btn btn-success" runat="server" Text="Add To Cart" OnClick="btnAddToCart_Click" />
                    <br />
                    <br />
                </div>
            </div>
        </div>
        <%--</form>--%>
</asp:Content>
