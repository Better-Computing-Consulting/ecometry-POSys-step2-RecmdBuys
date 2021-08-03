<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.TonySaveProgressToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ScottSetRemainingTo0ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ScottSaveProgressToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TonyFinalizeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DistributeToBuyersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.cItemNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cDescription = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cVendorNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cVendor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cMargin = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cVentorPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.oLandedCost = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cAvg52wk = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cAvg26Wk = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cAvg13Wk = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cAvg8Wk = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cAvg4Wk = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cLastWk = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cTotalDue = New System.Windows.Forms.DataGridViewLinkColumn()
        Me.cOnHand = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cWksOfStock = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cReorderLevel = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cMinQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cBOQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cRecmdBuy = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cMgrRecmdBuy = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cTonyApproved = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cFinalNumberToBuy = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cEDPNO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cItemID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TotalToBuyToolStripStatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ItemContextMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ItemSalesMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.StyleSalesMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ItemActivityHistoryMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.LastAdverticedMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.ItemContextMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TonySaveProgressToolStripMenuItem, Me.ScottSetRemainingTo0ToolStripMenuItem, Me.ScottSaveProgressToolStripMenuItem, Me.TonyFinalizeToolStripMenuItem, Me.DistributeToBuyersToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1558, 27)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'TonySaveProgressToolStripMenuItem
        '
        Me.TonySaveProgressToolStripMenuItem.Name = "TonySaveProgressToolStripMenuItem"
        Me.TonySaveProgressToolStripMenuItem.Size = New System.Drawing.Size(106, 23)
        Me.TonySaveProgressToolStripMenuItem.Text = "Save Progress"
        '
        'ScottSetRemainingTo0ToolStripMenuItem
        '
        Me.ScottSetRemainingTo0ToolStripMenuItem.Name = "ScottSetRemainingTo0ToolStripMenuItem"
        Me.ScottSetRemainingTo0ToolStripMenuItem.Size = New System.Drawing.Size(158, 23)
        Me.ScottSetRemainingTo0ToolStripMenuItem.Text = "Set Remaining To Zero"
        '
        'ScottSaveProgressToolStripMenuItem
        '
        Me.ScottSaveProgressToolStripMenuItem.Name = "ScottSaveProgressToolStripMenuItem"
        Me.ScottSaveProgressToolStripMenuItem.Size = New System.Drawing.Size(247, 23)
        Me.ScottSaveProgressToolStripMenuItem.Text = "Finalize for Tony/Paul (Save progress)"
        '
        'TonyFinalizeToolStripMenuItem
        '
        Me.TonyFinalizeToolStripMenuItem.Name = "TonyFinalizeToolStripMenuItem"
        Me.TonyFinalizeToolStripMenuItem.Size = New System.Drawing.Size(65, 23)
        Me.TonyFinalizeToolStripMenuItem.Text = "Finalize"
        Me.TonyFinalizeToolStripMenuItem.Visible = False
        '
        'DistributeToBuyersToolStripMenuItem
        '
        Me.DistributeToBuyersToolStripMenuItem.Name = "DistributeToBuyersToolStripMenuItem"
        Me.DistributeToBuyersToolStripMenuItem.Size = New System.Drawing.Size(143, 23)
        Me.DistributeToBuyersToolStripMenuItem.Text = "Distribute to Buyers"
        '
        'DataGridView1
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cItemNo, Me.cDescription, Me.cVendorNo, Me.cStatus, Me.cVendor, Me.cPrice, Me.cMargin, Me.cVentorPrice, Me.oLandedCost, Me.cAvg52wk, Me.cAvg26Wk, Me.cAvg13Wk, Me.cAvg8Wk, Me.cAvg4Wk, Me.cLastWk, Me.cTotalDue, Me.cOnHand, Me.cWksOfStock, Me.cReorderLevel, Me.cMinQty, Me.cBOQty, Me.cRecmdBuy, Me.cMgrRecmdBuy, Me.cTonyApproved, Me.cFinalNumberToBuy, Me.cEDPNO, Me.cItemID})
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle7
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 27)
        Me.DataGridView1.Name = "DataGridView1"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.RowHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.DataGridView1.RowHeadersWidth = 30
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(1558, 527)
        Me.DataGridView1.TabIndex = 1
        '
        'cItemNo
        '
        Me.cItemNo.HeaderText = "Item Number"
        Me.cItemNo.Name = "cItemNo"
        Me.cItemNo.ReadOnly = True
        Me.cItemNo.Width = 125
        '
        'cDescription
        '
        Me.cDescription.HeaderText = "Description"
        Me.cDescription.Name = "cDescription"
        Me.cDescription.ReadOnly = True
        Me.cDescription.Width = 240
        '
        'cVendorNo
        '
        Me.cVendorNo.HeaderText = "Vendor Item Number"
        Me.cVendorNo.Name = "cVendorNo"
        Me.cVendorNo.ReadOnly = True
        Me.cVendorNo.Width = 125
        '
        'cStatus
        '
        Me.cStatus.HeaderText = "Status"
        Me.cStatus.Name = "cStatus"
        Me.cStatus.ReadOnly = True
        Me.cStatus.Width = 40
        '
        'cVendor
        '
        Me.cVendor.HeaderText = "Vendor"
        Me.cVendor.Name = "cVendor"
        Me.cVendor.Width = 60
        '
        'cPrice
        '
        Me.cPrice.HeaderText = "Price"
        Me.cPrice.Name = "cPrice"
        Me.cPrice.ReadOnly = True
        Me.cPrice.Width = 50
        '
        'cMargin
        '
        Me.cMargin.HeaderText = "Margin"
        Me.cMargin.Name = "cMargin"
        Me.cMargin.ReadOnly = True
        Me.cMargin.Width = 50
        '
        'cVentorPrice
        '
        Me.cVentorPrice.HeaderText = "Vendor Price"
        Me.cVentorPrice.Name = "cVentorPrice"
        Me.cVentorPrice.ReadOnly = True
        Me.cVentorPrice.Width = 50
        '
        'oLandedCost
        '
        Me.oLandedCost.HeaderText = "Landed Cost"
        Me.oLandedCost.Name = "oLandedCost"
        Me.oLandedCost.ReadOnly = True
        Me.oLandedCost.Width = 50
        '
        'cAvg52wk
        '
        Me.cAvg52wk.HeaderText = "Avg 52 Wk"
        Me.cAvg52wk.Name = "cAvg52wk"
        Me.cAvg52wk.ReadOnly = True
        Me.cAvg52wk.Width = 40
        '
        'cAvg26Wk
        '
        Me.cAvg26Wk.HeaderText = "Avg 26 Wk"
        Me.cAvg26Wk.Name = "cAvg26Wk"
        Me.cAvg26Wk.ReadOnly = True
        Me.cAvg26Wk.Width = 40
        '
        'cAvg13Wk
        '
        Me.cAvg13Wk.HeaderText = "Avg 13 Wk"
        Me.cAvg13Wk.Name = "cAvg13Wk"
        Me.cAvg13Wk.ReadOnly = True
        Me.cAvg13Wk.Width = 40
        '
        'cAvg8Wk
        '
        Me.cAvg8Wk.HeaderText = "Avg 8 Wk"
        Me.cAvg8Wk.Name = "cAvg8Wk"
        Me.cAvg8Wk.ReadOnly = True
        Me.cAvg8Wk.Width = 40
        '
        'cAvg4Wk
        '
        Me.cAvg4Wk.HeaderText = "Avg 4 Wk"
        Me.cAvg4Wk.Name = "cAvg4Wk"
        Me.cAvg4Wk.ReadOnly = True
        Me.cAvg4Wk.Width = 40
        '
        'cLastWk
        '
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cLastWk.DefaultCellStyle = DataGridViewCellStyle2
        Me.cLastWk.HeaderText = "Last Week"
        Me.cLastWk.Name = "cLastWk"
        Me.cLastWk.ReadOnly = True
        Me.cLastWk.Width = 40
        '
        'cTotalDue
        '
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cTotalDue.DefaultCellStyle = DataGridViewCellStyle3
        Me.cTotalDue.HeaderText = "Total Due"
        Me.cTotalDue.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.cTotalDue.MinimumWidth = 2
        Me.cTotalDue.Name = "cTotalDue"
        Me.cTotalDue.ReadOnly = True
        Me.cTotalDue.Width = 45
        '
        'cOnHand
        '
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cOnHand.DefaultCellStyle = DataGridViewCellStyle4
        Me.cOnHand.HeaderText = "On Hand"
        Me.cOnHand.Name = "cOnHand"
        Me.cOnHand.ReadOnly = True
        Me.cOnHand.Width = 40
        '
        'cWksOfStock
        '
        Me.cWksOfStock.HeaderText = "Weeks Of Stock"
        Me.cWksOfStock.Name = "cWksOfStock"
        Me.cWksOfStock.ReadOnly = True
        Me.cWksOfStock.Width = 60
        '
        'cReorderLevel
        '
        Me.cReorderLevel.HeaderText = "Reorder Level"
        Me.cReorderLevel.Name = "cReorderLevel"
        Me.cReorderLevel.ReadOnly = True
        Me.cReorderLevel.Width = 45
        '
        'cMinQty
        '
        Me.cMinQty.HeaderText = "Min Qty"
        Me.cMinQty.Name = "cMinQty"
        Me.cMinQty.ReadOnly = True
        Me.cMinQty.Width = 40
        '
        'cBOQty
        '
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.cBOQty.DefaultCellStyle = DataGridViewCellStyle5
        Me.cBOQty.HeaderText = "BO Qty"
        Me.cBOQty.Name = "cBOQty"
        Me.cBOQty.ReadOnly = True
        Me.cBOQty.Width = 40
        '
        'cRecmdBuy
        '
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cRecmdBuy.DefaultCellStyle = DataGridViewCellStyle6
        Me.cRecmdBuy.HeaderText = "Recmd Buy"
        Me.cRecmdBuy.Name = "cRecmdBuy"
        Me.cRecmdBuy.ReadOnly = True
        Me.cRecmdBuy.Width = 50
        '
        'cMgrRecmdBuy
        '
        Me.cMgrRecmdBuy.HeaderText = "Mgr Recmd Buy"
        Me.cMgrRecmdBuy.Name = "cMgrRecmdBuy"
        Me.cMgrRecmdBuy.Width = 50
        '
        'cTonyApproved
        '
        Me.cTonyApproved.HeaderText = "Tony OK'd"
        Me.cTonyApproved.Name = "cTonyApproved"
        Me.cTonyApproved.Width = 50
        '
        'cFinalNumberToBuy
        '
        Me.cFinalNumberToBuy.HeaderText = "Total to Buy"
        Me.cFinalNumberToBuy.Name = "cFinalNumberToBuy"
        Me.cFinalNumberToBuy.ReadOnly = True
        Me.cFinalNumberToBuy.Width = 50
        '
        'cEDPNO
        '
        Me.cEDPNO.HeaderText = "EDPNO"
        Me.cEDPNO.Name = "cEDPNO"
        Me.cEDPNO.Visible = False
        '
        'cItemID
        '
        Me.cItemID.HeaderText = "Item ID"
        Me.cItemID.Name = "cItemID"
        Me.cItemID.Visible = False
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.TotalToBuyToolStripStatusLabel})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 530)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1558, 24)
        Me.StatusStrip1.TabIndex = 2
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(60, 19)
        Me.ToolStripStatusLabel1.Text = "Records:"
        '
        'TotalToBuyToolStripStatusLabel
        '
        Me.TotalToBuyToolStripStatusLabel.Name = "TotalToBuyToolStripStatusLabel"
        Me.TotalToBuyToolStripStatusLabel.Size = New System.Drawing.Size(128, 19)
        Me.TotalToBuyToolStripStatusLabel.Text = "Grand Total To Buy:"
        '
        'ItemContextMenu
        '
        Me.ItemContextMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ItemSalesMenuItem, Me.ToolStripSeparator1, Me.StyleSalesMenuItem, Me.ToolStripSeparator2, Me.ItemActivityHistoryMenuItem, Me.ToolStripSeparator3, Me.LastAdverticedMenuItem})
        Me.ItemContextMenu.Name = "ItemContextMenu"
        Me.ItemContextMenu.Size = New System.Drawing.Size(204, 118)
        '
        'ItemSalesMenuItem
        '
        Me.ItemSalesMenuItem.Name = "ItemSalesMenuItem"
        Me.ItemSalesMenuItem.Size = New System.Drawing.Size(203, 24)
        Me.ItemSalesMenuItem.Text = "Item Sales History"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(200, 6)
        '
        'StyleSalesMenuItem
        '
        Me.StyleSalesMenuItem.Name = "StyleSalesMenuItem"
        Me.StyleSalesMenuItem.Size = New System.Drawing.Size(203, 24)
        Me.StyleSalesMenuItem.Text = "Style Sales History"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(200, 6)
        '
        'ItemActivityHistoryMenuItem
        '
        Me.ItemActivityHistoryMenuItem.Name = "ItemActivityHistoryMenuItem"
        Me.ItemActivityHistoryMenuItem.Size = New System.Drawing.Size(203, 24)
        Me.ItemActivityHistoryMenuItem.Text = "Item Activity History"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(200, 6)
        '
        'LastAdverticedMenuItem
        '
        Me.LastAdverticedMenuItem.Name = "LastAdverticedMenuItem"
        Me.LastAdverticedMenuItem.Size = New System.Drawing.Size(203, 24)
        Me.LastAdverticedMenuItem.Text = "Last Advertised"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1558, 554)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Form1"
        Me.Text = "Recommended Buys"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ItemContextMenu.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
   Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
   Friend WithEvents ScottSaveProgressToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents TonySaveProgressToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents ScottSetRemainingTo0ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
   Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents TonyFinalizeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents DistributeToBuyersToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents ItemContextMenu As System.Windows.Forms.ContextMenuStrip
   Friend WithEvents ItemSalesMenuItem As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents StyleSalesMenuItem As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents ItemActivityHistoryMenuItem As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents cItemNo As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents cDescription As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents cVendorNo As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents cStatus As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents cVendor As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents cPrice As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents cMargin As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents cVentorPrice As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents oLandedCost As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents cAvg52wk As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents cAvg26Wk As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents cAvg13Wk As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents cAvg8Wk As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents cAvg4Wk As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents cLastWk As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents cTotalDue As System.Windows.Forms.DataGridViewLinkColumn
   Friend WithEvents cOnHand As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents cWksOfStock As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents cReorderLevel As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents cMinQty As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents cBOQty As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents cRecmdBuy As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents cMgrRecmdBuy As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents cTonyApproved As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents cFinalNumberToBuy As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents cEDPNO As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents cItemID As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents TotalToBuyToolStripStatusLabel As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents LastAdverticedMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
