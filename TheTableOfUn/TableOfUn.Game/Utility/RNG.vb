Imports System.Runtime.CompilerServices

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
Module DictionaryExtensions
    <Extension()>
    Function CombineGenerator(first As Dictionary(Of Integer, Integer), second As Dictionary(Of Integer, Integer)) As Dictionary(Of Integer, Integer)
        Dim result As New Dictionary(Of Integer, Integer)
        For Each firstItem In first
            For Each secondItem In second
                Dim combinedKey = firstItem.Key + secondItem.Key
                Dim combinedValue = firstItem.Value * secondItem.Value
                If result.ContainsKey(combinedKey) Then
                    result(combinedKey) += combinedValue
                Else
                    result.Add(combinedKey, combinedValue)
                End If
            Next
        Next
        Return result
    End Function
End Module
