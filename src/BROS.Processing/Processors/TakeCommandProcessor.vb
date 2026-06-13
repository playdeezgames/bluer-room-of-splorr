Imports BROS.Persistence

Friend Module TakeCommandProcessor
    Friend Function Process(world As IWorld, tokens As IEnumerable(Of String)) As CommandProcessorResult
        If tokens.Count <> 3 Then
            Return CommandProcessorResult.Invalid
        End If
        Dim noun = tokens.First
        tokens = tokens.Skip(1)
        Dim preposition = tokens.First
        If preposition <> Prepositions.FROM Then
            Return CommandProcessorResult.Invalid
        End If
        tokens = tokens.Skip(1)
        Dim containerNoun = tokens.Single
        Dim character = world.Avatar
        Dim feature = character.Location.FindFeatureByNoun(containerNoun)
        If feature Is Nothing Then
            character.AddMessage($"{character.GetName} sees no {containerNoun} here.")
            Return CommandProcessorResult.Processed
        End If
        Dim item = feature.Inventory.FindItemByNoun(noun)
        If item Is Nothing Then
            character.AddMessage($"{character.GetName} sees no {noun} here.")
            Return CommandProcessorResult.Processed
        End If
        character.AddMessage($"{character.GetName} takes {item.GetName}.")
        item.Inventory = character.Inventory
        Return CommandProcessorResult.Processed
    End Function
End Module
