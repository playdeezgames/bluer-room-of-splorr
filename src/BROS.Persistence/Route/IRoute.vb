Public Delegate Sub RouteInitializer(route As IRoute)
Public Interface IRoute
    Inherits IBROSEntity
    ReadOnly Property RouteId As Guid
    ReadOnly Property DestinationLocation As ILocation
    Function CreateLock(item As IItem, Optional initializer As LockInitializer = Nothing) As ILock
    Sub DestroyLock()
    ReadOnly Property Lock As ILock
End Interface
