Imports System.Text.Json
Imports BROS.Provision
Imports TGGD.Persistence

Public Class World
    Inherits Entity(Of BROSData)
    Implements IWorld

    Private Sub New(data As BROSData, persister As IPersister)
        Me.Data = data
        Me.persister = persister
    End Sub

    Protected Overrides ReadOnly Property Data As BROSData

    Public ReadOnly Property Avatar As ICharacter Implements IWorld.Avatar
        Get
            Return If(Data.AvatarId.HasValue, Character.Create(Data, Data.AvatarId.Value), Nothing)
        End Get
    End Property

    Private ReadOnly persister As IPersister

    Public Function Save(filename As String) As Task Implements IWorld.Save
        Throw New NotImplementedException()
    End Function

    Public Shared Function Create(data As BROSData, persister As IPersister) As IWorld
        Return New World(data, persister)
    End Function

    Public Shared Async Function Load(filename As String, persister As IPersister) As Task(Of IWorld)
        Return New World(JsonSerializer.Deserialize(Of BROSData)(Await persister.LoadAsync(filename)), persister)
    End Function
End Class
