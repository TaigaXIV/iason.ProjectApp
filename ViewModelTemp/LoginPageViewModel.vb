Imports Model

Public Class LoginPageViewModel
    Inherits ViewModelBase

    Property UserService As IUserService

    Sub New()
        UserService = New UserService
    End Sub

    Public Event LoginRequested()
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

    Public Sub SubmitLogin()
        Dim User = UserService.Login(Email, Password)
        If User Is Nothing Then
            RaiseEvent LoginFailed()
        Else
            AppViewModel.CurrentUser = New UserViewModel(User)
            RaiseEvent LoginRequested()
        End If
    End Sub
End Class
