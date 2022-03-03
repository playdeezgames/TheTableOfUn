Imports TableOfUn.Data

Public Class Location
    ReadOnly Property Id As Long
    Sub New(locationId As Long)
        Id = locationId
    End Sub
    ReadOnly Property X As Integer
        Get
            Return LocationData.ReadX(Id).Value
        End Get
    End Property
    ReadOnly Property Y As Integer
        Get
            Return LocationData.ReadY(Id).Value
        End Get
    End Property
    ReadOnly Property Character As Character
        Get
            Dim characterId = CharacterData.ReadForLocation(Id)
            If characterId IsNot Nothing Then
                Return New Character(characterId.Value)
            End If
            Return Nothing
        End Get
    End Property
    ReadOnly Property LocationType As LocationType
        Get
            Return CType(LocationData.ReadLocationType(Id).Value, LocationType)
        End Get
    End Property
    Private Shared ReadOnly locationTypeGenerator As New Dictionary(Of LocationType, Integer) From
        {
            {LocationType.Floor, 25},
            {LocationType.Solid, 1}
        }
    Shared Function FromXY(x As Integer, y As Integer) As Location
        Dim locationId = LocationData.ReadForXY(x, y)
        If locationId Is Nothing Then
            Dim locationType As LocationType = CType(RNG.FromGenerator(locationTypeGenerator), LocationType)
            locationId = LocationData.Create(x, y, locationType)
            Dim characterType = locationType.GenerateCharacterType()
            If characterType IsNot Nothing Then
                Game.CreateCharacter(locationId.Value, characterType.Value)
            End If
            Dim itemType = locationType.GenerateItemType()
            If itemType IsNot Nothing Then
                Dim item = Game.CreateItem(itemType.Value)
                Dim temp As New Location(locationId.Value)
                temp.Inventory.Add(item)
            End If
        End If
        Return New Location(locationId.Value)
    End Function
    Function CanBeEnteredBy(character As Character) As Boolean
        Return Me.Character Is Nothing AndAlso Feature Is Nothing AndAlso LocationType.CanBeEnteredBy(character.CharacterType)
    End Function
    ReadOnly Property Feature As Feature
        Get
            Dim featureId = FeatureData.ReadForLocation(Id)
            If featureId IsNot Nothing Then
                Dim featureType = FeatureData.ReadFeatureType(featureId.Value)
                Select Case CType(featureType, FeatureType)
                    Case TableOfUn.Game.FeatureType.TableOfUn
                        Return New TableOfUnFeature(featureId.Value)
                    Case Else
                        Return New Feature(featureId.Value)
                End Select
            End If
            Return Nothing
        End Get
    End Property
    ReadOnly Property Inventory As Inventory
        Get
            Dim inventoryId = LocationInventoryData.ReadForLocation(Id)
            If Not inventoryId.HasValue Then
                inventoryId = InventoryData.Create()
                LocationInventoryData.Write(Id, inventoryId.Value)
            End If
            Return New Inventory(inventoryId.Value)
        End Get
    End Property
    Function GetNeighbor(direction As Direction) As Location
        Return FromXY(direction.NextX(X), direction.NextY(Y))
    End Function
End Class
