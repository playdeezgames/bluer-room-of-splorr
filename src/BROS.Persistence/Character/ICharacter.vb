Public Interface ICharacter
    Inherits IInventoryEntity
    ReadOnly Property CharacterId As Guid
    ReadOnly Property Location As ILocation
    Function CreateEquipSlot(initializer As Action(Of IEquipSlot)) As IEquipSlot
End Interface
