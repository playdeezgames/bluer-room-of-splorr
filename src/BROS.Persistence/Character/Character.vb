Imports BROS.Provision
Imports TGGD.Persistence

Friend Class Character
    Inherits Entity(Of CharacterData)
    Implements ICharacter

    Public Sub New(data As BROSData, characterId As Guid)
        Me._data = data
        Me.CharacterId = characterId
    End Sub

    Private _data As BROSData
    Public ReadOnly Property CharacterId As Guid Implements ICharacter.CharacterId

    Protected Overrides ReadOnly Property Data As CharacterData
        Get
            Return _data.Characters(CharacterId)
        End Get
    End Property

    Friend Shared Function Create(data As BROSData, characterId As Guid) As ICharacter
        Return New Character(data, characterId)
    End Function
End Class
