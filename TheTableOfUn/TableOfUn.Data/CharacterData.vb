Public Module CharacterData
    Friend Sub Initialize()
        LocationData.Initialize()
        ExecuteNonQuery(
            "CREATE TABLE IF NOT EXISTS [Characters]
            (
                [CharacterId] INTEGER PRIMARY KEY AUTOINCREMENT,
                [LocationId] INT NOT NULL,
                FOREIGN KEY ([LocationId]) REFERENCES [Locations]([LocationId])
            );")
    End Sub
    Function ReadLocation(characterId As Long) As Long?
        Initialize()
        Using command = CreateCommand(
            "SELECT [LocationId] FROM [Characters] WHERE [CharacterId]=@CharacterId",
            MakeParameter("@CharacterId", characterId))
            Dim result = command.ExecuteScalar
            If result IsNot Nothing Then
                Return CType(result, Long)
            End If
            Return Nothing
        End Using
    End Function
    Function Create(locationId As Long) As Long
        Initialize()
        Using command = CreateCommand(
            "INSERT INTO [Characters]([LocationId]) VALUES (@LocationId);",
            MakeParameter("@LocationId", locationId))
            command.ExecuteNonQuery()
            Return LastInsertRowId
        End Using
    End Function
End Module
