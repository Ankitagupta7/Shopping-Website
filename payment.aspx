<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="payment.aspx.cs" Inherits="Superomart.payment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container" style="margin-top:130px;">
        <div class="col-md-8 col-md-offset-2">
            <div class="row">
                <div class="col-md-6">
                    <h3 class="text-center">Booking Details</h3>
                    Name : <asp:Label ID="name" runat="server" Text=""></asp:Label><br />
                    Email : <asp:Label ID="email" runat="server" Text=""></asp:Label><br />
                    
                     Amount: ₹ <asp:Label ID="amount_total" runat="server" Text=""></asp:Label><br />
                </div>
                <div class="col-md-6" style="border:1px solid #dadada;">
                    <div class="card card-outline-secondary" style="padding:10px; margin-bottom:20px;">
                        <asp:Label ID="lblCaptchaMsg" runat="server" Text=""></asp:Label>
                        <div class="card-body">
                            <h3 class="text-center">Card Payment</h3>
                            <hr>
                                <div class="form-group">
                                    <label for="cc_name">Card Holder's Name</label>
                                    <asp:TextBox ID="cc_name" runat="server" class="form-control" placeholder="Enter your Name" ></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter Card Holder Name" ControlToValidate="cc_name" ForeColor="Red"></asp:RequiredFieldValidator>
                                    <%--<input type="text" runat="server" class="form-control" id="cc_name" pattern="\w+ \w+.*" title="First and last name" required="required">--%>
                                </div>
                                <div class="form-group">
                                    <label>Card Number</label>
                                    <asp:TextBox ID="cc_number" runat="server" class="form-control" placeholder="Enter Card Number" MaxLength="16" ></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Enter card number" ControlToValidate="cc_number" ForeColor="Red"></asp:RequiredFieldValidator>
                                    <%--<input type="text" runat="server" class="form-control" id="cc_number" autocomplete="off" maxlength="20" pattern="\d{16}" title="Credit card number" required="">--%>
                                </div>
                                <div class="form-group row">
                                    <label class="col-md-12">Card Exp. Date</label>
                                    <div class="col-md-4">
                                        <select class="form-control" runat="server" name="cc_exp_mo" size="0">
                                            <option value="01">01</option>
                                            <option value="02">02</option>
                                            <option value="03">03</option>
                                            <option value="04">04</option>
                                            <option value="05">05</option>
                                            <option value="06">06</option>
                                            <option value="07">07</option>
                                            <option value="08">08</option>
                                            <option value="09">09</option>
                                            <option value="10">10</option>
                                            <option value="11">11</option>
                                            <option value="12">12</option>
                                        </select>
                                    </div>
                                    <div class="col-md-4">
                                        <select class="form-control" runat="server" name="cc_exp_yr" size="0">
                                            <option>2022</option>
                                             <option>2023</option>
                                             <option>2024</option>
                                             <option>2025</option>
                                             <option>2026</option>
                                             <option>2027</option>
                                             <option>2028</option>
                                             <option>2029</option>
                                             <option>2030</option>
                                             <option>2031</option>
                                             <option>2032</option>
                                        </select>
                                    </div>
                                    <div class="col-md-4">
                                        <input type="text" runat="server" id="ccv" class="form-control" autocomplete="off" maxlength="3" textmode="password" pattern="\d{3}" title="Three digits at back of your card" required="" placeholder="CVV">
                                    </div>
                                </div>
                                <div class="row">
                                    Amount: ₹ <asp:Label ID="amount" runat="server" Text=""></asp:Label>
                                </div>
                                <hr>
                                <div class="form-group row">
                                    <div class="col-md-6">
                                        <a class="btn btn-default btn-lg btn-block" href="Home.aspx">Cancel</a>
                                    </div>
                                    <div class="col-md-6">
                                        <asp:Button ID="paymentSubmit" runat="server" class="btn btn-success btn-lg btn-block" OnClick="paymentSubmit_Click"   />
                                    </div>
                                </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <%--<script>
        document.getElementById('cc_number').addEventListener('input', function (e) {
            e.target.value = e.target.value.replace(/[^\dA-Z]/g, '').replace(/(.{4})/g, '$1 ').trim();
        });
    </script>--%>
</asp:Content>
