Imports System.Runtime.CompilerServices

Public Enum ItemType
    None
    Shim
    Candle
    GrabtharsHammer
    MissingPage
    IncompleteBook
    Spellbook
    Rock
    SharpRock
    Tusk
    Hide
    Meat
    TicketToProm
    Shield
    Bone
    LeatherCord
    Needle
    Necklace
    Trousers
End Enum
Public Module ItemTypeExtensions
    <Extension()>
    Function GetName(itemType As ItemType) As String
        Select Case itemType
            Case ItemType.None
                Return ""
            Case ItemType.Candle
                Return "candle"
            Case ItemType.GrabtharsHammer
                Return "hammer"
            Case ItemType.Shim
                Return "shim"
            Case ItemType.MissingPage
                Return "loose page"
            Case ItemType.IncompleteBook
                Return "book with missing pages"
            Case ItemType.Spellbook
                Return "spellbook"
            Case ItemType.Rock
                Return "rock"
            Case ItemType.SharpRock
                Return "sharp rock"
            Case ItemType.Tusk
                Return "tusk"
            Case ItemType.Hide
                Return "hide"
            Case ItemType.Meat
                Return "meat"
            Case ItemType.TicketToProm
                Return "a ticket to prom"
            Case ItemType.Shield
                Return "a leather shield"
            Case ItemType.Bone
                Return "a bone"
            Case ItemType.LeatherCord
                Return "leather cord"
            Case ItemType.Needle
                Return "a sewing needle"
            Case ItemType.Necklace
                Return "a necklace of tusks"
            Case ItemType.Trousers
                Return "leather trousers"
            Case Else
                Throw New NotImplementedException()
        End Select
    End Function
    <Extension()>
    Function GetEquipSlot(itemType As ItemType) As EquipSlot?
        Select Case itemType
            Case ItemType.SharpRock, ItemType.Rock, ItemType.GrabtharsHammer
                Return EquipSlot.Weapon
            Case ItemType.Shield
                Return EquipSlot.Shield
            Case ItemType.Trousers
                Return EquipSlot.Legs
            Case ItemType.Necklace
                Return EquipSlot.Neck
            Case Else
                Return Nothing
        End Select
    End Function
    <Extension()>
    Function CanEquip(itemType As ItemType) As Boolean
        Return itemType.GetEquipSlot IsNot Nothing
    End Function
    <Extension()>
    Function GetAttackGenerator(itemType As ItemType) As Dictionary(Of Integer, Integer)
        Select Case itemType
            Case ItemType.Rock
                Return New Dictionary(Of Integer, Integer) From {{0, 1}, {1, 2}}
            Case ItemType.SharpRock
                Return New Dictionary(Of Integer, Integer) From {{0, 1}, {1, 2}, {2, 1}}
            Case ItemType.GrabtharsHammer
                Return New Dictionary(Of Integer, Integer) From {{0, 1}, {1, 3}, {2, 3}, {3, 1}}
            Case Else
                Return New Dictionary(Of Integer, Integer) From {{0, 1}}
        End Select
    End Function
    <Extension()>
    Function GetDefendGenerator(itemType As ItemType) As Dictionary(Of Integer, Integer)
        Select Case itemType
            Case ItemType.Shield
                Return New Dictionary(Of Integer, Integer) From {{0, 2}, {1, 1}}
            Case ItemType.Trousers
                Return New Dictionary(Of Integer, Integer) From {{0, 4}, {1, 4}, {2, 1}}
            Case Else
                Return New Dictionary(Of Integer, Integer) From {{0, 1}}
        End Select
    End Function
    <Extension()>
    Function CanConsume(itemType As ItemType) As Boolean
        Return itemType = ItemType.Meat
    End Function
    <Extension()>
    Function GetHealthBenefit(itemType As ItemType) As Integer
        Select Case itemType
            Case ItemType.Meat
                Return 1
            Case Else
                Return 0
        End Select
    End Function
End Module
