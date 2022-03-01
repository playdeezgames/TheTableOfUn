Imports TableOfUn.Data

Public Class TableOfUnFeature
    Inherits Feature
    Sub New(featureId As Long)
        MyBase.New(featureId)
    End Sub
    ReadOnly Property IsShimmed As Boolean
        Get
            Return TableOfUnFeatureData.ReadIsShimmed(Id).Value
        End Get
    End Property
    ReadOnly Property HasBook As Boolean
        Get
            Return TableOfUnFeatureData.ReadHasBook(Id).Value
        End Get
    End Property
    Sub Shim(character As Character)
        If Not IsShimmed AndAlso character.Inventory.HasItemType(ItemType.Shim) Then
            character.Inventory.GetItemOfType(ItemType.Shim).Destroy()
            TableOfUnFeatureData.WriteShimmed(Id, True)
        End If
    End Sub
    Sub PlaceBook(character As Character)
        If IsShimmed AndAlso Not HasBook AndAlso character.Inventory.HasItemType(ItemType.Spellbook) Then
            character.Inventory.GetItemOfType(ItemType.Spellbook).Destroy()
            TableOfUnFeatureData.WriteHasBook(Id, True)
        End If
    End Sub
    Sub AddCandle(character As Character)
        If IsShimmed AndAlso NeedsCandles AndAlso character.Inventory.HasItemType(ItemType.Candle) Then
            character.Inventory.GetItemOfType(ItemType.Candle).Destroy()
            TableOfUnFeatureData.WriteCandleCount(Id, TableOfUnFeatureData.ReadCandleCount(Id).Value + 1)
        End If
    End Sub
    ReadOnly Property NeedsCandles As Boolean
        Get
            Return CandleCount < 4
        End Get
    End Property
    ReadOnly Property CandleCount As Integer
        Get
            Return TableOfUnFeatureData.ReadCandleCount(Id).Value
        End Get
    End Property
End Class
