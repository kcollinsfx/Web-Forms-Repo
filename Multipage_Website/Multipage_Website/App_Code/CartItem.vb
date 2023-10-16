'

Imports Microsoft.VisualBasic

Public Class CartItem
    'Declare the properties
    Public Property Product As Product 'From Product.vb
    Public Property Quantity As Integer

    'Constructor
    Public Sub New(product As Product, quantity As Integer)
        'Initialize the Product and Quantity properties defined above
        Me.Product = product
        Me.Quantity = quantity
    End Sub

    'Adds the quantity that's passed to it to the cart item
    'This method is called when the user adds a quantity to the cart for the product that's already in the cart
    Public Sub AddQuantity(quantity As Integer)
        Me.Quantity += quantity
    End Sub

    'Returns a string that formats the data in the cart item so it can be displayed in one line of the list box on the Cart page.
    Public Function Display() As String
        Dim displayString As String = Product.Name & " (" & Quantity.ToString & " at " & FormatCurrency(Product.UnitPrice) & "each)"

        Return displayString
    End Function
End Class
