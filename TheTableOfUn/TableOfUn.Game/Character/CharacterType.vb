Imports System.Runtime.CompilerServices

Public Enum CharacterType As Integer
    None
    Player
    SaurianSwinoid
End Enum
Module CharacterTypeExtensions
    <Extension()>
    Public Function GetName(characterType As CharacterType) As String
        Select Case characterType
            Case CharacterType.None
                Return ""
            Case CharacterType.Player
                Return "you"
            Case CharacterType.SaurianSwinoid
                Return "saurian swinoid"
            Case Else
                Throw New NotImplementedException()
        End Select
    End Function
End Module