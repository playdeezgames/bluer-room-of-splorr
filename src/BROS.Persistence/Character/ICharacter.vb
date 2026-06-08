Public Interface ICharacter
    Inherits IBROSEntity
    ReadOnly Property CharacterId As Guid
    ReadOnly Property Location As ILocation
End Interface
