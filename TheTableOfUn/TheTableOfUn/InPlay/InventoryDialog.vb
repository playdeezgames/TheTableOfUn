Imports TableOfUn.Game
Imports Terminal.Gui

Module InventoryDialog
    Private Function HandleStack(itemStack As StackedItem) As Boolean
        Dim buttons As New List(Of NStack.ustring) From {"Keep it!", "Drop it!"}
        Dim item = itemStack.Items.First
        If item.CanEquip Then
            buttons.Add("Equip it!")
        End If
        If item.CanConsume Then
            buttons.Add("Consume it!")
        End If
        Dim choice = MessageBox.Query(item.ItemType.GetName(), "What do you want to do?", buttons.ToArray)
        Dim character As New PlayerCharacter()
        Select Case choice
            Case Is >= 2
                Select Case buttons(choice)
                    Case "Equip it!"
                        MessageBox.Query("Success!", $"You equip {item.ItemType.GetName}!", "Ok")
                        item.Equip(character)
                        Return True
                    Case "Consume it!"
                        MessageBox.Query("Success!", $"You consume {item.ItemType.GetName}!", "Ok")
                        item.Consume(character)
                        Return True
                    Case Else
                        Return False
                End Select
            Case 1
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
        Dim inventory = New PlayerCharacter().StackedInventory
        groundItems.SetSource(inventory.Stacks)
        AddHandler groundItems.OpenSelectedItem, Sub(args)
                                                     If HandleStack(CType(args.Value, StackedItem)) Then
                                                         If inventory.IsEmpty Then
                                                             Application.RequestStop()
                                                         Else
                                                             groundItems.SetSource(inventory.Stacks)
                                                         End If
                                                     End If
                                                 End Sub
        dlg.Add(groundItems)
        Application.Run(dlg)
    End Sub
End Module
