Public Interface ILocation
    Inherits IBROSEntity
    ReadOnly Property LocationId As Guid
    Function CreateCharacter(Optional initializer As Action(Of ICharacter) = Nothing) As ICharacter
End Interface
