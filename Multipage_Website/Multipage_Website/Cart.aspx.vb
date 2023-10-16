Public Class Cart
    Inherits System.Web.UI.Page

    'Holds the CartItemList object for the shopping cart
    Private cart As CartItemList

    'Each time the page is loaded, the Page_Load procedure calls the GetCart method of the CartItemList class to retrieve the shopping cart from the session state and store in this variable
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        cart = CartItemList.GetCart
        'If page is being called for the first time, it calls the DisplayCart() procedure
        If Not IsPostBack Then Me.DisplayCart()
    End Sub

    Private Sub DisplayCart()
        'clear the list box that will display the shopping cart items.
        lstCart.Items.Clear()
        Dim item As CartItem
        'Display the items in the cart to the lstCart
        For i As Integer = 0 To cart.Count - 1
            item = cart(i)
            lstCart.Items.Add(item.Display)
        Next
    End Sub

    Protected Sub btnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click
        If cart.Count > 0 Then
            If lstCart.SelectedIndex > -1 Then
                cart.RemoveAt(lstCart.SelectedIndex)
                Me.DisplayCart()
            Else
                lblMessage.Text = "Please select the item you want to remove."
            End If
        End If
    End Sub

    Protected Sub btnEmpty_Click(sender As Object, e As EventArgs) Handles btnEmpty.Click
        If cart.Count > 0 Then
            cart.Clear()
            lstCart.Items.Clear()
        End If
    End Sub

    Protected Sub btnCheckout_Click(sender As Object, e As EventArgs) Handles btnCheckOut.Click
        lblMessage.Text = "Sorry, that function hasn't been implemented yet."
    End Sub

End Class
