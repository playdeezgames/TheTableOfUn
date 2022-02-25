Public Module LocationData
    Friend Sub Initialize()
        ExecuteNonQuery(
            "CREATE TABLE IF NOT EXISTS [Locations]
            (
                [LocationId] INTEGER PRIMARY KEY,
                [X] INT NOT NULL,
                [Y] INT NOT NULL,
                UNIQUE([X],[Y])
            );")
    End Sub
    Function Create(x As Integer, y As Integer) As Long
        Initialize()
        Using command = CreateCommand("INSERT INTO [Locations]([X],[Y]) VALUES (@X,@Y);")
            command.Parameters.AddWithValue("@X", x)
            command.Parameters.AddWithValue("@Y", y)
            command.ExecuteNonQuery()
            Return LastInsertRowId
        End Using
    End Function
    Function ReadX(locationId As Long) As Integer?
        Initialize()
        Using command = CreateCommand(
            "SELECT [X] FROM [Locations] WHERE [LocationId]=@LocationId",
            MakeParameter("@LocationId", locationId))
            Dim result = command.ExecuteScalar
            If result IsNot Nothing Then
                Return CType(result, Integer)
            End If
            Return Nothing
        End Using
    End Function
    Function ReadY(locationId As Long) As Integer?
        Initialize()
        Using command = CreateCommand(
            "SELECT [Y] FROM [Locations] WHERE [LocationId]=@LocationId",
            MakeParameter("@LocationId", locationId))
            Dim result = command.ExecuteScalar
            If result IsNot Nothing Then
                Return CType(result, Integer)
            End If
            Return Nothing
        End Using
    End Function
    Function ReadForXY(x As Integer, y As Integer) As Long?
        Initialize()
        Using command = CreateCommand(
            "SELECT [LocationId] FROM [Locations] WHERE [X]=@X AND [Y]=@Y;",
            MakeParameter("@X", x),
            MakeParameter("@Y", y))
            Dim result = command.ExecuteScalar
            If result IsNot Nothing Then
                Return CType(result, Long)
            End If
            Return Nothing
        End Using
    End Function
End Module
