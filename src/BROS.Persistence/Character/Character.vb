Imports BROS.Provision

Friend Class Character
    Inherits InventoryEntity(Of CharacterData)
    Implements ICharacter

    Public Sub New(world As IWorld, data As WorldData, characterId As Guid)
        MyBase.New(world, data)
        Me.CharacterId = characterId
    End Sub

    Public ReadOnly Property CharacterId As Guid Implements ICharacter.CharacterId

    Public ReadOnly Property Location As ILocation Implements ICharacter.Location
        Get
            Return Persistence.Location.Create(World, _data, Data.LocationId)
        End Get
    End Property

    Protected Overrides ReadOnly Property Data As CharacterData
        Get
            Return _data.Characters(CharacterId)
        End Get
    End Property

    Public ReadOnly Property EquipSlots As IEnumerable(Of IEquipSlot) Implements ICharacter.EquipSlots
        Get
            Return Data.EquipSlotIds.Select(Function(x) EquipSlot.Create(World, _data, x))
        End Get
    End Property

    Friend Shared Function Create(world As IWorld, data As WorldData, characterId As Guid) As ICharacter
        Return New Character(world, data, characterId)
    End Function

    Public Function CreateEquipSlot(initializer As Action(Of IEquipSlot)) As IEquipSlot Implements ICharacter.CreateEquipSlot
        Dim equipSlotId = Guid.NewGuid
        _data.EquipSlots(equipSlotId) = New EquipSlotData With
            {
                .CharacterId = CharacterId
            }
        Dim result = EquipSlot.Create(World, _data, equipSlotId)
        initializer?.Invoke(result)
        AddEquipSlot(result)
        Return result
    End Function

    Private Sub AddEquipSlot(equipSlot As IEquipSlot)
        Data.EquipSlotIds.Add(equipSlot.EquipSlotId)
    End Sub

    Public Function FindEquipSlotByNoun(noun As String) As IEquipSlot Implements ICharacter.FindEquipSlotByNoun
        Return EquipSlots.FirstOrDefault(Function(x) x.HasNoun(noun))
    End Function
End Class
