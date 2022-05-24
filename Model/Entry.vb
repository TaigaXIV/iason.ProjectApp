Public Class Entry

    Property ProjectId As Integer
    Property Id As Integer
    Property Description As String
    Property StartTime As TimeSpan
    Property EndTime As TimeSpan
    Property User As User
    Property CostPerHour As Integer

    Public Shared Function GetEntries() As IEnumerable(Of Entry)

        Return New List(Of Entry) From {
            New Entry With {.ProjectId = 1, .Id = 1, .Description = "Just a Test", .StartTime = TimeSpan.FromTicks(DateTime.Now.Ticks),
                            .EndTime = TimeSpan.FromTicks(DateTime.Now.Ticks), .CostPerHour = 45, .User = New User With {
                            .FirstName = "Kyle", .LastName = "Admin", .Email = "k.admin@online.com", .Password = "adminpassword", .IsAdmin = True}},
            New Entry With {.ProjectId = 4, .Id = 1, .Description = "Just a Test", .StartTime = TimeSpan.FromTicks(DateTime.Now.Ticks),
                            .EndTime = TimeSpan.FromTicks(DateTime.Now.Ticks), .CostPerHour = 45, .User = New User With {
                            .FirstName = "Kyle", .LastName = "Admin", .Email = "k.admin@online.com", .Password = "adminpassword", .IsAdmin = True}},
            New Entry With {.ProjectId = 3, .Id = 1, .Description = "Just a Test", .StartTime = TimeSpan.FromTicks(DateTime.Now.Ticks),
                            .EndTime = TimeSpan.FromTicks(DateTime.Now.Ticks), .CostPerHour = 45, .User = New User With {
                            .FirstName = "Kyle", .LastName = "Admin", .Email = "k.admin@online.com", .Password = "adminpassword", .IsAdmin = True}},
            New Entry With {.ProjectId = 1, .Id = 1, .Description = "Just a Test", .StartTime = TimeSpan.FromTicks(DateTime.Now.Ticks),
                            .EndTime = TimeSpan.FromTicks(DateTime.Now.Ticks), .CostPerHour = 45, .User = New User With {
                            .FirstName = "Kyle", .LastName = "Admin", .Email = "k.admin@online.com", .Password = "adminpassword", .IsAdmin = True}},
            New Entry With {.ProjectId = 3, .Id = 1, .Description = "Just a Test", .StartTime = TimeSpan.FromTicks(DateTime.Now.Ticks),
                            .EndTime = TimeSpan.FromTicks(DateTime.Now.Ticks), .CostPerHour = 45, .User = New User With {
                            .FirstName = "Kyle", .LastName = "Admin", .Email = "k.admin@online.com", .Password = "adminpassword", .IsAdmin = True}},
            New Entry With {.ProjectId = 1, .Id = 1, .Description = "Just a Test", .StartTime = TimeSpan.FromTicks(DateTime.Now.Ticks),
                            .EndTime = TimeSpan.FromTicks(DateTime.Now.Ticks), .CostPerHour = 45, .User = New User With {
                            .FirstName = "Kyle", .LastName = "Admin", .Email = "k.admin@online.com", .Password = "adminpassword", .IsAdmin = True}},
            New Entry With {.ProjectId = 1, .Id = 1, .Description = "Just a Test", .StartTime = TimeSpan.FromTicks(DateTime.Now.Ticks),
                            .EndTime = TimeSpan.FromTicks(DateTime.Now.Ticks), .CostPerHour = 45, .User = New User With {
                            .FirstName = "Kyle", .LastName = "Admin", .Email = "k.admin@online.com", .Password = "adminpassword", .IsAdmin = True}},
            New Entry With {.ProjectId = 3, .Id = 1, .Description = "Just a Test", .StartTime = TimeSpan.FromTicks(DateTime.Now.Ticks),
                            .EndTime = TimeSpan.FromTicks(DateTime.Now.Ticks), .CostPerHour = 45, .User = New User With {
                            .FirstName = "Kyle", .LastName = "Admin", .Email = "k.admin@online.com", .Password = "adminpassword", .IsAdmin = True}},
            New Entry With {.ProjectId = 1, .Id = 1, .Description = "Just a Test", .StartTime = TimeSpan.FromTicks(DateTime.Now.Ticks),
                            .EndTime = TimeSpan.FromTicks(DateTime.Now.Ticks), .CostPerHour = 45, .User = New User With {
                            .FirstName = "Kyle", .LastName = "Admin", .Email = "k.admin@online.com", .Password = "adminpassword", .IsAdmin = True}},
            New Entry With {.ProjectId = 2, .Id = 1, .Description = "Just a Test", .StartTime = TimeSpan.FromTicks(DateTime.Now.Ticks),
                            .EndTime = TimeSpan.FromTicks(DateTime.Now.Ticks), .CostPerHour = 45, .User = New User With {
                            .FirstName = "Kyle", .LastName = "Admin", .Email = "k.admin@online.com", .Password = "adminpassword", .IsAdmin = True}},
            New Entry With {.ProjectId = 1, .Id = 1, .Description = "Just a Test", .StartTime = TimeSpan.FromTicks(DateTime.Now.Ticks),
                            .EndTime = TimeSpan.FromTicks(DateTime.Now.Ticks), .CostPerHour = 45, .User = New User With {
                            .FirstName = "Kyle", .LastName = "Admin", .Email = "k.admin@online.com", .Password = "adminpassword", .IsAdmin = True}}
        }
    End Function

    Public Shared Function GetEntries(Id As Integer) As IEnumerable(Of Entry)
        Dim Entries = GetEntries()

        Return New List(Of Entry)(Entries.Where(Function(c) c.ProjectId = Id))
    End Function

End Class
