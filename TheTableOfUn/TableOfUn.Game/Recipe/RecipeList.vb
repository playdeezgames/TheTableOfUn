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
                }),
            New Recipe(
                New Dictionary(Of ItemType, Integer) From
                {
                    {ItemType.Hide, 4},
                    {ItemType.Bone, 4},
                    {ItemType.Needle, 1},
                    {ItemType.LeatherCord, 1}
                },
                New Dictionary(Of ItemType, Integer) From
                {
                    {ItemType.Shield, 1},
                    {ItemType.Needle, 1}
                }),
            New Recipe(
                New Dictionary(Of ItemType, Integer) From
                {
                    {ItemType.Hide, 4},
                    {ItemType.Needle, 1},
                    {ItemType.LeatherCord, 2}
                },
                New Dictionary(Of ItemType, Integer) From
                {
                    {ItemType.Trousers, 1},
                    {ItemType.Needle, 1}
                }),
            New Recipe(
                New Dictionary(Of ItemType, Integer) From
                {
                    {ItemType.Hide, 1},
                    {ItemType.SharpRock, 1}
                },
                New Dictionary(Of ItemType, Integer) From
                {
                    {ItemType.LeatherCord, 1},
                    {ItemType.SharpRock, 1}
                }),
            New Recipe(
                New Dictionary(Of ItemType, Integer) From
                {
                    {ItemType.Tusk, 2}
                },
                New Dictionary(Of ItemType, Integer) From
                {
                    {ItemType.Tusk, 1},
                    {ItemType.Needle, 1}
                }),
            New Recipe(
                New Dictionary(Of ItemType, Integer) From
                {
                    {ItemType.Tusk, 12},
                    {ItemType.LeatherCord, 1},
                    {ItemType.Needle, 1}
                },
                New Dictionary(Of ItemType, Integer) From
                {
                    {ItemType.Necklace, 1},
                    {ItemType.Needle, 1}
                })
        }

End Module
