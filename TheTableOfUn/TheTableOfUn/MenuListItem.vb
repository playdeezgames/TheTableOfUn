Public Class MenuListItem
    ReadOnly Property Caption As String
    ReadOnly Property DoStuff As Action
    Sub New(caption As String, doStuff As Action)
        Me.Caption = caption
        Me.DoStuff = doStuff
    End Sub
    Public Overrides Function ToString() As String
        Return Caption
    End Function
End Class
