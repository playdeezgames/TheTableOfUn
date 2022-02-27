Public Class Recipe
    ReadOnly Property Inputs As Dictionary(Of ItemType, Integer)
    ReadOnly Property Outputs As Dictionary(Of ItemType, Integer)
    Sub New(inputs As Dictionary(Of ItemType, Integer), outputs As Dictionary(Of ItemType, Integer))
        Me.Inputs = inputs
        Me.Outputs = outputs
    End Sub
    Public Overrides Function ToString() As String
        Return String.Join("+", Inputs.Select(Function(entry)
                                                  Return $"{entry.Key.GetName()}({entry.Value})"
                                              End Function)) & "->" &
            String.Join("+", Outputs.Select(Function(entry)
                                                Return $"{entry.Key.GetName()}({entry.Value})"
                                            End Function))
    End Function
End Class
