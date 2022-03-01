Imports System.Runtime.CompilerServices

Public Enum ItemType
    Shim
    Candle
    GrabtharsHammer
    MissingPage
    IncompleteBook
    Spellbook
End Enum
Public Module ItemTypeExtensions
    <Extension()>
    Function GetName(itemType As ItemType) As String
        Select Case itemType
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
            Case Else
                Throw New NotImplementedException()
        End Select
    End Function
End Module
