﻿Imports Terminal.Gui
Imports TableOfUn.Game

Module CraftDialog
    Private Function HandleRecipe(recipe As Recipe) As Boolean
        Return New PlayerCharacter().Inventory.Craft(recipe)
    End Function
    Sub Run()
        Dim cancelButton As New Button("Never mind")
        AddHandler cancelButton.Clicked, AddressOf Application.RequestStop
        Dim dlg As New Dialog("Items in yer Inventory:", cancelButton)
        Dim groundItems As New ListView()
        groundItems.X = Pos.Center
        groundItems.Y = Pos.Center
        groundItems.Width = [Dim].Fill
        groundItems.Height = [Dim].Fill - 2
        Dim inventory = New PlayerCharacter().Inventory
        groundItems.SetSource(inventory.CraftableRecipes)
        AddHandler groundItems.OpenSelectedItem, Sub(args)
                                                     If HandleRecipe(CType(args.Value, Recipe)) Then
                                                         If Not inventory.CanCraft Then
                                                             Application.RequestStop()
                                                         Else
                                                             groundItems.SetSource(inventory.CraftableRecipes)
                                                         End If
                                                     End If
                                                 End Sub
        dlg.Add(groundItems)
        Application.Run(dlg)
    End Sub
End Module
