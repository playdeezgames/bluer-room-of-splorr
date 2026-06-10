Imports System.Runtime.CompilerServices
Imports BROS.Persistence

Friend Module CharacterExtensions
    <Extension>
    Friend Sub AddMessage(character As ICharacter, text As String, Optional mood As String = Nothing, Optional newLine As Boolean = False)
        If character.HasTag(Tags.IS_AVATAR) Then
            character.World.AddMessage(text, mood, newLine)
        End If
    End Sub
    <Extension>
    Friend Sub DescribeLocation(character As ICharacter)
        Dim characterName = character.GetName()
        character.AddMessage($"{characterName} is in {character.Location.GetName()}.", newLine:=True)
        Dim features = character.Location.Features
        If features.Any Then
            character.AddMessage($"Feature(s): {String.Join(", ", features.Select(Function(x) x.GetName()))}", newLine:=True)
        End If
    End Sub
End Module
