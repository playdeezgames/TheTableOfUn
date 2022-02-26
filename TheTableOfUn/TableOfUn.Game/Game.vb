Imports TableOfUn.Data

Public Module Game
    Sub Start()
        Store.Reset()
        Dim locationId = LocationData.Create(0, 0, LocationType.Floor)
        Dim characterId = CharacterData.Create(locationId, CharacterType.Player)
        PlayerData.WriteCharacterId(characterId)
    End Sub
    Sub Finish()
        Store.ShutDown()
    End Sub
End Module
