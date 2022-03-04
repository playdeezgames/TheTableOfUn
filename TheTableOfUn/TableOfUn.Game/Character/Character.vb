Imports System.Text
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
    ReadOnly Property Equipment As Dictionary(Of EquipSlot, Item)
        Get
            Dim result As New Dictionary(Of EquipSlot, Item)
            Dim equippedItems = CharacterEquipmentData.ReadForCharacter(Id)
            For Each equippedItem In equippedItems
                result.Add(CType(equippedItem.Key, EquipSlot), New Item(equippedItem.Value))
            Next
            Return result
        End Get
    End Property
    Function GetEquipment(equipSlot As EquipSlot) As Item
        Dim itemId = CharacterEquipmentData.ReadForEquipSlot(Id, equipSlot)
        If itemId IsNot Nothing Then
            Return New Item(itemId.Value)
        End If
        Return Nothing
    End Function
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
    Function RollAttack() As Integer
        'TODO: if weapon equipped, use those stats instead
        Return RNG.FromGenerator(CharacterType.GetAttackGenerator())
    End Function
    Function RollDefend() As Integer
        'TODO: if armor equipped, use those stats instead
        Return RNG.FromGenerator(CharacterType.GetDefendGenerator())
    End Function
    Private Shared Function DetermineDamage(attackRoll As Integer, defendRoll As Integer) As Integer
        If attackRoll > defendRoll Then
            Return attackRoll - defendRoll
        End If
        Return 0
    End Function
    Sub DoDamage(damage As Integer)
        Wounds += damage
    End Sub
    Property Wounds As Integer
        Get
            Return CharacterData.ReadWounds(Id).Value
        End Get
        Set(value As Integer)
            CharacterData.WriteWounds(Id, value)
        End Set
    End Property
    ReadOnly Property IsDead As Boolean
        Get
            Return Wounds >= CharacterType.GetBodyPoints()
        End Get
    End Property
    Function Attack(defender As Character, stringBuilder As StringBuilder) As AttackResult
        Dim result = AttackResult.Miss
        stringBuilder.AppendLine($"{Me} attacks {defender}!")
        Dim attackRoll = Me.RollAttack()
        Dim defendRoll = defender.RollDefend()
        Dim damage = DetermineDamage(attackRoll, defendRoll)
        If damage > 0 Then
            stringBuilder.AppendLine($"{Me} hits!")
            stringBuilder.AppendLine($"{defender} takes {damage} points of damage!")
            result = AttackResult.Hit
        Else
            stringBuilder.AppendLine($"{Me} misses!")
        End If
        defender.DoDamage(damage)
        If defender.IsDead Then
            stringBuilder.AppendLine($"{defender} dies!")
            result = AttackResult.Kill
        End If
        Return result
    End Function
    Sub Destroy()
        'TODO: drop any items?
        'TODO: remove from location
        CharacterData.Clear(Id)
    End Sub
    ReadOnly Property MaximumHealth As Integer
        Get
            Return CharacterType.GetBodyPoints()
        End Get
    End Property
    ReadOnly Property CurrentHealth As Integer
        Get
            Return MaximumHealth - Wounds
        End Get
    End Property
    ReadOnly Property HasEquipment As Boolean
        Get
            Return Equipment.Any()
        End Get
    End Property
End Class
