
Imports TGGD.Persistence

Public Interface IWorld
    Inherits IEntity
    ReadOnly Property Avatar As ICharacter
    Function Save(filename As String) As Task
End Interface
