Imports System
Imports Terminal.Gui
Imports TableOfUn.Game
Module Program
    Sub Main(args As String())
        Console.Title = "The Table of Un (aka: Un's Table)"
        AddHandler Game.PlaySfx, AddressOf SfxHandler.PlaySfx
        Application.Init()
        SplashScreen.Run()
        MainMenu.Run()
    End Sub
End Module
