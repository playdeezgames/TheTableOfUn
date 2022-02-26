Imports System.Runtime.CompilerServices
Imports TableOfUn.Game

Module FeatureTypeExtensions
    Private ReadOnly tableOfUnThingie As New Thingie("╥", BrownOnBlack)
    <Extension()>
    Function ToThingie(featureType As FeatureType) As Thingie
        Select Case featureType
            Case FeatureType.TableOfUn
                Return tableOfUnThingie
            Case Else
                Throw New NotImplementedException()
        End Select
    End Function
End Module
