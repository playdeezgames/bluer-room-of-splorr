Imports BROS.Persistence

Friend Module SouthWestTownInitializer
    Friend Sub Initialize(location As ILocation)
#If DEBUG Then
        BluerRoomInitializer.PortalDestination = location
#End If
        location.SetName("southwest corner")
        location.SetDescription("This is the dead-end southwest corner of Quotidian.")
        location.CreateCharacter(AddressOf InitializeBeggar)
        location.World.CreateLocation(FrontYardInitializer.Initialize(location))
    End Sub

    Private Sub InitializeBeggar(character As ICharacter)
        character.SetName("beggar")
        character.AddNouns(Nouns.BEGGAR, Nouns.STREAMBOO)
        character.SetDescription("This is Streamboo, the local beggar. He begs.")
    End Sub
End Module
