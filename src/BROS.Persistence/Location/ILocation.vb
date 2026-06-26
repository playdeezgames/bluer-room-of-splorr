Public Delegate Sub LocationInitializer(location As ILocation)
Public Interface ILocation
    Inherits IBROSEntity
    ReadOnly Property LocationId As Guid
    Function CreateCharacter(Optional initializer As CharacterInitializer = Nothing) As ICharacter
    Function CreateFeature(Optional initializer As FeatureInitializer = Nothing) As IFeature
    ReadOnly Property Features As IEnumerable(Of IFeature)
    ReadOnly Property Characters As IEnumerable(Of ICharacter)
    Function FindFeatureByNoun(noun As String) As IFeature
    Function CreateRoute(
                        direction As String,
                        destination As ILocation,
                        Optional initializer As RouteInitializer = Nothing) As IRoute
    ReadOnly Property Exits As IReadOnlyDictionary(Of String, IRoute)
    Function FindRouteByDirection(direction As String) As IRoute
    Function GetOtherCharacters(character As ICharacter) As IEnumerable(Of ICharacter)
    Function FindCharacterByNoun(noun As String) As ICharacter
End Interface
