Imports TableOfUn.Data

Public Class PlayerCharacter
    Inherits Character
    Sub New()
        MyBase.New(PlayerData.ReadCharacterId().Value)
    End Sub
End Class
