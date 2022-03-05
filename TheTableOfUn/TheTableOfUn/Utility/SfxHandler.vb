Imports System.Threading
Imports TableOfUn.Game

Module SfxHandler
    Private Sub Beep(frequency As Integer, Duration As Integer)
#Disable Warning CA1416 ' Validate platform compatibility
        Console.Beep(frequency, Duration)
#Enable Warning CA1416 ' Validate platform compatibility
    End Sub
    Private Sub PlayerDeathSong()
        Dim duration = 500
        'L4G
        Beep(392, duration)
        'L8D
        Beep(294, duration \ 2)
        'L8D
        Beep(294, duration \ 2)
        'L4E
        Beep(330, duration)
        'L4D
        Beep(294, duration)
        'L4R
        Thread.Sleep(duration)
        'L4F#
        Beep(370, duration)
        'L4G
        Beep(392, duration)
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
                PlayerDeathSong()
            Case Else
                Beep(100, 100)
        End Select
    End Sub
End Module
