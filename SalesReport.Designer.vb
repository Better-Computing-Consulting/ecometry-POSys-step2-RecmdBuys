<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SalesReport
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SalesReport))
        Me.ReportTextBox = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'ReportTextBox
        '
        Me.ReportTextBox.BackColor = System.Drawing.SystemColors.Window
        Me.ReportTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ReportTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ReportTextBox.Font = New System.Drawing.Font("Lucida Sans Typewriter", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReportTextBox.Location = New System.Drawing.Point(0, 0)
        Me.ReportTextBox.Multiline = True
        Me.ReportTextBox.Name = "ReportTextBox"
        Me.ReportTextBox.ReadOnly = True
        Me.ReportTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.ReportTextBox.Size = New System.Drawing.Size(1005, 567)
        Me.ReportTextBox.TabIndex = 0
        Me.ReportTextBox.WordWrap = False
        '
        'SalesReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1005, 567)
        Me.Controls.Add(Me.ReportTextBox)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "SalesReport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Sales Report"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ReportTextBox As System.Windows.Forms.TextBox
End Class
