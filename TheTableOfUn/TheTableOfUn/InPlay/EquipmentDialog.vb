Imports TableOfUn.Game
Imports Terminal.Gui
Class EquipmentDialogItem
    ReadOnly Property EquipSlot As EquipSlot
    ReadOnly Property Item As Item
    Sub New(equipSlot As EquipSlot, item As Item)
        Me.EquipSlot = equipSlot
        Me.Item = item
    End Sub
    Public Overrides Function ToString() As String
        Return $"{Me.EquipSlot.GetName()}: {Me.Item}"
    End Function
End Class
Module EquipmentDialog
    Private Sub HandleSlot(slot As EquipSlot)
        'TODO: the stuff
    End Sub
    Private Function GetDialogItems(character As Character) As List(Of EquipmentDialogItem)
        Return character.Equipment.Select(Function(entry)
                                              Return New EquipmentDialogItem(entry.Key, entry.Value)
                                          End Function).ToList()
    End Function
    Sub Run()
        Dim cancelButton As New Button("Never mind")
        AddHandler cancelButton.Clicked, AddressOf Application.RequestStop
        Dim dlg As New Dialog("Equipment:", cancelButton)
        Dim equipmentSlots As New ListView With {
            .X = Pos.Center,
            .Y = Pos.Center,
            .Width = [Dim].Fill,
            .Height = [Dim].Fill - 2
        }
        Dim character = New PlayerCharacter()
        equipmentSlots.SetSource(GetDialogItems(character))
        AddHandler equipmentSlots.OpenSelectedItem, Sub(args)
                                                        HandleSlot(CType(args.Value, EquipmentDialogItem).EquipSlot)
                                                        If Not character.HasEquipment Then
                                                            Application.RequestStop()
                                                        Else
                                                            equipmentSlots.SetSource(GetDialogItems(character))
                                                        End If
                                                    End Sub
        dlg.Add(equipmentSlots)
        Application.Run(dlg)

    End Sub
End Module
