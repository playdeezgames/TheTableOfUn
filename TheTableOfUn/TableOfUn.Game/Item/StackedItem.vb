Public Class StackedItem
    ReadOnly Property ItemType As ItemType
    ReadOnly Property Items As List(Of Item)
    Sub New(itemType As ItemType, items As List(Of Item))
        Me.ItemType = itemType
        Me.Items = items
    End Sub
    Public Overrides Function ToString() As String
        Return $"{Items.Count}x {ItemType.GetName}"
    End Function
End Class
