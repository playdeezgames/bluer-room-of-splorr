Public Class CharacterData
    Inherits InventoryEntityData
    Public Property LocationId As Guid
    Public Property EquipSlotIds As New HashSet(Of Guid)
End Class
