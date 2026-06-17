Imports BROS.Persistence

Friend Module SouthTownInitializer
    Friend Sub Initialize(location As ILocation)
        location.SetName("South End")
        location.SetDescription("This is the south end of town.")
        location.World.CreateLocation(SouthWestTownInitializer.Initialize(location))
        location.CreateCharacter(AddressOf InitializeTempleGuard)
    End Sub

    Private Sub InitializeTempleGuard(character As ICharacter)
        character.SetName("temple guard")
        character.AddNouns("guard")
        character.SetDescription("This is the guard to the Temple of the Perfect Fit. He is wearing a corset that is too tight, and a little too much rouge. His shapely legs are incredibly hairy and clad in fishnet stockings.")
        character.CreateDialog(AddressOf InitializeTempleGuardDialog)
    End Sub

    Private Sub InitializeTempleGuardDialog(dialog As IDialog)
        dialog.Message = "The guard says ""The temple has a dress code. Corsets are required. Fishnets are optional, but highly encouraged. High heels are alway nice, especially shiny red ones. I could loan you a pair."""
    End Sub
End Module
