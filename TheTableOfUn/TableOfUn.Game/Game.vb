Imports TableOfUn.Data

Public Module Game
    Private Function GenerateFloor() As Long
        Dim x As Integer
        Dim y As Integer
        Do
            x = RNG.FromRange(-100, 100)
            y = RNG.FromRange(-100, 100)
        Loop While x > -25 AndAlso y > -25 AndAlso x < 25 AndAlso y < 25 AndAlso LocationData.ReadForXY(x, y) Is Nothing
        Return LocationData.Create(x, y, LocationType.Floor)
    End Function
    Private Sub PlaceTable()
        Dim locationId = GenerateFloor()
        Dim featureId = FeatureData.Create(locationId, FeatureType.TableOfUn)
    End Sub
    Private Sub PlaceHammer()
        Dim item As New Item(ItemData.Create(ItemType.GrabtharsHammer))
        Dim location As New Location(GenerateFloor())
        location.Inventory.Add(item)
    End Sub
    Private Sub PlaceQuestItems()
        PlaceHammer()
    End Sub
    Sub Start()
        Store.Reset()
        Dim locationId = LocationData.Create(0, 0, LocationType.Floor)
        Dim characterId = CharacterData.Create(locationId, CharacterType.Player)
        PlayerData.WriteCharacterId(characterId)
        PlaceTable()
        'TODO: spawn enemy portal(s)
        PlaceQuestItems()
    End Sub
    Sub Finish()
        Store.ShutDown()
    End Sub
End Module
