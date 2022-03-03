Imports TableOfUn.Game

Module SfxHandler
    Private Sub Beep(frequency As Integer, Duration As Integer)
#Disable Warning CA1416 ' Validate platform compatibility
        Console.Beep(frequency, Duration)
#Enable Warning CA1416 ' Validate platform compatibility
    End Sub

    Sub PlaySfx(sfx As Sfx)
        Select Case sfx
            Case Sfx.HitEnemy
                Beep(500, 100)
            Case Sfx.KillEnemy
                Beep(600, 100)
            Case Sfx.MissEnemy
                Beep(200, 100)
            Case Sfx.HitPlayer
                Beep(400, 100)
            Case Sfx.KillPlayer
                Beep(300, 100)
            Case Else
                Beep(100, 100)
        End Select
    End Sub
End Module
