Imports BROS.Provision
Imports TGGD.Persistence
Imports TGGD.Provision

Friend MustInherit Class BROSEntity(Of TData As EntityData)
    Inherits Entity(Of TData)
    Implements IBROSEntity

    Public ReadOnly Property World As IWorld Implements IBROSEntity.World
    Protected _data As WorldData

    Protected Sub New(world As IWorld, data As WorldData)
        Me.World = world
        Me._data = data
    End Sub
End Class
