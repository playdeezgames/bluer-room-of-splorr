Public Interface IRoute
    Inherits IBROSEntity
    ReadOnly Property RouteId As Guid
    ReadOnly Property DestinationLocation As ILocation
    Property KeyItem As IItem
End Interface
