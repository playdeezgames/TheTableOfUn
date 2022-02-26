Imports System.Runtime.CompilerServices

Public Enum LocationType As Integer
    Floor
    Solid
End Enum
Module LocationTypeExtensions
    <Extension()>
    Function CanBeEnteredBy(locationType As LocationType, characterType As CharacterType) As Boolean
        Select Case locationType
            Case LocationType.Floor
                Return True
            Case LocationType.Solid
                Return False
            Case Else
                Throw New NotImplementedException()
        End Select
    End Function
End Module
