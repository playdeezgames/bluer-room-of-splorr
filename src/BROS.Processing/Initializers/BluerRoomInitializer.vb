Imports BROS.Persistence

Friend Module BluerRoomInitializer
    Friend Sub Initialize(location As ILocation)
        location.SetName("The Bluer Room")
        location.CreateCharacter(AddressOf InitializeN00b)
        location.CreateFeature(AddressOf InitializeTable)
    End Sub

    Private Sub InitializeTable(feature As IFeature)
        feature.SetName("table")
        feature.AddNouns("table")
        feature.SetDescription("It is an old table that only wobbles a little bit.")
        feature.Inventory.CreateItem(AddressOf InitializeNote)
    End Sub

    Private Sub InitializeNote(item As IItem)
        item.SetName("Note from Yermom")
    End Sub

    Private Sub InitializeN00b(character As ICharacter)
        character.SetName("Olen Kyrpa")
        character.SetTag(Tags.IS_AVATAR)
        character.World.Avatar = character
    End Sub
End Module
