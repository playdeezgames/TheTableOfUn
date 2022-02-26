Imports System.Runtime.CompilerServices
Imports Terminal.Gui

Module LabelExtensions
    <Extension()>
    Sub ApplyThingie(label As Label, thingie As Thingie)
        label.Text = thingie.Text
        label.ColorScheme = thingie.ColorScheme
    End Sub
End Module