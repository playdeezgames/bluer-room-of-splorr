Imports BROS.Persistence

Friend Module SouthWestTownInitializer
    Friend Function Initialize(context As IInitializationContext) As Action(Of ILocation)
        Return Sub(location)
                   context.PortalDestination = location
                   location.SetName("southwest corner")
                   location.SetDescription("This is the dead-end southwest corner of Quotidian.")
                   location.CreateCharacter(AddressOf InitializeBeggar)
                   context.SouthWestTownLocation = location
                   location.World.CreateLocation(FrontYardInitializer.Initialize(context))
                   location.CreateRoute(Directions.EAST, context.SouthTownLocation, AddressOf InitializeSouthEastRoad)
                   context.SouthTownLocation.CreateRoute(Directions.WEST, location, AddressOf InitializeSouthEastRoad)
               End Sub
    End Function

    Private Sub InitializeSouthEastRoad(route As IRoute)
        route.SetName("road")
        route.SetDescription("This is a road between the south end of town and the southwest corner of town.")
    End Sub

    Private Sub InitializeBeggar(character As ICharacter)
        character.SetName("beggar")
        character.AddNouns(Nouns.BEGGAR, Nouns.STREAMBOO)
        character.SetDescription("This is Streamboo, the local beggar. He begs.")
        character.CreateDialog(AddressOf InitializeSubsequentStreambooGreeting)
        character.CreateDialog(AddressOf InitializeInitialStreambooGreeting)
    End Sub

    Private Sub InitializeSubsequentStreambooGreeting(dialog As IDialog)
        dialog.Message = "Streamboo asks ""Where's my sprite?"""
        dialog.RequireTags(Tags.INITIAL_GREETING)
    End Sub

    Private Sub InitializeInitialStreambooGreeting(dialog As IDialog)
        dialog.Message = "Streamboo wakes up groggily. You introduce yerself. He tells you that he can provide you with the best viewers, but in exchange he will need a sprite."
        dialog.AddTags(Tags.INITIAL_GREETING)
    End Sub
End Module
