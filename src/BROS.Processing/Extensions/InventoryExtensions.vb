Imports System.Runtime.CompilerServices
Imports BROS.Persistence

Friend Module InventoryExtensions
    <Extension>
    Friend Function CanAccept(inventory As IInventory, item As IItem) As Boolean
        Return False
    End Function
End Module
