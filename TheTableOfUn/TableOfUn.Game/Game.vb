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
    Public Sub PlacePortal()
        Dim locationId = LocationData.ReadForXY(0, 0).Value
        CreateFeature(locationId, FeatureType.Portal)
    End Sub
    Private Sub PlaceTable()
        Dim locationId = GenerateFloor()
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
    Friend Function CreateCharacter(locationId As Long, characterType As CharacterType) As Character
        Dim characterId = CharacterData.Create(locationId, characterType)
        Return New Character(characterId)
    End Function
    Sub Start()
        Store.Reset()
        Dim locationId = LocationData.Create(0, 0, LocationType.Floor)
        Dim character = CreateCharacter(locationId, CharacterType.Player)
        PlayerData.WriteCharacterId(character.Id)
        PlaceTable()
        PlaceQuestItems()
    End Sub
    Sub Finish()
        Store.ShutDown()
    End Sub
    Public Event PlaySfx As Action(Of Sfx)
    Sub Play(sfx As Sfx)
        RaiseEvent PlaySfx(sfx)
    End Sub
    Sub DoNothing(character As Character)
        'mission accomplished!
    End Sub
    Sub SaurianSwinoidTurn(character As Character)
        Dim direction = PickDirection()
        Dim nextLocation = character.Location.GetNeighbor(direction)
        If nextLocation.CanBeEnteredBy(character) Then
            character.Location = nextLocation
        End If
    End Sub
    Private nonplayerMovers As New Dictionary(Of CharacterType, Action(Of Character)) From
        {
            {CharacterType.None, AddressOf DoNothing},
            {CharacterType.Player, AddressOf DoNothing},
            {CharacterType.SaurianSwinoid, AddressOf SaurianSwinoidTurn}
        }
    Sub MoveNonplayers()
        Dim characterIds = CharacterData.All()
        For Each characterId In characterIds
            Dim character As New Character(characterId)
            nonplayerMovers(character.CharacterType).Invoke(character)
        Next
    End Sub
    Private directionGenerator As New Dictionary(Of Direction, Integer) From
        {{Direction.North, 1}, {Direction.South, 1}, {Direction.East, 1}, {Direction.West, 1}}
    Private Function PickDirection() As Direction
        Return RNG.FromGenerator(directionGenerator)
    End Function
End Module
