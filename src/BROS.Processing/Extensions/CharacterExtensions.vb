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
        character.AddMessage($"{character.GetName()} is in {character.Location.GetName()}.", newLine:=True)
    End Sub
End Module
