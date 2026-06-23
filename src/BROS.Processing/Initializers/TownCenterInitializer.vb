Imports BROS.Persistence

Friend Module TownCenterInitializer
    Friend Function Initialize(context As IInitializationContext) As Action(Of ILocation)
        Return Sub(location)
                   location.SetName("Town Center")
                   location.SetDescription("This is the center of town.")
                   context.TownCenterLocation = location
                   location.World.CreateLocation(SouthTownInitializer.Initialize(context))
               End Sub
    End Function
End Module
