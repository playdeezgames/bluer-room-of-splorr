Public Interface ICharacter
    Inherits IInventoryEntity
    ReadOnly Property CharacterId As Guid
    ReadOnly Property Location As ILocation
End Interface
