Imports Terminal.Gui

Module ConfirmQuit
    Sub Run()
        If MessageBox.Query("Are you sure?", "Are you sure you want to quit?", "No", "Yes") = 1 Then
            Application.RequestStop()
        End If
    End Sub
End Module
