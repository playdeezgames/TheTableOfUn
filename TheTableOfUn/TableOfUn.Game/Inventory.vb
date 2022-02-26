Imports TableOfUn.Data

Public Class Inventory
    ReadOnly Property Id As Long
    Sub New(inventoryId As Long)
        Id = inventoryId
    End Sub
    ReadOnly Property Items As List(Of Item)
        Get
            Return New List(Of Item)
        End Get
    End Property
    ReadOnly Property IsEmpty As Boolean
        Get
            Return True
        End Get
    End Property
    ReadOnly Property TopItem As Item
        Get
            Return Nothing
        End Get
    End Property
    Sub Add(item As Item)
        InventoryItemData.Write(item.Id, Id)
    End Sub
End Class
