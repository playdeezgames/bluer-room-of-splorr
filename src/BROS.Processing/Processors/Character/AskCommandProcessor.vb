Imports BROS.Persistence

Friend Module AskCommandProcessor
    Friend Function Process(world As IWorld, tokens As Queue(Of String)) As CommandProcessorResult
        If tokens.Count <> 3 Then
            Return CommandProcessorResult.Invalid
        End If
        Dim characterNoun = tokens.Dequeue
        Dim character = world.Avatar
        Dim location = character.Location
        Dim target = location.FindCharacterByNoun(characterNoun)
        If target Is Nothing Then
            character.AddMessage($"{character.GetName} does not see anyone going by `{characterNoun}` here.")
            Return CommandProcessorResult.Processed
        End If
        Dim preposition = tokens.Dequeue
        If Not preposition.Equals(Prepositions.ABOUT, StringComparison.InvariantCultureIgnoreCase) Then
            Return CommandProcessorResult.Invalid
        End If
        Dim topicNoun = tokens.Single
        Dim topic As ITopic = target.FindTopicByNoun(topicNoun)
        If topic Is Nothing Then
            character.AddMessage($"{target.GetName} has nothing to say about {topicNoun}.")
            Return CommandProcessorResult.Processed
        End If
        character.AddMessage(topic.Message)
        Return CommandProcessorResult.Processed
    End Function
End Module
