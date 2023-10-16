'CartItemList class is a CONTAINER CLASS;
'In effect, it is the shopping cart.
'An object created from this class keeps track of CartItem objects

Imports Microsoft.VisualBasic

Public Class CartItemList
    'Declaring a List of cartItems
    'cartItems stores a list of CartItems
    Private cartItems As List(Of CartItem)

    'Constructor
    Public Sub New()
        'Initializing a List of cartItems
        cartItems = New List(Of CartItem)
    End Sub

    'Returns a count of the items in the list
    Public ReadOnly Property Count As Integer
        Get
            Return cartItems.Count
        End Get
    End Property

    'This property is used to get the items in the cart when they're displayed in the listbox of the Cart page.
    Default Public Property Item(index As Integer) As CartItem
        'Get a CartItem object by Index 
        Get
            Return cartItems(index)
        End Get
        'Set a CartItem object by index 
        Set(value As CartItem)
            cartItems(index) = value
        End Set
    End Property

    'This property is used to determine if a product is already in the cart
    'If a product with the specified ID isn't found, this property returns Nothing
    Default Public ReadOnly Property Item(id As String) As CartItem
        'Get a CartItem object by ProductID
        Get
            For Each c As CartItem In cartItems
                If c.Product.ProductID = id Then
                    Return c
                End If
            Next
            Return Nothing
        End Get
    End Property

    'The GetCart method gets the CartItemList object that's stored in session state.
    'Then it checks to see if that object is equal to Nothing. If it is, it means that a cart hasn't yet been created for the current user.
    'Then, a new CartItemList object is created and added to Session state.
    'This method is shared because it simply retrieves the CartItemList object that's stored in session state; It doesn't work with
    'the current CartItemList object
    'Because this code is NOT A CODE-BEHIND FILE, you can't use the Session property of the page to refer to the session state object.
    'Instead you have to refer to the session state object through the HTtpContext object for the current request.
    Public Shared Function GetCart() As CartItemList
        'Get a CartItemList object from the session state object if one is there
        Dim cart As CartItemList = CType(HttpContext.Current.Session("Cart"), CartItemList)

        'If 
        If cart Is Nothing Then
            HttpContext.Current.Session("Cart") = New CartItemList
        End If
        Return CType(HttpContext.Current.Session("Cart"), CartItemList)
    End Function

    Public Sub AddItem(product As Product, quantity As Integer)
        ' Creates a CartItem object from the Product and Quantity Values
        Dim c As New CartItem(product, quantity)
        ' Add the cart item to the cart item list
        cartItems.Add(c)
    End Sub

    'This method removes the cart item at the given index.
    Public Sub RemoveAt(index As Integer)
        cartItems.RemoveAt(index)
    End Sub

    'This method clears the cart altogether.
    Public Sub Clear()
        cartItems.Clear()
    End Sub
End Class


