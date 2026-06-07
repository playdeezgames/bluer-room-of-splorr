Imports BROS.Provision
Imports TGGD.Persistence

Friend Class Location
    Inherits Entity(Of LocationData)
    Implements ILocation

    Private Sub New(data As BROSData, locationId As Guid)
        Me._data = data
        Me.LocationId = locationId
    End Sub

    Private ReadOnly _data As BROSData
    Public ReadOnly Property LocationId As Guid Implements ILocation.LocationId

    Protected Overrides ReadOnly Property Data As LocationData
        Get
            Return _data.Locations(LocationId)
        End Get
    End Property

    Public Function CreateCharacter() As ICharacter Implements ILocation.CreateCharacter
        Dim characterId = Guid.NewGuid
        _data.Characters(characterId) = New CharacterData With
            {
                .LocationId = LocationId
            }
        Return Character.Create(_data, characterId)
    End Function

    Friend Shared Function Create(data As BROSData, locationId As Guid) As ILocation
        Return New Location(data, locationId)
    End Function
End Class
