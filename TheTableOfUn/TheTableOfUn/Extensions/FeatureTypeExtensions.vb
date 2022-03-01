Imports System.Runtime.CompilerServices
Imports TableOfUn.Game

Module FeatureTypeExtensions
    Private ReadOnly noneThingie As New Thingie(".", GrayOnBlack)
    Private ReadOnly tableOfUnThingie As New Thingie("╥", BrownOnBlack)
    Private ReadOnly portalThingie As New Thingie("֍", BrightGreenOnBlack)
    <Extension()>
    Function ToThingie(featureType As FeatureType) As Thingie
        Select Case featureType
            Case FeatureType.TableOfUn
                Return tableOfUnThingie
            Case FeatureType.Portal
                Return portalThingie
            Case FeatureType.None
                Return noneThingie
            Case Else
                Throw New NotImplementedException()
        End Select
    End Function
End Module
