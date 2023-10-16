'An object derived from the Product class is a DTO (Data Transfer Object) As it contains only properties.
'As its name implies, a DTO is used primarly to store and transfer data.
'Product objects are used to transfer data between the Order page and the business classes.
'DTOs do not contain any methods or further functionality

Imports Microsoft.VisualBasic

Public Class Product
    'NOTE: That we are not taking the data from the "OnHand" and "CategoryID" columns of the Products table in the Halloween.mdf DB
    Public Property ProductID As String
    Public Property Name As String
    Public Property ShortDescription As String
    Public Property LongDescription As String
    Public Property UnitPrice As Decimal
    Public Property ImageFile As String

End Class


