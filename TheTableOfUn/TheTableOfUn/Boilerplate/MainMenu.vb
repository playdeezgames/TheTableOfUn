Imports Terminal.Gui
Module MainMenu
    Private Function GetMainMenuListItems() As IList
        Dim listItems As New List(Of MenuListItem)
        listItems.Add(New MenuListItem("Embark!", AddressOf Embark.Run))
        listItems.Add(New MenuListItem("Quit", AddressOf ConfirmQuit.Run))
        Return listItems
    End Function
    Private Sub HandleMenuItem(args As ListViewItemEventArgs)
        Dim listItemAction = CType(args.Value, MenuListItem).DoStuff
        listItemAction()
    End Sub
    Sub Run()
        Dim window As New Window("The Table of Un")
        Dim listView As New ListView()
        listView.X = Pos.Center
        listView.Y = Pos.Center
        listView.Width = [Dim].Percent(50)
        listView.Height = [Dim].Percent(50)
        listView.SetSource(GetMainMenuListItems())
        AddHandler listView.OpenSelectedItem, AddressOf HandleMenuItem
        window.Add(listView)
        Application.Run(window)
    End Sub
End Module
