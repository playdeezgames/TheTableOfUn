Module RNG
    Private ReadOnly random As New Random
    Function FromGenerator(Of TGenerated)(table As Dictionary(Of TGenerated, Integer)) As TGenerated
        Dim generated = random.Next(table.Values.Sum)
        For Each entry In table
            generated -= entry.Value
            If generated < 0 Then
                Return entry.Key
            End If
        Next
        Throw New NotImplementedException()
    End Function
    Function FromRange(minimum As Integer, maximum As Integer) As Integer
        Return random.Next(maximum - minimum + 1) + minimum
    End Function
End Module
