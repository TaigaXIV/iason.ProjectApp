Imports Model

Public Class LoginPageViewModel
    Inherits ViewModelBase

    Dim Model As New User

    Public Event LoginRequested(Value As Boolean)
    Public Event LoginFailed()

    Private _Email As String = "k.admin@online.com"
    ''' <summary>
    ''' Gets or sets the user email
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

    Private _Password As String = "admiNp4sswoRd"
    ''' <summary>
    ''' Gets or sets the user password
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

    ''' <summary>
    ''' Checks if the Login is valid if the SubmitButton is clicked on LoginPage
    ''' </summary>
    ''' <param name="Email"></param>
    ''' <param name="Password"></param>
    ''' <returns></returns>
    Public Function IsLoginValid(Email As String, Password As String) As Boolean
        If String.IsNullOrEmpty(Email) OrElse String.IsNullOrEmpty(Password) Then
            Return False
        End If
        Return Model.GetUsers().Any(Function(U) U.Email.ToLower.Trim = Email.ToLower.Trim AndAlso U.Password = Password)
    End Function

    Public Sub SubmitLogin()
        If IsLoginValid(Email, Password) Then
            If Email.ToLower.Contains("admin".ToLower) Then     ' <- dont do this in real world problems!
                RaiseEvent LoginRequested(True)
            Else
                RaiseEvent LoginRequested(False)
            End If
        Else
            RaiseEvent LoginFailed()
        End If
    End Sub

End Class
