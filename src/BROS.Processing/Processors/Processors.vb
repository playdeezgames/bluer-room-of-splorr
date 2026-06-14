Imports BROS.Persistence

Friend Module Processors
    Private ReadOnly commandList As IReadOnlyList(Of (Command As String, HelpTexts As IEnumerable(Of String), Processor As Func(Of IWorld, IEnumerable(Of String), CommandProcessorResult))) =
        New List(Of (String, IEnumerable(Of String), Func(Of IWorld, IEnumerable(Of String), CommandProcessorResult))) From
        {
            ("menu", {"Brings up the main menu.", "Example:", "    MENU"}, AddressOf MenuCommandProcessor.Process),
            ("help", {"Shows context sensitive help.", "Examples:", "    HELP", "    HELP [COMMAND]"}, AddressOf HelpCommandProcessor.Process),
            ("look", {"Describes the immediate area.", "Example:", "    LOOK"}, AddressOf LookCommandProcessor.Process),
            ("examine", {"Looks at something closely.", "Example:", "    EXAMINE [NOUN]", "    EXAMINE [NOUN1] [PREPOSITION] [NOUN2]"}, AddressOf ExamineCommandProcessor.Process),
            ("check", {"Alias for EXAMINE. For lore reasons. Bend over!"}, AddressOf ExamineCommandProcessor.Process),
            ("take", {"Transfers an item into yer inventory.", "Example:", "    TAKE [NOUN1] FROM [NOUN2]"}, AddressOf TakeCommandProcessor.Process),
            ("inventory", {"Shows the items in yer inventory.", "Example:", "    INVENTORY"}, AddressOf InventoryCommandProcessor.Process),
            ("drop", {"Drops an item onto the floor.", "Example:", "    DROP [NOUN]"}, AddressOf DropCommandProcessor.Process),
            ("equipment", {"Shows equipment slots and the equipment thereof.", "Example:", "    EQUIPMENT"}, AddressOf EquipmentCommandProcessor.Process)
        }
    Private ReadOnly processorTable As IReadOnlyDictionary(Of String, Func(Of IWorld, IEnumerable(Of String), CommandProcessorResult)) =
        commandList.ToDictionary(Function(x) x.Command.ToUpper, Function(x) x.Processor)
    Private ReadOnly processorHelp As Dictionary(Of String, IEnumerable(Of String)) =
        commandList.ToDictionary(Function(x) x.Command.ToUpper, Function(x) x.HelpTexts)
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
    Friend Function GetHelpTexts(command As String) As IEnumerable(Of String)
        Dim result As IEnumerable(Of String) = Nothing
        If processorHelp.TryGetValue(command.ToUpper, result) Then
            Return result
        End If
        Return {$"There ain't no `{command}` command, fool!"}
    End Function
End Module
