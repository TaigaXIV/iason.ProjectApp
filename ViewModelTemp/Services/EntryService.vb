Imports Microsoft.EntityFrameworkCore
Imports Model

Public Interface IEntryService
    Function LoadAllEntriesForProject(Id As Integer) As IQueryable(Of Entry)
End Interface

Public Class EntryService
    Inherits GenericService(Of Entry, Integer)
    Implements IEntryService

    Public Function LoadAllEntriesForProject(Id As Integer) As IQueryable(Of Entry) Implements IEntryService.LoadAllEntriesForProject
        Return Context.Set(Of Entry)().Where(Function(E) E.ProjectId = Id).Include(Function(E) E.User)
    End Function
End Class
