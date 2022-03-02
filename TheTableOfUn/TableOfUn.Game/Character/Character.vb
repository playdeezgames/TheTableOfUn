Imports TableOfUn.Data

Public Class Character
    ReadOnly Property Id As Long
    Sub New(characterId As Long)
        Id = characterId
    End Sub
    Property Location As Location
        Get
            Return New Location(CharacterData.ReadLocation(Id).Value)
        End Get
        Set(value As Location)
            CharacterData.WriteLocation(Id, value.Id)
        End Set
    End Property
    ReadOnly Property CharacterType As CharacterType
        Get
            Dim result = CharacterData.ReadCharacterType(Id)
            If result.HasValue Then
                Return CType(result.Value, CharacterType)
            End If
            Return CharacterType.None
        End Get
    End Property
    Sub Move(direction As Direction)
        Dim start = Location
        Dim destination = TableOfUn.Game.Location.FromXY(direction.NextX(start.X), direction.NextY(start.Y))
        If destination.CanBeEnteredBy(Me) Then
            Location = destination
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
    ReadOnly Property Attackables As List(Of Character)
        Get
            Dim result As New List(Of Character) From {
                Location.GetNeighbor(Direction.East).Character,
                Location.GetNeighbor(Direction.North).Character,
                Location.GetNeighbor(Direction.South).Character,
                Location.GetNeighbor(Direction.West).Character
            }
            Return result.Where(Function(x)
                                    Return x IsNot Nothing
                                End Function).ToList()
        End Get
    End Property
    ReadOnly Property CanAttack As Boolean
        Get
            Return Attackables.Any()
        End Get
    End Property
    ReadOnly Property DidWinninate As Boolean
        Get
            Return CharacterData.ReadDidWinninate(Id).Value
        End Get
    End Property
    Sub Winninate()
        CharacterData.WriteDidWinninate(Id, True)
    End Sub
    Public Overrides Function ToString() As String
        Return CharacterType.GetName()
    End Function
End Class
