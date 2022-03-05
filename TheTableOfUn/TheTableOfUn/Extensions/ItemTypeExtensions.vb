﻿Imports System.Runtime.CompilerServices
Imports TableOfUn.Game

Module ItemTypeExtensions
    Private ReadOnly noneThingie As New Thingie(".", GrayOnBlack)
    Private ReadOnly candleThingie As New Thingie("i", YellowOnBlack)
    Private ReadOnly shimThingie As New Thingie("_", BrownOnBlack)
    Private ReadOnly grabtharsThingie As New Thingie("ͳ", RedOnBlack)
    Private ReadOnly pageThingie As New Thingie("p", YellowOnBlack)
    Private ReadOnly incompeteBookThingie As New Thingie("b", BlueOnBlack)
    Private ReadOnly spellbookThingie As New Thingie("B", BrightBlueOnBlack)
    Private ReadOnly rockThingie As New Thingie("◦", BrownOnBlack)
    Private ReadOnly sharpRockThingie As New Thingie("▫", BrownOnBlack)
    Private ReadOnly tuskThingie As New Thingie("ˀ", DarkGrayOnBlack)
    Private ReadOnly hideThingie As New Thingie("ʜ", BrownOnBlack)
    Private ReadOnly meatThingie As New Thingie("ᵯ", RedOnBlack)
    Private ReadOnly ticketThingie As New Thingie("━", BlueOnBlack)
    <Extension()>
    Function ToThingie(itemType As ItemType) As Thingie
        Select Case itemType
            Case ItemType.None
                Return noneThingie
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
            Case ItemType.Spellbook
                Return spellbookThingie
            Case ItemType.Rock
                Return rockThingie
            Case ItemType.SharpRock
                Return sharpRockThingie
            Case ItemType.Tusk
                Return tuskThingie
            Case ItemType.Hide
                Return hideThingie
            Case ItemType.Meat
                Return meatThingie
            Case ItemType.TicketToProm
                Return ticketThingie
            Case Else
                Throw New NotImplementedException()
        End Select
    End Function
End Module
