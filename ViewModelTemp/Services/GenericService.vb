Imports Microsoft.EntityFrameworkCore
Imports Microsoft.EntityFrameworkCore.ChangeTracking
Imports Model

Public Interface IGenericService(Of T As {EntityBase}, TKey)
    Function List() As IQueryable(Of T)
    Function Create(Entity As T) As Integer
    Function Read(Id As TKey) As T
    Function Delete(Entity As T) As Boolean
    Function Update(Entity As T) As T
    Function Delete(Id As Integer) As Boolean
End Interface

Public Class GenericService(Of T As {EntityBase}, TKey)
    Implements IGenericService(Of T, Integer)

    Property Context As ProjectAppContext
    Sub New()
        Context = New ProjectAppContext
    End Sub
    Public Function List() As IQueryable(Of T) Implements IGenericService(Of T, Integer).List
        Return Context.Set(Of T)()
    End Function

    Public Function Create(Entity As T) As Integer Implements IGenericService(Of T, Integer).Create
        Try
            Context.Set(Of T).Add(Entity)
            Dim Result As Integer = Context.SaveChanges()
            If Result > 0 Then
                Return Entity.Id
            End If
        Catch ex As Exception
            
        End Try
    End Function

    Public Function Read(Id As Integer) As T Implements IGenericService(Of T, Integer).Read
        Return Context.Set(Of T).Find(Id)
    End Function

    Public Function Delete(Entity As T) As Boolean Implements IGenericService(Of T, Integer).Delete
        Context.Set(Of T).Remove(Entity)
        Dim Result = Context.SaveChanges()
        If Result > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function Delete(Id As Integer) As Boolean Implements IGenericService(Of T, Integer).Delete
        Dim Entity As T = Read(Id)
        Return Delete(Entity)
    End Function

    Public Function Update(Entity As T) As T Implements IGenericService(Of T, Integer).Update
        Dim ChangedEntity = Read(Entity.Id)
        Context.Entry(ChangedEntity).State = EntityState.Modified
        Context.SaveChanges()
        Return ChangedEntity
    End Function
End Class
