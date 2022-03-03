Imports TableOfUn.Data

Public Class Item
    ReadOnly Property Id As Long
    Sub New(itemId As Long)
        Id = itemId
    End Sub
    ReadOnly Property ItemType As ItemType
        Get
            Return CType(ItemData.ReadItemType(Id).Value, ItemType)
        End Get
    End Property
    Shared Function FromId(itemId As Long) As Item
        Return New Item(itemId)
    End Function
    Public Overrides Function ToString() As String
        Dim itemType = ItemData.ReadItemType(Id)
        If itemType.HasValue Then
            Return CType(itemType.Value, ItemType).GetName()
        Else
            Return "????"
        End If
    End Function
    Public Sub Destroy()
        ItemData.Clear(Id)
    End Sub
    ReadOnly Property CanEquip As Boolean
        Get
            Return ItemType.CanEquip
        End Get
    End Property
    Public Sub Unequip(character As Character)
        CharacterEquipmentData.ClearForItem(Id)
        character.Inventory.Add(Me)
    End Sub
    Public Sub Equip(character As Character)
        If CanEquip Then
            InventoryItemData.ClearForItem(Id)
            Dim equipSlot = ItemType.GetEquipSlot.Value
            Dim equippedItem = character.GetEquipment(equipSlot)
            If equippedItem IsNot Nothing Then
                equippedItem.Unequip(character)
            End If
            CharacterEquipmentData.Write(character.Id, equipSlot, Id)
        End If
    End Sub
End Class
