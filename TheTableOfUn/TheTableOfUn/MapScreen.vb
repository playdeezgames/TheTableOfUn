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
            Dim label = New Label(column + 1, row + 1, ".")
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
                label.Text = "?"
            Next
        Next
    End Sub
    Sub Run()
        Dim window As New Window("Map")
        InitializeLabels(window)
        UpdateLabels()
        Application.Run(window)
    End Sub
End Module
