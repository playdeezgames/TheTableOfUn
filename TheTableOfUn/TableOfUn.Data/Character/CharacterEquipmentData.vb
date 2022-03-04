Public Module CharacterEquipmentData
    Friend Sub Initialize()
        CharacterData.Initialize()
        ItemData.Initialize()
        ExecuteNonQuery(
            "CREATE TABLE IF NOT EXISTS [CharacterEquipment]
            (
                [CharacterId] INT NOT NULL,
                [EquipSlot] INT NOT NULL,
                [ItemId] INT NOT NULL,
                UNIQUE([CharacterId],[EquipSlot]),
                UNIQUE([ItemId]),
                FOREIGN KEY ([CharacterId]) REFERENCES [Characters]([CharacterId]),
                FOREIGN KEY ([ItemId]) REFERENCES [Items]([ItemId])
            );")
    End Sub
    Sub Write(characterId As Long, equipSlot As Integer, itemId As Long)
        Initialize()
        Using command = CreateCommand(
            "REPLACE INTO [CharacterEquipment]([CharacterId],[EquipSlot],[ItemId]) VALUES(@CharacterId,@EquipSlot,@ItemId);",
            MakeParameter("@CharacterId", characterId),
            MakeParameter("@EquipSlot", equipSlot),
            MakeParameter("@ItemId", itemId))
            command.ExecuteNonQuery()
        End Using
    End Sub
    Sub ClearForItem(itemId As Long)
        Initialize()
        Using command = CreateCommand("DELETE FROM [CharacterEquipment] WHERE [ItemId]=@ItemId;", MakeParameter("@ItemId", itemId))
            command.ExecuteNonQuery()
        End Using
    End Sub
    Function ReadForEquipSlot(characterId As Long, equipSlot As Integer) As Long?
        Initialize()
        Using command =
            CreateCommand(
            "SELECT [ItemId] FROM [CharacterEquipment] WHERE [CharacterId]=@CharacterId AND [EquipSlot]=@EquipSlot;",
            MakeParameter("@CharacterId", characterId),
            MakeParameter("@EquipSlot", equipSlot))
            Dim result = command.ExecuteScalar
            If result IsNot Nothing Then
                Return CType(result, Long)
            End If
            Return Nothing
        End Using
    End Function
    Function ReadForCharacter(characterId As Long) As Dictionary(Of Integer, Long)
        Initialize()
        Using command = CreateCommand("SELECT [EquipSlot],[ItemId] FROM [CharacterEquipment] WHERE [CharacterId]=@CharacterId;", MakeParameter("@CharacterId", characterId))
            Using reader = command.ExecuteReader
                Dim result As New Dictionary(Of Integer, Long)
                While reader.Read
                    result.Add(CInt(reader("EquipSlot")), CLng(reader("ItemId")))
                End While
                Return result
            End Using
        End Using
    End Function
End Module
