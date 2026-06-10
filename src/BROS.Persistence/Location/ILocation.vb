Public Interface ILocation
    Inherits IBROSEntity
    ReadOnly Property LocationId As Guid
    Function CreateCharacter(Optional initializer As Action(Of ICharacter) = Nothing) As ICharacter
    Function CreateFeature(Optional initializer As Action(Of IFeature) = Nothing) As IFeature
End Interface
