Imports BROS.Provision

Friend Class Item
    Inherits BROSEntity(Of ItemData)
    Implements IItem

    Private Sub New(world As IWorld, data As WorldData, itemId As Guid)
        MyBase.New(world, data)
        Me.ItemId = itemId
    End Sub

    Public ReadOnly Property ItemId As Guid Implements IItem.ItemId

    Protected Overrides ReadOnly Property Data As ItemData
        Get
            Return _data.Items(ItemId)
        End Get
    End Property

    Friend Shared Function Create(world As IWorld, data As WorldData, itemId As Guid) As IItem
        Return New Item(world, data, itemId)
    End Function
End Class
