Imports TableOfUn.Game
Imports Terminal.Gui

Public Class MapView
    Inherits View
    Const MapViewColumns As Integer = 31
    Const MapViewRows As Integer = 15
    Const CenterColumn = MapViewColumns \ 2
    Const CenterRow = MapViewRows \ 2
    Sub New(column As Integer, row As Integer)
        MyBase.New(New Rect(column, row, MapViewColumns, MapViewRows))
    End Sub
    Public Overrides Sub Redraw(bounds As Rect)
        Dim character As New PlayerCharacter()
        If character IsNot Nothing Then
            For column = 0 To bounds.Width - 1
                Dim gameColumn = column - CenterColumn + character.Location.X
                For row = 0 To bounds.Height - 1
                    Dim gameRow = row - CenterRow + character.Location.Y
                    Move(column, row)
                    Dim location = TableOfUn.Game.Location.FromXY(gameColumn, gameRow)
                    Dim thingie As Thingie
                    If location.Character IsNot Nothing Then
                        thingie = location.Character.CharacterType.ToThingie()
                    ElseIf location.Feature IsNot Nothing Then
                        thingie = location.Feature.FeatureType.ToThingie()
                    ElseIf location.Inventory.TopItem IsNot Nothing Then
                        thingie = location.Inventory.TopItem.ItemType.ToThingie()
                    Else
                        thingie = location.LocationType.ToThingie()
                    End If
                    Driver.SetAttribute(thingie.ColorScheme.Normal)
                    Driver.AddStr(thingie.Text)
                Next
            Next
        End If
    End Sub
End Class
