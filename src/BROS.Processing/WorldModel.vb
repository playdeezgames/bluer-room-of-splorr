Imports BROS.Persistence
Imports TGGD.Persistence
Imports TGGD.Processing

Public Class WorldModel
    Inherits BaseModel(Of IWorld)
    Implements IWorldModel

    Protected Sub New(entity As IWorld)
        MyBase.New(entity)
    End Sub

    Public Shared Async Function Create(quittable As Boolean, persister As IPersister) As Task(Of IWorldModel)
        Dim world As IWorld
        Try
            world = Await BROS.Persistence.World.Load(SAVE_FILE_NAME, persister)
        Catch ex As Exception
            world = BROS.Persistence.World.Create(New Provision.BROSData, persister)
        End Try
        If quittable Then
            world.SetTag(Tags.QUITTABLE)
        End If
        Return New WorldModel(world)
    End Function
End Class
