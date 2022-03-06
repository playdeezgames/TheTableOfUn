Imports System.Text
Imports TableOfUn.Game
Imports Terminal.Gui

Module AttackDialog
    Sub HandleAttack(attacker As Character, defender As Character)
        Dim stringBuilder As New StringBuilder()
        Select Case attacker.Attack(defender, stringBuilder)
            Case AttackResult.Miss
                Game.Play(Sfx.MissEnemy)
            Case AttackResult.Hit
                Game.Play(GetHitSfx(attacker.CharacterType))
            Case AttackResult.Kill
                Game.Play(GetKillSfx(attacker.CharacterType))
        End Select
        If Not defender.IsDead Then
            Select Case defender.Attack(attacker, stringBuilder)
                Case AttackResult.Kill
                    Game.Play(GetKillSfx(defender.CharacterType))
                Case AttackResult.Hit
                    Game.Play(GetHitSfx(defender.CharacterType))
            End Select
        End If
        MessageBox.ErrorQuery("HUZZAH!", stringBuilder.ToString(), "Ok")
        If defender.IsDead Then
            defender.Destroy()
        End If
    End Sub
    Private Sub ResolveAttack(defender As Character)
        Dim attacker As New PlayerCharacter()
        HandleAttack(attacker, defender)
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
                                                              ResolveAttack(CType(args.Value, Character))
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
