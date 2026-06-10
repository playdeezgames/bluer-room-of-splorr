Imports BROS.Persistence

Friend Module CommandProcessor
    Friend Function Process(world As IWorld, tokens As IEnumerable(Of String)) As CommandProcessorResult
        Return Processors.GetProcessor(tokens.First).Invoke(world, tokens.Skip(1))
    End Function
End Module
