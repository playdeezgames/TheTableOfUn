Imports TableOfUn.Game
Imports Terminal.Gui

Module MapScreen
    Private ReadOnly groundButton As New Button(1, 16, " Ground  ")
    Private ReadOnly inventoryButton As New Button(15, 16, "Inventory")
    Private ReadOnly craftButton As New Button(29, 16, "  Craft  ")
    Private ReadOnly interactButton As New Button(1, 17, "I_nteract ")
    Private ReadOnly attackButton As New Button(15, 17, " Attack  ")
    Private ReadOnly equipmentButton As New Button(29, 17, "Equipment")
    Private ReadOnly healthLabel As New Label(33, 1, "Health: X/X")
    Private Sub UpdateActions(character As Character)
        groundButton.Enabled = Not character.Location.Inventory.IsEmpty
        inventoryButton.Enabled = Not character.Inventory.IsEmpty
        craftButton.Enabled = character.Inventory.CanCraft
        interactButton.Enabled = character.CanInteract
        attackButton.Enabled = character.CanAttack
        equipmentButton.Enabled = character.HasEquipment
    End Sub
    Private Sub UpdateStatistics(character As Character)
        healthLabel.Text = $"Health: {character.CurrentHealth}/{character.MaximumHealth}  "
    End Sub
    Private Sub UpdateScreen()
        Dim character As New PlayerCharacter()
        UpdateActions(character)
        UpdateStatistics(character)
    End Sub
    Private Sub Move(direction As Direction)
        Dim character As New PlayerCharacter()
        character.Move(direction)
        Game.MoveNonplayers()
        UpdateScreen()
    End Sub
    Private Function HandleKey(view As View) As Action(Of View.KeyEventEventArgs)
        Return Sub(args)
                   view.SetNeedsDisplay()
                   Select Case args.KeyEvent.Key
                       Case Key.Esc
                           If GameMenu.Run() Then
                               Application.RequestStop()
                           End If
                           args.Handled = True
                       Case Key.CursorUp
                           Move(Direction.North)
                           args.Handled = True
                       Case Key.CursorDown
                           Move(Direction.South)
                           args.Handled = True
                       Case Key.CursorRight
                           Move(Direction.East)
                           args.Handled = True
                       Case Key.CursorLeft
                           Move(Direction.West)
                           args.Handled = True
                   End Select
               End Sub
    End Function
    Private Sub ShowInventory()
        InventoryDialog.Run()
        UpdateScreen()
    End Sub
    Private Sub ShowGround()
        GroundInventoryDialog.Run()
        UpdateScreen()
    End Sub
    Private Sub Craft()
        CraftDialog.Run()
        UpdateScreen()
    End Sub
    Private Sub Interact()
        If InteractDialog.Run() Then
            MessageBox.Query("YAY!", "You winninated the game!", "Ok")
            Application.RequestStop()
        End If
        UpdateScreen()
    End Sub
    Private Sub Attack()
        If AttackDialog.Run() Then
            MessageBox.Query("BOO!", "You losinated the game!", "Ok")
            Application.RequestStop()
        End If
        UpdateScreen()
    End Sub
    Private Sub Equipment()
        EquipmentDialog.Run()
        UpdateScreen()
    End Sub
    Sub Run()
        Dim window As New Window("Map")
        Dim mapView As New MapView(1, 1)
        AddHandler window.KeyPress, HandleKey(mapView)
        AddHandler groundButton.Clicked, AddressOf ShowGround
        AddHandler inventoryButton.Clicked, AddressOf ShowInventory
        AddHandler craftButton.Clicked, AddressOf Craft
        AddHandler interactButton.Clicked, AddressOf Interact
        AddHandler attackButton.Clicked, AddressOf Attack
        AddHandler equipmentButton.Clicked, AddressOf Equipment
        UpdateScreen()
        window.Add(
            groundButton,
            inventoryButton,
            craftButton,
            interactButton,
            attackButton,
            equipmentButton,
            healthLabel,
            mapView)
        Application.Run(window)
    End Sub
End Module
