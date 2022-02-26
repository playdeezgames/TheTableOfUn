﻿Imports TableOfUn.Game
Imports Terminal.Gui

Module MapScreen
    Const MapViewColumns As Integer = 31
    Const MapViewRows As Integer = 15
    Private labels As New List(Of Label)
    Private Sub InitializeLabels(window As Window)
        While labels.Count < MapViewColumns * MapViewRows
            Dim column = labels.Count Mod MapViewColumns
            Dim row = labels.Count \ MapViewColumns
            Dim label = New Label(column + 1, row + 1, "?")
            window.Add(label)
            labels.Add(label)
        End While
    End Sub
    Private Sub UpdateLabels()
        Dim character As New PlayerCharacter()
        Dim left = character.Location.X - MapViewColumns \ 2
        Dim top = character.Location.Y - MapViewRows \ 2
        For row = 0 To MapViewRows - 1
            For column = 0 To MapViewColumns - 1
                Dim label = labels(row * MapViewColumns + column)
                Dim x = left + column
                Dim y = top + row
                Dim location = TableOfUn.Game.Location.FromXY(x, y)
                If location.Character IsNot Nothing Then
                    label.ApplyThingie(location.Character.CharacterType.ToThingie())
                Else
                    label.ApplyThingie(location.LocationType.ToThingie())
                End If
            Next
        Next
    End Sub
    Private Sub MoveNorth()
        Dim character As New PlayerCharacter()
        character.Move(Direction.North)
        UpdateLabels()
    End Sub
    Private Sub MoveSouth()
        Dim character As New PlayerCharacter()
        character.Move(Direction.South)
        UpdateLabels()
    End Sub
    Private Sub MoveEast()
        Dim character As New PlayerCharacter()
        character.Move(Direction.East)
        UpdateLabels()
    End Sub
    Private Sub MoveWest()
        Dim character As New PlayerCharacter()
        character.Move(Direction.West)
        UpdateLabels()
    End Sub
    Private Sub HandleKey(args As View.KeyEventEventArgs)
        Select Case args.KeyEvent.Key
            Case Key.CursorUp
                MoveNorth()
                args.Handled = True
            Case Key.CursorDown
                MoveSouth()
                args.Handled = True
            Case Key.CursorRight
                MoveEast()
                args.Handled = True
            Case Key.CursorLeft
                MoveWest()
                args.Handled = True
        End Select
    End Sub
    Sub Run()
        Dim window As New Window("Map")
        AddHandler window.KeyPress, AddressOf HandleKey
        InitializeLabels(window)
        UpdateLabels()
        Application.Run(window)
    End Sub
End Module
