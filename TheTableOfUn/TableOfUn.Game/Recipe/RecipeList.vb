Public Module RecipeList
    Public ReadOnly Recipes As New List(Of Recipe) From
        {
            New Recipe(
                New Dictionary(Of ItemType, Integer) From
                {
                    {ItemType.MissingPage, 3},
                    {ItemType.IncompleteBook, 1}
                },
                New Dictionary(Of ItemType, Integer) From
                {
                    {ItemType.Spellbook, 1}
                }),
            New Recipe(
                New Dictionary(Of ItemType, Integer) From
                {
                    {ItemType.Rock, 2}
                },
                New Dictionary(Of ItemType, Integer) From
                {
                    {ItemType.SharpRock, 1},
                    {ItemType.Rock, 1}
                })
        }

End Module
