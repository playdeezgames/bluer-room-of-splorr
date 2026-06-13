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

    Private Function ProcessExamineContainer(
                                            character As ICharacter,
                                            containerNoun As String,
                                            preposition As String,
                                            noun As String) As CommandProcessorResult
        Dim feature = character.Location.FindFeatureByNoun(containerNoun)
        If feature IsNot Nothing Then
            Return ProcessExamineContainerFeature(character, feature, preposition, noun)
        End If
        Return CommandProcessorResult.Invalid
    End Function

    Private Function ProcessExamineContainerFeature(character As ICharacter, feature As IFeature, preposition As String, noun As String) As CommandProcessorResult
        If Not feature.Inventory.HasPreposition(preposition) Then
            Return CommandProcessorResult.Invalid
        End If
        Return ProcessExamineItem(character, feature.Inventory.FindItemByNoun(noun), noun)
    End Function

    Private Function ProcessExamineItem(character As ICharacter, item As IItem, noun As String) As CommandProcessorResult
        If item Is Nothing Then
            character.AddMessage($"{character.GetName()} sees no `{noun}` here.")
            Return CommandProcessorResult.Processed
        End If
        character.DescribeItem(item)
        Return CommandProcessorResult.Processed
    End Function

    Private Function ProcessExamineLocation(character As ICharacter, noun As String) As CommandProcessorResult
        character.World.ClearMessages()
        Dim feature = character.Location.FindFeatureByNoun(noun)
        If feature IsNot Nothing Then
            Return ProcessExamineFeature(character, feature)
        End If
        Dim item = character.Inventory.FindItemByNoun(noun)
        If item IsNot Nothing Then
            Return ProcessExamineItem(character, item, noun)
        End If
        character.AddMessage($"{character.GetName()} sees no `{noun}` here.")
        Return CommandProcessorResult.Processed
    End Function

    Private Function ProcessExamineFeature(character As ICharacter, feature As IFeature) As CommandProcessorResult
        character.DescribeFeature(feature)
        Dim items = feature.Inventory.Items
        If items.Any Then
            character.AddMessage($"Items {feature.Inventory.DefaultPreposition.ToLower} {feature.GetName()} include {String.Join(", ", items.Select(Function(x) x.GetName()))}.")
        End If
        Return CommandProcessorResult.Processed
    End Function
End Module
