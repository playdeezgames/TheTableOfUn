﻿Imports System.Runtime.CompilerServices

Public Enum CharacterType As Integer
    None
    Player
    SaurianSwinoid
    Gorignak
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
            Case CharacterType.Gorignak
                Return "Gorignak!"
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
            },
            {
                CharacterType.Gorignak,
                New Dictionary(Of Integer, Integer) From
                {
                    {4, 1},
                    {3, 8},
                    {2, 24},
                    {1, 32},
                    {0, 16}
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
            },
            {
                CharacterType.Gorignak,
                New Dictionary(Of Integer, Integer) From
                {
                    {4, 1},
                    {3, 20},
                    {2, 150},
                    {1, 500},
                    {0, 625}
                }
            }
        }
    <Extension()>
    Public Function GetDefendGenerator(characterType As CharacterType) As Dictionary(Of Integer, Integer)
        Return attackGenerators(characterType)
    End Function
    <Extension()>
    Public Function GetBodyPoints(characterType As CharacterType) As Integer
        Select Case characterType
            Case CharacterType.None
                Return 0
            Case CharacterType.Player
                Return 5
            Case CharacterType.SaurianSwinoid
                Return 1
            Case CharacterType.Gorignak
                Return 10
            Case Else
                Throw New NotImplementedException()
        End Select
    End Function
    <Extension()>
    Public Function IsHostileTowards(source As CharacterType, destination As CharacterType) As Boolean
        Select Case source
            Case CharacterType.None
                Return False
            Case CharacterType.Player
                Return True
            Case Else
                Return destination = CharacterType.Player
        End Select
    End Function
End Module