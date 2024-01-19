Public Class frmBattleShip
    'GAME BOARD VARIABLES
    Public GameBoard(9, 9) As GameTile
    Public ComputerGameBoard(9, 9) As ComputerGametile
    Public intGameState As Integer 'represents current gamestate. 0=Intro, 1=ShipPlacement, 2=GamePlay
    Public intCompHits, intPlayerHits As Integer 'amounts of hits player/computer has landed. 17 to win
    Public blnWin As Boolean

    'VARIBALE FOR EASY SIZE CHANGE OF BOXES
    Private intTileSize As Integer = 30 ' 30

    'OTHER GLOBAL VARIABLES
    Public intShipSize As Integer
    Public blnShipOrientation As Boolean 'False = Right, True = Down
    Public blnPlayerTurn As Boolean
    Public sodSoundPlayer As New Media.SoundPlayer

    Private Sub frmBattleShip_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        'LOOP TO CREATE A NEW ROW, THEN FILL ROW
        For y = 0 To 9
            For x = 0 To 9

                'CREATES 10X10 PLAYER GAMEBOARD AS GAMETILE
                GameBoard(x, y) = New GameTile(x, y, intTileSize)
                AddHandler GameBoard(x, y).btnTile.Click, AddressOf GameBoard(x, y).Button_Click

                'CREATES 10X10 COMPUTER GAMEBOARD AS GAMETILE
                ComputerGameBoard(x, y) = New ComputerGametile(x, y, intTileSize)
                AddHandler ComputerGameBoard(x, y).btnCompTile.Click, AddressOf ComputerGameBoard(x, y).ComputerTile_Click
            Next x
        Next y

        'OPENING MESSAGE FOR PLAYERS
        MessageBox.Show("Welcome to BattleShip! Press the Start Game button to begin.", "Welcome")


    End Sub


    Private Sub radHorizontal_Click(sender As Object, e As System.EventArgs) Handles radHorizontal.Click
        'UPDATE BOOLEAN FOR SHIP ORIENTATION
        blnShipOrientation = False

    End Sub

    Private Sub radVertical_Click(sender As Object, e As System.EventArgs) Handles radVertical.Click
        'UPDATE BOOLEAN FOR SHIP ORIENTATION
        blnShipOrientation = True

    End Sub

    Private Sub lstShips_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lstShips.SelectedIndexChanged

        'CHANGE VARIABLE DEPENDING ON SELECTED SHIP
        If lstShips.SelectedItem = "Supply Ship(2)" Then
            intShipSize = 2
        ElseIf lstShips.SelectedItem = "Submarine(3)" Then
            intShipSize = 3
        ElseIf lstShips.SelectedItem = "Frigate(3)" Then
            intShipSize = 3
        ElseIf lstShips.SelectedItem = "Battleship(4)" Then
            intShipSize = 4
        ElseIf lstShips.SelectedItem = "Aircraft Carrier(5)" Then
            intShipSize = 5
        End If

    End Sub


    Private Sub btnBegin_Click(sender As System.Object, e As System.EventArgs) Handles btnBegin.Click
        'VARIABLES 
        Dim intX As Integer
        Dim intY As Integer

        'REMOVE BUTTON
        btnBegin.Visible = False

        'ENABLE GAME ELEMENTS
        For intX = 0 To 9
            For intY = 0 To 9
                'RE ENABLE GAME BOARDS
                GameBoard(intX, intY).btnTile.Enabled = 1
                ComputerGameBoard(intX, intY).btnCompTile.Enabled = 1
            Next intY
        Next intX

        Call HelpMessage()
        Call UpdateGame()


    End Sub

    Public Sub UpdateGame()
        Static blnFirstTurn

        'ENABLE AND DISABLE GAME ELEMENTS BASED ON GAME PHASE
        If intGameState = 0 Then 'UPDATE FORM AND GAMESTATE FOR FIRST PHASE
            radHorizontal.Visible = 1
            radHorizontal.PerformClick()
            radVertical.Visible = 1
            lstShips.Visible = 1
            lblOrientation.Visible = 1
            lblShip.Visible = 1
            picHelp.Visible = 1

            intGameState = 1 'INITIATE FIRST PHASE
            Call PlaceComputerShips()

        ElseIf intGameState = 1 Then
            'CHECK IF PHASE ONE IF OVER, AND UPDATE GAMESTATE ACCORDINGLY
            'CHECK IF THERE ARE ANY SHIPS REMAINING IN THE LIST BOX
            If Me.lstShips.Items.Count = 0 Then
                intGameState = 2
                Call UpdateGame() 'reset update for new gamestate
            End If

        ElseIf intGameState = 2 Then
            If blnFirstTurn = False Then
                'DISABLE FORM ELEMENTS FOR SHIP  PLACING, AND  ENABLE PHASE 2 ELEMENTS
                radHorizontal.Visible = 0
                radVertical.Visible = 0
                lstShips.Visible = 0
                lblOrientation.Visible = 0
                lblShip.Visible = 0
                ovlTurnStatus.Visible = 1
                lblTurnStatus.Visible = 1
                blnPlayerTurn = True

                'DISPLAY MESSAGE WELCOMING PLAYER TO NEXT STAGE OF PLAY
                MessageBox.Show("Welcome to the next stage Admiral. Our fleet is in position to attack. In this stage you and your opponent will take turns attacking. Wait for the status light to turn green, then pick a tile to fire upon.")

                'CHANGE BOOLEAN SO CODE WILL BE SKIPPED ON NEXT UPDATES
                blnFirstTurn = True
            End If

            'CHECK IF PLAYER HAS WON
            If blnWin = False Then

                If intPlayerHits = 17 Then
                    MessageBox.Show("Excellent work Admiral. We've won")
                    blnWin = True
                    tmrComputerTurnTimer.Enabled = 0
                ElseIf intCompHits = 17 Then
                    MessageBox.Show("They've sunk our ships! We've lost")
                    blnWin = True
                End If
            End If
        End If

            'UPDATE TILE COLOURS

            For x = 0 To 9
                For y = 0 To 9
                    'UPDATE COLOUR IF A SHIP IS PRESENT (PLAYER BOARD ONLY)
                    If Me.GameBoard(x, y).blnShip = True Then
                        Me.GameBoard(x, y).btnTile.BackColor = Color.Brown
                    End If

                'BUG PURPOSES
                ' If Me.ComputerGameBoard(x, y).blnShip = True Then
                'Me.ComputerGameBoard(x, y).btnCompTile.BackColor = Color.Brown
                '  End If

                'UPDATE COLOUR IF TILE HAS BEEN HIT (BOTH BOARDS)
                If Me.GameBoard(x, y).blnHit = True Then
                    Me.GameBoard(x, y).btnTile.BackColor = Color.Red
                End If
                If Me.ComputerGameBoard(x, y).blnHit = True Then
                    Me.ComputerGameBoard(x, y).btnCompTile.BackColor = Color.Red
                End If

                'UPDATE COLOUR IF TILE HAS BEEN SHOT AT AND MISSED
                If Me.GameBoard(x, y).blnMiss = True Then
                    Me.GameBoard(x, y).btnTile.BackColor = Color.White
                End If
                If Me.ComputerGameBoard(x, y).blnMiss = True Then
                    Me.ComputerGameBoard(x, y).btnCompTile.BackColor = Color.White
                End If

            Next y
            Next x

    End Sub

    Private Sub HelpMessage()
        'DISPLAY HELP BASED ON THE PLAYERS POINT IN THE GAME
        If intGameState = 0 Then
            MessageBox.Show("Welcome Admiral. This is Battleship. Your goal is to sink the opponents ships before they sink ours. If you ever need assistance/instructions press the help button in the bottom right of your screen.")

        ElseIf intGameState = 1 Then
            MessageBox.Show("During this portion of the game, you will place your ships. You will need to select a ship from the list, and an orientation in the radio buttons above." _
                            & "The orientation indicates which direction the ship will place from your click. Click right if you want the ship to fill out to the right, and down if you want a vertical ship down from your click" _
                            & "You will notice a number in brackets behind each ship. This indicates the ships length, or how many squares it will cover." _
                            & " To place your ship, select the tile on the Players Board you would like the ship to start at, and it will auto fill right, or down, depending on the orientation you selected." _
                            & vbCrLf & "The game will move on when you have selected and placed all ships.")

        ElseIf intGameState = 2 Then
            MessageBox.Show("Here you and the computer will take turns attacking. When the light in between the boards is green, you can attack. Select a tile on the computers board to attack it. " _
                            & "The tile will turn red if you hit a ship, and white if you miss. The computer will take a moment, and fire back. You will notice one of your tiles will turn white or red, indicating a hit or miss from the computer. " _
                            & "You can not fire on the same tile twice. To win the game, you will need to hit all of the computers ships. If they hit all of yours first, you lose")
        End If
    End Sub

    Private Sub PictureBox1_Click(sender As System.Object, e As System.EventArgs) Handles picHelp.Click
        'CALL HELP MESSAGE
        Call HelpMessage()
    End Sub

    Private Sub PlaceComputerShips()
        'VARIABLES
        Dim i, intShipSize, intRndX, intRndY, intShipCheckCord, intCounter As Integer
        Dim intCompShipOrientation As Integer '0 FOR RIGHT 1 FOR DOWN
        Dim blnUsedThree As Boolean
        Dim blnPlaceShip As Boolean = True
        intShipSize = 2 'First ship size

        'PLACE SHIPS, ONE LOOP FOR EACH SHIP
        Randomize()
        For intCounter = 0 To 4
            'DECIDE IF SHIP WILL BE DOWN OR RIGHT
            intCompShipOrientation = Int((1 - 0 + 1) * Rnd() + 0)

            'PLACE SHIP RIGHT
            If intCompShipOrientation = 0 Then

                'CHECK IF SHIP INTERSECTS
                Do
                    'RESET PLACE SHIP VARIABLE
                    blnPlaceShip = True

                    'PICK X AND Y VARIABLES UNTIL THEY WILL FIT IN THE GRID
                    Do
                        intRndX = Int((9 - 0 + 1) * Rnd() + 0)
                        intRndY = Int((9 - 0 + 1) * Rnd() + 0)
                    Loop Until intRndX + intShipSize - 1 <= 9

                    intShipCheckCord = intRndX

                    'CHECK IF SHIP INTERCEPTS OTHER SHIPS
                    For i = 0 To intShipSize - 1
                        'CHANGE BOOLEAN IF SHIP IN THE WAY
                        If Me.ComputerGameBoard(intShipCheckCord, intRndY).blnShip = True Then
                            blnPlaceShip = False
                        End If

                        intShipCheckCord += 1

                    Next i
                Loop While blnPlaceShip = False

                'PLACE
                For i = 0 To intShipSize - 1
                    Me.ComputerGameBoard(intRndX, intRndY).blnShip = True

                    'CODE FOR EASILY TELLING IF COMPUTER IS PLACING SHIPS CORRECTLY BY DISTINGUISHING EACH SHIP
                    'If intCounter = 0 Then
                    '    Me.ComputerGameBoard(intRndX, intRndY).btnCompTile.BackColor = Color.Red
                    'ElseIf intCounter = 1 Then
                    '    Me.ComputerGameBoard(intRndX, intRndY).btnCompTile.BackColor = Color.Blue
                    'ElseIf intCounter = 2 Then
                    '    Me.ComputerGameBoard(intRndX, intRndY).btnCompTile.BackColor = Color.Green
                    'ElseIf intCounter = 3 Then
                    '    Me.ComputerGameBoard(intRndX, intRndY).btnCompTile.BackColor = Color.Orange
                    'ElseIf intCounter = 4 Then
                    '    Me.ComputerGameBoard(intRndX, intRndY).btnCompTile.BackColor = Color.Purple
                    'End If

                    intRndX = intRndX + 1
                Next i


                'PLACE SHIP DOWN
            ElseIf intCompShipOrientation = 1 Then
                'CHECK IF SHIP INTERSECTS
                Do

                    'RESET PLACE SHIP VARIABLE
                    blnPlaceShip = True

                    'PICK X AND Y VARIABLES UNTIL THEY WILL FIT IN THE GRID
                    Do
                        intRndX = Int((9 - 0 + 1) * Rnd() + 0)
                        intRndY = Int((9 - 0 + 1) * Rnd() + 0)
                    Loop Until intRndY + intShipSize - 1 <= 9

                    intShipCheckCord = intRndY

                    'CHECK IF SHIP INTERCEPTS OTHER SHIPS


                    For i = 0 To intShipSize - 1
                        'CHANGE BOOLEAN IF SHIP IN THE WAY
                        If Me.ComputerGameBoard(intRndX, intShipCheckCord).blnShip = True Then
                            blnPlaceShip = False
                        End If

                        intShipCheckCord += 1
                    Next i

                Loop While blnPlaceShip = False


                'PLACE
                For i = 0 To intShipSize - 1
                    Me.ComputerGameBoard(intRndX, intRndY).blnShip = True

                    'CODE FOR EASILY TELLING IF COMPUTER IS PLACING SHIPS CORRECTLY BY DISTINGUISHING EACH SHIP
                    'If intCounter = 0 Then
                    '    Me.ComputerGameBoard(intRndX, intRndY).btnCompTile.BackColor = Color.Red
                    'ElseIf intCounter = 1 Then
                    '    Me.ComputerGameBoard(intRndX, intRndY).btnCompTile.BackColor = Color.Blue
                    'ElseIf intCounter = 2 Then
                    '    Me.ComputerGameBoard(intRndX, intRndY).btnCompTile.BackColor = Color.Green
                    'ElseIf intCounter = 3 Then
                    '    Me.ComputerGameBoard(intRndX, intRndY).btnCompTile.BackColor = Color.Orange
                    'ElseIf intCounter = 4 Then
                    '    Me.ComputerGameBoard(intRndX, intRndY).btnCompTile.BackColor = Color.Purple
                    'End If

                    intRndY = intRndY + 1

                Next i


            End If

            'RESET SHIP TO SIZE THREE ONCE, SO 2 SHIPS ARE PLACED
            If blnUsedThree = False Then
                If intShipSize = 3 Then
                    intShipSize = 2
                    blnUsedThree = True
                End If
            End If

            intShipSize = intShipSize + 1

        Next intCounter

        'UPDATE GAME
        Call UpdateGame()

    End Sub

    Private Sub tmrComputerTurnTimer_Tick(sender As System.Object, e As System.EventArgs) Handles tmrComputerTurnTimer.Tick
        'VARIABLE FOR 1 TICK
        Static intRndTickNumber As Integer = 1

        If intRndTickNumber = 0 Then
            'VARIABLES
            Dim intRndX, intRndY As Integer

            'RANDOMLY PICK X AND Y VALUES UNTIL A TILE THAT HAS NOT BEEN SHOT IS SELECTED, THEN CHANGE VARIABLES ACCORDINGLY

            Do
                intRndX = Int((9 - 0 + 1) * Rnd() + 0)
                intRndY = Int((9 - 0 + 1) * Rnd() + 0)

                'CHECK IF CORDS HAVE BEEN SHOT BEFORE
                If Me.GameBoard(intRndX, intRndY).blnHit = False Then
                    If Me.GameBoard(intRndX, intRndY).blnMiss = False Then

                        'SHOOT, CHANGE VARIABLES ACCORDINGLY, AND PLAY SOUND
                        If Me.GameBoard(intRndX, intRndY).blnShip = True Then
                            Me.GameBoard(intRndX, intRndY).blnHit = True
                            intCompHits = intCompHits + 1

                            sodSoundPlayer.Stream = My.Resources.Bomb_SoundBible_com_891110113
                            sodSoundPlayer.Play()
                        Else
                            Me.GameBoard(intRndX, intRndY).blnMiss = True
                            sodSoundPlayer.Stream = My.Resources.Video_Game_Splash_Ploor_699235037__1_
                            sodSoundPlayer.Play()
                        End If

                        'CHANGE TO PLAYERS TURN
                        blnPlayerTurn = True
                        Me.ovlTurnStatus.BackColor = Color.Lime
                        Me.lblTurnStatus.Text = "Attack!"

                    End If
                End If
            Loop Until blnPlayerTurn = True

            tmrComputerTurnTimer.Enabled = 0
            'RESET TICK TO 2, SO ITS RESET TO ONE AT TICK END
            intRndTickNumber = 2
        End If


        'UPDATE GAME AND TICK
        If intPlayerHits <> 17 Then
            If intCompHits <> 17 Then
                Call UpdateGame()
            End If
        End If

        'RESET TICK BACK TO 1 IF ITS 0, 0 IF ITS 1
        intRndTickNumber = intRndTickNumber - 1
    End Sub
