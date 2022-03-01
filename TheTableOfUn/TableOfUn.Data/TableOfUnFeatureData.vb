Public Module TableOfUnFeatureData
    Friend Sub Initialize()
        FeatureData.Initialize()
        ExecuteNonQuery(
            "CREATE TABLE IF NOT EXISTS [TableOfUnFeatures]
            (
                [FeatureId] INT NOT NULL UNIQUE,
                [IsShimmed] INT NOT NULL,
                [CandleCount] INT NOT NULL,
                [HasBook] INT NOT NULL,
                FOREIGN KEY ([FeatureId]) REFERENCES [Features]([FeatureId])
            );")
    End Sub
    Sub Write(featureId As Long, isShimmed As Boolean, candleCount As Integer, hasBook As Boolean)
        Initialize()
        Using command = CreateCommand(
            "REPLACE INTO [TableOfUnFeatures]
            (
                [FeatureId],
                [IsShimmed],
                [CandleCount],
                [HasBook]
            ) 
            VALUES(@FeatureId,@IsShimmed,@CandleCount,@HasBook);",
            MakeParameter("@FeatureId", featureId),
            MakeParameter("@IsShimmed", isShimmed),
            MakeParameter("@CandleCount", candleCount),
            MakeParameter("@HasBook", hasBook))
            command.ExecuteNonQuery()
        End Using
    End Sub
    Function ReadIsShimmed(featureId As Long) As Boolean?
        Initialize()
        Using command = CreateCommand(
            "SELECT [IsShimmed] FROM [TableOfUnFeatures] WHERE [FeatureID]=@FeatureId;",
            MakeParameter("@FeatureId", featureId))
            Dim result = command.ExecuteScalar
            If result IsNot Nothing Then
                Return CType(result, Boolean)
            End If
            Return Nothing
        End Using
    End Function
    Sub WriteShimmed(featureId As Long, isShimmed As Boolean)
        Initialize()
        Using command = CreateCommand(
            "UPDATE [TableOfUnFeatures] SET [IsShimmed]=@IsShimmed WHERE [FeatureId]=@FeatureId;",
            MakeParameter("@FeatureId", featureId),
            MakeParameter("@IsShimmed", isShimmed))
            command.ExecuteNonQuery()
        End Using
    End Sub
End Module
