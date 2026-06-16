Imports System.Runtime.CompilerServices
Imports BROS.Persistence

Friend Module ItemExtensions
    <Extension>
    Friend Function IsTakeable(item As IItem) As Boolean
        Return Not item.HasTag(Tags.LUREABLE)
    End Function
End Module
