Imports Terminal.Gui
Module MainMenu
    Private Function GetMainMenuListItems() As IList
        Dim listItems As New List(Of MenuListItem)
        listItems.Add(New MenuListItem("Embark!", AddressOf Embark.Run))
        listItems.Add(New MenuListItem("Quit", AddressOf ConfirmQuit.Run))
        Return listItems
    End Function
    Sub Run()
        Do
            Dim window As New Window("The Table of Un")
            Dim listView As New ListView()
            listView.X = Pos.Center
            listView.Y = Pos.Center
            listView.Width = [Dim].Percent(50)
            listView.Height = [Dim].Percent(50)
            listView.SetSource(GetMainMenuListItems())
            Dim doStuff As Func(Of Boolean) = Nothing
            AddHandler listView.OpenSelectedItem, Sub(args As ListViewItemEventArgs)
                                                      doStuff = CType(args.Value, MenuListItem).DoStuff
                                                      Application.RequestStop()
                                                  End Sub
            window.Add(listView)
            Application.Run(window)
            If doStuff IsNot Nothing Then
                If doStuff() Then
                    Exit Do
                End If
            End If
        Loop
    End Sub
End Module
