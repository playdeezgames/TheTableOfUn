Imports TableOfUn.Game
Imports Terminal.Gui
Module Embark
    Function Run() As Boolean
        Game.Start()
        MapScreen.Run()
        Game.Finish()
        Return False
    End Function
End Module
