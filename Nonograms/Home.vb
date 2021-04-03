Public Class Home
    Private Sub NewGame_Click(sender As Object, e As EventArgs) Handles NewGame.Click
        Dim Puzzle As New Puzzle

        Puzzle.Show() 'takes user to the puzzle form
        Me.Close()
    End Sub

    Private Sub Leaderboards_Click(sender As Object, e As EventArgs) Handles Leaderboards.Click
        Dim Leaderboard As New Leaderboard

        Leaderboard.Show() 'takes users to the leaderboard form
        Me.Close()
    End Sub
End Class