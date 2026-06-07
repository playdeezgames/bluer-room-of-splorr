Imports TGGD.Processing

Public Interface IWorldModel
    Inherits IModel
    ReadOnly Property IsInPlay As Boolean
    ReadOnly Property IsQuittable As Boolean
    Sub Embark()
End Interface
