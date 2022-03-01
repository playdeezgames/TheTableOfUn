Public Module FeatureData
    Friend Sub Initialize()
        ExecuteNonQuery(
            "CREATE TABLE IF NOT EXISTS [Features]
            (
                [FeatureId] INTEGER PRIMARY KEY AUTOINCREMENT,
                [LocationId] INT NOT NULL UNIQUE,
                [FeatureType] INT NOT NULL
            );")
    End Sub
    Function Create(locationId As Long, featureType As Integer) As Long
        Initialize()
        Using command = CreateCommand(
                "INSERT INTO [Features]([LocationId],[FeatureType]) VALUES(@LocationId,@FeatureType);",
                MakeParameter("@LocationId", locationId),
                MakeParameter("@FeatureType", featureType)
            )
            command.ExecuteNonQuery()
            Return LastInsertRowId
        End Using
    End Function
    Function ReadForLocation(locationId As Long) As Long?
        Initialize()
        Using command = CreateCommand(
            "SELECT [FeatureId] FROM [Features] WHERE [LocationId]=@LocationId;",
            MakeParameter("@LocationId", locationId))
            Dim result = command.ExecuteScalar
            If result IsNot Nothing Then
                Return CType(result, Long)
            End If
            Return Nothing
        End Using
    End Function
    Function ReadFeatureType(featureId As Long) As Integer?
        Initialize()
        Using command = CreateCommand(
            "SELECT [FeatureType] FROM [Features] WHERE [FeatureId]=@FeatureId;",
            MakeParameter("@FeatureId", featureId))
            Dim result = command.ExecuteScalar
            If result IsNot Nothing Then
                Return CType(result, Integer)
            End If
            Return Nothing
        End Using
    End Function
    Sub Clear(featureId As Long)
        Initialize()
        TableOfUnFeatureData.Clear(featureId)
        Using command = CreateCommand("DELETE FROM [Features] WHERE [FeatureId]=@FeatureId;", MakeParameter("@FeatureId", featureId))
            command.ExecuteNonQuery()
        End Using
    End Sub
End Module
