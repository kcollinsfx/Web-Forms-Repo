<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Cart.aspx.vb" Inherits="Multipage_Website.Cart" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Chapter 4: Shopping Cart</title>
    <link href="Styles/Main.css" rel="stylesheet" type="text/css" />
    <link href="Styles/Cart.css" rel="stylesheet" type="text/css" />
</head>
<body style="margin-top:0; margin-left:0; margin-right: 0;">
    <header>
        <img src="Images/banner.jpg" width="100%" alt="Halloween Store" />
    </header>
    <section>
        <form id="form1" runat="server" style="padding-left:40%">
            <h1>Your Shopping Cart</h1>
            <asp:ListBox ID="lstCart" runat="server" style="width:30%;"></asp:ListBox>
            <br />
            <br />
            <div id="cardbuttons">
                <asp:Button ID="btnRemove" runat="server" Text="Remove Item" CssClass="button" /> &nbsp;&nbsp;
                <asp:Button ID="btnEmpty" runat="server" Text="Empty Cart" CssClass="button" />
            </div>
            <br />
            <div id="shopButtons">
                <asp:Button ID="btnContinue" runat="server" PostBackUrl="~/Order.aspx" Text="Continue Shopping" CssClass="button" /> &nbsp;&nbsp;
                <asp:Button ID="btnCheckOut" runat="server" Text="Check Out" CssClass="button" />
            </div>
            <br />
            <p id="message">
                <!-- Left blank so that the text from the backend is assigned to it -->
                <asp:Label ID ="lblMessage" runat="server" EnableViewState="False"></asp:Label> 
            </p>
        </form>
    </section>
    
</body>
</html>
