Imports Model

Public Class NewEntryViewModel
    Inherits ViewModelBase

    Dim Model As Entry
    Sub New(Entry As EntryViewModel)
        Me.Model = Entry.Model

    End Sub

    Public ReadOnly Property Users As List(Of UserViewModel)
        Get
            Return User.GetUsers().Select(Of UserViewModel)(Function(u) New UserViewModel(u)).ToList()
        End Get
    End Property

    Property Id As Integer
        Get
            Return Model.Id
        End Get
        Set
            If Value <> Id Then
                Model.Id = Value
                NotifyPropertyChanged()
            End If
        End Set
    End Property

    Property Description As String
        Get
            Return Model.Description
        End Get
        Set
            If Value <> Description Then
                Model.Description = Value
                NotifyPropertyChanged()
            End If
        End Set
    End Property

    Property StartTime As TimeSpan
        Get
            Return Model.StartTime
        End Get
        Set
            If Value <> StartTime Then
                Model.StartTime = Value
                NotifyPropertyChanged()
            End If
        End Set
    End Property

    Property EndTime As TimeSpan
        Get
            Return Model.EndTime
        End Get
        Set
            If Value <> EndTime Then
                Model.EndTime = Value
                NotifyPropertyChanged()
            End If
        End Set
    End Property

    Property CostPerHour As Integer
        Get
            Return Model.CostPerHour
        End Get
        Set
            If Value <> CostPerHour Then
                Model.CostPerHour = Value
                NotifyPropertyChanged()
            End If
        End Set
    End Property

    Private _SelectedUser As UserViewModel
    ''' <summary>
    ''' Gets or sets 
    ''' </summary>
    ''' <returns></returns>
    Public Property SelectedUser() As UserViewModel
        Get
            Return _SelectedUser
        End Get
        Set
            If _SelectedUser IsNot Value Then
                _SelectedUser = Value
                NotifyPropertyChanged()

            End If
        End Set
    End Property

    Private _NewEntry As EntryViewModel
    ''' <summary>
    ''' Gets or sets 
    ''' </summary>
    ''' <returns></returns>
    Public Property NewEntry() As EntryViewModel
        Get
            Return _NewEntry
        End Get
        Set
            If _NewEntry IsNot Value Then
                _NewEntry = Value
                NotifyPropertyChanged()
            End If
        End Set
    End Property

    Public Sub InitializeNewEntry()

        NewEntry = New EntryViewModel(Model)
        NewEntry.SelectedUser = SelectedUser
        NewEntry.Model.User = SelectedUser.Model
    End Sub

End Class
