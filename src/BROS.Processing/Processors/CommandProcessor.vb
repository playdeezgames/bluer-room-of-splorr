Friend Module CommandProcessor
    Private ReadOnly table As IReadOnlyDictionary(Of String, Func(Of IEnumerable(Of String), CommandProcessorResult)) =
        New List(Of (String, Func(Of IEnumerable(Of String), CommandProcessorResult))) From
        {
            ("menu", AddressOf MenuCommandProcessor.Process)
        }.ToDictionary(Function(x) x.Item1.ToUpper, Function(x) x.Item2)
    Friend Function Process(tokens As IEnumerable(Of String)) As CommandProcessorResult
        Dim processor As Func(Of IEnumerable(Of String), CommandProcessorResult) = Nothing
        If table.TryGetValue(tokens.First.ToUpper, processor) Then
            Return processor.Invoke(tokens.Skip(1))
        End If
        Return CommandProcessorResult.Invalid
    End Function
End Module
