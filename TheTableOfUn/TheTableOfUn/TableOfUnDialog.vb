Imports TableOfUn.Game
Imports Terminal.Gui

Module TableOfUnDialog
    Function Run(tableOfUn As TableOfUnFeature) As Boolean
        Dim character As New PlayerCharacter()
        Dim cancelButton As New Button("Never mind")
        Dim shimButton As New Button("Shim")
        AddHandler cancelButton.Clicked, AddressOf Application.RequestStop

        Dim dlg As New Dialog("The Table of Un", cancelButton, shimButton)
        shimButton.Enabled = Not tableOfUn.IsShimmed AndAlso character.Inventory.HasItemType(ItemType.Shim)
        'TODO: shim state
        'TODO: candles
        'TODO: spellbook
        Application.Run(dlg)
        Return False
    End Function
    Sub Blah()
    End Sub
End Module
