Imports System.Runtime.CompilerServices
Imports BROS.Persistence

Friend Module CharacterExtensions
    <Extension>
    Friend Sub AddMessage(character As ICharacter, text As String, Optional mood As String = Nothing, Optional newLine As Boolean = True)
        If character.HasTag(Tags.IS_AVATAR) Then
            character.World.AddMessage(text, mood, newLine)
        End If
    End Sub
    <Extension>
    Friend Sub DescribeLocation(character As ICharacter)
        Dim characterName = character.GetName()
        character.AddMessage($"{characterName} is in {character.Location.GetName()}.")
        Dim location = character.Location
        Dim features = location.Features
        If features.Any Then
            character.AddMessage($"Feature(s): {String.Join(", ", features.Select(Function(x) x.GetName()))}")
        End If
        Dim otherCharacters = location.GetOtherCharacters(character)
        If otherCharacters.Any Then
            character.AddMessage($"Other character(s): {String.Join(", ", otherCharacters.Select(Function(x) x.GetName))}")
        End If
        Dim exits = location.Exits
        If exits.Any Then
            character.AddMessage($"Exit(s):")
            For Each [exit] In exits
                character.AddMessage($"    {[exit].Key}: {[exit].Value.GetName()}")
            Next
        End If
    End Sub
    <Extension>
    Friend Sub DescribeFeature(character As ICharacter, feature As IFeature)
        character.AddMessage(feature.GetDescription())
    End Sub
    <Extension>
    Friend Sub DescribeItem(character As ICharacter, item As IItem)
        character.AddMessage(item.GetDescription())
    End Sub
    <Extension>
    Friend Sub DescribeEquipSlot(character As ICharacter, equipSlot As IEquipSlot)
        character.AddMessage(equipSlot.GetDescription())
    End Sub
    <Extension>
    Friend Sub DescribeRoute(character As ICharacter, route As IRoute)
        character.AddMessage(route.GetDescription())
        Dim lock = route.Lock
        If lock IsNot Nothing Then
            character.AddMessage($"It is locked with: {lock.GetName}.")
            character.AddMessage(lock.GetDescription())
        End If
    End Sub
    <Extension>
    Friend Sub DescribeCharacter(character As ICharacter, otherCharacter As ICharacter)
        character.AddMessage(otherCharacter.GetDescription())
    End Sub
End Module
