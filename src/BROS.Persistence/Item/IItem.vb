Public Delegate Sub ItemInitializer(item As IItem)
Public Interface IItem
    Inherits IBROSEntity
    ReadOnly Property ItemId As Guid
    Property Inventory As IInventory
    Property EquipSlot As IEquipSlot
    Sub Destroy()
End Interface
