Imports TGGD.Provision

Public Class BROSData
    Inherits EntityData
    Public Property AvatarId As Guid?
    Public Property Characters As New Dictionary(Of Guid, CharacterData)
End Class
