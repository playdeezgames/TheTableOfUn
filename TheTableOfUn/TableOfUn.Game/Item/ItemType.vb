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
End Module
