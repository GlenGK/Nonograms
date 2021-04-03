'Public Class EasyPuzzle
Class Puzzle
    Dim Answer(99) As Boolean
    Dim Check(110) As Boolean
    Dim Randomizer(110) As Integer
    Public Shared Clock As Integer
    Public Shared Time As String 'public to be used in other form
    Public Const GridSize As Integer = 11 ' small = 9, medium = 13, large = 19
    Private Grid As New List(Of List(Of Boolean?))() ' nullable boolean (black:true, white:false, blank:nothing)
    Private Sub Home_Click(sender As Object, e As EventArgs) Handles Home.Click
        Dim Casa As New Home

        Timer1.Stop() 'stops timer
        Casa.Show() 'hides puzzle and shows home page
        Me.Hide()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Panel1.BackColor = Color.Tan 'changes panel colour
        Timer1.Interval = 1000
        Timer1.Start() 'starts timer
        ' initialize the grid to all blanks
        For col As Integer = 1 To GridSize
            Dim column As New List(Of Boolean?)
            For row As Integer = 1 To GridSize
                column.Add(Nothing)
            Next
            Grid.Add(column)
        Next

        Dim i As Integer

        For i = 0 To 99 'creates random array of 1s and 0s
            Answer(i) = False
            Randomize()
            Randomizer(i) = Int(2 * Rnd())

            If Randomizer(i) = 1 Then 'converts 1s and 0s to boolean
                Check(i) = True
            ElseIf Randomizer(i) = 0 Then
                Check(i) = False
            End If
        Next

        Call CalculateRows() 'calculates rows 
        Call CalculateColumns() 'calculates columns
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick 'updates clock on form every second
        Clock += 1
        Label1.Text = GetTime(Clock)
    End Sub

    Public Function GetTime(Time As Integer) As String 'changes time from integer to readable time in minutes and seconds
        Dim Min As Integer
        Dim Sec As Integer

        Sec = Time Mod 60
        Min = ((Time - Sec) / 60) Mod 60

        Return Format(Min, "00") & ":" & Format(Sec, "00")
    End Function

    Private Sub CalculateRows()
        Dim index, LowerBound, UpperBound, Counter, x As Integer
        Dim Rows(99) As Integer
        LowerBound = 0 'initialize variables
        UpperBound = 9
        x = 0
        Dim RowString As String = ""

        For index = 0 To 99 'makes all values of array Rows() 0
            Rows(index) = 0
        Next

        For Counter = 0 To 9 'loops for each row
            For index = LowerBound To UpperBound
                If Check(index) = True And index = UpperBound Then
                    Rows(x) = Rows(x) + 1
                    RowString = RowString & " " & Rows(x) 'adds rows(x) to rowstring
                    x += 1
                ElseIf Check(index) = True Then
                    Rows(x) = Rows(x) + 1
                ElseIf Check(index) = False Then
                    If Not Rows(x) = 0 Then
                        RowString = RowString & " " & Rows(x)
                    End If
                    x += 1
                End If

            Next

            ListBox1.Items.Add(vbNewLine) 'spacing
            ListBox1.Items.Add(RowString) 'value
            ListBox1.Items.Add(vbNewLine) 'spacing

            RowString = ""

            LowerBound += 10 'for next row
            UpperBound += 10

        Next

    End Sub

    Private Sub CalculateColumns()
        Dim index, LowerBound, UpperBound, Counter, x As Integer
        Dim Columns(99) As Integer
        Dim ColumnsString As String = ""
        LowerBound = 0 'initialize variables
        UpperBound = 90
        x = 0

        For index = 0 To 99 'makes all values of array Rows() 0
            Columns(index) = 0
        Next

        For Counter = 0 To 9 'loops for each column

            For index = LowerBound To UpperBound Step 10
                If Check(index) = True And index = UpperBound Then
                    Columns(x) = Columns(x) + 1
                    ColumnsString = ColumnsString & " " & Columns(x) 'adds Columns(x) to Columnsstring
                    x += 1
                ElseIf Check(index) = True Then
                    Columns(x) = Columns(x) + 1
                ElseIf Check(index) = False Then
                    If Not Columns(x) = 0 Then
                        ColumnsString = ColumnsString & " " & Columns(x)
                    End If
                    x += 1
                End If

            Next

            ColumnsString &= " | "
            LowerBound += 1
            UpperBound += 1

        Next
        ListBox2.Items.Add(ColumnsString)
    End Sub
    Private Sub Panel1_SizeChanged(sender As Object, e As EventArgs) Handles Panel1.SizeChanged
        Dim pnl As Panel = DirectCast(sender, Panel)
        pnl.Invalidate() ' redraw the board whenever it gets resized
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
        Dim pnl As Panel = DirectCast(sender, Panel)

        Dim p As Decimal
        Dim x, y As Integer
        Dim margin As Integer = (1 / (GridSize + 1)) * pnl.Size.Height

        ' draw the pieces:
        For x = 0 To GridSize - 1
            Dim column As List(Of Boolean?) = Grid(x)
            For y = 0 To GridSize - 1
                If Grid(x)(y).HasValue Then
                    Dim clr As Color = If(Grid(x)(y), Color.Black, Color.White)
                    Dim pt As New Point((x + (1 / 2)) / (GridSize + 1) * pnl.Size.Width, (y + (1 / 2)) / (GridSize + 1) * pnl.Size.Height)
                    Dim rc As New Rectangle(pt, New Size(1, 1))
                    rc.Inflate((1 / (GridSize + 1)) * pnl.Size.Width - margin / 2, (1 / (GridSize + 1)) * pnl.Size.Height - margin / 2)
                    Using brsh As New SolidBrush(clr)
                        e.Graphics.FillRectangle(brsh, rc)
                    End Using
                End If
            Next
        Next
        ' draw the vertical lines:
        For col As Integer = 1 To GridSize
            p = col / (GridSize + 1)
            x = p * pnl.Size.Width
            e.Graphics.DrawLine(Pens.Black, x, margin, x, pnl.Size.Height - margin)
        Next

        ' draw the horizontal lines:
        margin = (1 / (GridSize + 1)) * pnl.Size.Width
        For row As Integer = 1 To GridSize
            p = row / (GridSize + 1)
            y = p * pnl.Size.Height
            e.Graphics.DrawLine(Pens.Black, margin, y, pnl.Size.Width - margin, y)
        Next
    End Sub

    Private Sub Panel1_Click(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles Panel1.MouseClick

        Dim pnl As Panel = DirectCast(sender, Panel)

        ' figure out where the user clicked: min = 0, max = (gridsize -1)
        Dim pt As Point = pnl.PointToClient(Cursor.Position)
        Dim colWidth As Integer = (1 / (GridSize + 1)) * pnl.Size.Width
        Dim rowHeight As Integer = (1 / (GridSize + 1)) * pnl.Size.Height
        Dim gridPosition As New Point(Math.Min(Math.Max((pt.X / colWidth - (1 / 2)), 1), GridSize - 1), Math.Min(Math.Max((pt.Y / rowHeight - (1 / 2)), 1), GridSize - 1))
        If e.Button = MouseButtons.Left Then
            ' now do something with gridPosition: (here we just toggle between black:true, white:false and blank:nothing)
            If Not Grid(gridPosition.X)(gridPosition.Y).HasValue Then
                Grid(gridPosition.X)(gridPosition.Y) = True
                Answer((gridPosition.X + ((gridPosition.Y - 1) * 10)) - 1) = True
            ElseIf Grid(gridPosition.X)(gridPosition.Y) = False Then
                Grid(gridPosition.X)(gridPosition.Y) = True
                Answer((gridPosition.X + ((gridPosition.Y - 1) * 10)) - 1) = True
            Else
                Grid(gridPosition.X)(gridPosition.Y) = Nothing
                Answer((gridPosition.X + ((gridPosition.Y - 1) * 10)) - 1) = False
            End If
        ElseIf e.Button = MouseButtons.Right Then
            If Not Grid(gridPosition.X)(gridPosition.Y).HasValue Then
                Grid(gridPosition.X)(gridPosition.Y) = False
            ElseIf Grid(gridPosition.X)(gridPosition.Y) = True Then
                Grid(gridPosition.X)(gridPosition.Y) = False
                Answer((gridPosition.X + ((gridPosition.Y - 1) * 10)) - 1) = False
            Else
                Grid(gridPosition.X)(gridPosition.Y) = Nothing
            End If
        End If

        pnl.Invalidate() ' force the board to redraw itself

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim CorrectCheck As Integer = 0
        Dim index As Integer
        Dim winScreen As New WinScreen

        For index = 0 To 99 'checks if the puzzle is solved
            If Answer(index) = Check(index) Then
                CorrectCheck += 1
            End If
        Next

        If CorrectCheck = 100 Then 'if puzzle is solved
            Timer1.Stop()
            Time = GetTime(Clock)
            winScreen.Show()

        Else 'if puzzle is wrong the user can try again and the time continues
            Timer1.Stop()
            MsgBox("Sorry, that's not quite right, try again.")
            Timer1.Start()
        End If
    End Sub

End Class