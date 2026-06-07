Imports System.Runtime.CompilerServices
Imports BROS.Persistence

Friend Module WorldExtensions
    <Extension>
    Friend Sub Abandon(world As IWorld)
        Dim isQuittable = world.HasTag(Tags.QUITTABLE)
        world.Clear()
        If isQuittable Then
            world.SetTag(Tags.QUITTABLE)
        End If
    End Sub
    <Extension>
    Friend Sub Initialize(world As IWorld)
        world.Abandon()
        BluerRoom.Initialize(world)
    End Sub
End Module
