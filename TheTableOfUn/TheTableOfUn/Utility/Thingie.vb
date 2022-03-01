Imports System.Runtime.CompilerServices
Imports Terminal.Gui

Public Class Thingie
    ReadOnly Property Text As String
    ReadOnly Property ColorScheme As ColorScheme
    Sub New(text As String, colorScheme As ColorScheme)
        Me.Text = text
        Me.ColorScheme = colorScheme
    End Sub
End Class

