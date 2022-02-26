
Imports System.Runtime.CompilerServices
Imports TableOfUn.Game

Module CharacterTypeExtensions
    Private ReadOnly playerThingie As New Thingie("@", WhiteOnBlack)
    <Extension()>
    Function ToThingie(characterType As CharacterType) As Thingie
        Select Case characterType
            Case CharacterType.Player
                Return playerThingie
            Case Else
                Throw New NotImplementedException()
        End Select
    End Function
End Module
