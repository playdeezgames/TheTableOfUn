Imports TableOfUn.Data

Public Class Character
    ReadOnly Property Id As Long
    Sub New(characterId As Long)
        Id = characterId
    End Sub
    ReadOnly Property Location As Location
        Get
            Return New Location(CharacterData.ReadLocation(Id).Value)
        End Get
    End Property
    ReadOnly Property CharacterType As CharacterType
        Get
            Return CType(CharacterData.ReadCharacterType(Id).Value, CharacterType)
        End Get
    End Property
    Sub Move(deltaX As Integer, deltaY As Integer)
        Dim start = Location
        Dim destination = TableOfUn.Game.Location.FromXY(start.X + deltaX, start.Y + deltaY)
        If destination.CanBeEnteredBy(Me) Then
            CharacterData.WriteLocation(Id, destination.Id)
        End If
    End Sub
End Class
