Imports Model

Public Class UserViewModel
    Inherits ViewModelBase

    Friend Model As User

    Sub New(User As User)
        Me.Model = User
    End Sub

    Public ReadOnly Property FullName As String
        Get
            Return $"{Model.FirstName.First} {Model.LastName.First}"
        End Get
    End Property

    Public Overrides Function ToString() As String
        Return FullName
    End Function
End Class
