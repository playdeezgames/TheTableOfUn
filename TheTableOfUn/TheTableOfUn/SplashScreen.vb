Imports Terminal.Gui

Module SplashScreen
    Sub Run()
        Dim startButton As New Button("Start")
        AddHandler startButton.Clicked, AddressOf Application.RequestStop
        Dim dlg As New Dialog("", startButton)
        Dim label As New Label("The Table of Un")
        label.X = Pos.Center()
        label.Y = Pos.Center() - 2
        dlg.Add(label)
        label = New Label("(aka: Un's Table)")
        label.X = Pos.Center()
        label.Y = Pos.Center()
        dlg.Add(label)
        label = New Label("A production of TheGrumpyGameDev")
        label.X = Pos.Center()
        label.Y = Pos.Center() + 2
        dlg.Add(label)
        Application.Run(dlg)
    End Sub
End Module
