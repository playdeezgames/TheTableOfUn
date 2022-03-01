Public Module CharacterData
    Friend Sub Initialize()
        LocationData.Initialize()
        ExecuteNonQuery(
            "CREATE TABLE IF NOT EXISTS [Characters]
            (
                [CharacterId] INTEGER PRIMARY KEY AUTOINCREMENT,
                [LocationId] INT NOT NULL UNIQUE,
                [CharacterType] INT NOT NULL,
                [DidWinninate] INT NOT NULL,
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
    Sub WriteLocation(characterId As Long, locationId As Long)
        Initialize()
        Using command = CreateCommand(
            "UPDATE [Characters] SET [LocationId]=@LocationId WHERE [CharacterId]=@CharacterId;",
            MakeParameter("@CharacterId", characterId),
            MakeParameter("@LocationId", locationId))
            command.ExecuteNonQuery()
        End Using
    End Sub
    Function ReadCharacterType(characterId As Long) As Integer?
        Initialize()
        Using command = CreateCommand("SELECT [CharacterType] FROM [Characters] WHERE [CharacterId]=@CharacterId;", MakeParameter("@CharacterId", characterId))
            Dim result = command.ExecuteScalar
            If result IsNot Nothing Then
                Return CType(result, Integer)
            End If
            Return Nothing
        End Using
    End Function
    Function ReadForLocation(locationId As Long) As Long?
        Initialize()
        Using command = CreateCommand(
            "SELECT [CharacterId] FROM [Characters] WHERE [LocationId]=@LocationId",
            MakeParameter("@LocationId", locationId))
            Dim result = command.ExecuteScalar
            If result IsNot Nothing Then
                Return CType(result, Long)
            End If
            Return Nothing
        End Using
    End Function
    Function Create(locationId As Long, characterType As Integer) As Long
        Initialize()
        Using command = CreateCommand(
            "INSERT INTO [Characters]([LocationId],[CharacterType],[DidWinninate]) VALUES (@LocationId,@CharacterType,0);",
            MakeParameter("@LocationId", locationId),
            MakeParameter("@CharacterType", characterType))
            command.ExecuteNonQuery()
            Return LastInsertRowId
        End Using
    End Function
    Function ReadDidWinninate(characterId As Long) As Boolean?
        Initialize()
        Using command = CreateCommand(
            "SELECT [DidWinninate] FROM [Characters] WHERE [CharacterId]=@CharacterId;",
            MakeParameter("@CharacterId", characterId))
            Dim result = command.ExecuteScalar
            If result IsNot Nothing Then
                Return CType(result, Boolean)
            End If
            Return Nothing
        End Using
    End Function
    Sub WriteDidWinninate(characterId As Long, didWinninated As Boolean)
        Initialize()
        Using command = CreateCommand(
            "UPDATE [Characters] SET [DidWinninate]=@DidWinninate WHERE [CharacterId]=@CharacterId;",
            MakeParameter("@CharacterId", characterId),
            MakeParameter("@DidWinninate", didWinninated))
            command.ExecuteNonQuery()
        End Using
    End Sub
End Module
