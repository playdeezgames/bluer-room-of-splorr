Imports BROS.Persistence

Friend Module SouthWestTownInitializer
    Friend Function Initialize(southTownLocation As ILocation) As Action(Of ILocation)
        Return Sub(location)
#If DEBUG Then
                   BluerRoomInitializer.PortalDestination = location
#End If
                   location.SetName("southwest corner")
                   location.SetDescription("This is the dead-end southwest corner of Quotidian.")
                   location.CreateCharacter(AddressOf InitializeBeggar)
                   location.World.CreateLocation(FrontYardInitializer.Initialize(location))
                   location.CreateRoute(Directions.EAST, southTownLocation, AddressOf InitializeSouthEastRoad)
                   southTownLocation.CreateRoute(Directions.WEST, location, AddressOf InitializeSouthEastRoad)
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
        character.SetGreeting("Streamboo wakes up groggily. You introduce yerself. He tells you that he can provide you with the best viewers, but in exchange he will need a sprite.")
    End Sub
End Module
