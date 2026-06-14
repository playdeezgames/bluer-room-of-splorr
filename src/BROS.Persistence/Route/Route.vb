Imports BROS.Provision

Friend Class Route
    Inherits BROSEntity(Of RouteData)
    Implements IRoute

    Private Sub New(world As IWorld, data As WorldData, routeId As Guid)
        MyBase.New(world, data)
        Me.RouteId = routeId
    End Sub

    Public ReadOnly Property RouteId As Guid Implements IRoute.RouteId

    Public ReadOnly Property DestinationLocation As ILocation Implements IRoute.DestinationLocation
        Get
            Return Location.Create(World, _data, Data.DestinationLocationId)
        End Get
    End Property

    Protected Overrides ReadOnly Property Data As RouteData
        Get
            Return _data.Routes(RouteId)
        End Get
    End Property

    Friend Shared Function Create(world As IWorld, data As WorldData, routeId As Guid?) As IRoute
        If Not routeId.HasValue Then
            Return Nothing
        End If
        Return New Route(world, data, routeId.Value)
    End Function
End Class
