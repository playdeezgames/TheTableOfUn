Imports System.Runtime.CompilerServices
Imports TableOfUn.Game

Module ItemTypeExtensions
    Private ReadOnly candleThingie As New Thingie("i", WhiteOnBlack)
    Private ReadOnly shimThingie As New Thingie("-", BrownOnBlack)
    Private ReadOnly grabtharsThingie As New Thingie("ͳ", RedOnBlack)
    <Extension()>
    Function ToThingie(itemType As ItemType) As Thingie
        Select Case itemType
            Case ItemType.Candle
                Return candleThingie
            Case ItemType.Shim
                Return shimThingie
            Case ItemType.GrabtharsHammer
                Return grabtharsThingie
            Case Else
                Throw New NotImplementedException()
        End Select
    End Function
End Module
