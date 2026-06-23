Imports BROS.Persistence

Friend Module TownCenterInitializer
    Friend Function Initialize(context As IInitializationContext) As Action(Of ILocation)
        Return Sub(location)
                   location.SetName("Town Center")
                   location.SetDescription("This is the center of town.")
                   context.TownCenterLocation = location
                   location.World.CreateLocation(SouthTownInitializer.Initialize(context))
                   location.CreateFeature(AddressOf InitializeShrine)
               End Sub
    End Function

    Private Sub InitializeShrine(feature As IFeature)
        feature.SetName("shrine")
        feature.AddNouns(Nouns.SHRINE, Nouns.BUTTPLUG)
        feature.SetDescription("This is the memorial shrine for Captain Jack. He was a good kitty. RIP Jack. To be honest, however, the shrine does indeed look more than a little bit like a giant buttplug.")
    End Sub
End Module