End Class

Public Class ComputerGametile
    'VARIABLES
    Private x, y As Integer
    Public btnCompTile As Button

    Public blnShip, blnHit, blnMiss As Boolean 'REPRESENTS WHETHER A TILE HAS A SHIP, AND WHETHER IT HAS BEEN SHOT AT AND MISSED OR HIT

    Sub New(x As Integer, y As Integer, intTileSize As Integer)

        'CREATES LOCAL X VARIABLE EQUAL TO BROUGHT DOWN X VARIABLES FOR USE ELSEWHERE IN THE CLASS
        Me.x = x
        Me.y = y

        'CREATES A BUTTON THAT CAN HOLD PROPERTIES OF THE GAME TILE
        btnCompTile = New Button

        'DETERMINES EACH NEW TILES SIZE AND LOCATION
        btnCompTile.Size = New Size(intTileSize, intTileSize)
        btnCompTile.Location = New Point(x * intTileSize + 500, y * intTileSize + 60)
        btnCompTile.Enabled = 0
        btnCompTile.BackColor = Color.DeepSkyBlue

        'ADDS NEW TILE TO FORM
        frmBattleShip.Controls.Add(btnCompTile)

    End Sub

    Public Sub ComputerTile_Click(sender As System.Object, e As System.EventArgs)

        'ATTACK TILE DEPENDING ON GAME, TURN, AND TILE STATUS
        If frmBattleShip.intGameState = 2 Then
            If frmBattleShip.blnPlayerTurn = True Then

                'CHECK IF TILE HAS BEEN SHOT AT ALREADY
                'DISPLAY MESSAGE IF TILE HAS ALREADY BEEN HIT
                If frmBattleShip.ComputerGameBoard(x, y).blnHit = True Then
                    MessageBox.Show("This tile has been attacked already!")
                ElseIf frmBattleShip.ComputerGameBoard(x, y).blnMiss = True Then
                    MessageBox.Show("This tile has been attacked already!")

                    'FIRE ON TILE AND CHANGE VARIABLES ACCORDINGLY, AND PLAY SOUNDS
                Else
                    If frmBattleShip.ComputerGameBoard(x, y).blnShip = True Then
                        frmBattleShip.ComputerGameBoard(x, y).blnHit = True
                        frmBattleShip.intPlayerHits = frmBattleShip.intPlayerHits + 1

                        frmBattleShip.sodSoundPlayer.Stream = My.Resources.Bomb_SoundBible_com_891110113
                        frmBattleShip.sodSoundPlayer.Play()
                    Else
                        frmBattleShip.ComputerGameBoard(x, y).blnMiss = True

                        frmBattleShip.sodSoundPlayer.Stream = My.Resources.Video_Game_Splash_Ploor_699235037__1_
                        frmBattleShip.sodSoundPlayer.Play()
                    End If

                    frmBattleShip.blnPlayerTurn = False

                    frmBattleShip.ovlTurnStatus.BackColor = Color.Red
                    frmBattleShip.lblTurnStatus.Text = "Stand by..."

                    'ENABLE TIMER FOR COMP TURN
                    frmBattleShip.tmrComputerTurnTimer.Enabled = True
                End If
            End If
        End If

        'UPDATE GAME
        Call frmBattleShip.UpdateGame()

    End Sub
