Public Class User

    Property FirstName As String
    Property LastName As String
    Property Email As String
    Property Password As String
    Property IsAdmin As Boolean

    Public Function GetUsers() As IEnumerable(Of User)

        Return New List(Of User) From {
            New User With {.FirstName = "Kyle", .LastName = "Admin", .Email = "k.admin@online.com", .Password = "adminpassword", .IsAdmin = True},
            New User With {.FirstName = "Vitali", .LastName = "User", .Email = "k.user@online.com", .Password = "userpassword", .IsAdmin = False}
        }
    End Function

End Class
