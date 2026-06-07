Imports BROS.Persistence

Friend Module BluerRoom
    Friend Sub Initialize(world As IWorld)
        Dim bluerRoom = world.CreateLocation()
        bluerRoom.SetName("The Bluer Room")
        Dim n00b = bluerRoom.CreateCharacter()
        n00b.SetName("Olen Kyrpa")
        world.Avatar = n00b
    End Sub
End Module
