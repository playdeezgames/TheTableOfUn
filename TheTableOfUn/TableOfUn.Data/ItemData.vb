Public Module ItemData
    Friend Sub Initialize()
        ExecuteNonQuery(
            "CREATE TABLE IF NOT EXISTS [Items]
            (
                [ItemId] INTEGER PRIMARY KEY AUTOINCREMENT,
                [ItemType] INT NOT NULL
            );")
    End Sub
    Function Create(itemType As Integer) As Long
        Initialize()
        Using command = CreateCommand(
            "INSERT INTO [Items]([ItemType]) VALUES (@ItemType);",
            MakeParameter("@ItemType", itemType))
            command.ExecuteNonQuery()
            Return LastInsertRowId
        End Using
    End Function
    Function ReadItemType(itemId As Long) As Integer?
        Initialize()
        Using command = CreateCommand(
            "SELECT [ItemType] FROM [Items] WHERE [ItemId]=@ItemId;",
            MakeParameter("@ItemId", itemId))
            Dim result = command.ExecuteScalar
            If result IsNot Nothing Then
                Return CType(result, Integer)
            End If
            Return Nothing
        End Using
    End Function
End Module
