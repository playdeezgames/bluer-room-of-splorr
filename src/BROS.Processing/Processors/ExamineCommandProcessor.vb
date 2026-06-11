Imports BROS.Persistence

Friend Module ExamineCommandProcessor
    Friend Function Process(world As IWorld, tokens As IEnumerable(Of String)) As CommandProcessorResult
        'EXAMINE [NOUN] - noun is found immediately in the location we are examining in
        'EXAMINE [NOUN1] [PREPOSITION] [NOUN2] - noun2 is part of the inventory of noun1, and preposition is associated with noun2
        If Not tokens.Any Then
            Return CommandProcessorResult.Invalid
        End If
        Dim noun = tokens.First
        tokens = tokens.Skip(1)
        If Not tokens.Any Then
            Return ProcessExamineLocation(world.Avatar, noun)
        ElseIf tokens.Count <> 2 Then
            Return CommandProcessorResult.Invalid
        End If
        Dim preposition = tokens.First
        tokens = tokens.Skip(1)
        Dim containerNoun = tokens.Single
        Return ProcessExamineContainer(world.Avatar, containerNoun, preposition, noun)
    End Function

    Private Function ProcessExamineContainer(character As ICharacter, containerNoun As String, preposition As String, noun As String) As CommandProcessorResult
        Return CommandProcessorResult.Invalid
    End Function

    Private Function ProcessExamineLocation(character As ICharacter, noun As String) As CommandProcessorResult
        character.World.ClearMessages()
        Dim feature = character.Location.FindFeatureByNoun(noun)
        If feature IsNot Nothing Then
            Return ProcessExamineLocationFeature(character, feature)
        End If
        character.AddMessage($"{character.GetName()} sees no `{noun}` here.")
        Return CommandProcessorResult.Processed
    End Function

    Private Function ProcessExamineLocationFeature(character As ICharacter, feature As IFeature) As CommandProcessorResult
        character.DescribeFeature(feature)
        Return CommandProcessorResult.Processed
    End Function
End Module
