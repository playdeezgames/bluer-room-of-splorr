Public Class CharacterData
    Inherits InventoryEntityData
    Public Property LocationId As Guid
    Public Property EquipSlotIds As New HashSet(Of Guid)
    Public Property DialogIds As New List(Of Guid)
End Class
