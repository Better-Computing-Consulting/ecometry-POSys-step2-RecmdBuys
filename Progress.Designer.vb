<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProgressWindow
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ProgressWindow))
      Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
      Me.SuspendLayout()
      '
      'ProgressBar1
      '
      Me.ProgressBar1.Cursor = System.Windows.Forms.Cursors.AppStarting
      Me.ProgressBar1.Dock = System.Windows.Forms.DockStyle.Fill
      Me.ProgressBar1.Location = New System.Drawing.Point(0, 0)
      Me.ProgressBar1.Name = "ProgressBar1"
      Me.ProgressBar1.Size = New System.Drawing.Size(284, 23)
      Me.ProgressBar1.Step = 1
      Me.ProgressBar1.TabIndex = 0
      '
      'ProgressWindow
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(284, 23)
      Me.Controls.Add(Me.ProgressBar1)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.Name = "ProgressWindow"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
      Me.Text = "Processing..."
      Me.ResumeLayout(False)

   End Sub
   Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
End Class
