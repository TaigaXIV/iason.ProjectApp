Imports Model

Public Class LoginPageViewModel
    Inherits ViewModelBase

    Dim Model As New User

    Public Event LoginRequested(Value As Boolean)
    Public Event LoginFailed()

    Private _Email As String = "k.user@online.com"
    ''' <summary>
    ''' Gets or sets 
    ''' </summary>
    ''' <returns></returns>
    Public Property Email() As String
        Get
            Return _Email
        End Get
        Set
            If _Email <> Value Then
                _Email = Value
                NotifyPropertyChanged()
            End If
        End Set
    End Property

    Private _Password As String = "userpassword"
    ''' <summary>
    ''' Gets or sets 
    ''' </summary>
    ''' <returns></returns>
    Public Property Password() As String
        Get
            Return _Password
        End Get
        Set
            If _Password <> Value Then
                _Password = Value
                NotifyPropertyChanged()
            End If
        End Set
    End Property

    Public Function IsLoginValid(Email As String, Password As String) As Boolean
        Return Model.GetUsers().Any(Function(u) u.Email.ToLower = Email.ToLower AndAlso u.Password = Password)
    End Function

    Public Sub SubmitButton()
        If IsLoginValid(Email, Password) Then
            If Email.ToLower.Contains("admin".ToLower) Then
                RaiseEvent LoginRequested(True)
            Else
                RaiseEvent LoginRequested(False)
            End If
        Else
            RaiseEvent LoginFailed()
        End If
    End Sub

End Class
