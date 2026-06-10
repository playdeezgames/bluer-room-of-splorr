Imports BROS.Persistence

Friend Module LookCommandProcessor
    Friend Function Process(world As IWorld, tokens As IEnumerable(Of String)) As CommandProcessorResult
        Select Case tokens.Count
            Case 0
                world.ClearMessages()
                world.Avatar.DescribeLocation()
                Return CommandProcessorResult.Processed
            Case Else
                Return CommandProcessorResult.Invalid
        End Select
    End Function
End Module
