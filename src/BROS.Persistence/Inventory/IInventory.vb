Public Interface IInventory
    ReadOnly Property InventoryId As Guid
    Function CreateItem(Optional initializer As Action(Of IItem) = Nothing) As IItem
End Interface
