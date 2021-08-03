Imports System.IO
Imports System.Data.SqlClient
Imports System.Net.Mail
Public Class Form1
   Dim RcmdItems As New List(Of RecommendedBuyItem)
   Dim AppUser As String = ""
   Dim aborted As Boolean = False
   Dim SelectedManager As String = ""
   Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
      If aborted Then Exit Sub
      Dim counter As Integer = 0
      For Each onerow As DataGridViewRow In DataGridView1.Rows
         If onerow.Cells.Item("cMgrRecmdBuy").Value = "" Then
            counter += 1
         End If
      Next
      If counter > 0 Then
         If (MessageBox.Show("There are " & counter & " records unset.  Okay to close?", "Confirm Close", MessageBoxButtons.YesNo) = DialogResult.Yes) Then
            e.Cancel = False
         Else
            e.Cancel = True
         End If
      End If
   End Sub
   Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      Dim GrandTotalApproved As Decimal = 0
      AppUser = My.Application.GetEnvironmentVariable("USERNAME")
      If AppUser.ToUpper = "FEDERICO" Then AppUser = InputBox("User", "Enter Runas user", "", , )
      If AppUser.ToUpper = "PAUL" Then
         Dim SelectModeWindow As New SelectModeForm
         Dim reslt As DialogResult = DialogResult.None
         With SelectModeWindow
            reslt = .ShowDialog
            If Not reslt = DialogResult.OK Then Exit Sub
            If .SelectedMode = "MANAGER" Then
               AppUser = "PAULMANAGER"
            End If
         End With
      End If
      Select Case UCase(AppUser)
         Case "TONY", "TSCHMIDT", "PAULMANAGER"
            Dim SelectBox As New SelectManagerForm
            Dim result As DialogResult = DialogResult.None
            With SelectBox
               result = .ShowDialog
               If Not result = DialogResult.OK Then Exit Sub
               SelectedManager = .SelectedManager
            End With
            Select Case SelectedManager
               Case "PAUL"
                  RcmdItems = GetListOfItemsFromDBNoCathyNoZeroes()
               Case "CATHY"
                  RcmdItems = GetListOfItemsFromDBOnlyCathyNoZeroes()
               Case "BRIAN"
                  RcmdItems = GetListOfItemsFromDBOnlyBuyer("BRIAN")
               Case "SCOTTM"
                  RcmdItems = GetListOfItemsFromDBOnlyBuyer("SCOTTM")
               Case "TRACEY"
                  RcmdItems = GetListOfItemsFromDBOnlyBuyer("TRACEY")
               Case "EDLYN"
                  RcmdItems = GetListOfItemsFromDBOnlyBuyer("EDLYN")
            End Select
            DataGridView1.Columns.Item("cMgrRecmdBuy").ReadOnly = True
            MenuStrip1.Items("ScottSaveProgressToolStripMenuItem").Visible = False
            MenuStrip1.Items("ScottSetRemainingTo0ToolStripMenuItem").Visible = False
            MenuStrip1.Items("TonyFinalizeToolStripMenuItem").Visible = True
            MenuStrip1.Items("DistributeToBuyersToolStripMenuItem").Visible = False
         Case "PAUL"
            DataGridView1.Columns.Item("cTonyApproved").ReadOnly = True
            MenuStrip1.Items("TonySaveProgressToolStripMenuItem").Visible = False
            MenuStrip1.Items("DistributeToBuyersToolStripMenuItem").Visible = True
            RcmdItems = GetListOfItemsFromDBNoCathyNoZeroes()
         Case "CATHY"
            DataGridView1.Columns.Item("cTonyApproved").ReadOnly = True
            MenuStrip1.Items("TonySaveProgressToolStripMenuItem").Visible = False
            MenuStrip1.Items("DistributeToBuyersToolStripMenuItem").Visible = True
            RcmdItems = GetListOfItemsFromDBOnlyCathyNoZeroes()
         Case "BRIAN"
            DataGridView1.Columns.Item("cTonyApproved").ReadOnly = True
            MenuStrip1.Items("TonySaveProgressToolStripMenuItem").Visible = False
            MenuStrip1.Items("DistributeToBuyersToolStripMenuItem").Visible = True
            RcmdItems = GetListOfItemsFromDBOnlyBuyer("BRIAN")
         Case "SCOTTM"
            DataGridView1.Columns.Item("cTonyApproved").ReadOnly = True
            MenuStrip1.Items("TonySaveProgressToolStripMenuItem").Visible = False
            MenuStrip1.Items("DistributeToBuyersToolStripMenuItem").Visible = True
            RcmdItems = GetListOfItemsFromDBOnlyBuyer("SCOTTM")
         Case "TRACEY"
            DataGridView1.Columns.Item("cTonyApproved").ReadOnly = True
            MenuStrip1.Items("TonySaveProgressToolStripMenuItem").Visible = False
            MenuStrip1.Items("DistributeToBuyersToolStripMenuItem").Visible = True
            RcmdItems = GetListOfItemsFromDBOnlyBuyer("TRACEY")
         Case "EDLYN"
            DataGridView1.Columns.Item("cTonyApproved").ReadOnly = True
            MenuStrip1.Items("TonySaveProgressToolStripMenuItem").Visible = False
            MenuStrip1.Items("DistributeToBuyersToolStripMenuItem").Visible = True
            RcmdItems = GetListOfItemsFromDBOnlyBuyer("EDLYN")
         Case Else
            MsgBox("You are not authorized to access this program.", , "Access Error")
            aborted = True
            Me.Close()
      End Select
      With DataGridView1
         .AllowUserToAddRows = False
         .AllowUserToDeleteRows = False
         .EditMode = DataGridViewEditMode.EditOnEnter
         .Columns.Item("cRecmdBuy").ValueType = GetType(Integer)
         For Each oneitem In RcmdItems
            GrandTotalApproved += oneitem.TotalToBuyForTotalSum * oneitem.ItemCost
            If Not IsNumeric(oneitem.MgrRecommendedBuy) Then MenuStrip1.Items("TonyFinalizeToolStripMenuItem").Enabled = False
            If Not oneitem.TotalQtyToBuy >= 0 And {"PAUL", "BRIAN", "EDLYN", "SCOTTM", "TRACEY"}.Contains(AppUser.ToUpper) Then MenuStrip1.Items("DistributeToBuyersToolStripMenuItem").Visible = False
            .Rows.Add(oneitem.GetDataGridRow)
            With .Rows.Item(.Rows.Count - 1)
               If oneitem.EnteredDate < Now.AddDays(-7) Then
                  .DefaultCellStyle.BackColor = Color.LemonChiffon
               End If
               .Cells.Item("cRecmdBuy").Value = oneitem.RecommendedBuy
            End With
         Next
      End With
      ToolStripStatusLabel1.Text = RcmdItems.Count & " Records"
      TotalToBuyToolStripStatusLabel.Text = "  Grand Total: " & GrandTotalApproved
   End Sub
   Private Function GetListOfItemsFromDBNoCathyNoZeroes() As List(Of RecommendedBuyItem)
      Dim QueryString As String = "SELECT * FROM SCOTT_OPEN_ITEMS WHERE RBI_TOTAL_TO_BUY <> 0 OR (RBI_TONY_RECMDBUY = '0' AND RBI_MGR_APPRVD IS NULL) OR (RBI_TONY_APPRVD IS NULL AND RBI_MGR_APPRVD IS NULL) ORDER BY RBI_VENDOR, RBI_STATUS DESC, RBI_NUMBER"
      Dim tmpResult As New List(Of RecommendedBuyItem)
      Using conn As New SqlConnection(DBCONNSTR)
         Dim cmd As New SqlCommand(QueryString, conn)
         Try
            conn.Open()
            Dim r As SqlDataReader = cmd.ExecuteReader
            If r.HasRows Then
               Do While r.Read
                  tmpResult.Add(New RecommendedBuyItem(r))
               Loop
            End If
         Catch ex As Exception
            MsgBox(ex.Message)
         End Try
      End Using
      Return tmpResult
   End Function
   Private Function GetListOfItemsFromDBOnlyBuyer(ByVal Buyer As String) As List(Of RecommendedBuyItem)
      Dim QueryString As String = "SELECT * FROM " & Buyer & "_OPEN_ITEMS WHERE RBI_TOTAL_TO_BUY <> 0 OR (RBI_TONY_RECMDBUY = '0' AND RBI_MGR_APPRVD IS NULL) OR (RBI_TONY_APPRVD IS NULL AND RBI_MGR_APPRVD IS NULL) ORDER BY RBI_VENDOR, RBI_STATUS DESC, RBI_NUMBER"
      Dim tmpResult As New List(Of RecommendedBuyItem)
      Using conn As New SqlConnection(DBCONNSTR)
         Dim cmd As New SqlCommand(QueryString, conn)
         Try
            conn.Open()
            Dim r As SqlDataReader = cmd.ExecuteReader
            If r.HasRows Then
               Do While r.Read
                  tmpResult.Add(New RecommendedBuyItem(r))
               Loop
            End If
         Catch ex As Exception
            MsgBox(ex.Message)
         End Try
      End Using
      Return tmpResult
   End Function
   Private Function GetListOfItemsFromDBOnlyCathyNoZeroes() As List(Of RecommendedBuyItem)
      Dim QueryString As String = "SELECT * FROM CATHY_OPEN_ITEMS WHERE RBI_TOTAL_TO_BUY <> 0 OR (RBI_TONY_RECMDBUY = '0' AND RBI_MGR_APPRVD IS NULL) OR (RBI_TONY_APPRVD IS NULL AND RBI_MGR_APPRVD IS NULL) ORDER BY RBI_VENDOR, RBI_STATUS DESC, RBI_NUMBER"
      Dim tmpResult As New List(Of RecommendedBuyItem)
      Using conn As New SqlConnection(DBCONNSTR)
         Dim cmd As New SqlCommand(QueryString, conn)
         Try
            conn.Open()
            Dim r As SqlDataReader = cmd.ExecuteReader
            If r.HasRows Then
               Do While r.Read
                  tmpResult.Add(New RecommendedBuyItem(r))
               Loop
            End If
         Catch ex As Exception
            MsgBox(ex.Message)
         End Try
      End Using
      Return tmpResult
   End Function
   Private Sub DataGridView1_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
      Try
         Dim anItem As RecommendedBuyItem = RcmdItems.Find(RecommendedBuyItem.FindPredicateByItemId(DataGridView1.Rows(e.RowIndex).Cells("cItemID").Value))
         If e.ColumnIndex = 15 Then
            If e.RowIndex > -1 Then
               Dim ReportWindow As New SalesReport
               With ReportWindow
                  .Text = "Open POs for " & anItem.ITEMNO
                  .ReportTextBox.Text = anItem.GetPOs
                  .ReportTextBox.SelectionStart = 0
                  .ReportTextBox.SelectionLength = 0
                  .Show()
               End With
            End If
         End If
      Catch ex As Exception
         Debug.Print("In CellContentClick: " & ex.Message)
      End Try
   End Sub
   Private Sub ScottSaveProgressToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ScottSaveProgressToolStripMenuItem.Click
      SaveManagerProgress()
   End Sub
   Private Sub SetRemaininglMgrRmndToZero()
      For Each onerow As DataGridViewRow In DataGridView1.Rows
         If onerow.Cells.Item("cMgrRecmdBuy").Value = "" Then
            onerow.Cells.Item("cMgrRecmdBuy").Value = "0"
         End If
      Next
   End Sub
   Private Sub TonySaveProgressToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TonySaveProgressToolStripMenuItem.Click
      SaveTonyProgress()
   End Sub
   Private Sub FinalizeTonysChanges()
      DataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit)
      MenuStrip1.Items("TonyFinalizeToolStripMenuItem").Enabled = False
      Dim ovrwrtncnt As Integer = 0
      Dim acceptedcnt As Integer = 0
      SaveTonyProgress()
      MenuStrip1.Items("TonySaveProgressToolStripMenuItem").Enabled = False
      Dim tmpValue As Integer = Nothing
      Dim ProgWindow As New ProgressWindow
      ProgWindow.ProgressBar1.Maximum = DataGridView1.Rows.Count
      ProgWindow.Show()
      For Each onerow As DataGridViewRow In DataGridView1.Rows
         ProgWindow.ProgressBar1.PerformStep()
         If onerow.Cells.Item("cTonyApproved").Value <> "" Then
            Try
               tmpValue = CInt(onerow.Cells.Item("cTonyApproved").Value)
               ovrwrtncnt += 1
            Catch ex As Exception
               MsgBox("Error setting Total To Buy value for item " & onerow.Cells.Item("cItemNo").Value & " to " & onerow.Cells.Item("cTonyApproved").Value & ": " & ex.Message)
            End Try
         Else
            tmpValue = CInt(onerow.Cells.Item("cMgrRecmdBuy").Value)
            acceptedcnt += 1
         End If
         onerow.Cells.Item("cFinalNumberToBuy").Value = tmpValue
         Dim anItem As RecommendedBuyItem = RcmdItems.Find(RecommendedBuyItem.FindPredicateByItemId(onerow.Cells.Item("cItemID").Value))
         If anItem.UpdateTotalRecommendedBuy(tmpValue) <> 1 Then MsgBox("Failed to update Total Recoomended Buy for item " & onerow.Cells.Item("cItemNo").Value & " with ID of " & onerow.Cells.Item("cItemID").Value & " to " & tmpValue)
      Next
      If ovrwrtncnt + acceptedcnt = DataGridView1.Rows.Count Then
         SendAlert("Accepted " & acceptedcnt & " Mgr Recommended buys." & vbCrLf & "Overwrote " & ovrwrtncnt & " Mgr Recommended buys.", "")
         MsgBox("Accepted " & acceptedcnt & " Mgr Recommended buys." & vbCrLf & "Overwrote " & ovrwrtncnt & " Mgr Recommended buys." & Environment.NewLine & "An alert was sent to " & SelectedManager & " so the items can be distributed to buyers.", MsgBoxStyle.Information, "Finalize Complete")
      Else
         MsgBox("There was an error finalizing " & DataGridView1.Rows.Count - (ovrwrtncnt + acceptedcnt) & " items." & Environment.NewLine & "Please check the items and try again.", MsgBoxStyle.Exclamation, "Finalize Error")
      End If
      ProgWindow.Close()
      MenuStrip1.Items("TonySaveProgressToolStripMenuItem").Enabled = True
      MenuStrip1.Items("TonyFinalizeToolStripMenuItem").Enabled = True
   End Sub
   Private Sub SaveTonyProgress()
      DataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit)
      MenuStrip1.Items("TonySaveProgressToolStripMenuItem").Enabled = False
      Dim counter As Integer = 0
      Dim ProgWindow As New ProgressWindow
      ProgWindow.ProgressBar1.Maximum = DataGridView1.Rows.Count
      ProgWindow.Show()
      For Each onerow As DataGridViewRow In DataGridView1.Rows
         ProgWindow.ProgressBar1.PerformStep()
         If onerow.Cells.Item("cTonyApproved").Value <> "" Then
            Try
               Dim tmpValue As Integer = CInt(onerow.Cells.Item("cTonyApproved").Value)
               If tmpValue >= 0 Then
                  For Each oneItem As RecommendedBuyItem In RcmdItems
                     If oneItem.ITEMID = onerow.Cells.Item("cItemID").Value Then
                        If oneItem.UpdateTonyApproved(tmpValue) = 1 Then
                           counter += 1
                        Else
                           MsgBox("Failed to update Tony RecmdBuy for item " & onerow.Cells.Item("cItemNo").Value & " with ID of " & onerow.Cells.Item("cItemID").Value & " to " & tmpValue)
                        End If
                     End If
                  Next
               End If
            Catch ex As Exception
               MsgBox("Error updading item " & onerow.Cells.Item("cItemNo").Value & ": " & ex.Message)
            End Try
         End If
      Next
      ProgWindow.Close()
      MenuStrip1.Items("TonySaveProgressToolStripMenuItem").Enabled = True
      'MsgBox("Updated " & counter & " records.")
   End Sub
   Private Sub SaveManagerProgress()
      DataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit)
      MenuStrip1.Items("ScottSaveProgressToolStripMenuItem").Enabled = False
      Dim counter As Integer = 0
      Dim ProgWindow As New ProgressWindow
      ProgWindow.ProgressBar1.Maximum = DataGridView1.Rows.Count
      ProgWindow.Show()
      For Each onerow As DataGridViewRow In DataGridView1.Rows
         If onerow.Cells.Item("cMgrRecmdBuy").Value <> "" Then
            Try
               Dim tmpValue As Integer = CInt(onerow.Cells.Item("cMgrRecmdBuy").Value)
               If tmpValue >= 0 Then
                  Dim anItem As RecommendedBuyItem = RcmdItems.Find(RecommendedBuyItem.FindPredicateByItemId(onerow.Cells("cItemID").Value))
                  If anItem.UpdateManagerRecommendedBuy(tmpValue) = 1 Then
                     counter += 1
                  Else
                     MsgBox("Failed to update Mgr RecmdBuy for item " & onerow.Cells.Item("cItemNo").Value & " with ID of " & onerow.Cells.Item("cItemID").Value & " to " & tmpValue)
                  End If
               End If
            Catch ex As Exception
               MsgBox("Error updading item " & onerow.Cells.Item("cItemNo").Value & ": " & ex.Message)
            End Try
         End If
         ProgWindow.ProgressBar1.PerformStep()
      Next
      ProgWindow.Close()
      MenuStrip1.Items("ScottSaveProgressToolStripMenuItem").Enabled = True
      If counter = DataGridView1.Rows.Count Then
         SendAlert(counter & " items finalized.", "FinalizeForTony")
         MsgBox("Updated " & counter & " records." & Environment.NewLine & "The Items were sucessfully finalized and an Email alert was sent to Tony", MsgBoxStyle.Information, "Items Finalized for Tony")
      Else
         MsgBox("There are still " & DataGridView1.Rows.Count - counter & " items unset." & Environment.NewLine & "Progress has been saved but the Items have not been finalized for Tony.", MsgBoxStyle.Exclamation, "Progress saved")
      End If
   End Sub
   Private Sub ScottSetRemainingTo0ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ScottSetRemainingTo0ToolStripMenuItem.Click
      SetRemaininglMgrRmndToZero()
   End Sub
   Private Sub TonyFinalizeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TonyFinalizeToolStripMenuItem.Click
      FinalizeTonysChanges()
   End Sub
   Private Sub DistributeToBuyersToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DistributeToBuyersToolStripMenuItem.Click
      DistributeToBuyersToolStripMenuItem.Enabled = False
      Dim cnt As Integer = 0
      For Each row As DataGridViewRow In DataGridView1.Rows
         Dim i As RecommendedBuyItem = RcmdItems.Find(RecommendedBuyItem.FindPredicateByItemId(row.Cells.Item("cItemID").Value)) 'GetRecommendedItemByID(row.Cells.Item("cItemID").Value)
         If i.TotalQtyToBuy >= 0 Then
            i.UpdateScottDistributeToBuyers()
            cnt += 1
            DistributeToBuyersToolStripMenuItem.Text = "Distributed " & cnt & " items to Buyers"
         End If
      Next
      If DataGridView1.Rows.Count = cnt Then
         SendAlert("", "FinalizeForBuyers")
         MsgBox(cnt & " items were distributed to buyers.  An an alert was sent to buyer to process the items with POMaker.", MsgBoxStyle.Information, "Distribution result")
      Else
         MsgBox(DataGridView1.Rows.Count - cnt & " items were not distributed.  Make sure all items have a Total Recommended Buy set and try again.", MsgBoxStyle.Exclamation, "Distribution to buyers alert.")
      End If
      DistributeToBuyersToolStripMenuItem.Text = "Distribute to Buyers"
      DistributeToBuyersToolStripMenuItem.Enabled = True
   End Sub
   Private Sub DataGridView1_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseClick
      If e.RowIndex >= 0 And e.ColumnIndex >= 0 And e.Button = MouseButtons.Right Then
         DataGridView1.ClearSelection()
         DataGridView1.Rows(e.RowIndex).Selected = True
         Dim r As Rectangle = DataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, True)
         ItemContextMenu.Show(sender, r.Left + e.X, r.Top + e.Y)
      End If
   End Sub
   Private Sub DataGridView1_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles DataGridView1.CellValidating
      If Not {"TONY", "TSCHMIDT", "PAULMANAGER"}.Contains(AppUser.ToUpper) Then Return
      If Not DataGridView1.Columns(e.ColumnIndex).Name = "cTonyApproved" Then Return
      Dim anItemRow As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
      Dim anItem As RecommendedBuyItem = RcmdItems.Find(RecommendedBuyItem.FindPredicateByItemId(anItemRow.Cells("cItemID").Value))
      Dim NewValue As String = e.FormattedValue.ToString().Trim
      If String.IsNullOrEmpty(NewValue) Then
         Debug.Print("new value empty")
         anItem.UpdateTotalRecommendedBuy(anItemRow.Cells.Item("cMgrRecmdBuy").Value)
         anItem.UpdateTonyApproved(NewValue)
         anItemRow.Cells.Item("cFinalNumberToBuy").Value = anItemRow.Cells.Item("cMgrRecmdBuy").Value
      ElseIf IsNumeric(NewValue) Then
         Debug.Print("new value is number")
         anItem.UpdateTotalRecommendedBuy(NewValue)
         anItemRow.Cells.Item("cFinalNumberToBuy").Value = NewValue
         anItem.UpdateTonyApproved(NewValue)
      Else
         Debug.Print("new value is not number ")
         DataGridView1.Rows(e.RowIndex).ErrorText = "New Value is not a number or blank"
         MsgBox("New Value is not a number or blank", MsgBoxStyle.Exclamation, "Data Error")
         e.Cancel = True
      End If
   End Sub
   Private Sub ItemSalesMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ItemSalesMenuItem.Click
      Dim anItem As RecommendedBuyItem = RcmdItems.Find(RecommendedBuyItem.FindPredicateByItemId(DataGridView1.SelectedRows.Item(0).Cells("cItemID").Value))
      Dim ReportWindow As New SalesReport
      With ReportWindow
         .Text = "Sales History"
         .ReportTextBox.Text = anItem.ItemSales
         .ReportTextBox.SelectionStart = 0
         .ReportTextBox.SelectionLength = 0
         .Show()
      End With
   End Sub
   Private Sub StyleSalesMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StyleSalesMenuItem.Click
      Dim anItem As RecommendedBuyItem = RcmdItems.Find(RecommendedBuyItem.FindPredicateByItemId(DataGridView1.SelectedRows.Item(0).Cells("cItemID").Value))
      Dim ReportWindow As New SalesReport
      With ReportWindow
         .Text = "Style Sales"
         .ReportTextBox.Text = anItem.StyleSales
         .ReportTextBox.SelectionStart = 0
         .ReportTextBox.SelectionLength = 0
         .Show()
      End With
   End Sub
   Private Sub LastAdverticedMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LastAdverticedMenuItem.Click
      Dim anItem As RecommendedBuyItem = RcmdItems.Find(RecommendedBuyItem.FindPredicateByItemId(DataGridView1.SelectedRows.Item(0).Cells("cItemID").Value))
      Dim ReportWindow As New SalesReport
      With ReportWindow
         .Text = "Last Advertised"
         .ReportTextBox.Text = anItem.LastAdverticed
         .ReportTextBox.SelectionStart = 0
         .ReportTextBox.SelectionLength = 0
         .Show()
      End With
   End Sub
   Private Sub ItemActivityHistoryMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ItemActivityHistoryMenuItem.Click
      Debug.Print("In Show History")
      Dim anItem As RecommendedBuyItem = RcmdItems.Find(RecommendedBuyItem.FindPredicateByItemId(DataGridView1.SelectedRows.Item(0).Cells("cItemID").Value))
      Dim ReportWindow As New SalesReport
      With ReportWindow
         .Text = "Item Activity History"
         .ReportTextBox.Text = anItem.ActivityHistory
         .ReportTextBox.SelectionStart = 0
         .ReportTextBox.SelectionLength = 0
         .Show()
      End With
   End Sub
   Private Sub SendAlert(ByVal MsgBody As String, ByVal Source As String)
      Dim anEmail As New MailMessage
      With anEmail
         .Priority = MailPriority.High
         .Body = MsgBody
            '.To.Add("federico@ecommerce.com")
            Select Case UCase(AppUser)
            Case "PAUL"
                    .From = New MailAddress("paul@ecommerce.com")
                    If Source.Contains("FinalizeForBuyers") Then
                  .Subject = "Paul already approved new items to be processed with POMaker"
               ElseIf Source.Contains("FinalizeForTony") Then
                  .Subject = "Paul already finalized Recommended Buys to be approved by Manager"
               End If
            Case "CATHY"
                    .From = New MailAddress("cathy@ecommerce.com")
                    If Source.Contains("FinalizeForBuyers") Then
                  .Subject = "Cathy already approved new items to be processed with POMaker"
                        .To.Add("cathy@ecommerce.com")
                    ElseIf Source.Contains("FinalizeForTony") Then
                  .Subject = "Cathy already finalized Recommended Buys to be approved by Tony"
               End If
            Case "BRIAN"
                    .From = New MailAddress("brian@ecommerce.com")
                    If Source.Contains("FinalizeForBuyers") Then
                  .Subject = "Brian already approved new items to be processed with POMaker"
               ElseIf Source.Contains("FinalizeForTony") Then
                  .Subject = "Brian already finalized Recommended Buys to be approved by Manager"
               End If
                    .To.Add("brian@ecommerce.com")
                Case "EDLYN"
                    .From = New MailAddress("edlyn@ecommerce.com")
                    If Source.Contains("FinalizeForBuyers") Then
                  .Subject = "Edlyn already approved new items to be processed with POMaker"
               ElseIf Source.Contains("FinalizeForTony") Then
                  .Subject = "Edlyn already finalized Recommended Buys to be approved by Manager"
               End If
                    .To.Add("edlyn@ecommerce.com")
                Case "SCOTTM"
                    .From = New MailAddress("scottm@ecommerce.com")
                    If Source.Contains("FinalizeForBuyers") Then
                  .Subject = "Scott already approved new items to be processed with POMaker"
               ElseIf Source.Contains("FinalizeForTony") Then
                  .Subject = "Scott already finalized Recommended Buys to be approved by Manager"
               End If
                    .To.Add("scottm@ecommerce.com")
                Case "TRACEY"
                    .From = New MailAddress("tracey@ecommerce.com")
                    If Source.Contains("FinalizeForBuyers") Then
                  .Subject = "Tracey already approved new items to be processed with POMaker"
               ElseIf Source.Contains("FinalizeForTony") Then
                  .Subject = "Tracey already finalized Recommended Buys to be approved by Manager"
               End If
                    .To.Add("tracey@ecommerce.com")
                Case "TONY", "TSCHMIDT"
                    .From = New MailAddress("tony@ecommerce.com")
                    If SelectedManager.Contains("PAUL") Then
                  .Subject = "Tony already approved Paul's Recommeded Buys"
               ElseIf SelectedManager.Contains("CATHY") Then
                  .Subject = "Tony already approved Cathy's Recommeded Buys"
                        .To.Add("cathy@ecommerce.com")
                    ElseIf SelectedManager.Contains("BRIAN") Then
                  .Subject = "Tony already approved Brian's Recommeded Buys"
                        .To.Add("brian@ecommerce.com")
                    ElseIf SelectedManager.Contains("EDLYN") Then
                  .Subject = "Tony already approved Edlyn's Recommeded Buys"
                        .To.Add("edlyn@ecommerce.com")
                    ElseIf SelectedManager.Contains("SCOTTM") Then
                  .Subject = "Tony already approved Scott's Recommeded Buys"
                        .To.Add("scottm@ecommerce.com")
                    ElseIf SelectedManager.Contains("TRACEY") Then
                  .Subject = "Tony already approved Tracey's Recommeded Buys"
                        .To.Add("tracey@ecommerce.com")
                    End If
            Case "PAULMANAGER"
                    .From = New MailAddress("paul@ecommerce.com")
                    If SelectedManager.Contains("PAUL") Then
                  .Subject = "Paul already approved his own Recommeded Buys"
               ElseIf SelectedManager.Contains("CATHY") Then
                  .Subject = "Paul already approved Cathy's Recommeded Buys"
                        .To.Add("cathy@ecommerce.com")
                    ElseIf SelectedManager.Contains("BRIAN") Then
                  .Subject = "Paul already approved Brian's Recommeded Buys"
                        .To.Add("brian@ecommerce.com")
                    ElseIf SelectedManager.Contains("EDLYN") Then
                  .Subject = "Paul already approved Edlyn's Recommeded Buys"
                        .To.Add("edlyn@ecommerce.com")
                    ElseIf SelectedManager.Contains("SCOTTM") Then
                  .Subject = "Paul already approved Scott's Recommeded Buys"
                        .To.Add("scottm@ecommerce.com")
                    ElseIf SelectedManager.Contains("TRACEY") Then
                  .Subject = "Paul already approved Tracey's Recommeded Buys"
                        .To.Add("tracey@ecommerce.com")
                    End If
         End Select
            .To.Add("paul@ecommerce.com")
            .CC.Add("tony@ecommerce.com")
        End With
      Dim aSMTPClient As New SmtpClient("172.16.92.10")
      Try
         aSMTPClient.Send(anEmail)
      Catch ex As Exception
         LogThis("EMAILERROR", ex.Message)
         Console.WriteLine(ex.Message)
      End Try
   End Sub
