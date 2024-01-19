<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmBattleShip
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
        Me.components = New System.ComponentModel.Container()
        Me.btnBegin = New System.Windows.Forms.Button()
        Me.lblPlayersBoard = New System.Windows.Forms.Label()
        Me.lblComputerBoard = New System.Windows.Forms.Label()
        Me.lblPlayerLetters = New System.Windows.Forms.Label()
        Me.picHelp = New System.Windows.Forms.PictureBox()
        Me.lblOrientation = New System.Windows.Forms.Label()
        Me.radHorizontal = New System.Windows.Forms.RadioButton()
        Me.radVertical = New System.Windows.Forms.RadioButton()
        Me.lblShip = New System.Windows.Forms.Label()
        Me.lstShips = New System.Windows.Forms.ListBox()
        Me.lblTurnStatus = New System.Windows.Forms.Label()
        Me.tmrComputerTurnTimer = New System.Windows.Forms.Timer(Me.components)
        Me.ovlTurnStatus = New System.Windows.Forms.PictureBox()
        CType(Me.picHelp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ovlTurnStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnBegin
        '
        Me.btnBegin.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBegin.Location = New System.Drawing.Point(12, 408)
        Me.btnBegin.Name = "btnBegin"
        Me.btnBegin.Size = New System.Drawing.Size(802, 80)
        Me.btnBegin.TabIndex = 0
        Me.btnBegin.Text = "Start!"
        Me.btnBegin.UseVisualStyleBackColor = True
        '
        'lblPlayersBoard
        '
        Me.lblPlayersBoard.AutoSize = True
        Me.lblPlayersBoard.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPlayersBoard.Location = New System.Drawing.Point(28, 9)
        Me.lblPlayersBoard.Name = "lblPlayersBoard"
        Me.lblPlayersBoard.Size = New System.Drawing.Size(107, 20)
        Me.lblPlayersBoard.TabIndex = 1
        Me.lblPlayersBoard.Text = "Players Board"
        '
        'lblComputerBoard
        '
        Me.lblComputerBoard.AutoSize = True
        Me.lblComputerBoard.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblComputerBoard.Location = New System.Drawing.Point(498, 9)
        Me.lblComputerBoard.Name = "lblComputerBoard"
        Me.lblComputerBoard.Size = New System.Drawing.Size(134, 20)
        Me.lblComputerBoard.TabIndex = 2
        Me.lblComputerBoard.Text = "Computers Board"
        '
        'lblPlayerLetters
        '
        Me.lblPlayerLetters.AutoSize = True
        Me.lblPlayerLetters.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPlayerLetters.Location = New System.Drawing.Point(28, 29)
        Me.lblPlayerLetters.Name = "lblPlayerLetters"
        Me.lblPlayerLetters.Size = New System.Drawing.Size(769, 24)
        Me.lblPlayerLetters.TabIndex = 3
        Me.lblPlayerLetters.Text = "A    B   C    D   E    F   G   H    I     J                                      " &
    " A    B   C   D    E    F   G   H    I     J"
        '
        'picHelp
        '
        Me.picHelp.Image = Global.WindowsApplication1.My.Resources.Resources.help_147419_640
        Me.picHelp.Location = New System.Drawing.Point(743, 418)
        Me.picHelp.Name = "picHelp"
        Me.picHelp.Size = New System.Drawing.Size(71, 70)
        Me.picHelp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picHelp.TabIndex = 4
        Me.picHelp.TabStop = False
        Me.picHelp.Visible = False
        '
        'lblOrientation
        '
        Me.lblOrientation.AutoSize = True
        Me.lblOrientation.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOrientation.Location = New System.Drawing.Point(340, 85)
        Me.lblOrientation.Name = "lblOrientation"
        Me.lblOrientation.Size = New System.Drawing.Size(87, 20)
        Me.lblOrientation.TabIndex = 5
        Me.lblOrientation.Text = "Orientation"
        Me.lblOrientation.Visible = False
        '
        'radHorizontal
        '
        Me.radHorizontal.AutoSize = True
        Me.radHorizontal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radHorizontal.Location = New System.Drawing.Point(344, 108)
        Me.radHorizontal.Name = "radHorizontal"
        Me.radHorizontal.Size = New System.Drawing.Size(65, 24)
        Me.radHorizontal.TabIndex = 6
        Me.radHorizontal.TabStop = True
        Me.radHorizontal.Text = "Right"
        Me.radHorizontal.UseVisualStyleBackColor = True
        Me.radHorizontal.Visible = False
        '
        'radVertical
        '
        Me.radVertical.AutoSize = True
        Me.radVertical.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radVertical.Location = New System.Drawing.Point(344, 138)
        Me.radVertical.Name = "radVertical"
        Me.radVertical.Size = New System.Drawing.Size(68, 24)
        Me.radVertical.TabIndex = 7
        Me.radVertical.TabStop = True
        Me.radVertical.Text = "Down"
        Me.radVertical.UseVisualStyleBackColor = True
        Me.radVertical.Visible = False
        '
        'lblShip
        '
        Me.lblShip.AutoSize = True
        Me.lblShip.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblShip.Location = New System.Drawing.Point(340, 199)
        Me.lblShip.Name = "lblShip"
        Me.lblShip.Size = New System.Drawing.Size(108, 20)
        Me.lblShip.TabIndex = 8
        Me.lblShip.Text = "Selected Ship"
        Me.lblShip.Visible = False
        '
        'lstShips
        '
        Me.lstShips.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstShips.FormattingEnabled = True
        Me.lstShips.ItemHeight = 20
        Me.lstShips.Items.AddRange(New Object() {"Supply Ship(2)", "Submarine(3)", "Frigate(3)", "Battleship(4)", "Aircraft Carrier(5)"})
        Me.lstShips.Location = New System.Drawing.Point(344, 222)
        Me.lstShips.Name = "lstShips"
        Me.lstShips.Size = New System.Drawing.Size(134, 104)
        Me.lstShips.TabIndex = 9
        Me.lstShips.Visible = False
        '
        'lblTurnStatus
        '
        Me.lblTurnStatus.AutoSize = True
        Me.lblTurnStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTurnStatus.Location = New System.Drawing.Point(382, 199)
        Me.lblTurnStatus.Name = "lblTurnStatus"
        Me.lblTurnStatus.Size = New System.Drawing.Size(59, 20)
        Me.lblTurnStatus.TabIndex = 10
        Me.lblTurnStatus.Text = "Attack!"
        Me.lblTurnStatus.Visible = False
        '
        'tmrComputerTurnTimer
        '
        Me.tmrComputerTurnTimer.Interval = 500
        '
        'ovlTurnStatus
        '
        Me.ovlTurnStatus.BackColor = System.Drawing.Color.Lime
        Me.ovlTurnStatus.Location = New System.Drawing.Point(386, 146)
        Me.ovlTurnStatus.Name = "ovlTurnStatus"
        Me.ovlTurnStatus.Size = New System.Drawing.Size(50, 50)
        Me.ovlTurnStatus.TabIndex = 11
        Me.ovlTurnStatus.TabStop = False
        Me.ovlTurnStatus.Visible = False
        '
        'frmBattleShip
        '
        Me.ClientSize = New System.Drawing.Size(826, 500)
        Me.Controls.Add(Me.ovlTurnStatus)
        Me.Controls.Add(Me.lblTurnStatus)
        Me.Controls.Add(Me.lstShips)
        Me.Controls.Add(Me.lblShip)
        Me.Controls.Add(Me.radVertical)
        Me.Controls.Add(Me.radHorizontal)
        Me.Controls.Add(Me.lblOrientation)
        Me.Controls.Add(Me.picHelp)
        Me.Controls.Add(Me.lblPlayerLetters)
        Me.Controls.Add(Me.lblComputerBoard)
        Me.Controls.Add(Me.lblPlayersBoard)
        Me.Controls.Add(Me.btnBegin)
        Me.Name = "frmBattleShip"
        CType(Me.picHelp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ovlTurnStatus, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnBegin As Button
    Friend WithEvents lblPlayersBoard As Label
    Friend WithEvents lblComputerBoard As Label
    Friend WithEvents lblPlayerLetters As Label
    Friend WithEvents picHelp As PictureBox
    Friend WithEvents lblOrientation As Label
    Friend WithEvents radHorizontal As RadioButton
    Friend WithEvents radVertical As RadioButton
    Friend WithEvents lblShip As Label
    Friend WithEvents lstShips As ListBox
    Friend WithEvents lblTurnStatus As Label
    Friend WithEvents tmrComputerTurnTimer As Timer
    Friend WithEvents ovlTurnStatus As PictureBox
End Class
