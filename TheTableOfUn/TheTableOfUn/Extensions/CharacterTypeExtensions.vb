
Imports System.Runtime.CompilerServices
Imports TableOfUn.Game

Module CharacterTypeExtensions
    'ȸʃʘɷ Ѧ҈҉ ᴥϠ₷
    Private ReadOnly noneThingie As New Thingie(".", GrayOnBlack)
    Private ReadOnly playerThingie As New Thingie("@", WhiteOnBlack)
    Private ReadOnly swinoidThingie As New Thingie("ȸ", BrightRedOnBlack)
    Private ReadOnly gorignakThingie As New Thingie("Ѧ", BrownOnBlack)
    <Extension()>
    Function ToThingie(characterType As CharacterType) As Thingie
        Select Case characterType
            Case CharacterType.None
                Return noneThingie
            Case CharacterType.Player
                Return playerThingie
            Case CharacterType.SaurianSwinoid
                Return swinoidThingie
            Case CharacterType.Gorignak
                Return gorignakThingie
            Case Else
                Throw New NotImplementedException()
        End Select
    End Function
End Module
