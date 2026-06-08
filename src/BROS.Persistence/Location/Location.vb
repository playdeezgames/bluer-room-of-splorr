Imports BROS.Provision

Friend Class Location
    Inherits BROSEntity(Of LocationData)
    Implements ILocation

    Private Sub New(world As IWorld, data As WorldData, locationId As Guid)
        MyBase.New(world, data)
        Me.LocationId = locationId
    End Sub

    Public ReadOnly Property LocationId As Guid Implements ILocation.LocationId

    Protected Overrides ReadOnly Property Data As LocationData
        Get
            Return _data.Locations(LocationId)
        End Get
    End Property

    Public Function CreateCharacter(Optional initializer As Action(Of ICharacter) = Nothing) As ICharacter Implements ILocation.CreateCharacter
        Dim characterId = Guid.NewGuid
        _data.Characters(characterId) = New CharacterData With
            {
                .LocationId = LocationId
            }
        Dim result = Character.Create(World, _data, characterId)
        initializer?.Invoke(result)
        Return result
    End Function

    Friend Shared Function Create(world As IWorld, data As WorldData, locationId As Guid) As ILocation
        Return New Location(world, data, locationId)
    End Function
End Class
