Public Interface ILocation
    Inherits IBROSEntity
    ReadOnly Property LocationId As Guid
    Function CreateCharacter(Optional initializer As Action(Of ICharacter) = Nothing) As ICharacter
    Function CreateFeature(Optional initializer As Action(Of IFeature) = Nothing) As IFeature
    ReadOnly Property Features As IEnumerable(Of IFeature)
    ReadOnly Property Characters As IEnumerable(Of ICharacter)
    Function FindFeatureByNoun(noun As String) As IFeature
End Interface
