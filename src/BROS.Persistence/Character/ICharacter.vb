Public Interface ICharacter
    Inherits IInventoryEntity
    ReadOnly Property CharacterId As Guid
    ReadOnly Property Location As ILocation
    Function CreateEquipSlot(initializer As Action(Of IEquipSlot)) As IEquipSlot
    Function FindEquipSlotByNoun(noun As String) As IEquipSlot
    ReadOnly Property EquipSlots As IEnumerable(Of IEquipSlot)
End Interface
