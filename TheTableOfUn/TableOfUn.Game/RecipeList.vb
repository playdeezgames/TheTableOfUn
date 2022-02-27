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
                })
        }

End Module
