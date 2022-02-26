Public Module LocationInventoryData
    Friend Sub Initialize()
        LocationData.Initialize()
        InventoryData.Initialize()
        ExecuteNonQuery(
            "CREATE TABLE IF NOT EXISTS [LocationInventories]
            (
                [LocationId] INT NOT NULL UNIQUE,
                [InventoryId] INT NOT NULL UNIQUE,
                FOREIGN KEY ([LocationId]) REFERENCES [Locations]([LocationId]),
                FOREIGN KEY ([InventoryId]) REFERENCES [Inventories]([InventoryId])
            );")
    End Sub
    Function ReadForLocation(locationId As Long) As Long?
        Initialize()
        Using command = CreateCommand(
            "SELECT [InventoryId] FROM [LocationInventories] WHERE [LocationId]=@LocationId;",
            MakeParameter("@LocationId", locationId))
            Dim result = command.ExecuteScalar
            If result IsNot Nothing Then
                Return CType(result, Long)
            End If
            Return Nothing
        End Using
    End Function
    Sub Write(locationId As Long, inventoryId As Long)
        Initialize()
        Using command = CreateCommand(
            "INSERT INTO [LocationInventories]([LocationId],[InventoryId]) VALUES(@LocationId,@InventoryId);",
            MakeParameter("@LocationId", locationId),
            MakeParameter("@InventoryId", inventoryId))
            command.ExecuteNonQuery()
        End Using
    End Sub
End Module
