Imports System.Data.OleDb
Public Class Leaderboard
    Structure User 'creates structure user
        Dim Rank As Integer
        Dim Name As String
        Dim Score As DateTime
    End Structure

    Dim Counter As Integer

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load 'on form start up executes code in this sub
        Dim Leaderboard(9999) As User

        Call ReadFile(Leaderboard)
        Call SortFile(Leaderboard)
        Call DisplayFile(Leaderboard)

    End Sub

    Private Sub Home_Click(sender As Object, e As EventArgs) Handles Home.Click
        Dim Casa As New Home

        Casa.Show() 'hides the leaderboard and shows the home form
        Me.Hide()
    End Sub

    Public Sub ReadFile(ByRef Player() As User)

        Counter = 0 'initialize counter
        Dim SQLReader As OleDbDataReader
        Dim conn As OleDbConnection

        Try 'connects to database
            Dim connection_type As String = "Provider = Microsoft.JET.OleDB.4.0;"
            Dim file_location As String = "Data Source = C:\Users\knoxg08\OneDrive - Hutchesons' Grammar School\AdvHigher\Computing Science\Project\Project\Nonograms\Nonograms\bin\Debug\EasyLeaderboard.mdb"
            conn = New OleDbConnection(connection_type & file_location)
            conn.Open()
        Catch ex As Exception
        End Try

        Dim query1 As String = "SELECT * FROM [EasyDatabase]" 'Gets all data from EasyDatabase
        Dim command1 As New OleDbCommand(query1, conn)

        SQLReader = command1.ExecuteReader()


        If SQLReader.HasRows Then 'puts data from database into variables from the structure users and also keeps a running total of how big the array is
            While SQLReader.Read
                Player(Counter).Rank = SQLReader("Rank")
                Player(Counter).Name = SQLReader("Username")
                Player(Counter).Score = SQLReader("Score")
                Counter += 1
            End While
        Else
            MsgBox("No results returned")
        End If
    End Sub
    Private Sub Clear_Click(sender As Object, e As EventArgs) Handles Clear.Click
        Display.Rows.Clear() 'clears datagrid
    End Sub

    Public Sub DisplayFile(ByVal Player() As User)

        Dim index As Integer

        Display.Rows.Clear() 'prevents the same data from being output while it is already on the grid

        For index = 0 To (Counter - 1) 'outputs data to display
            Display.Rows.Add()
            Display.Item(0, index).Value = Player(index).Rank
            Display.Item(1, index).Value = Player(index).Name
            If Player(index).Score.Second > 9 Then 'formatting the time
                Display.Item(2, index).Value = Player(index).Score.Minute & ":" & Player(index).Score.Second
            Else
                Display.Item(2, index).Value = Player(index).Score.Minute & ":0" & Player(index).Score.Second
            End If
        Next

    End Sub
    Private Function Binary_Search(ByRef Leaderboard() As User, ByVal target As Integer) As Integer

        Dim iMax As Integer = Counter
        Dim iMin As Integer = 0
        Dim iMid As Integer

        Do While iMax >= iMin

            iMid = Int((iMax + iMin) / 2)

            If Leaderboard(iMid).Rank = target Then 'checks if the value has been found

                Return iMid

                Exit Function

            ElseIf Leaderboard(iMid).Rank < target Then

                iMin = iMid + 1 'sets new bounds to search for target
            Else
                iMax = iMid - 1 'sets new bounds to search for target
            End If
        Loop

        Return -1 'exits if nothing found
    End Function
    Private Sub SortFile(ByRef Player() As User)
        Dim index As Integer
        Dim ScoreVal As DateTime
        Dim NameVal As String
        Dim i As Integer

        For i = 1 To Counter - 1 'standard bubble sort
            ScoreVal = Player(i).Score 'initialises temps as player data
            NameVal = Player(i).Name
            index = i
            Do While (index > 0) AndAlso (ScoreVal < Player(index - 1).Score) 'AndAlso used so it doesn't check scoreval if index isn't met, prevents errors
                Player(index).Score = Player(index - 1).Score 'changes array order
                Player(index).Name = Player(index - 1).Name 'changes array order
                index -= 1 'running total
            Loop
            Player(index).Score = ScoreVal 'fixes order of array for nex sort
            Player(index).Name = NameVal 'makes sure to keep next to its score value
        Next

    End Sub
    Private Sub Display_Click(sender As Object, e As EventArgs) Handles Display.Click
        Dim Leaderboard(9999) As User

        Call ReadFile(Leaderboard) 'reads file
        Call SortFile(Leaderboard) 'sorts file (bubble sort)
        Call DisplayFile(Leaderboard) 'displays file

    End Sub
    Private Sub Search_Click(sender As Object, e As EventArgs) Handles Search.Click
        Dim Leaderboard(10000) As User
        Dim result As Integer
        Dim Target As Integer


        Call ReadFile(Leaderboard) 'reads file
        Call SortFile(Leaderboard) 'sorts file
        Call DisplayFile(Leaderboard) 'display file

        Target = InputBox("Please enter the leaderboard position of the person you would like to search for.") 'gets value from user to find using binary search

        result = Binary_Search(Leaderboard, Target) 'binary search function

        If result = -1 Then 'if value isn't found message below will be displayed
            MsgBox("Sorry that user does not exist please try another name.")
        ElseIf Leaderboard(result).Score.Second > 9 Then
            MsgBox("Rank: " & Leaderboard(result).Rank & " Name: " & Leaderboard(result).Name & " Score: " & Leaderboard(result).Score.Minute & ":" & Leaderboard(result).Score.Second) 'displays user that coincides with the number the user chose
        Else
            MsgBox("Rank: " & Leaderboard(result).Rank & " Name: " & Leaderboard(result).Name & " Score: " & Leaderboard(result).Score.Minute & ":0" & Leaderboard(result).Score.Second) 'displays user that coincides with the number the user chose
        End If
    End Sub
End Class