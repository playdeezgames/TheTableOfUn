Imports TableOfUn.Data

Public Class Character
    ReadOnly Property Id As Long
    Sub New(characterId As Long)
        Id = characterId
    End Sub
    ReadOnly Property Location As Location
        Get
            Return New Location(CharacterData.ReadLocation(Id).Value)
        End Get
    End Property
    ReadOnly Property CharacterType As CharacterType
        Get
            Return CType(CharacterData.ReadCharacterType(Id).Value, CharacterType)
        End Get
    End Property
    Sub Move(direction As Direction)
        Dim start = Location
        Dim destination = TableOfUn.Game.Location.FromXY(direction.NextX(start.X), direction.NextY(start.Y))
        If destination.CanBeEnteredBy(Me) Then
            CharacterData.WriteLocation(Id, destination.Id)
        Else
            Game.Play(Sfx.Impassable)
        End If
    End Sub
    ReadOnly Property Inventory As Inventory
        Get
            Dim inventoryId = CharacterInventoryData.ReadForCharacter(Id)
            If Not inventoryId.HasValue Then
                inventoryId = InventoryData.Create()
                CharacterInventoryData.Write(Id, inventoryId.Value)
            End If
            Return New Inventory(inventoryId.Value)
        End Get
    End Property
    ReadOnly Property CanInteract As Boolean
        Get
            Return Interactables().Any()
        End Get
    End Property
    ReadOnly Property Interactables As List(Of Feature)
        Get
            Dim result As New List(Of Feature) From {
                Location.GetNeighbor(Direction.East).Feature,
                Location.GetNeighbor(Direction.North).Feature,
                Location.GetNeighbor(Direction.South).Feature,
                Location.GetNeighbor(Direction.West).Feature
            }
            Return result.Where(Function(x)
                                    Return x IsNot Nothing
                                End Function).ToList()
        End Get
    End Property
End Class
