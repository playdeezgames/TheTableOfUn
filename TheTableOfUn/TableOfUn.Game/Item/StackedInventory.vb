Imports TableOfUn.Data
Public Class StackedInventory
    ReadOnly Property Id As Long
    Sub New(inventoryId As Long)
        Id = inventoryId
    End Sub
    ReadOnly Property IsEmpty As Boolean
        Get
            Return Not Stacks.Any()
        End Get
    End Property
    ReadOnly Property Stacks As List(Of StackedItem)
        Get
            Dim items = InventoryItemData.Read(Id).Select(AddressOf Item.FromId)

            Dim groupings = items.GroupBy(Of ItemType)(Function(item)
                                                           Return item.ItemType
                                                       End Function)

            Return groupings.Select(Function(group)
                                        Dim result = group.Select(Function(item, dunno)
                                                                      Return item
                                                                  End Function).ToList
                                        Return New StackedItem(group.Key, result)
                                    End Function).ToList()
        End Get
    End Property
End Class
