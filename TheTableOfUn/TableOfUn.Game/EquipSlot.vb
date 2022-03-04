Imports System.Runtime.CompilerServices

Public Enum EquipSlot
    Weapon
End Enum
Public Module EquipSlotExtensions
    <Extension()>
    Function GetName(slot As EquipSlot) As String
        Select Case slot
            Case EquipSlot.Weapon
                Return "Weapon"
            Case Else
                Throw New NotImplementedException()
        End Select
    End Function
End Module