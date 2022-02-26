Imports Terminal.Gui

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
End Module
