Imports BROS.Persistence

Friend Module WorldInitializer
    Friend Sub InitializeWorld(world As IWorld)
        world.Abandon()
        Dim frontYard = world.CreateLocation(AddressOf FrontYardInitializer.Initialize)
        world.CreateLocation(BluerRoomInitializer.Initialize(frontYard))
        world.AddMessage("Welcome to The Bluer Room of SPLORR!!")
        world.Avatar.DescribeLocation()
    End Sub
End Module
