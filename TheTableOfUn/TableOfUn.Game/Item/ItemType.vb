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
            Case Else
                Throw New NotImplementedException()
        End Select
    End Function
    <Extension()>
    Function GetEquipSlot(itemType As ItemType) As EquipSlot?
        Select Case itemType
            Case ItemType.SharpRock, ItemType.Rock, ItemType.GrabtharsHammer
                Return EquipSlot.Weapon
            Case Else
                Return Nothing
        End Select
    End Function
    <Extension()>
    Function CanEquip(itemType As ItemType) As Boolean
        Return itemType.GetEquipSlot IsNot Nothing
    End Function
End Module
