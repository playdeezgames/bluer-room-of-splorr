Imports BROS.Persistence

Friend Module BluerRoomInitializer
    Friend Sub Initialize(location As ILocation)
        location.SetName("The Bluer Room")
        location.CreateCharacter(AddressOf InitializeN00b)
        location.CreateFeature(AddressOf InitializeTable)
    End Sub

    Private Sub InitializeTable(feature As IFeature)
        feature.SetName("table")
        feature.AddNouns(Nouns.TABLE)
        feature.SetDescription("It is an old table that only wobbles a little bit.")
        feature.Inventory.CreateItem(AddressOf InitializeNote)
        feature.Inventory.AddPrepositions(Prepositions.ON)
    End Sub

    Private Sub InitializeNote(item As IItem)
        item.SetName("Note from Yermom")
        item.AddNouns(Nouns.NOTE)
        item.SetDescription("The note reads: ""Hello! I woke up this morning to find that my tits were missing! I have gone to look them. - Yermom""")
    End Sub

    Private Sub InitializeN00b(character As ICharacter)
        character.SetName("Olen Kyrpa")
        character.SetTag(Tags.IS_AVATAR)
        character.World.Avatar = character
    End Sub
End Module
