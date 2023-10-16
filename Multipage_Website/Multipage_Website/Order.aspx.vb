Imports System.Data
Imports System.Reflection

Partial Class Order
    Inherits System.Web.UI.Page

    'Private property that holds a Product object that represents the item that the user has selected from the drop-down list
    Private selectedProduct As New Product

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'If the page is being loaded for the first call the DataBind() method
        'This method binds the drop-down list to the SQL data source which causes the data source to retrieve the data specified in its SelectCommand property
        'For many applications, you don't need to call the DataBind method in the Page_Load procedure when you use data binding as ASP.NET automatically bind any data-bind controls.
        'Unfortunately, this automatic data binding doesn't occur until after the Page_Load procedure has been executed.
        'In this case, because the GetSelected procedure would not work unless the drop-down list has already been bound.
        'The application calls the DataBind method to force the data binding to occur earlier that it normally would.
        If Not IsPostBack Then ddlProducts.DataBind()

        'The GetSelectedProduct procedure gets the data for the selected product from the SQL data source and returns a Product object
        selectedProduct = Me.GetSelectedProduct()
        lblName.Text = selectedProduct.Name
        lblShortDescription.Text = selectedProduct.ShortDescription
        lblLongDescription.Text = selectedProduct.LongDescription
        lblUnitPrice.Text = FormatCurrency(selectedProduct.UnitPrice) & " each"
        imgProduct.ImageUrl = "Images/Products/" & selectedProduct.ImageFile
    End Sub

    Private Function GetSelectedProduct() As Product
        Dim productsTable As DataView = CType(SqlDataSource1.Select(DataSourceSelectArguments.Empty), DataView)
        productsTable.RowFilter = "ProductID = '" & ddlProducts.SelectedValue & "'"

        Dim row As DataRowView = CType(productsTable(0), DataRowView)
        Dim p As New Product
        p.ProductID = row("ProductID").ToString
        p.Name = row("Name").ToString
        p.ShortDescription = row("ShortDescription").ToString
        p.LongDescription = row("LongDescription").ToString
        p.UnitPrice = row("UnitPrice").ToString
        p.ImageFile = row("ImageFile").ToString

        Return p
    End Function

    Protected Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If Page.IsValid Then
            'Get the cart that is stored in the session state
            Dim cart As CartItemList = CartItemList.GetCart
            'Get the cart item for the product that's selected by the drop-down list using the ProductID
            Dim cartItem As CartItem = cart(selectedProduct.ProductID)

            'If cartItem is not in the list, the CartItemList object is called to add an item with the selected product and quantity to the list
            If cartItem Is Nothing Then
                cart.AddItem(selectedProduct, CInt(txtQuantity.Text))
                'If a cartItem is already in the list just add the quantity to the current quantity amount
            Else
                cartItem.AddQuantity(CInt(txtQuantity.Text))
            End If
            Response.Redirect("Cart.aspx", False)
        End If
    End Sub

End Class

