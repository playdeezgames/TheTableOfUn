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
    Sub Shim(character As Character)
        If Not IsShimmed AndAlso character.Inventory.HasItemType(ItemType.Shim) Then
            character.Inventory.GetItemOfType(ItemType.Shim).Destroy()
            TableOfUnFeatureData.WriteShimmed(Id, True)
        End If
    End Sub
End Class
