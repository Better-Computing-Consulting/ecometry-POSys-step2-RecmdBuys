<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SelectModeForm
   Inherits System.Windows.Forms.Form

   'Form overrides dispose to clean up the component list.
   <System.Diagnostics.DebuggerNonUserCode()> _
   Protected Overrides Sub Dispose(ByVal disposing As Boolean)
      Try
         If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
         End If
      Finally
         MyBase.Dispose(disposing)
      End Try
   End Sub

   'Required by the Windows Form Designer
   Private components As System.ComponentModel.IContainer

   'NOTE: The following procedure is required by the Windows Form Designer
   'It can be modified using the Windows Form Designer.  
   'Do not modify it using the code editor.
   <System.Diagnostics.DebuggerStepThrough()> _
   Private Sub InitializeComponent()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SelectModeForm))
      Me.BuyerButton = New System.Windows.Forms.Button()
      Me.ManagerButton = New System.Windows.Forms.Button()
      Me.CancelButton = New System.Windows.Forms.Button()
      Me.SuspendLayout()
      '
      'BuyerButton
      '
      Me.BuyerButton.Location = New System.Drawing.Point(0, 0)
      Me.BuyerButton.Name = "BuyerButton"
      Me.BuyerButton.Size = New System.Drawing.Size(75, 23)
      Me.BuyerButton.TabIndex = 0
      Me.BuyerButton.Text = "Buyer"
      Me.BuyerButton.UseVisualStyleBackColor = True
      '
      'ManagerButton
      '
      Me.ManagerButton.Location = New System.Drawing.Point(81, 0)
      Me.ManagerButton.Name = "ManagerButton"
      Me.ManagerButton.Size = New System.Drawing.Size(75, 23)
      Me.ManagerButton.TabIndex = 1
      Me.ManagerButton.Text = "Manager"
      Me.ManagerButton.UseVisualStyleBackColor = True
      '
      'CancelButton
      '
      Me.CancelButton.Location = New System.Drawing.Point(162, 0)
      Me.CancelButton.Name = "CancelButton"
      Me.CancelButton.Size = New System.Drawing.Size(75, 23)
      Me.CancelButton.TabIndex = 2
      Me.CancelButton.Text = "Cancel"
      Me.CancelButton.UseVisualStyleBackColor = True
      '
      'SelectModeForm
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(236, 24)
      Me.Controls.Add(Me.CancelButton)
      Me.Controls.Add(Me.ManagerButton)
      Me.Controls.Add(Me.BuyerButton)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.Name = "SelectModeForm"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
      Me.Text = "Select Buyer or Manager Mode"
      Me.ResumeLayout(False)

   End Sub
   Friend WithEvents BuyerButton As System.Windows.Forms.Button
   Friend WithEvents ManagerButton As System.Windows.Forms.Button
   Friend WithEvents CancelButton As System.Windows.Forms.Button
End Class
