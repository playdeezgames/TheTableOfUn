Imports TableOfUn.Game
Imports Terminal.Gui

Module AttackDialog
    Private Function HandleAttack(character As Character) As Boolean
        Return False
    End Function
    Function Run() As Boolean
        Dim cancelButton As New Button("Never mind")
        AddHandler cancelButton.Clicked, AddressOf Application.RequestStop
        Dim dlg As New Dialog("Things to Attack:", cancelButton)
        Dim groundItems As New ListView With {
            .X = Pos.Center,
            .Y = Pos.Center,
            .Width = [Dim].Fill,
            .Height = [Dim].Fill - 2
        }
        Dim character = New PlayerCharacter()
        groundItems.SetSource(character.Attackables)
        AddHandler groundItems.OpenSelectedItem, Sub(args)
                                                     If HandleAttack(CType(args.Value, Character)) Then
                                                         If Not character.CanAttack Then
                                                             Application.RequestStop()
                                                         Else
                                                             groundItems.SetSource(character.Attackables)
                                                         End If
                                                     End If
                                                 End Sub
        dlg.Add(groundItems)
        Application.Run(dlg)
        Return character.DidWinninate
    End Function
End Module
