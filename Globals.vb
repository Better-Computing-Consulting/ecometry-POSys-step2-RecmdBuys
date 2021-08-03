Module Globals
    'Public DBCONNSTR As String = "Data Source=ECOMDB3;Initial Catalog=RECBYSDEV;UID=sss;PWD=sssss"
    Public DBCONNSTR As String = "Data Source=ECOMDB3;Initial Catalog=RECBUYS;UID=sss;PWD=sssss"

    'Public ECOMDB As String = "Data Source=ecom-db2;Initial Catalog=ECOMVER;UID=sss;PWD=ssss"
    Public ECOMDB As String = "Data Source=ecom-db1;Initial Catalog=ECOMLIVE;UID=sss;PWD=ssss"

    Public Sub LogThis(ByVal ShortText As String, ByVal LongText As String)
      Dim entryDateTime As DateTime = Now
      Dim logfile As String = My.Application.Info.DirectoryPath & "\" & My.Application.Info.ProductName & ".log"
      My.Computer.FileSystem.WriteAllText(logfile, "[" & entryDateTime.ToString("yyyy-MM-dd HH:mm:ss") & "]" & " " & String.Format("{0,-15}{1}" & Environment.NewLine, ShortText, LongText), True)
   End Sub
End Module
