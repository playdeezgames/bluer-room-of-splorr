Imports BROS.Persistence

Friend Module FrontYardInitializer
    Private Sub LegacyInitialize(location As ILocation, townLocation As ILocation)
        location.SetName("Front yard")
        location.CreateFeature(AddressOf InitializeBush)
        location.World.CreateLocation(BluerRoomInitializer.Initialize(location))
        location.CreateRoute(Directions.NORTH, townLocation, AddressOf InitializeGate)
        townLocation.CreateRoute(Directions.SOUTH, location, AddressOf InitializeGate)
    End Sub

    Private Sub InitializeGate(route As IRoute)
        route.SetName("gate")
        route.SetDescription("This is the gate to the Bluer Room's front yard.")
    End Sub


    Private Sub InitializeBush(feature As IFeature)
        feature.SetName("Bush")
        feature.AddNouns(Nouns.BUSH)
        feature.SetDescription("It is a shrubbery. Not too expensive. You surmise that this is not a mulberry bush, for you see neither monkey nor weasel.")
        feature.Inventory.AddPrepositions(Prepositions.IN)
        feature.Inventory.CreateItem(AddressOf InitializeSwallow)
    End Sub

    Private Sub InitializeSwallow(item As IItem)
        item.SetName("Swallow")
        item.AddNouns(Nouns.BIRD, Nouns.SWALLOW)
        item.SetDescription("This is a swallow. The bird of true love.")
        item.SetTag(Tags.LUREABLE)
    End Sub

    Friend Function Initialize(townLocation As ILocation) As Action(Of ILocation)
        Return Sub(location)
                   LegacyInitialize(location, townLocation)
               End Sub
    End Function
End Module
