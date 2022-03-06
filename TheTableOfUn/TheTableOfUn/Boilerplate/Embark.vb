Imports TableOfUn.Game
Imports Terminal.Gui
Module Embark
    Function Run() As Boolean
        Dim button As New Button("Let's Go!")
        AddHandler button.Clicked, AddressOf Application.RequestStop
        Dim dlg As New Dialog("The Table of Un", button)
        Dim expository As New Label With {
            .X = Pos.Center,
            .Y = Pos.Center,
            .Width = [Dim].Fill - 2,
            .Height = [Dim].Fill - 2,
            .Text = "You have been teleported to an alien world!

Yer only hope of escape is to open a portal back to yer own!

In order to open a portal, you will need to find the Table of Un and perform a ritual.

In order to perform the ritual, you will need a magic spellbook!

The magic spellbook is currently incomplete, missing a few pages.

You will need to find the missing pages and complete the spellbook prior to performing the ritual.

In addition, several candles are necessary in order to complete the ritual.

Finally, the Table of Un has one leg that is too short, so you will not be able to put anything on the table without it sliding off until you shim it."
        }
        dlg.Add(expository)
        Application.Run(dlg)
        Game.Start()
        MapScreen.Run()
        Game.Finish()
        Return False
    End Function
End Module
