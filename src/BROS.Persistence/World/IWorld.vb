
Imports TGGD.Persistence

Public Interface IWorld
    Inherits IEntity
    Property Avatar As ICharacter
    Function Save(filename As String) As Task
    Function CreateLocation() As ILocation
End Interface
