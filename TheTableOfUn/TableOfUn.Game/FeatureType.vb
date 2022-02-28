Imports System.Runtime.CompilerServices

Public Enum FeatureType
    TableOfUn
End Enum
Public Module FeatureTypeExtensions
    <Extension()>
    Function GetName(featureType As FeatureType) As String
        Select Case featureType
            Case FeatureType.TableOfUn
                Return "The Table of Un"
            Case Else
                Throw New NotImplementedException()
        End Select
    End Function
End Module