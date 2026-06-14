Imports BROS.Persistence

Friend Module BluerRoomInitializer
    Private Sub LegacyInitialize(location As ILocation, frontYard As ILocation)
        location.SetName("The Bluer Room")
        location.CreateCharacter(AddressOf InitializeN00b)
        location.CreateFeature(AddressOf InitializeTable)
        location.CreateRoute(Directions.OUT, frontYard, AddressOf InitializeExit)
        frontYard.CreateRoute(Directions.IN, location, AddressOf InitializeEntrance)
    End Sub

    Private Sub InitializeEntrance(route As IRoute)
        route.SetName("Entrance to the Bluer Room")
    End Sub

    Private Sub InitializeExit(route As IRoute)
        route.SetName("Exit from the Bluer Room")
    End Sub

    Private Sub InitializeTable(feature As IFeature)
        feature.SetName("table")
        feature.AddNouns(Nouns.TABLE)
        feature.SetDescription("It is an old table that only wobbles a little bit.")
        feature.Inventory.CreateItem(AddressOf InitializeNote)
        feature.Inventory.AddPrepositions(Prepositions.ON)
    End Sub

    Private Sub InitializeNote(item As IItem)
        item.SetName("Note from Yermom")
        item.AddNouns(Nouns.NOTE)
        item.SetDescription("The note reads: ""Hello! I woke up this morning to find that my tits were missing! I have gone to look them. - Yermom""")
    End Sub

    Private Sub InitializeN00b(character As ICharacter)
        character.SetName("Olen Kyrpa")
        character.SetTag(Tags.IS_AVATAR)
        character.CreateEquipSlot(AddressOf InitializeButthole)
        character.World.Avatar = character
    End Sub

    Private Sub InitializeButthole(equipSlot As IEquipSlot)
        equipSlot.SetName("butthole")
        equipSlot.AddNouns(Nouns.BUTTHOLE)
        equipSlot.AddPrepositions(Prepositions.IN)
        equipSlot.SetDescription("It's a butthole. It looks kinda like this: *.")
        equipSlot.CreateItem(AddressOf InitializeKey)
    End Sub

    Private Sub InitializeKey(item As IItem)
        item.SetName("key")
        item.AddNouns(Nouns.KEY)
        item.SetDescription("This key smells like poop. I wonder why. Quit sniffing it, and maybe go wash yer hands.")
    End Sub

    Friend Function Initialize(frontYard As ILocation) As Action(Of ILocation)
        Return Sub(location)
                   LegacyInitialize(location, frontYard)
               End Sub
    End Function
End Module
