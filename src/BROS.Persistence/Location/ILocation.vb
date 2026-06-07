Imports TGGD.Persistence

Public Interface ILocation
    Inherits IEntity
    ReadOnly Property LocationId As Guid
    Function CreateCharacter() As ICharacter
End Interface
