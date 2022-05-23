Imports Model

Public Class DetailsViewModel
    Inherits ViewModelBase

    Sub New(Project As ProjectViewModel)
        LoadEntries(Project.Id)
        Name = Project.Name
    End Sub

    Private _Entries As ObservableCollection(Of EntryViewModel)
    ''' <summary>
    ''' Gets or sets 
    ''' </summary>
    ''' <returns></returns>
    Public Property Entries() As ObservableCollection(Of EntryViewModel)
        Get
            Return _Entries
        End Get
        Set
            If _Entries IsNot Value Then
                _Entries = Value
                NotifyPropertyChanged()
            End If
        End Set
    End Property

    Public ReadOnly Property Name As String
    Public Sub LoadEntries(Id As integer)
        Entries = New ObservableCollection(Of EntryViewModel)(Entry.GetEntries(Id).Select(Function(e) New EntryViewModel(e)))
    End Sub

    Public Function TryGoBack() As Boolean
        Dim rootFrame As Frame = TryCast(Window.Current.Content, Frame)
        If rootFrame.CanGoBack Then
            rootFrame.GoBack()
            Return True
        End If

        Return False
    End Function

    Public Function CreateEntryViewModel()
        Dim NewProject As New EntryViewModel(New Entry)

        Return NewProject
    End Function

    Public Sub InsertEntryViewModel(NewEntry As EntryViewModel)
        Entries.Insert(0, NewEntry)
    End Sub

End Class
