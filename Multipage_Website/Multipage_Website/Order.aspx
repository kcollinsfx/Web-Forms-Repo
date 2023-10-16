<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Order.aspx.vb" Inherits="Multipage_Website.Order"  %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Chapter 4: Shopping Cart</title>
    <link href="Styles/Main.css" rel="stylesheet" />
    <link href="Styles/Order.css" rel="stylesheet" />
</head>
<body style="margin-top:0; margin-left:0; margin-right: 0;">
    <header>
        <img src="Images/banner.jpg" width="100%" alt="Halloween Store" />
    </header>
    <br />
    <br />
    <section>
        <form id="form1" runat="server" style="padding-left:20%">
            <label>Please select a product&nbsp</label>
            <asp:DropDownList ID="ddlProducts" runat="server" AutoPostBack="true" 
                DataSourceID="SqlDataSource1" DataTextField="Name" DataValueField="ProductID"></asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                ConnectionString='<%$ ConnectionStrings:ConnectionString %>' 
                ProviderName='<%$ ConnectionStrings:ConnectionString.ProviderName %>' 
                SelectCommand="SELECT [ProductID], [Name], [ShortDescription], [LongDescription], [ImageFile], [UnitPrice] FROM [Products] ORDER BY [Name]">
            </asp:SqlDataSource>
            <div id="productData">
                <asp:Label ID="lblName" runat="server"></asp:Label>
                <asp:Label ID="lblShortDescription" runat="server"></asp:Label>
                <br />
                &nbsp;&nbsp;&nbsp; &nbsp; &#x2022; &nbsp;
                <asp:Label ID="lblLongDescription" runat="server"></asp:Label>
                <asp:Label ID="lblUnitPrice" runat="server"></asp:Label>
                <br />
                <br />
                <label id="lblQuantity" runat="server">Quantity&nbsp;</label>
                <asp:TextBox ID="txtQuantity" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator 
                        ID="RequiredFieldValidator1" 
                        runat="server" 
                        CssClass="validator"
                        ControlToValidate="txtQuantity"
                        Display="Dynamic"
                        ErrorMessage="Quantity is a required field."></asp:RequiredFieldValidator>
                    <asp:RangeValidator 
                        ID="RangeValidator1" 
                        CssClass="validator"
                        runat="server" 
                        ControlToValidate="txtQuantity"
                        Display="Dynamic"
                        ErrorMessage="Quantity must range from 1 to 500."
                        MaximumValue="500"
                        MinimumValue="1"
                        Type="Integer"></asp:RangeValidator>
                <br />
                <br />
                <br />
                <asp:Button ID="btnAdd" runat="server" Text="Add to Cart" />
                <asp:Button ID="btnCart" runat="server" Text="Go to Cart" PostBackUrl="~/Cart.aspx" CausesValidation="false" />
            </div>
            <br />
            <br />
            <asp:Image ID="imgProduct" runat="server" />
        </form>
    </section>
</body>
</html>
