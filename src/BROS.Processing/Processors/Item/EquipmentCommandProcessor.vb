Imports BROS.Persistence

Friend Module EquipmentCommandProcessor
    Friend Function Process(world As IWorld, tokens As Queue(Of String)) As CommandProcessorResult
        If tokens.Count <> 0 Then
            Return CommandProcessorResult.Invalid
        End If
        Dim character = world.Avatar
        character.AddMessage($"{character.GetName}'s Equipment:")
        For Each equipSlot In character.EquipSlots
            Dim item = equipSlot.Item
            character.AddMessage($"{equipSlot.GetName}: {If(item IsNot Nothing, item.GetName, "Nothing")}")
        Next
        Return CommandProcessorResult.Processed
    End Function
End Module
