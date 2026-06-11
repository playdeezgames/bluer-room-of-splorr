Public Interface IItem
    Inherits IBROSEntity
    ReadOnly Property ItemId As Guid
    Property Inventory As IInventory
End Interface