End Class
Class RecommendedBuyItem
   Implements IComparable(Of RecommendedBuyItem)
#Region "Class Private Variables"
   Private oItemID As Integer = 0
   Private oItemNo As String = ""
   Private oEDPNO As String = ""
   Private oItemDesc As String = ""
   Private oVendor As String = ""
   Private oVendorNo As String = ""
   Private oVendorDesc As String = ""
   Private oStatus As String = ""
   Private oPrice As String = ""
   Private oMarginPercent As String = ""
   Private oAvg52Wk As String = ""
   Private oAvg26Wk As String = ""
   Private oAvg13Wk As String = ""
   Private oAvg8Wk As String = ""
   Private oAvg4Wk As String = ""
   Private oLastWk As String = ""
   Private oPONum1 As String = ""
   Private oPOExpDate1 As String = ""
   Private oPOQty1 As String = ""
   Private oPONum2 As String = ""
   Private oPOExpDate2 As String = ""
   Private oPOQty2 As String = ""
   Private oPONum3 As String = ""
   Private oPOExpDate3 As String = ""
   Private oPOQty3 As String = ""
   Private oPONum4 As String = ""
   Private oPOExpDate4 As String = ""
   Private oPOQty4 As String = ""
   Private oTotalDue As String = ""
   Private oOnHand As String = ""
   Private oWeeksOfStock As String = ""
   Private oReorderLevel As String = ""
   Private oVendorPrice As String = ""
   Private oLandedCost As String = ""
   Private oMinQty As String = ""
   Private oBOQty As String = ""
   Private oRecmdBuy As String = ""
   Private oEnteredDate As String = ""
   Private oMgrRecmdBuy As String = ""
   Private oMgrAppredDate As String = ""
   Private oTonyRecmdBuy As String = ""
   Private oTonyApprovedDate As String = ""
   Private oMgrPartNo As String = ""
   Private oTotalToBuy As Integer = -1
