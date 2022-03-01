Imports System.Runtime.CompilerServices

Public Enum Direction
    North
    East
    South
    West
End Enum
Module DirectionExtensions
    <Extension()>
    Function NextX(direction As Direction, x As Integer) As Integer
        Select Case direction
            Case Direction.North, Direction.South
                Return x
            Case Direction.East
                Return x + 1
            Case Direction.West
                Return x - 1
            Case Else
                Throw New NotImplementedException()
        End Select
    End Function
    <Extension()>
    Function NextY(direction As Direction, y As Integer) As Integer
        Select Case direction
            Case Direction.East, Direction.West
                Return y
            Case Direction.South
                Return y + 1
            Case Direction.North
                Return y - 1
            Case Else
                Throw New NotImplementedException()
        End Select
    End Function
End Module
