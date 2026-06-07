Imports System.Runtime.CompilerServices
Imports TGGD.Persistence

Friend Module EntityExtensions
    <Extension>
    Friend Sub SetName(entity As IEntity, name As String)
        entity.SetMetadata(Metadatas.NAME, name)
    End Sub
End Module
