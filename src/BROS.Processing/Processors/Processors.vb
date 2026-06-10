Imports BROS.Persistence

Friend Module Processors
    Private ReadOnly commandList As IReadOnlyList(Of (Command As String, HelpText As String, Processor As Func(Of IWorld, IEnumerable(Of String), CommandProcessorResult))) =
        New List(Of (String, String, Func(Of IWorld, IEnumerable(Of String), CommandProcessorResult))) From
        {
            ("menu", "Brings up the main menu.", AddressOf MenuCommandProcessor.Process),
            ("help", "Shows context sensitive help.", AddressOf HelpCommandProcessor.Process)
        }
    Private ReadOnly processorTable As IReadOnlyDictionary(Of String, Func(Of IWorld, IEnumerable(Of String), CommandProcessorResult)) =
        commandList.ToDictionary(Function(x) x.Command.ToUpper, Function(x) x.Processor)
    Private ReadOnly processorHelp As IReadOnlyDictionary(Of String, String) =
        commandList.ToDictionary(Function(x) x.Command.ToUpper, Function(x) x.HelpText)
    Friend ReadOnly Property AllCommands As IEnumerable(Of String)
        Get
            Return processorTable.Keys.Order()
        End Get
    End Property
    Friend Function GetProcessor(command As String) As Func(Of IWorld, IEnumerable(Of String), CommandProcessorResult)
        Dim result As Func(Of IWorld, IEnumerable(Of String), CommandProcessorResult) = Nothing
        If processorTable.TryGetValue(command.ToUpper, result) Then
            Return result
        End If
        Return Function(x, y) CommandProcessorResult.Invalid
    End Function
    Friend Function GetHelpText(command As String) As String
        Dim result As String = Nothing
        If processorHelp.TryGetValue(command.ToUpper, result) Then
            Return result
        End If
        Return $"There ain't no `{command}` command, fool."
    End Function
End Module
