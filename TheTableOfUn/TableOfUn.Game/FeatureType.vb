Imports System.Runtime.CompilerServices

Public Enum FeatureType
    None
    TableOfUn
    Portal
End Enum
Public Module FeatureTypeExtensions
    <Extension()>
    Function GetName(featureType As FeatureType) As String
        Select Case featureType
            Case FeatureType.TableOfUn
                Return "The Table of Un"
            Case FeatureType.Portal
                Return "A Shimmering Portal"
            Case FeatureType.None
                Return ""
            Case Else
                Throw New NotImplementedException()
        End Select
    End Function
End Module