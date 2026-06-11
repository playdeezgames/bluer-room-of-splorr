Imports BROS.Provision

Friend Class Inventory
    Implements IInventory
    Private Sub New(world As IWorld, data As WorldData, inventoryId As Guid)
        Me.world = world
        Me.InventoryId = inventoryId
        Me._data = data
    End Sub

    Private ReadOnly world As IWorld
    Public ReadOnly Property InventoryId As Guid Implements IInventory.InventoryId
    Private ReadOnly _data As WorldData
    Private ReadOnly Property Data As InventoryData
        Get
            Return _data.Inventories(InventoryId)
        End Get
    End Property

    Friend Shared Function Create(world As IWorld, data As WorldData, inventoryId As Guid) As IInventory
        Return New Inventory(world, data, inventoryId)
    End Function

    Public Function CreateItem(Optional initializer As Action(Of IItem) = Nothing) As IItem Implements IInventory.CreateItem
        Dim itemId As Guid = Guid.NewGuid
        _data.Items(itemId) = New ItemData()
        Dim result = Item.Create(world, _data, itemId)
        initializer?.Invoke(result)
        Return result
    End Function

    Public Sub AddPrepositions(ParamArray prepositions() As String) Implements IInventory.AddPrepositions
        For Each preposition In prepositions
            Data.Prepositions.Add(preposition.ToUpper)
        Next
    End Sub
End Class
