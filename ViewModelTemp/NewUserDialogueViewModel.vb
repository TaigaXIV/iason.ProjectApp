Imports Model

Public Class NewUserDialogueViewModel
    Inherits ViewModelBase

    Property UserService As New UserService

    Private _FirstName As String
    ''' <summary>
    ''' Gets or sets 
    ''' </summary>
    ''' <returns></returns>
    Public Property FirstName() As String
        Get
            Return _FirstName
        End Get
        Set
            If _FirstName <> Value Then
                _FirstName = Value
                IsSubmitClickable()
                NotifyPropertyChanged()
                NotifyPropertyChanged(NameOf(IsSubmitEnabled))
            End If
        End Set
    End Property

    Private _LastName As String
    ''' <summary>
    ''' Gets or sets 
    ''' </summary>
    ''' <returns></returns>
    Public Property LastName() As String
        Get
            Return _LastName
        End Get
        Set
            If _LastName <> Value Then
                _LastName = Value
                IsSubmitClickable()
                NotifyPropertyChanged()
                NotifyPropertyChanged(NameOf(IsSubmitEnabled))
            End If
        End Set
    End Property

    Private _Email As String
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
                IsSubmitClickable()
                NotifyPropertyChanged()
                NotifyPropertyChanged(NameOf(IsSubmitEnabled))
            End If
        End Set
    End Property

    Private _Password As String
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
                IsSubmitClickable()
                NotifyPropertyChanged()
                NotifyPropertyChanged(NameOf(IsSubmitEnabled))
            End If
        End Set
    End Property

    Private _IsAdmin As Boolean
    ''' <summary>
    ''' Gets or sets 
    ''' </summary>
    ''' <returns></returns>
    Public Property IsAdmin() As Boolean
        Get
            Return _IsAdmin
        End Get
        Set
            If _IsAdmin <> Value Then
                _IsAdmin = Value
                NotifyPropertyChanged()
            End If
        End Set
    End Property

    Private _IsSubmitEnabled As Boolean
    ''' <summary>
    ''' Gets or sets 
    ''' </summary>
    ''' <returns></returns>
    Public Property IsSubmitEnabled() As Boolean
        Get
            Return _IsSubmitEnabled
        End Get
        Set
            If _IsSubmitEnabled <> Value Then
                _IsSubmitEnabled = Value
                NotifyPropertyChanged()
            End If
        End Set
    End Property

    Private Sub IsSubmitClickable()
        If Not String.IsNullOrWhiteSpace(FirstName) AndAlso Not String.IsNullOrWhiteSpace(LastName) AndAlso Not String.IsNullOrWhiteSpace(Email) AndAlso Not String.IsNullOrWhiteSpace(Password) Then
            IsSubmitEnabled = True
        Else
            IsSubmitEnabled = False
        End If
    End Sub

    Public Sub CreateNewUser()
        Dim User As New User With {.FirstName = FirstName, .LastName = LastName, .Email = Email, .Password = Password, .IsAdmin = IsAdmin}
        UserService.Create(User)
        AppViewModel.CurrentUser = New UserViewModel(User)
    End Sub

End Class
