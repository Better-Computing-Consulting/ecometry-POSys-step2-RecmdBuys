Public Class SelectModeForm
   Public SelectedMode As String = ""
   Private Sub BuyerButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BuyerButton.Click
      SelectedMode = "BUYER"
      DialogResult = DialogResult.OK
   End Sub
   Private Sub ManagerButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ManagerButton.Click
      SelectedMode = "MANAGER"
      DialogResult = DialogResult.OK
   End Sub
   Private Sub CancelButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CancelButton.Click
      DialogResult = DialogResult.Cancel
   End Sub
End Class