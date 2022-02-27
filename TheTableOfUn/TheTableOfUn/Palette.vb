﻿Imports Terminal.Gui

Module Palette
    Public ReadOnly WhiteOnBlack As New ColorScheme() With
        {
            .Disabled = Attribute.Make(Color.White, Color.Black),
            .Focus = Attribute.Make(Color.White, Color.Black),
            .HotFocus = Attribute.Make(Color.White, Color.Black),
            .HotNormal = Attribute.Make(Color.White, Color.Black),
            .Normal = Attribute.Make(Color.White, Color.Black)
        }
    Public ReadOnly GrayOnBlack As New ColorScheme() With
        {
            .Disabled = Attribute.Make(Color.Gray, Color.Black),
            .Focus = Attribute.Make(Color.Gray, Color.Black),
            .HotFocus = Attribute.Make(Color.Gray, Color.Black),
            .HotNormal = Attribute.Make(Color.Gray, Color.Black),
            .Normal = Attribute.Make(Color.Gray, Color.Black)
        }
    Public ReadOnly BrownOnBlack As New ColorScheme() With
        {
            .Disabled = Attribute.Make(Color.Brown, Color.Black),
            .Focus = Attribute.Make(Color.Brown, Color.Black),
            .HotFocus = Attribute.Make(Color.Brown, Color.Black),
            .HotNormal = Attribute.Make(Color.Brown, Color.Black),
            .Normal = Attribute.Make(Color.Brown, Color.Black)
        }
    Public ReadOnly RedOnBlack As New ColorScheme() With
        {
            .Disabled = Attribute.Make(Color.Red, Color.Black),
            .Focus = Attribute.Make(Color.Red, Color.Black),
            .HotFocus = Attribute.Make(Color.Red, Color.Black),
            .HotNormal = Attribute.Make(Color.Red, Color.Black),
            .Normal = Attribute.Make(Color.Red, Color.Black)
        }
    Public ReadOnly YellowOnBlack As New ColorScheme() With
        {
            .Disabled = Attribute.Make(Color.BrightYellow, Color.Black),
            .Focus = Attribute.Make(Color.BrightYellow, Color.Black),
            .HotFocus = Attribute.Make(Color.BrightYellow, Color.Black),
            .HotNormal = Attribute.Make(Color.BrightYellow, Color.Black),
            .Normal = Attribute.Make(Color.BrightYellow, Color.Black)
        }
End Module
