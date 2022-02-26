Imports System.Runtime.CompilerServices
Imports TableOfUn.Game

Module LocationTypeExtensions
    Private ReadOnly floorThingie As New Thingie(".", GrayOnBlack)
    Private ReadOnly solidThingie As New Thingie("█", GrayOnBlack)
    <Extension()>
    Function ToThingie(locationType As LocationType) As Thingie
        Select Case locationType
            Case LocationType.Floor
                Return floorThingie
            Case LocationType.Solid
                Return solidThingie
            Case Else
                Throw New NotImplementedException()
        End Select
    End Function
End Module
