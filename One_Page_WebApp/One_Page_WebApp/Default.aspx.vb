Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None

        If Not IsPostBack Then
            For i As Integer = 50 To 500 Step 50
                ddlMonthlyInvestment.Items.Add(i.ToString)
            Next
        End If
    End Sub

    Protected Sub btnCalculate_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCalculate.Click
        If IsValid Then
            Dim monthlyInvestment As Integer = CInt(ddlMonthlyInvestment.SelectedValue)
            Dim yearlyInterestRate As Decimal = CDec(txtInterestRate.Text)
            Dim years As Integer = CInt(txtYears.Text)
            Dim futureValue As Decimal = Me.CalculateFutureValue(monthlyInvestment, yearlyInterestRate, years)
            lblFutureValue.Text = FormatCurrency(futureValue)
        End If
    End Sub

    Protected Function CalculateFutureValue(ByVal monthlyInvestment As Integer, ByVal yearlyInterestRate As Decimal, ByVal years As Integer) As Decimal
        Dim months As Integer = years * 12
        Dim monthlyInterestRate As Decimal = yearlyInterestRate / 12 / 100
        Dim futureValue As Decimal = 0

        For i As Integer = 0 To months - 1
            futureValue = (futureValue + monthlyInvestment) * (1 + monthlyInterestRate)
        Next

        Return futureValue
    End Function

    Protected Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ddlMonthlyInvestment.SelectedIndex = 0
        txtInterestRate.Text = ""
        txtYears.Text = ""
        lblFutureValue.Text = ""
    End Sub

End Class