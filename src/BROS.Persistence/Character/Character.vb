Imports BROS.Provision

Friend Class Character
    Inherits BROSEntity(Of CharacterData)
    Implements ICharacter

    Public Sub New(world As IWorld, data As WorldData, characterId As Guid)
        MyBase.New(world, data)
        Me.CharacterId = characterId
    End Sub

    Public ReadOnly Property CharacterId As Guid Implements ICharacter.CharacterId

    Public ReadOnly Property Location As ILocation Implements ICharacter.Location
        Get
            Return Persistence.Location.Create(World, _data, Data.LocationId)
        End Get
    End Property

    Protected Overrides ReadOnly Property Data As CharacterData
        Get
            Return _data.Characters(CharacterId)
        End Get
    End Property

    Friend Shared Function Create(world As IWorld, data As WorldData, characterId As Guid) As ICharacter
        Return New Character(world, data, characterId)
    End Function
End Class