#End Region
   Sub New(ByVal r As SqlDataReader)
      oItemID = r.Item("RBITEM_ID")
      oItemNo = r.Item("RBI_NUMBER")
      oEDPNO = r.Item("RBI_EDPNO_NUMBER")
      oItemDesc = r.Item("RBI_DESCRIPTION")
      oAvg52Wk = r.Item("RBI_AVG52WK")
      oAvg26Wk = r.Item("RBI_AVG26WK")
      oAvg13Wk = r.Item("RBI_AVG13WK")
      oAvg8Wk = r.Item("RBI_AVG8WK")
      oAvg4Wk = r.Item("RBI_AVG4WK")
      oLastWk = r.Item("RBI_LASTWK")
      oPONum1 = r.Item("RBI_PO_NUMBER1")
      oPOExpDate1 = r.Item("RBI_PO_EXPDATE1")
      oPOQty1 = r.Item("RBI_PO_QTY1")
      oPONum2 = r.Item("RBI_PO_NUMBER2")
      oPOExpDate2 = r.Item("RBI_PO_EXPDATE2")
      oPOQty2 = r.Item("RBI_PO_QTY2")
      oPONum3 = r.Item("RBI_PO_NUMBER3")
      oPOExpDate3 = r.Item("RBI_PO_EXPDATE3")
      oPOQty3 = r.Item("RBI_PO_QTY3")
      oPONum4 = r.Item("RBI_PO_NUMBER4")
      oPOExpDate4 = r.Item("RBI_PO_EXPDATE4")
      oPOQty4 = r.Item("RBI_PO_QTY4")
      oTotalDue = r.Item("RBI_TOTAL_DUE")
      oOnHand = r.Item("RBI_ONHAND")
      oWeeksOfStock = r.Item("RBI_WEEKSOFSTOCK")
      oReorderLevel = r.Item("RBI_REORDERLEVEL")
      oVendorPrice = r.Item("RBI_VENDOR_PRICE")
      If Not IsDBNull(r.Item("RBI_LANDED_COST")) Then oLandedCost = r.Item("RBI_LANDED_COST")
      oMinQty = r.Item("RBI_MINQTY")
      oBOQty = r.Item("RBI_BOQTY")
      oRecmdBuy = r.Item("RBI_RECMDBUY")
      oVendor = r.Item("RBI_VENDOR")
      oVendorNo = r.Item("RBI_VENDOR_ITM_NUMBER")
      oStatus = r.Item("RBI_STATUS")
      oPrice = r.Item("RBI_PRICE")
      oMarginPercent = r.Item("RBI_MARGIN")
      oVendorDesc = r.Item("RBI_VENDOR_DESCRIPTION")
      oEnteredDate = r.Item("RBI_ADDED_DATE")
      If Not IsDBNull(r.Item("RBI_MGR_RECMDBUY")) Then oMgrRecmdBuy = r.Item("RBI_MGR_RECMDBUY")
      If Not IsDBNull(r.Item("RBI_MGR_APPRVD")) Then oMgrAppredDate = r.Item("RBI_MGR_APPRVD")
      If Not IsDBNull(r.Item("RBI_TONY_RECMDBUY")) Then oTonyRecmdBuy = r.Item("RBI_TONY_RECMDBUY")
      If Not IsDBNull(r.Item("RBI_TONY_APPRVD")) Then oTonyApprovedDate = r.Item("RBI_TONY_APPRVD")
      If Not IsDBNull(r.Item("RBI_TOTAL_TO_BUY")) Then oTotalToBuy = r.Item("RBI_TOTAL_TO_BUY")
   End Sub
   Public Function GetDataGridRow() As String()
      Dim tmptotaldue As String = ""
      Dim i As Integer = Convert.ToInt32(oTotalDue)
      If i > 0 Then
         tmptotaldue = oTotalDue
      End If
      Dim tmptotaltobuy As String = ""
      If oTotalToBuy >= 0 Then
         tmptotaltobuy = oTotalToBuy
      End If
      Dim tmpstring() As String = {oItemNo.Trim, oItemDesc.Trim, oVendorNo.Trim, oStatus.Trim, oVendor.Trim, oPrice.Trim, oMarginPercent.Trim, oVendorPrice.Trim, oLandedCost.Trim, oAvg52Wk.Trim, oAvg26Wk.Trim, oAvg13Wk.Trim, oAvg8Wk.Trim, oAvg4Wk.Trim, _
                                   oLastWk.Trim, tmptotaldue.Trim, oOnHand.Trim, oWeeksOfStock.Trim, oReorderLevel.Trim, oMinQty.Trim, oBOQty.Trim, oRecmdBuy.Trim, oMgrRecmdBuy.Trim, oTonyRecmdBuy.Trim, tmptotaltobuy, oEDPNO, oItemID}
      Return tmpstring
   End Function
   Public Function GetPOs() As String
      Dim sformat As String = "{0,-13}{1,-13}{2}" & vbCrLf
      Dim tmpResult As String = ""
      If oPONum1.Length > 7 Then
         tmpResult &= String.Format(sformat, "PO", "Exp Date", "Qty")
         tmpResult &= String.Format(sformat, oPONum1, oPOExpDate1, oPOQty1)
      End If
      If oPONum2.Length > 7 Then
         tmpResult &= String.Format(sformat, oPONum2, oPOExpDate2, oPOQty2)
      End If
      If oPONum3.Length > 7 Then
         tmpResult &= String.Format(sformat, oPONum3, oPOExpDate3, oPOQty3)
      End If
      If oPONum4.Length > 7 Then
         tmpResult &= String.Format(sformat, oPONum4, oPOExpDate4, oPOQty4)
      End If
      Return tmpResult
   End Function
   ReadOnly Property ITEMNO() As String
      Get
         Return oItemNo.Trim
      End Get
   End Property
   ReadOnly Property EnteredDate() As DateTime
      Get
         Return CDate(oEnteredDate)
      End Get
   End Property
   ReadOnly Property RecommendedBuy() As Integer
      Get
         If IsNumeric(oRecmdBuy) Then
            Return CInt(oRecmdBuy)
         Else
            Return Nothing
         End If
      End Get
   End Property
   ReadOnly Property MgrRecommendedBuy As String
      Get
         Return oMgrRecmdBuy
      End Get
   End Property
   ReadOnly Property ITEMID() As String
      Get
         Return oItemID
      End Get
   End Property
   ReadOnly Property EDPNO() As Integer
      Get
         Return CInt(oEDPNO)
      End Get
   End Property
   ReadOnly Property TotalQtyToBuy() As Integer
      Get
         Return oTotalToBuy
      End Get
   End Property
   ReadOnly Property TotalToBuyForTotalSum As Integer
      Get
         If oTotalToBuy >= 0 Then
            Return oTotalToBuy
         Else
            Return 0
         End If
      End Get
   End Property
   ReadOnly Property ItemCost As Decimal
      Get
         Return CDec(oVendorPrice)
      End Get
   End Property
   ReadOnly Property LastAdverticed As String
      Get
         Dim tmpResult As String = ITEMNO & vbCrLf & vbCrLf
         Dim QueryString As String =
         "SELECT TOP 1 LEFT(OFFERITEM,8) AS OFFERNO, OFFERNAME_001 + OFFERNAME_002 + OFFERNAME_003 AS OFFER_DESCRIPTION,DATEENTERED " & _
         "FROM OFFERITEMS O JOIN OFFERS F ON F.OFFERNO = LEFT(OFFERITEM,8) " & _
         "WHERE OFFERITEM LIKE '%" & EDPNO.ToString.PadLeft(8, "0") & "' AND O.USERID <> 'MSGUPDT' AND O.STARTDATE <> '00000000' ORDER BY DATEENTERED DESC"
         Using conn As New SqlConnection(ECOMDB)
            Dim cmd As New SqlCommand(QueryString, conn)
            Try
               conn.Open()
               Dim r As SqlDataReader = cmd.ExecuteReader
               If r.HasRows Then
                  r.Read()
                  tmpResult &= "Last Adverticed: " & vbCrLf & vbCrLf & _
                  String.Format("{0,-9}{1,-61}{2}", "OFFERNO", "OFFER DESCRIPTION", "DATE") & vbCrLf & _
                  String.Format("{0,-9}{1,-61}{2}", r.Item("OFFERNO"), r.Item("OFFER_DESCRIPTION"), r.Item("DATEENTERED"))
               Else
                  tmpResult &= "Last Adverticed: Never"
               End If
            Catch ex As Exception
               MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error Getting Last Adverticement")
            End Try
         End Using
         Return tmpResult
      End Get
   End Property
   ReadOnly Property StyleSales() As String
      Get
         Dim QueryOne As String = ""
         Using conn As New SqlConnection(ECOMDB)
            Dim cmd As New SqlCommand("SELECT STYLE FROM ITEMMAST WHERE EDPNO = " & oEDPNO, conn)
            Try
               conn.Open()
               Dim r As SqlDataReader = cmd.ExecuteReader
               If r.HasRows Then
                  r.Read()
                  Dim s As String = r.Item("STYLE")
                  If s.Trim.Length < 3 Then Return "Item is not part of a style"
               End If
            Catch ex As Exception
               MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error Getting Style Sales")
            End Try
         End Using
         Dim GrandTotal As Integer = 0
         Dim L1Codes As New List(Of String)
         Dim L2Codes As New List(Of String)
         Dim SalesDetails As New List(Of OneStyleSales)
         Dim ShipDate As Date = Now.AddDays(-364)
         Dim QueryString = "SELECT SUM(ITEMQTYS) AS TOTAL,L2CODE,L1CODE " & _
         "FROM VW_ORDERSUBHEAD O JOIN STYLEITEMDATA S ON O.EDPNO = S.EDPNO " & _
         "WHERE O.EDPNO IN (SELECT EDPNO FROM ITEMMAST WHERE STYLE IN (SELECT STYLE FROM ITEMMAST WHERE EDPNO = @EDPNO AND STATUS NOT IN ('W2','W1'))) AND " & _
         "SHIPDATE > @SHIPDATE AND BS = 'S' GROUP BY L2CODE,L1CODE ORDER BY L2CODE DESC,L1CODE"
         Using conn As New SqlConnection(ECOMDB)
            Dim cmd As New SqlCommand(QueryString, conn)
            With cmd.Parameters
               .Add("@EDPNO", SqlDbType.BigInt).Value = oEDPNO
               .Add("@SHIPDATE", SqlDbType.Char, 8).Value = ShipDate.ToString("yyyyMMdd")
            End With
            Debug.Print("From Style Sales: EDPNO: " & oEDPNO)
            Try
               conn.Open()
               Dim r As SqlDataReader = cmd.ExecuteReader
               If r.HasRows Then
                  While r.Read
                     Dim oneResult As New OneStyleSales
                     Dim l1c As String = Trim(r.Item("L1CODE"))
                     Dim l2c As String = Trim(r.Item("L2CODE"))
                     Dim total As Integer = r.Item("TOTAL")
                     GrandTotal += total
                     oneResult.L1Code = l1c
                     oneResult.L2Code = l2c
                     oneResult.Items = total
                     SalesDetails.Add(oneResult)
                     If Not L1Codes.Contains(l1c) Then L1Codes.Add(l1c)
                     If Not L2Codes.Contains(l2c) Then L2Codes.Add(l2c)
                  End While
               End If
            Catch ex As Exception
               MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error Getting Style Sales")
            End Try
         End Using
         Dim L1Totals(L1Codes.Count - 1) As Integer
         Dim L2Totals(L2Codes.Count - 1) As Integer
         Dim Report As New System.Text.StringBuilder
         Report.AppendLine(Now.ToString & Environment.NewLine)
         Report.AppendLine(vbTab & "Style Sales Matrix for last 52 Weeks" & Environment.NewLine)
         Report.AppendLine("Style # " & oItemNo.Substring(0, oItemNo.IndexOf(" ", 5)) & vbTab & "Total Sold   " & GrandTotal & Environment.NewLine)
         Dim sformat1 As String = "{0,-8}{1,-8}{2,-8}"
         Report.Append(String.Format(sformat1, "COLOR", "TOTAL", "%COLOR"))
         Dim sfomat2 As String = ""
         For i As Integer = 0 To L1Codes.Count - 1
            For Each sResult As OneStyleSales In SalesDetails
               If sResult.L1Code = L1Codes(i) Then L1Totals(i) += sResult.Items
            Next
            sfomat2 &= "{" & i & ",-8}"
         Next
         Report.Append(String.Format(sfomat2, L1Codes.ToArray))
         Report.AppendLine()
         For i As Integer = 0 To L2Codes.Count - 1
            For Each sResult As OneStyleSales In SalesDetails
               If sResult.L2Code = L2Codes(i) Then L2Totals(i) += sResult.Items
            Next
            Report.Append(String.Format(sformat1, L2Codes(i), L2Totals(i), ((L2Totals(i) / GrandTotal) * 100).ToString("f2")))
            For Each sResult As OneStyleSales In SalesDetails
               If sResult.L2Code = L2Codes(i) Then
                  Report.Append(sResult.Items.ToString.PadRight(8, " "))
               End If
            Next
            Report.AppendLine()
         Next
         Report.AppendLine()
         Report.Append(String.Format(sformat1, "Total", "", ""))
         For i As Integer = 0 To L1Totals.Count - 1
            Report.Append(L1Totals(i).ToString.PadRight(8, " "))
         Next
         Report.AppendLine()
         Report.Append(String.Format(sformat1, "Size %", "", ""))
         For i As Integer = 0 To L1Totals.Count - 1
            Report.Append(((L1Totals(i) / GrandTotal) * 100).ToString("f2").PadRight(8, " "))
         Next
         Return Report.ToString
      End Get
   End Property
   ReadOnly Property ItemSales() As String
      Get
         Dim Report As New System.Text.StringBuilder
         Dim ThreeYearSales As New List(Of YearSales)
         For i As Integer = 0 To 2
            Dim aYear As YearSales = New YearSales(Now.AddYears(-i).Year)
            ThreeYearSales.Add(aYear)
         Next
         Dim QueryString = "SELECT SUBSTRING(SHIPDATE,1,6) AS SHIPMONTH,SUM(ITEMQTYS) AS TOTAL FROM VW_ORDERSUBHEAD " & _
         "WHERE EDPNO = @EDPNO AND (CAST(SUBSTRING(SHIPDATE,1,4) AS INT)) >= (YEAR(GETDATE()) - 2) AND BS = 'S' " & _
         "GROUP BY SUBSTRING(SHIPDATE,1,6)"
         Using conn As New SqlConnection(ECOMDB)
            Dim cmd As New SqlCommand(QueryString, conn)
            cmd.Parameters.Add("@EDPNO", SqlDbType.BigInt).Value = oEDPNO
            Try
               conn.Open()
               Dim r As SqlDataReader = cmd.ExecuteReader
               If r.HasRows Then
                  While r.Read
                     Dim ShipYearMonth As String = r.Item("SHIPMONTH")
                     Dim Total As Integer = r.Item("TOTAL")
                     For Each y As YearSales In ThreeYearSales
                        If y.Year = ShipYearMonth.Substring(0, 4) Then y.Months(CInt(ShipYearMonth.Substring(4, 2)) - 1) = Total
                     Next
                  End While
               End If
            Catch ex As Exception
               MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error Getting Style Sales")
            End Try
         End Using
         Report.AppendLine(Now.ToString & Environment.NewLine)
         Report.AppendLine(vbTab & "SALES HISTORY" & Environment.NewLine)
         Report.AppendLine("Item No. " & oItemNo & vbTab & oItemDesc & Environment.NewLine)
         Report.AppendLine(vbTab & ThreeYearSales(0).Year & vbTab & ThreeYearSales(1).Year & vbTab & ThreeYearSales(2).Year)
         Report.AppendLine("Month" & vbTab & "====" & vbTab & "====" & vbTab & "====")
         For i As Integer = 0 To 11
            Report.Append(i + 1 & vbTab)
            For y As Integer = 0 To 2
               Report.Append(ThreeYearSales(y).Months(i) & vbTab)
            Next
            Report.AppendLine()
         Next
         Report.AppendLine(vbTab & ThreeYearSales(0).YearTotal & vbTab & ThreeYearSales(1).YearTotal & vbTab & ThreeYearSales(2).YearTotal)
         Return Report.ToString
      End Get
   End Property
   ReadOnly Property ActivityHistory() As String
      Get
         Dim tmpResult As String = String.Format("{0,-20}{1}" & Environment.NewLine, CDate(oEnteredDate).ToString, oItemNo & " item added")
         Using conn As New SqlConnection(DBCONNSTR)
            Dim QueryString As String = "SELECT * FROM RECMDBUYITEMACTIONS WHERE RBITEM_ID = @RBITEM_ID"
            Dim cmd As New SqlCommand(QueryString, conn)
            cmd.Parameters.Add("@RBITEM_ID", SqlDbType.BigInt).Value = oItemID
            Try
               conn.Open()
               Dim r As SqlDataReader = cmd.ExecuteReader
               If r.HasRows Then
                  While r.Read
                     tmpResult &= String.Format("{0,-20}{1}" & Environment.NewLine, CDate(r.Item("RBIA_ACTION_DATETIME")).ToString, r.Item("RBIA_ACTION_LONG_TEXT"))
                     Debug.Print("read entry")
                  End While
               End If
            Catch ex As Exception
               Debug.Print("Error Entering Item Action into DB: " & ex.Message)
            End Try
         End Using
         Return tmpResult
      End Get
   End Property
   ReadOnly Property ManufacturerPartNumber As String
      Get
         Dim tmpResult As String = ""
         Using conn As New SqlConnection(ECOMDB)
            Dim cmd As New SqlCommand("SELECT TOP 1 RIGHT(REFITEMNO,21) FROM EDPITEMXREF WHERE EDPNO=" & oEDPNO & " AND STATUS='A'", conn)
            Try
               conn.Open()
               Dim r As SqlDataReader = cmd.ExecuteReader
               If r.HasRows Then
                  r.Read()
                  tmpResult = Trim(r.Item(0))
                  If {"AVD", "SRA", "TRU"}.Contains(oItemNo.Substring(4, 3)) Then Return tmpResult.PadLeft(12, "0").Insert(9, ".").Insert(6, ".").Insert(2, ".")
               End If
            Catch ex As Exception
               MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error Getting Manufacturer Part Number")
            End Try
         End Using
         Return tmpResult
      End Get
   End Property
   Public Function UpdateManagerRecommendedBuy(ByVal NewNumber As String) As Integer
      Dim QueryString As String = "UPDATE RECMDBUYITEMS SET RBI_MGR_RECMDBUY = '" & NewNumber & "' WHERE RBITEM_ID = " & oItemID
      Using conn As New SqlConnection(DBCONNSTR)
         Dim cmd As New SqlCommand(QueryString, conn)
         Try
            conn.Open()
            Return cmd.ExecuteNonQuery()
         Catch ex As Exception
            MsgBox(ex.Message)
            Return 0
         End Try
      End Using
   End Function
   Public Function UpdateTonyApproved(ByVal NewNumber As String) As Integer
      Dim QueryString As String = "UPDATE RECMDBUYITEMS SET RBI_TONY_RECMDBUY = '" & NewNumber & "' WHERE RBITEM_ID = " & oItemID
      Using conn As New SqlConnection(DBCONNSTR)
         Dim cmd As New SqlCommand(QueryString, conn)
         Try
            conn.Open()
            Return cmd.ExecuteNonQuery()
         Catch ex As Exception
            MsgBox(ex.Message)
            Return 0
         End Try
      End Using
   End Function
   Public Function UpdateScottDistributeToBuyers() As Integer
      Dim QueryString As String = "UPDATE RECMDBUYITEMS SET RBI_MGR_APPRVD = '" & Now.ToString("yyyy-MM-ddTHH:mm:ss") & "' WHERE RBITEM_ID = " & oItemID
      Using conn As New SqlConnection(DBCONNSTR)
         Dim cmd As New SqlCommand(QueryString, conn)
         Try
            conn.Open()
            Return cmd.ExecuteNonQuery()
         Catch ex As Exception
            MsgBox(ex.Message)
            Return 0
         End Try
      End Using
   End Function
   Public Function UpdateTotalRecommendedBuy(ByVal NewNumber As String) As Integer
      Dim QueryString As String = "UPDATE RECMDBUYITEMS SET RBI_TOTAL_TO_BUY = '" & NewNumber & "',RBI_TONY_APPRVD = '" & Now.ToString("yyyy-MM-ddTHH:mm:ss") & "' WHERE RBITEM_ID = " & oItemID
      Using conn As New SqlConnection(DBCONNSTR)
         Dim cmd As New SqlCommand(QueryString, conn)
         Try
            conn.Open()
            Return cmd.ExecuteNonQuery()
         Catch ex As Exception
            MsgBox(ex.Message)
            Return 0
         End Try
      End Using
   End Function
   Private Structure OneStyleSales
      Dim L1Code As String
      Dim L2Code As String
      Dim Items As Integer
   End Structure
   Public Function CompareTo(ByVal other As RecommendedBuyItem) As Integer Implements System.IComparable(Of RecommendedBuyItem).CompareTo
      Return New CaseInsensitiveComparer().Compare(ITEMID, other.ITEMID)
   End Function
   Public Shared Function FindPredicate(ByVal Item As RecommendedBuyItem) As Predicate(Of RecommendedBuyItem)
      Return Function(Item2 As RecommendedBuyItem) Item.ITEMID = Item.ITEMID
   End Function
   Public Shared Function FindPredicateByItemId(ByVal Item As String) As Predicate(Of RecommendedBuyItem)
      Return Function(Item2 As RecommendedBuyItem) Item = Item2.ITEMID
   End Function
   Public Shared Function FindPredicateByEDPNO(ByVal Item As String) As Predicate(Of RecommendedBuyItem)
      Return Function(Item2 As RecommendedBuyItem) Item = Item2.EDPNO
   End Function
End Class
Public Class YearSales
   Private oYear As Integer
   Public Months(11) As Integer
   ReadOnly Property Year As Integer
      Get
         Return oYear
      End Get
   End Property
   Sub New(ByVal Yr As Integer)
      oYear = Yr
   End Sub
   ReadOnly Property YearTotal As Integer
      Get
         Dim i As Integer = 0
         For Each m As Integer In Months
            i += m
         Next
         Return i
      End Get
   End Property
End Class