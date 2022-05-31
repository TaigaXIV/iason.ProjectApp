Public Class ProjectManager

    Public Shared Function GetProjects() As IEnumerable(Of Project)

        Return New List(Of Project) From {
            New Project With {.Id = 1, .Name = "Projecta 1", .DateCreated = New DateTimeOffset(Date.Now), .Status = ProjectStatus.Active},
            New Project With {.Id = 2, .Name = "Projecte 2", .DateCreated = New DateTimeOffset(Date.Now), .Status = ProjectStatus.Active},
            New Project With {.Id = 3, .Name = "Projecti 3", .DateCreated = New DateTimeOffset(Date.Now), .Status = ProjectStatus.Active},
            New Project With {.Id = 4, .Name = "Projectus 4", .DateCreated = New DateTimeOffset(Date.Now), .Status = ProjectStatus.Active},
            New Project With {.Id = 5, .Name = "Projecto 5", .DateCreated = New DateTimeOffset(Date.Now), .Status = ProjectStatus.Active},
            New Project With {.Id = 6, .Name = "Projectu 6", .DateCreated = New DateTimeOffset(Date.Now), .Status = ProjectStatus.Active},
            New Project With {.Id = 7, .Name = "Projecty 7", .DateCreated = New DateTimeOffset(Date.Now), .Status = ProjectStatus.Active},
            New Project With {.Id = 8, .Name = "Projectx 8", .DateCreated = New DateTimeOffset(Date.Now), .Status = ProjectStatus.Active},
            New Project With {.Id = 9, .Name = "Projectoy 9", .DateCreated = New DateTimeOffset(Date.Now), .Status = ProjectStatus.Active},
            New Project With {.Id = 10, .Name = "Projectai 10", .DateCreated = New DateTimeOffset(Date.Now), .Status = ProjectStatus.Active}
        }.AsEnumerable
    End Function

End Class
