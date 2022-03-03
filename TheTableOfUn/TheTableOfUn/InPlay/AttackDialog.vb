Imports System.Text
Imports TableOfUn.Game
Imports Terminal.Gui

Module AttackDialog
    Private Sub HandleAttack(defender As Character)
        Dim attacker As New PlayerCharacter()
        Dim stringBuilder As New StringBuilder()
        attacker.Attack(defender, stringBuilder)
        If Not defender.IsDead Then
            defender.Attack(attacker, stringBuilder)
        End If
        MessageBox.ErrorQuery("HUZZAH!", stringBuilder.ToString(), "Ok")
        If defender.IsDead Then
            defender.Destroy()
        End If
    End Sub
    Function Run() As Boolean
        Dim cancelButton As New Button("Never mind")
        AddHandler cancelButton.Clicked, AddressOf Application.RequestStop
        Dim dlg As New Dialog("Things to Attack:", cancelButton)
        Dim attackableCharacters As New ListView With {
            .X = Pos.Center,
            .Y = Pos.Center,
            .Width = [Dim].Fill,
            .Height = [Dim].Fill - 2
        }
        Dim character = New PlayerCharacter()
        attackableCharacters.SetSource(character.Attackables)
        AddHandler attackableCharacters.OpenSelectedItem, Sub(args)
                                                              HandleAttack(CType(args.Value, Character))
                                                              If Not character.CanAttack OrElse character.IsDead Then
                                                                  Application.RequestStop()
                                                              Else
                                                                  attackableCharacters.SetSource(character.Attackables)
                                                              End If
                                                          End Sub
        dlg.Add(attackableCharacters)
        Application.Run(dlg)
        Return character.IsDead
    End Function
End Module
