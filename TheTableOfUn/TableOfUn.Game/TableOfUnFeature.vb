Imports TableOfUn.Data

Public Class TableOfUnFeature
    Inherits Feature
    Sub New(featureId As Long)
        MyBase.New(featureId)
    End Sub
    ReadOnly Property IsShimmed As Boolean
        Get
            Return TableOfUnFeatureData.ReadIsShimmed(Id).Value
        End Get
    End Property
End Class
