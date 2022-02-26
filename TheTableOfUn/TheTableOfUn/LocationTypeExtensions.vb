Imports System.Runtime.CompilerServices
Imports TableOfUn.Game

Module LocationTypeExtensions
    Private ReadOnly floorThingie As New Thingie(".", GrayOnBlack)
    <Extension()>
    Function ToThingie(locationType As LocationType) As Thingie
        Select Case locationType
            Case LocationType.Floor
                Return floorThingie
            Case Else
                Throw New NotImplementedException()
        End Select
    End Function
End Module
