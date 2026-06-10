Imports BROS.Persistence

Friend Module BluerRoomInitializer
    Friend Sub Initialize(location As ILocation)
        location.SetName("The Bluer Room")
        location.CreateCharacter(AddressOf InitializeN00b)
        location.CreateFeature(AddressOf InitializeTable)
    End Sub

    Private Sub InitializeTable(feature As IFeature)
        feature.SetName("table")
    End Sub

    Private Sub InitializeN00b(character As ICharacter)
        character.SetName("Olen Kyrpa")
        character.SetTag(Tags.IS_AVATAR)
        character.World.Avatar = character
    End Sub
End Module
