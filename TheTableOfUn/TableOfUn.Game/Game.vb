Imports TableOfUn.Data

Public Module Game
    Private Sub PlaceTable()
        Dim x As Integer
        Dim y As Integer
        Do
            x = RNG.FromRange(-100, 100)
            y = RNG.FromRange(-100, 100)
        Loop While x > -25 AndAlso y > -25 AndAlso x < 25 AndAlso y < 25
        Dim locationId = LocationData.Create(x, y, LocationType.Floor)
        Dim featureId = FeatureData.Create(locationId, FeatureType.TableOfUn)
    End Sub
    Sub Start()
        Store.Reset()
        Dim locationId = LocationData.Create(0, 0, LocationType.Floor)
        Dim characterId = CharacterData.Create(locationId, CharacterType.Player)
        PlayerData.WriteCharacterId(characterId)
        PlaceTable()
        'TODO: spawn enemy portal(s)
        'TODO: spawn quest items
    End Sub
    Sub Finish()
        Store.ShutDown()
    End Sub
End Module
