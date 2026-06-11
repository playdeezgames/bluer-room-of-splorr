Public Interface IInventory
    ReadOnly Property InventoryId As Guid
    Function CreateItem(Optional initializer As Action(Of IItem) = Nothing) As IItem
    Sub AddPrepositions(ParamArray prepositions As String())
    ReadOnly Property Items As IEnumerable(Of IItem)
    Function HasPreposition(preposition As String) As Boolean
    Function FindItemByNoun(noun As String) As IItem
    ReadOnly Property DefaultPreposition As String
End Interface
