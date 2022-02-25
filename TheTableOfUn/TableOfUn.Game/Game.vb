Imports TableOfUn.Data

Public Module Game
    Sub Start()
        Store.Reset()
        Dim locationId = LocationData.Create(0, 0)
        Dim characterId = CharacterData.Create(locationId)
        PlayerData.WriteCharacterId(characterId)
    End Sub
    Sub Finish()
        Store.ShutDown()
    End Sub
End Module
