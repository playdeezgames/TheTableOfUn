Imports TableOfUn.Data

Public Class Location
    ReadOnly Property Id As Long
    Sub New(locationId As Long)
        Id = locationId
    End Sub
    ReadOnly Property X As Integer
        Get
            Return LocationData.ReadX(Id).Value
        End Get
    End Property
    ReadOnly Property Y As Integer
        Get
            Return LocationData.ReadY(Id).Value
        End Get
    End Property
    ReadOnly Property Character As Character
        Get
            Dim characterId = CharacterData.ReadForLocation(Id)
            If characterId IsNot Nothing Then
                Return New Character(characterId.Value)
            End If
            Return Nothing
        End Get
    End Property
    Shared Function FromXY(x As Integer, y As Integer) As Location
        Dim locationId = LocationData.ReadForXY(x, y)
        If locationId Is Nothing Then
            locationId = LocationData.Create(x, y)
            'TODO: populate location
        End If
        Return New Location(locationId.Value)
    End Function
End Class
