Imports TableOfUn.Game
Imports Terminal.Gui

Module TableOfUnDialog
    Function Run(tableOfUn As TableOfUnFeature) As Boolean
        Dim character As New PlayerCharacter()
        Dim cancelButton As New Button("Never mind")
        Dim shimButton As New Button("Shim")
        Dim shimLabel As New Label(1, 1, "")
        Dim updateDialog = Sub()
                               If tableOfUn.IsShimmed Then
                                   shimLabel.Text = "A shim is holding the table steady.                                 "
                               Else
                                   shimLabel.Text = "One leg of the table is shorter, so you cannot place anything on it."
                               End If
                               shimButton.Enabled = Not tableOfUn.IsShimmed AndAlso character.Inventory.HasItemType(ItemType.Shim)
                               'TODO: candles
                               'TODO: spellbook
                           End Sub
        AddHandler shimButton.Clicked, Sub()
                                           tableOfUn.Shim(character)
                                           updateDialog()
                                       End Sub
        AddHandler cancelButton.Clicked, AddressOf Application.RequestStop

        Dim dlg As New Dialog("The Table of Un", cancelButton, shimButton)
        dlg.Add(shimLabel)
        updateDialog()
        Application.Run(dlg)
        Return False
    End Function
    Sub Blah()
    End Sub
End Module
