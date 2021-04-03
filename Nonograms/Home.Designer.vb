<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Home
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.NewGame = New System.Windows.Forms.Button()
        Me.Leaderboards = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 66.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(128, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(456, 108)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Nonograms"
        '
        'NewGame
        '
        Me.NewGame.Font = New System.Drawing.Font("Calibri", 54.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NewGame.Location = New System.Drawing.Point(119, 191)
        Me.NewGame.Name = "NewGame"
        Me.NewGame.Size = New System.Drawing.Size(485, 135)
        Me.NewGame.TabIndex = 1
        Me.NewGame.Text = "New Game"
        Me.NewGame.UseVisualStyleBackColor = True
        '
        'Leaderboards
        '
        Me.Leaderboards.Font = New System.Drawing.Font("Calibri", 54.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Leaderboards.Location = New System.Drawing.Point(119, 379)
        Me.Leaderboards.Name = "Leaderboards"
        Me.Leaderboards.Size = New System.Drawing.Size(485, 135)
        Me.Leaderboards.TabIndex = 2
        Me.Leaderboards.Text = "Leaderboard"
        Me.Leaderboards.UseVisualStyleBackColor = True
        '
        'Home
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(734, 711)
        Me.Controls.Add(Me.Leaderboards)
        Me.Controls.Add(Me.NewGame)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Home"
        Me.Text = "Home"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents NewGame As Button
    Friend WithEvents Leaderboards As Button
End Class
