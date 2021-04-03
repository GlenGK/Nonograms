Imports System.Data.OleDb
Public Class WinScreen
    Public Clock As String

    Public Sub WinScreen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Clock = Puzzle.Time 'gets the time taken to complete the puzzle from Puzzle form
        Label1.Text = "Congratulations! You beat this nonogram with a time of " & Clock 'Displays puzzle time
    End Sub
    Public Sub WriteFile(ByVal Name As String)
        Dim conn As OleDbConnection
        Dim SQLReader As OleDbDataReader
        Dim Counter As Integer = 0

        'connects to database
        Try
            Dim connection_type As String = "Provider = Microsoft.JET.OleDB.4.0;"
            Dim file_location As String = "Data Source = C:\Users\knoxg08\OneDrive - Hutchesons' Grammar School\AdvHigher\Computing Science\Project\Project\Nonograms\Nonograms\bin\Debug\EasyLeaderboard.mdb"
            conn = New OleDbConnection(connection_type & file_location)
            conn.Open()
        Catch ex As Exception
        End Try

        Dim query As String = "SELECT * FROM [EasyDatabase]" 'gets all the data from the database EasyDatabase
        Dim command As New OleDbCommand(query, conn)

        SQLReader = command.ExecuteReader() ' executes sql query

        If SQLReader.HasRows Then 'counts rows in database
            While SQLReader.Read
                Counter += 1
            End While
        End If

        Dim query1 As String = "INSERT INTO EasyDatabase VALUES (" & Counter + 1 & " , ' " & Name & " ' , ' " & "00:" & Clock & " ');" 'adds new record to database
        Dim command1 As New OleDbCommand(query1, conn)

        SQLReader = command1.ExecuteReader 'executes command


    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim index As Integer
        Dim Temp As String
        Dim Username As String = ""
        Dim Puzzle As New Puzzle
        Dim Leaderboard As New LeaderBoard

        Temp = TextBox1.Text

        For index = 0 To 2 'validates if the Temp is All capitalized and the string is 3 letters long
            Do Until Len(Temp) = 3 And ((Asc(Temp.Substring(index)) > 96 And Asc(Temp.Substring(index)) < 123) Or Asc(Temp.Substring(index)) > 64 And Asc(Temp.Substring(index)) < 91)
                Temp = InputBox("Sorry, the name must only be 3 letters long")
            Loop
        Next

        For index = 0 To 2 'converts lowercase letters to capital letters
            If Asc(Temp.Substring(index)) > 96 And Asc(Temp.Substring(index)) < 123 Then
                Username &= Chr(Asc(Temp.Substring(index, 1)) - 32)
            ElseIf Asc(Temp.Substring(index)) > 64 And Asc(Temp.Substring(index)) < 91 Then
                Username &= Temp.Substring(index, 1)
            End If
        Next

        Call WriteFile(Username) 'writes data to file

        Me.Hide() 'displays leaderboard and hides puzzle and winscreen
        Puzzle.Hide()
        Leaderboard.Show()
    End Sub
End Class