Imports TGGD.Provision

Public Class WorldData
    Inherits EntityData
    Public Property AvatarId As Guid?
    Public Property Characters As New Dictionary(Of Guid, CharacterData)
    Public Property Locations As New Dictionary(Of Guid, LocationData)
    Public Property Messages As New List(Of MessageData)
    Public Property Features As New Dictionary(Of Guid, FeatureData)
End Class
