Imports System.Runtime.CompilerServices

Public Enum EquipSlot
    Weapon
    Shield
    Legs
    Neck
End Enum
Public Module EquipSlotExtensions
    <Extension()>
    Function GetName(slot As EquipSlot) As String
        Select Case slot
            Case EquipSlot.Weapon
                Return "Weapon"
            Case EquipSlot.Shield
                Return "Shield"
            Case EquipSlot.Legs
                Return "Legs"
            Case EquipSlot.Neck
                Return "Neck"
            Case Else
                Throw New NotImplementedException()
        End Select
    End Function
End Module