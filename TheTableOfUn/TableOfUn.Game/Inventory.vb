﻿Imports TableOfUn.Data

Public Class Inventory
    ReadOnly Property Id As Long
    Sub New(inventoryId As Long)
        Id = inventoryId
    End Sub
    ReadOnly Property Items As List(Of Item)
        Get
            Return InventoryItemData.
                Read(Id).
                Select(AddressOf Item.FromId).
                ToList()
        End Get
    End Property
    ReadOnly Property IsEmpty As Boolean
        Get
            Return TopItem Is Nothing
        End Get
    End Property
    ReadOnly Property TopItem As Item
        Get
            Dim itemId = InventoryItemData.ReadTop(Id)
            If itemId.HasValue Then
                Return New Item(itemId.Value)
            End If
            Return Nothing
        End Get
    End Property
    Sub Add(item As Item)
        InventoryItemData.Write(item.Id, Id)
    End Sub
    Function CanCraftRecipe(recipe As Recipe) As Boolean
        Dim inputs As New Dictionary(Of ItemType, Integer)(recipe.Inputs)
        For Each item In Items
            If inputs.ContainsKey(item.ItemType) Then
                inputs(item.ItemType) -= 1
            End If
        Next
        Return Not inputs.Any(Function(entry)
                                  Return entry.Value > 0
                              End Function)
    End Function
    ReadOnly Property CanCraft As Boolean
        Get
            Return RecipeList.Recipes.Any(Function(recipe)
                                              Return CanCraftRecipe(recipe)
                                          End Function)
        End Get
    End Property
End Class
