Imports TableOfUn.Game

Module SfxHandler
    Sub PlaySfx(sfx As Sfx)
#Disable Warning CA1416 ' Validate platform compatibility
        Console.Beep(110, 100) 'TODO: make "audio" better
#Enable Warning CA1416 ' Validate platform compatibility
    End Sub
End Module
