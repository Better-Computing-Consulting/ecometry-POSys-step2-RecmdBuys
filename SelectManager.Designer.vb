<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SelectManagerForm
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SelectManagerForm))
      Me.ComboBox1 = New System.Windows.Forms.ComboBox()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.OkayButton = New System.Windows.Forms.Button()
      Me.CancelButton = New System.Windows.Forms.Button()
      Me.SuspendLayout()
      '
      'ComboBox1
      '
      Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.ComboBox1.FormattingEnabled = True
      Me.ComboBox1.Items.AddRange(New Object() {"BRIAN", "EDLYN", "PAUL", "SCOTTM", "TRACEY"})
      Me.ComboBox1.Location = New System.Drawing.Point(12, 35)
      Me.ComboBox1.Name = "ComboBox1"
      Me.ComboBox1.Size = New System.Drawing.Size(121, 21)
      Me.ComboBox1.TabIndex = 1
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(12, 19)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(70, 13)
      Me.Label1.TabIndex = 1
      Me.Label1.Text = "Select Buyer:"
      '
      'OkayButton
      '
      Me.OkayButton.Location = New System.Drawing.Point(163, 9)
      Me.OkayButton.Name = "OkayButton"
      Me.OkayButton.Size = New System.Drawing.Size(75, 23)
      Me.OkayButton.TabIndex = 1
      Me.OkayButton.Text = "Okay"
      Me.OkayButton.UseVisualStyleBackColor = True
      '
      'CancelButton
      '
      Me.CancelButton.Location = New System.Drawing.Point(163, 38)
      Me.CancelButton.Name = "CancelButton"
      Me.CancelButton.Size = New System.Drawing.Size(75, 23)
      Me.CancelButton.TabIndex = 3
      Me.CancelButton.Text = "Cancel"
      Me.CancelButton.UseVisualStyleBackColor = True
      '
      'SelectManagerForm
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(245, 89)
      Me.Controls.Add(Me.CancelButton)
      Me.Controls.Add(Me.OkayButton)
      Me.Controls.Add(Me.Label1)
      Me.Controls.Add(Me.ComboBox1)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.MaximizeBox = False
      Me.Name = "SelectManagerForm"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Select Buyer"
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents OkayButton As System.Windows.Forms.Button
   Friend WithEvents CancelButton As System.Windows.Forms.Button
End Class
