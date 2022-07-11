Imports Microsoft.EntityFrameworkCore
Imports Model

Public Interface IProjectService
    Function LoadFullProjects() As IQueryable(Of Project)
    Function LoadFullProject(Id As Integer) As Project

End Interface

Public Class ProjectService
    Inherits GenericService(Of Project, Integer)
    Implements IProjectService

    Public Function LoadFullProjects() As IQueryable(Of Project) Implements IProjectService.LoadFullProjects
        Return Me.List().
            Include(Function(p) p.ProjectContracts)
    End Function

    Public Function LoadFullProject(Id As Integer) As Project Implements IProjectService.LoadFullProject

        Return Me.List().
            Where(Function(p) p.Id = Id).
            Include(Function(p) p.ProjectContracts).
            Include(Function(e) e.Entries).
            FirstOrDefault
        Stop
    End Function
End Class
