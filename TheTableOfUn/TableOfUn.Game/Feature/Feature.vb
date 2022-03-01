Imports TableOfUn.Data

Public Class Feature
    Public ReadOnly Id As Long
    Sub New(featureId As Long)
        Me.Id = featureId
    End Sub
    ReadOnly Property FeatureType As FeatureType
        Get
            Dim result = FeatureData.ReadFeatureType(Id)
            If result IsNot Nothing Then
                Return CType(result.Value, FeatureType)
            End If
            Return FeatureType.None
        End Get
    End Property
    Public Overrides Function ToString() As String
        Return FeatureType.GetName()
    End Function
    Sub Destroy()
        FeatureData.Clear(Id)
    End Sub
End Class
