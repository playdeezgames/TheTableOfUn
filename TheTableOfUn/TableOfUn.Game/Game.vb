Imports TableOfUn.Data

Public Module Game
    Private Function GenerateFloor() As Long
        Dim x As Integer
        Dim y As Integer
        Do
            x = RNG.FromRange(-50, 50)
            y = RNG.FromRange(-50, 50)
        Loop While x > -10 AndAlso y > -10 AndAlso x < 10 AndAlso y < 10 AndAlso LocationData.ReadForXY(x, y) Is Nothing
        Return LocationData.Create(x, y, LocationType.Floor)
    End Function
    Friend Function CreateFeature(locationId As Long, featureType As FeatureType) As Feature
        Dim featureId = FeatureData.Create(locationId, featureType)
        Select Case featureType
            Case FeatureType.TableOfUn
                TableOfUnFeatureData.Write(featureId, False, 0, False)
        End Select
        Return New Feature(featureId)
    End Function
    Private Sub PlaceTable()
        Dim locationId = GenerateFloor()
        'Dim locationId = LocationData.Create(10, 10, LocationType.Floor)
        CreateFeature(locationId, FeatureType.TableOfUn)
    End Sub
    Friend Function CreateItem(itemType As ItemType) As Item
        Return New Item(ItemData.Create(itemType))
    End Function
    Private Sub PlaceHammer()
        Dim item = CreateItem(ItemType.GrabtharsHammer)
        Dim location As New Location(GenerateFloor())
        location.Inventory.Add(item)
    End Sub
    Private Sub PlaceShim()
        Dim item = CreateItem(ItemType.Shim)
        Dim location As New Location(GenerateFloor())
        location.Inventory.Add(item)
    End Sub
    Private Sub PlaceCandle()
        Dim item = CreateItem(ItemType.Candle)
        Dim location As New Location(GenerateFloor())
        location.Inventory.Add(item)
    End Sub
    Private Sub PlacePage()
        Dim item = CreateItem(ItemType.MissingPage)
        Dim location As New Location(GenerateFloor())
        location.Inventory.Add(item)
    End Sub
    Private Sub PlaceBook()
        Dim item = CreateItem(ItemType.IncompleteBook)
        Dim location As New Location(GenerateFloor())
        location.Inventory.Add(item)
    End Sub
    Private Sub PlaceQuestItems()
        PlaceHammer()
        PlaceShim()
        PlaceCandle()
        PlaceCandle()
        PlaceCandle()
        PlaceCandle()
        PlacePage()
        PlacePage()
        PlacePage()
        PlaceBook()
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
    Public Event PlaySfx As Action(Of Sfx)
    Sub Play(sfx As Sfx)
        RaiseEvent PlaySfx(sfx)
    End Sub
End Module
