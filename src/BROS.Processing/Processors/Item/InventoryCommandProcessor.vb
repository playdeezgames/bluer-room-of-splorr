Imports BROS.Persistence

Friend Module InventoryCommandProcessor
    Friend Function Process(world As IWorld, tokens As IEnumerable(Of String)) As CommandProcessorResult
        If tokens.Any Then
            Return CommandProcessorResult.Invalid
        End If
        Dim character = world.Avatar
        Dim items = character.Inventory.Items
        If Not items.Any Then
            character.AddMessage($"{character.GetName} is carrying no items.")
            Return CommandProcessorResult.Processed
        End If
        character.AddMessage($"{character.GetName} is carrying {String.Join(", ", items.Select(Function(x) x.GetName))}.")
        Return CommandProcessorResult.Processed
    End Function
End Module
