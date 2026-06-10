Friend Module CommandProcessor
    Friend Function Process(tokens As IEnumerable(Of String)) As CommandProcessorResult
        Return Processors.GetProcessor(tokens.First).Invoke(tokens.Skip(1))
    End Function
End Module
