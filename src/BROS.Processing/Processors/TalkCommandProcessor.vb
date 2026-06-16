Imports BROS.Persistence

Friend Module TalkCommandProcessor
    Friend Function Process(world As IWorld, tokens As IEnumerable(Of String)) As CommandProcessorResult
        If tokens.Count <> 2 Then
            Return CommandProcessorResult.Invalid
        End If
        Dim preposition = tokens.First
        tokens = tokens.Skip(1)
        If Not preposition.Equals(Prepositions.TO, StringComparison.InvariantCultureIgnoreCase) Then
            Return CommandProcessorResult.Invalid
        End If
        Dim noun = tokens.Single
        Dim character = world.Avatar
        Dim location = character.Location
        Dim target = location.FindCharacterByNoun(noun)
        If target Is Nothing Then
            character.AddMessage($"{character.GetName()} sees no one called `{noun}` here.")
            Return CommandProcessorResult.Processed
        End If
        'TODO: other character response goes here!
        character.AddMessage($"{target.GetName()} does not respond.")
        Return CommandProcessorResult.Processed
    End Function
End Module
