Public Delegate Sub FeatureInitializer(feature As IFeature)
Public Interface IFeature
    Inherits IInventoryEntity
    ReadOnly Property FeatureId As Guid
End Interface
