Public Module InventoryItemData
    Friend Sub Initialize()
        ItemData.Initialize()
        InventoryData.Initialize()
        ExecuteNonQuery(
            "CREATE TABLE IF NOT EXISTS [InventoryItems]
            (
                [ItemId] INT NOT NULL UNIQUE,
                [InventoryId] INT NOT NULL,
                FOREIGN KEY ([ItemId]) REFERENCES [Items]([ItemId]),
                FOREIGN KEY ([InventoryId]) REFERENCES [Inventories]([InventoryId])
            );")
    End Sub
    Sub Write(itemId As Long, inventoryId As Long)
        Initialize()
        Using command = CreateCommand(
            "REPLACE INTO [InventoryItems]([ItemId],[InventoryId]) VALUES(@ItemId,@InventoryId);",
            MakeParameter("@ItemId", itemId),
            MakeParameter("@InventoryId", inventoryId))
            command.ExecuteNonQuery()
        End Using
    End Sub
    Function ReadTop(inventoryId As Long) As Long?
        Initialize()
        Using command = CreateCommand("SELECT [ItemId] FROM [InventoryItems] WHERE [InventoryId]=@InventoryId;", MakeParameter("@InventoryId", inventoryId))
            Dim result = command.ExecuteScalar
            If result IsNot Nothing Then
                Return CType(result, Long)
            End If
            Return Nothing
        End Using
    End Function
    Function Read(inventoryId As Long) As List(Of Long)
        Initialize()
        Using command = CreateCommand("SELECT [ItemId] FROM [InventoryItems] WHERE [InventoryId]=@InventoryId;", MakeParameter("@InventoryId", inventoryId))
            Dim result As New List(Of Long)
            Using reader = command.ExecuteReader
                While reader.Read
                    result.Add(CType(reader("ItemId"), Long))
                End While
            End Using
            Return result
        End Using
    End Function
End Module
