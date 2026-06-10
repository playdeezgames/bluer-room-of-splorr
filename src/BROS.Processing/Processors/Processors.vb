Friend Module Processors
    Private ReadOnly commandList As IReadOnlyList(Of (Command As String, HelpText As String, Processor As Func(Of IEnumerable(Of String), CommandProcessorResult))) =
        New List(Of (String, String, Func(Of IEnumerable(Of String), CommandProcessorResult))) From
        {
            ("menu", "Brings up the main menu.", AddressOf MenuCommandProcessor.Process)
        }
    Private ReadOnly processorTable As IReadOnlyDictionary(Of String, Func(Of IEnumerable(Of String), CommandProcessorResult)) =
        commandList.ToDictionary(Function(x) x.Command.ToUpper, Function(x) x.Processor)
    Private ReadOnly processorHelp As IReadOnlyDictionary(Of String, String) =
        commandList.ToDictionary(Function(x) x.Command.ToUpper, Function(x) x.HelpText)
    Friend Function GetProcessor(command As String) As Func(Of IEnumerable(Of String), CommandProcessorResult)
        Dim result As Func(Of IEnumerable(Of String), CommandProcessorResult) = Nothing
        If processorTable.TryGetValue(command.ToUpper, result) Then
            Return result
        End If
        Return Function(x) CommandProcessorResult.Invalid
    End Function
End Module
