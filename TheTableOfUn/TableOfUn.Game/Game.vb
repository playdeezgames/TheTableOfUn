Imports TableOfUn.Data

Public Module Game
    Private Sub PlaceTable()
        Dim locationId = LocationData.Create(10, 10, LocationType.Floor) 'TODO: randomly generate location
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