End Class




Public Class GameTile
    'VARIABLES
    Private x, y As Integer
    Public btnTile As Button

    Public blnShip, blnHit, blnMiss As Boolean 'REPRESENTS WHETHER A TILE HAS A SHIP, AND WHETHER IT HAS BEEN SHOT AT AND MISSED OR HIT

    Public Sub New(x As Integer, y As Integer, intTileSize As Integer)

        'CREATES LOCAL X VARIABLE EQUAL TO BROUGHT DOWN X VARIABLES FOR USE ELSEWHERE IN THE CLASS
        Me.x = x
        Me.y = y

        'DIM VARIABLE FOR TILE STATUS


        'CREATES A BUTTON THAT CAN HOLD PROPERTIES OF THE GAME TILE
        btnTile = New Button

        'DETERMINES EACH NEW TILES SIZE AND LOCATION
        btnTile.Size = New Size(intTileSize, intTileSize)
        btnTile.Location = New Point(x * intTileSize + 25, y * intTileSize + 60)
        btnTile.Enabled = 0
        btnTile.BackColor = Color.DeepSkyBlue

        'ADDS NEW TILE TO FORM
        frmBattleShip.Controls.Add(btnTile)

    End Sub

    Public Sub Button_Click(sender As System.Object, e As System.EventArgs)

        ' MessageBox.Show(x & "," & y & vbCrLf & blnShip)
        'DECLARE BUTTON TO BE ABLE TO CHANGE PROPERTIES
        Dim btnSelectedTile As Button = sender

        'PERFORM ACTIONS BASED ON GAME STATE

        If frmBattleShip.intGameState = 1 Then ' PLACE SHIPS FROM CURRENT TILE
            Call PlaceShip(x, y)
        End If

    End Sub

    Public Sub PlaceShip(ByVal x, ByVal y)

        'VARIBALES
        Dim i, intClickedTileLocation As Integer
        Dim blnPlaceShip As Boolean

        'RESET VARIABLE
        blnPlaceShip = True

        'CHECK IF SHIP CAN BE PLACED
        'ONLY CHECK IF THERE IS A SHIP SELECTED
        If frmBattleShip.lstShips.SelectedIndex <> -1 Then

            If frmBattleShip.blnShipOrientation = False Then
                If x - 1 + frmBattleShip.intShipSize > 9 Then
                    MessageBox.Show("Invalid Placement", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

                Else 'CHECK IF SHIP INTERCEPTS OTHER SHIPS THEN PLACE
                    'DECLARE VARIABLE FOR X AS ONE BELOW SO LOOP CAN CHECK X AND TILES  AFTER
                    intClickedTileLocation = x

                    For i = 0 To frmBattleShip.intShipSize - 1 'check if ship will intercept other ships
                        'CHANGE BOOLEAN IF SHIP IN THE WAY
                        If frmBattleShip.GameBoard(intClickedTileLocation, y).blnShip = True Then
                            blnPlaceShip = False
                        End If
                        intClickedTileLocation += 1

                    Next i

                    'PROCEED TO PLACE SHIP
                    If blnPlaceShip = True Then
                        'RESET CLICKED TILE
                        intClickedTileLocation = x

                        For i = 0 To frmBattleShip.intShipSize - 1
                            frmBattleShip.GameBoard(intClickedTileLocation, y).blnShip = True
                            intClickedTileLocation = intClickedTileLocation + 1
                        Next i

                        'REMOVE THE PLACED SHIP, ONLY IF THERE WAS A SHIP SELECTED WHEN A SQUARE WAS CLICKED
                        If frmBattleShip.lstShips.SelectedIndex <> -1 Then
                            If frmBattleShip.intShipSize <> 0 Then
                                frmBattleShip.lstShips.Items.RemoveAt(frmBattleShip.lstShips.SelectedIndex)
                            End If
                        End If

                    Else
                        'ERROR MESSAGE IF SHIP CANT BE PLACED
                        MessageBox.Show("Invalid Placement", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End If


                'SAME AS ABOVE, FOR DOWN PLACING SHIPS
            ElseIf frmBattleShip.blnShipOrientation = True Then
                If y - 1 + frmBattleShip.intShipSize > 9 Then
                    MessageBox.Show("Invalid Placement", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

                Else 'CHECK IF SHIP INTERCEPTS OTHER SHIPS THEN PLACE
                    'DECLARE VARIABLE FOR X AS ONE BELOW SO LOOP CAN CHECK X AND TILES  AFTER
                    intClickedTileLocation = y

                    For i = 0 To frmBattleShip.intShipSize - 1 'check if ship will intercept other ships
                        'CHANGE BOOLEAN IF THERES A SHIP IN THE WAY
                        If frmBattleShip.GameBoard(x, intClickedTileLocation).blnShip = True Then
                            blnPlaceShip = False
                        End If
                        intClickedTileLocation += 1

                    Next i

                    'PROCEED TO PLACE SHIP
                    If blnPlaceShip = True Then
                        'RESET CLICKED TILE
                        intClickedTileLocation = y

                        For i = 0 To frmBattleShip.intShipSize - 1
                            frmBattleShip.GameBoard(x, intClickedTileLocation).blnShip = True
                            intClickedTileLocation += 1
                        Next i

                        If frmBattleShip.intShipSize <> 0 Then
                            frmBattleShip.lstShips.Items.RemoveAt(frmBattleShip.lstShips.SelectedIndex)
                        End If

                    Else
                        'ERROR MESSAGE IF SHIP CANT BE PLACED
                        MessageBox.Show("Invalid Placement", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End If

            End If
        End If

        'UPDATE GAME
        Call frmBattleShip.UpdateGame()
    End Sub
End Class

'BATTLESHIP
'DECEMBER 8, 2015
'KEVIN SHANKS

'PURPOSE: RECREATE THE CLASSIC GAME BATTLESHIP