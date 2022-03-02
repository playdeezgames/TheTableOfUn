Public Module PlayerData
    Friend Sub Initialize()
        CharacterData.Initialize()
        ExecuteNonQuery(
            "CREATE TABLE IF NOT EXISTS [Players]
            (
                [PlayerId] INT NOT NULL UNIQUE,
                [CharacterId] INT NOT NULL,
                FOREIGN KEY ([CharacterId]) REFERENCES [Characters]([CharacterId])
                CHECK([PlayerId]=1)
            );")
    End Sub
    Function ReadCharacterId() As Long?
        Initialize()
        Using command = CreateCommand("SELECT [CharacterId] FROM [Players]")
            Dim result = command.ExecuteScalar
            If result IsNot Nothing Then
                Return CType(result, Long)
            End If
            Return Nothing
        End Using
    End Function
    Sub WriteCharacterId(characterId As Long)
        Initialize()
        Using command = CreateCommand("REPLACE INTO [Players]([PlayerId],[CharacterId]) VALUES(1, @CharacterId);")
            command.Parameters.AddWithValue("@CharacterId", characterId)
            command.ExecuteNonQuery()
        End Using
    End Sub
    Sub Clear()
        Initialize()
        Using command = CreateCommand("DELETE FROM [Players];")
            command.ExecuteNonQuery()
        End Using
    End Sub
End Module
