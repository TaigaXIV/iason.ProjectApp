Imports Model

Public Interface IUserService
    Function Login(Email As String, Password As String) As User
End Interface

Public Class UserService
    Inherits GenericService(Of User, Integer)
    Implements IUserService

    Public Function Login(Email As String, Password As String) As User Implements IUserService.Login
        Return Me.List().AsEnumerable.FirstOrDefault(Function(u) u.Email = Email AndAlso u.Password = Password)
    End Function
End Class
