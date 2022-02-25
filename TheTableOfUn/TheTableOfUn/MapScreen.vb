Imports Terminal.Gui

Module MapScreen
    Const MapViewColumns As Integer = 31
    Const MapViewRows As Integer = 15
    Private labels As New List(Of Label)
    Private Sub InitializeLabels(window As Window)
        While labels.Count < MapViewColumns * MapViewRows
            Dim column = labels.Count Mod MapViewColumns
            Dim row = labels.Count \ MapViewColumns
            Dim label = New Label(column + 1, row + 1, ".")
            window.Add(label)
            labels.Add(label)
        End While
    End Sub
    Sub Run()
        Dim window As New Window("Map")
        InitializeLabels(window)
        Application.Run(window)
    End Sub
End Module
