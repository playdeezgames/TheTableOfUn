Imports TableOfUn.Game
Imports Terminal.Gui

Module TableOfUnDialog
    Function Run(tableOfUn As TableOfUnFeature) As Boolean
        Dim character As New PlayerCharacter()
        Dim cancelButton As New Button("Never mind")
        Dim shimButton As New Button("Shim")
        Dim candleButton As New Button("Place Candle")
        Dim bookButton As New Button("Place Spellbook")
        Dim ritualButton As New Button("Perform Ritual")
        Dim shimLabel As New Label(1, 1, "")
        Dim candleLabel As New Label(1, 2, "")
        Dim bookLabel As New Label(1, 3, "")
        Dim updateDialog = Sub()
                               If tableOfUn.IsShimmed Then
                                   shimLabel.Text = "A shim is holding the table steady.                                 "
                               Else
                                   shimLabel.Text = "One leg of the table is shorter, so you cannot place anything on it."
                               End If
                               If tableOfUn.HasBook Then
                                   bookLabel.Text = "A spellbook is lain open in the middle of the table."
                               Else
                                   bookLabel.Text = ""
                               End If
                               candleLabel.Text = $"There are {tableOfUn.CandleCount} candles placed upon it."
                               shimButton.Enabled = Not tableOfUn.IsShimmed AndAlso character.Inventory.HasItemType(ItemType.Shim)
                               candleButton.Enabled = tableOfUn.IsShimmed AndAlso tableOfUn.NeedsCandles AndAlso character.Inventory.HasItemType(ItemType.Candle)
                               bookButton.Enabled = tableOfUn.IsShimmed AndAlso Not tableOfUn.HasBook AndAlso character.Inventory.HasItemType(ItemType.Spellbook)
                               ritualButton.Enabled = tableOfUn.HasBook AndAlso Not tableOfUn.NeedsCandles
                           End Sub
        AddHandler shimButton.Clicked, Sub()
                                           tableOfUn.Shim(character)
                                           updateDialog()
                                       End Sub
        AddHandler candleButton.Clicked, Sub()
                                             tableOfUn.AddCandle(character)
                                             updateDialog()
                                         End Sub
        AddHandler bookButton.Clicked, Sub()
                                           tableOfUn.PlaceBook(character)
                                           updateDialog()
                                       End Sub
        AddHandler cancelButton.Clicked, AddressOf Application.RequestStop

        Dim dlg As New Dialog("The Table of Un", cancelButton, shimButton, candleButton, bookButton, ritualButton)
        dlg.Add(shimLabel, candleLabel, bookLabel)
        updateDialog()
        Application.Run(dlg)
        Return False
    End Function
    Sub Blah()
    End Sub
End Module
