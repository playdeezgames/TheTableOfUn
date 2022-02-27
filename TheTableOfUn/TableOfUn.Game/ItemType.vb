Imports System.Runtime.CompilerServices

Public Enum ItemType
    Shim
    Candle
    GrabtharsHammer
End Enum
Public Module ItemTypeExtensions
    <Extension()>
    Function GetName(itemType As ItemType) As String
        Select Case itemType
            Case ItemType.Candle
                Return "candle"
            Case ItemType.GrabtharsHammer
                Return "hammer"
            Case ItemType.Shim
                Return "shim"
            Case Else
                Throw New NotImplementedException()
        End Select
    End Function
End Module
