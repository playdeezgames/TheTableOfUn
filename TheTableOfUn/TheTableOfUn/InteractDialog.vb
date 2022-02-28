Imports TableOfUn.Game
Imports Terminal.Gui

Module InteractDialog
    Private Function HandleFeature(feature As Feature) As Boolean
        Select Case feature.FeatureType
            Case FeatureType.TableOfUn
                Return TableOfUnDialog.Run(CType(feature, TableOfUnFeature))
            Case Else
                Throw New NotImplementedException
        End Select
        Return False
    End Function
    Sub Run()
        Dim cancelButton As New Button("Never mind")
        AddHandler cancelButton.Clicked, AddressOf Application.RequestStop
        Dim dlg As New Dialog("Things to Interact With:", cancelButton)
        Dim groundItems As New ListView With {
            .X = Pos.Center,
            .Y = Pos.Center,
            .Width = [Dim].Fill,
            .Height = [Dim].Fill - 2
        }
        Dim character = New PlayerCharacter()
        groundItems.SetSource(character.Interactables)
        AddHandler groundItems.OpenSelectedItem, Sub(args)
                                                     If HandleFeature(CType(args.Value, Feature)) Then
                                                         If character.CanInteract Then
                                                             Application.RequestStop()
                                                         Else
                                                             groundItems.SetSource(character.Interactables)
                                                         End If
                                                     End If
                                                 End Sub
        dlg.Add(groundItems)
        Application.Run(dlg)
    End Sub
End Module
