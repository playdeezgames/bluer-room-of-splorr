Friend Module MenuCommandProcessor
    Friend Function Process(tokens As IEnumerable(Of String)) As CommandProcessorResult
        If tokens.Any Then
            Return CommandProcessorResult.Invalid
        End If
        Return CommandProcessorResult.MenuRequest
    End Function
End Module
