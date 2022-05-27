Imports Model

Public Class UserViewModel
    Inherits ViewModelBase

    Friend Model As User

    Sub New(User As User)
        Me.Model = User
    End Sub

    Public ReadOnly Property FirstName As String
        Get
            Return Model.FirstName
        End Get
    End Property

    Public ReadOnly Property LastName As String
        Get
            Return Model.LastName
        End Get
    End Property

    Public ReadOnly Property FullName As String
        Get
            Return $"{Model.FirstName} {Model.LastName}"
        End Get
    End Property

    Public Overrides Function ToString() As String
        Return FullName
    End Function

    Public Overrides Function Equals(obj As Object) As Boolean
        Return Me.FullName = CType(obj, UserViewModel).FullName
    End Function
End Class
