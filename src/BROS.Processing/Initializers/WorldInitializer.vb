Imports BROS.Persistence

Friend Module WorldInitializer
    Friend Sub InitializeWorld(world As IWorld)
        world.Abandon()
        world.CreateLocation(AddressOf BluerRoomInitializer.Initialize)
        world.AddMessage("Welcome to The Bluer Room of SPLORR!!")
        world.Avatar.DescribeLocation()
    End Sub
End Module
