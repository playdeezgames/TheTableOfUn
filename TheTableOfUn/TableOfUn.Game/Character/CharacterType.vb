Imports System.Runtime.CompilerServices

Public Enum CharacterType As Integer
    None
    Player
    SaurianSwinoid
End Enum
Module CharacterTypeExtensions
    <Extension()>
    Public Function GetName(characterType As CharacterType) As String
        Select Case characterType
            Case CharacterType.None
                Return ""
            Case CharacterType.Player
                Return "you"
            Case CharacterType.SaurianSwinoid
                Return "saurian swinoid"
            Case Else
                Throw New NotImplementedException()
        End Select
    End Function
    Private attackGenerators As New Dictionary(Of CharacterType, Dictionary(Of Integer, Integer)) From
        {
            {CharacterType.None, New Dictionary(Of Integer, Integer) From {{0, 1}}},
            {
                CharacterType.Player,
                New Dictionary(Of Integer, Integer) From
                {
                    {0, 1},
                    {1, 1}
                }
            },
            {
                CharacterType.SaurianSwinoid,
                New Dictionary(Of Integer, Integer) From
                {
                    {0, 2},
                    {1, 1}
                }
            }
        }
    <Extension()>
    Public Function GetAttackGenerator(characterType As CharacterType) As Dictionary(Of Integer, Integer)
        Return attackGenerators(characterType)
    End Function
    Private defendGenerators As New Dictionary(Of CharacterType, Dictionary(Of Integer, Integer)) From
        {
            {CharacterType.None, New Dictionary(Of Integer, Integer) From {{0, 1}}},
            {
                CharacterType.Player,
                New Dictionary(Of Integer, Integer) From
                {
                    {0, 4},
                    {1, 4},
                    {2, 1}
                }
            },
            {
                CharacterType.SaurianSwinoid,
                New Dictionary(Of Integer, Integer) From
                {
                    {0, 25},
                    {1, 10},
                    {2, 1}
                }
            }
        }
    <Extension()>
    Public Function GetDefendGenerator(characterType As CharacterType) As Dictionary(Of Integer, Integer)
        Return attackGenerators(characterType)
    End Function
End Module