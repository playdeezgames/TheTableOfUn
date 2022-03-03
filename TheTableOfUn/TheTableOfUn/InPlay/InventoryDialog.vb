Imports TableOfUn.Game
Imports Terminal.Gui

Module InventoryDialog
    Private Function HandleItem(item As Item) As Boolean
        Dim buttons As New List(Of NStack.ustring) From {"Keep it!", "Drop it!"}
        If item.CanEquip Then
            buttons.Add("Equip it!")
        End If
        Select Case MessageBox.Query(item.ItemType.GetName(), "What do you want to do?", buttons.ToArray)
            Case 1
                Dim character As New PlayerCharacter()
                character.Location.Inventory.Add(item)
                Return True
            Case Else
                Return False
        End Select
    End Function
    Sub Run()
        Dim cancelButton As New Button("Never mind")
        AddHandler cancelButton.Clicked, AddressOf Application.RequestStop
        Dim dlg As New Dialog("Items in yer Inventory:", cancelButton)
        Dim groundItems As New ListView()
        groundItems.X = Pos.Center
        groundItems.Y = Pos.Center
        groundItems.Width = [Dim].Fill
        groundItems.Height = [Dim].Fill - 2
        Dim inventory = New PlayerCharacter().Inventory
        groundItems.SetSource(inventory.Items)
        AddHandler groundItems.OpenSelectedItem, Sub(args)
                                                     If HandleItem(CType(args.Value, Item)) Then
                                                         If inventory.IsEmpty Then
                                                             Application.RequestStop()
                                                         Else
                                                             groundItems.SetSource(inventory.Items)
                                                         End If
                                                     End If
                                                 End Sub
        dlg.Add(groundItems)
        Application.Run(dlg)
    End Sub
End Module
