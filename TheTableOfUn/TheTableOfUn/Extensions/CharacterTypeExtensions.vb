
Imports System.Runtime.CompilerServices
Imports TableOfUn.Game

Module CharacterTypeExtensions
    'ȸʃʘɷѦ҈҉ᴥϠ₷
    Private ReadOnly noneThingie As New Thingie(".", GrayOnBlack)
    Private ReadOnly playerThingie As New Thingie("@", WhiteOnBlack)
    Private ReadOnly swinoidThingie As New Thingie("ȸ", BrightRedOnBlack)
    <Extension()>
    Function ToThingie(characterType As CharacterType) As Thingie
        Select Case characterType
            Case CharacterType.None
                Return noneThingie
            Case CharacterType.Player
                Return playerThingie
            Case CharacterType.SaurianSwinoid
                Return swinoidThingie
            Case Else
                Throw New NotImplementedException()
        End Select
    End Function
End Module
