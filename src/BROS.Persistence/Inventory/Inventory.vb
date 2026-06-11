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

    Public ReadOnly Property Items As IEnumerable(Of IItem) Implements IInventory.Items
        Get
            Return Data.ItemIds.Select(Function(x) Item.Create(world, _data, x))
        End Get
    End Property

    Public ReadOnly Property DefaultPreposition As String Implements IInventory.DefaultPreposition
        Get
            Return Data.Prepositions.First
        End Get
    End Property

    Friend Shared Function Create(world As IWorld, data As WorldData, inventoryId As Guid) As IInventory
        Return New Inventory(world, data, inventoryId)
    End Function

    Public Function CreateItem(Optional initializer As Action(Of IItem) = Nothing) As IItem Implements IInventory.CreateItem
        Dim itemId As Guid = Guid.NewGuid
        _data.Items(itemId) = New ItemData With
            {
                .InventoryId = InventoryId
            }
        Dim result = Item.Create(world, _data, itemId)
        initializer?.Invoke(result)
        AddItem(result)
        Return result
    End Function

    Private Sub AddItem(item As IItem)
        Data.ItemIds.Add(item.ItemId)
    End Sub

    Public Sub AddPrepositions(ParamArray prepositions() As String) Implements IInventory.AddPrepositions
        For Each preposition In prepositions
            Data.Prepositions.Add(preposition.ToUpper)
        Next
    End Sub

    Public Function HasPreposition(preposition As String) As Boolean Implements IInventory.HasPreposition
        Return Data.Prepositions.Contains(preposition.ToUpper)
    End Function

    Public Function FindItemByNoun(noun As String) As IItem Implements IInventory.FindItemByNoun
        Return Items.FirstOrDefault(Function(x) x.HasNoun(noun))
    End Function
End Class
