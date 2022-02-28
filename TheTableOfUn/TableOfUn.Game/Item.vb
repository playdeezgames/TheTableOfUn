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
End Class
