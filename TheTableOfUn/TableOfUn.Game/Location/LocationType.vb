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
    Private characterGenerators As New Dictionary(Of LocationType, Dictionary(Of CharacterType, Integer)) From
        {
            {
                LocationType.Floor,
                New Dictionary(Of CharacterType, Integer) From
                {
                    {CharacterType.None, 100},
                    {CharacterType.SaurianSwinoid, 1}
                }
            }
        }
    <Extension()>
    Function GenerateCharacterType(locationType As LocationType) As CharacterType?
        If characterGenerators.ContainsKey(locationType) Then
            Dim characterType = RNG.FromGenerator(characterGenerators(locationType))
            If characterType <> CharacterType.None Then
                Return characterType
            End If
        End If
        Return Nothing
    End Function
End Module
