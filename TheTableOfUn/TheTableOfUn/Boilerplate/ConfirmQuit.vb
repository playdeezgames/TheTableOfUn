Imports Terminal.Gui

Module ConfirmQuit
    Function Run() As Boolean
        If MessageBox.Query("Are you sure?", "Are you sure you want to quit?", "No", "Yes") = 1 Then
            Return True
        End If
        Return False
    End Function
End Module
