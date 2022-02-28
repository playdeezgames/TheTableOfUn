Imports TableOfUn.Data

Public Class Feature
    Private ReadOnly Id As Long
    Sub New(featureId As Long)
        Me.Id = featureId
    End Sub
    ReadOnly Property FeatureType As FeatureType
        Get
            Return CType(FeatureData.ReadFeatureType(Id).Value, FeatureType)
        End Get
    End Property
    Public Overrides Function ToString() As String
        Return FeatureType.GetName()
    End Function
End Class
