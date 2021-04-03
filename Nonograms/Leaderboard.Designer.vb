<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Leaderboard
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Home = New System.Windows.Forms.Button()
        Me.Clear = New System.Windows.Forms.Button()
        Me.Display = New System.Windows.Forms.DataGridView()
        Me.Search = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Position = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Player = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Time = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.Display, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Home
        '
        Me.Home.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Home.Location = New System.Drawing.Point(12, 664)
        Me.Home.Name = "Home"
        Me.Home.Size = New System.Drawing.Size(75, 35)
        Me.Home.TabIndex = 0
        Me.Home.Text = "Home"
        Me.Home.UseVisualStyleBackColor = True
        '
        'Clear
        '
        Me.Clear.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Clear.Location = New System.Drawing.Point(647, 664)
        Me.Clear.Name = "Clear"
        Me.Clear.Size = New System.Drawing.Size(75, 35)
        Me.Clear.TabIndex = 1
        Me.Clear.Text = "Clear"
        Me.Clear.UseVisualStyleBackColor = True
        '
        'Display
        '
        Me.Display.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Display.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Position, Me.Player, Me.Time})
        Me.Display.Location = New System.Drawing.Point(129, 100)
        Me.Display.Name = "Display"
        Me.Display.Size = New System.Drawing.Size(493, 525)
        Me.Display.TabIndex = 2
        '
        'Search
        '
        Me.Search.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Search.Location = New System.Drawing.Point(338, 664)
        Me.Search.Name = "Search"
        Me.Search.Size = New System.Drawing.Size(75, 35)
        Me.Search.TabIndex = 3
        Me.Search.Text = "Search"
        Me.Search.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 48.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(176, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(398, 73)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Leaderboard"
        '
        'Position
        '
        Me.Position.HeaderText = "RANK"
        Me.Position.Name = "Position"
        Me.Position.Width = 150
        '
        'Player
        '
        Me.Player.HeaderText = "NAME"
        Me.Player.Name = "Player"
        Me.Player.Width = 150
        '
        'Time
        '
        Me.Time.HeaderText = "SCORE"
        Me.Time.Name = "Time"
        Me.Time.Width = 150
        '
        'Leaderboard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(734, 711)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Search)
        Me.Controls.Add(Me.Display)
        Me.Controls.Add(Me.Clear)
        Me.Controls.Add(Me.Home)
        Me.Name = "Leaderboard"
        Me.Text = "Leaderboard"
        CType(Me.Display, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Home As Button
    Friend WithEvents Clear As Button
    Friend WithEvents Display As DataGridView
    Friend WithEvents Search As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Position As DataGridViewTextBoxColumn
    Friend WithEvents Player As DataGridViewTextBoxColumn
    Friend WithEvents Time As DataGridViewTextBoxColumn
End Class
