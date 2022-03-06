Imports Terminal.Gui
Module GameMenu
    Private Sub HandleSave()
        Dim dlg As New SaveDialog()
        Application.Run(dlg)
        If dlg.FileName IsNot Nothing Then
            TableOfUn.Data.Store.Save(dlg.FileName.ToString())
            Application.RequestStop()
        End If
    End Sub
    Function Run() As Boolean
        Dim result As Boolean = False
        Dim cancelButton As New Button("Cancel")
        AddHandler cancelButton.Clicked, AddressOf Application.RequestStop
        Dim abandonButton As New Button("Abandon Game")
        AddHandler abandonButton.Clicked, Sub()
                                              If MessageBox.Query("Confirm Abandon", "Are you sure you want to abandon the game?", "No", "Yes") = 1 Then
                                                  result = True
                                                  Application.RequestStop()
                                              End If
                                          End Sub
        'Dim saveButton As New Button("Save Game...")
        'AddHandler saveButton.Clicked, AddressOf HandleSave
        Dim dlg As New Dialog("Game Menu", cancelButton, abandonButton) ', saveButton)
        Application.Run(dlg)
        Return result
    End Function
End Module
