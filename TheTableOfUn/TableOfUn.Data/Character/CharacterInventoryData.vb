Public Module CharacterInventoryData
    Friend Sub Initialize()
        CharacterData.Initialize()
        InventoryData.Initialize()
        ExecuteNonQuery(
            "CREATE TABLE IF NOT EXISTS [CharacterInventories]
            (
                [CharacterId] INT NOT NULL UNIQUE,
                [InventoryId] INT NOT NULL UNIQUE,
                FOREIGN KEY ([CharacterId]) REFERENCES [Characters]([CharacterId]),
                FOREIGN KEY ([InventoryId]) REFERENCES [Inventories]([InventoryId])
            );")
    End Sub
    Function ReadForCharacter(characterId As Long) As Long?
        Initialize()
        Using command = CreateCommand(
            "SELECT [InventoryId] FROM [CharacterInventories] WHERE [CharacterId]=@CharacterId;",
            MakeParameter("@CharacterId", characterId))
            Dim result = command.ExecuteScalar
            If result IsNot Nothing Then
                Return CType(result, Long)
            End If
            Return Nothing
        End Using
    End Function
    Sub Write(characterId As Long, inventoryId As Long)
        Initialize()
        Using command = CreateCommand(
            "INSERT INTO [CharacterInventories]([CharacterId],[InventoryId]) VALUES(@CharacterId,@InventoryId);",
            MakeParameter("@CharacterId", characterId),
            MakeParameter("@InventoryId", inventoryId))
            command.ExecuteNonQuery()
        End Using
    End Sub
    Sub ClearForCharacter(characterId As Long)
        Initialize()
        Using command = CreateCommand(
            "DELETE FROM [CharacterInventories] WHERE [CharacterId]=@CharacterId;",
            MakeParameter("@CharacterId", characterId))
            command.ExecuteNonQuery()

        End Using
    End Sub
End Module
