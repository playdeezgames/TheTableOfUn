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
End Module
