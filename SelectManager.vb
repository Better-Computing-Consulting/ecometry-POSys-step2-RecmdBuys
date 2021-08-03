Public Class SelectManagerForm
   Public SelectedManager As String = ""
   Private Sub OkayButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OkayButton.Click
      SelectedManager = ComboBox1.SelectedItem
      DialogResult = DialogResult.OK
   End Sub

   Private Sub CancelButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CancelButton.Click
      Me.Close()
   End Sub

   Private Sub SelectManagerForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
      ComboBox1.SelectedItem = "PAUL"
      OkayButton.Select()
   End Sub

   Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
      OkayButton.Select()
   End Sub
End Class