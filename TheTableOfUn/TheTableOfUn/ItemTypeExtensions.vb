﻿Imports System.Runtime.CompilerServices
Imports TableOfUn.Game

Module ItemTypeExtensions
    Private ReadOnly candleThingie As New Thingie("i", YellowOnBlack)
    Private ReadOnly shimThingie As New Thingie("-", BrownOnBlack)
    Private ReadOnly grabtharsThingie As New Thingie("ͳ", RedOnBlack)
    Private ReadOnly pageThingie As New Thingie("p", YellowOnBlack)
    Private ReadOnly incompeteBookThingie As New Thingie("b", BlueOnBlack)
    <Extension()>
    Function ToThingie(itemType As ItemType) As Thingie
        Select Case itemType
            Case ItemType.Candle
                Return candleThingie
            Case ItemType.Shim
                Return shimThingie
            Case ItemType.GrabtharsHammer
                Return grabtharsThingie
            Case ItemType.IncompleteBook
                Return incompeteBookThingie
            Case ItemType.MissingPage
                Return pageThingie
            Case Else
                Throw New NotImplementedException()
        End Select
    End Function
End Module
