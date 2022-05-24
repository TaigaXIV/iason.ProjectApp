Imports Model

Public Class DetailsViewModel
    Inherits ViewModelBase

    Sub New(Project As ProjectViewModel)
        LoadEntries(Project.Id)
        CalculateTotalCosts()
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

    Private _EntryTotalCosts As Integer
    ''' <summary>
    ''' Gets or sets 
    ''' </summary>
    ''' <returns></returns>
    Public Property EntryTotalCosts() As Integer
        Get
            Return _EntryTotalCosts
        End Get
        Set
            If _EntryTotalCosts <> Value Then
                _EntryTotalCosts = Value
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
        Return New EntryViewModel(New Entry)
    End Function

    Public Sub InsertEntryViewModel(NewEntry As EntryViewModel)
        Entries.Insert(0, NewEntry)
    End Sub

    Public Function CalculateTotalCosts()
        EntryTotalCosts = 0
        For Each Entry As EntryViewModel In Entries
            EntryTotalCosts += Entry.CostPerHour * (Entry.EndTime.Hours - Entry.StartTime.Hours)
        Next

        Return EntryTotalCosts
    End Function

    Dim IsOrderedByDescending As Boolean

    Public Sub SortByEnd()
        If IsOrderedByDescending Then
            Entries = New ObservableCollection(Of EntryViewModel)(Entries.OrderBy(Function(p) p.EndTime).ToList)
            IsOrderedByDescending = False
        Else
            Entries = New ObservableCollection(Of EntryViewModel)(Entries.OrderByDescending(Function(p) p.EndTime).ToList)
            IsOrderedByDescending = True
        End If
    End Sub

    Public Sub SortByStart()
        If IsOrderedByDescending Then
            Entries = New ObservableCollection(Of EntryViewModel)(Entries.OrderBy(Function(p) p.StartTime).ToList)
            IsOrderedByDescending = False
        Else
            Entries = New ObservableCollection(Of EntryViewModel)(Entries.OrderByDescending(Function(p) p.StartTime).ToList)
            IsOrderedByDescending = True
        End If
    End Sub

    Public Sub SortByDescription()
        If IsOrderedByDescending Then
            Entries = New ObservableCollection(Of EntryViewModel)(Entries.OrderBy(Function(p) p.Description).ToList)
            IsOrderedByDescending = False
        Else
            Entries = New ObservableCollection(Of EntryViewModel)(Entries.OrderByDescending(Function(p) p.Description).ToList)
            IsOrderedByDescending = True
        End If
    End Sub

    Public Sub SortById()
        If IsOrderedByDescending Then
            Entries = New ObservableCollection(Of EntryViewModel)(Entries.OrderBy(Function(p) Convert.ToInt32(p.Id)).ToList)
            IsOrderedByDescending = False
        Else
            Entries = New ObservableCollection(Of EntryViewModel)(Entries.OrderByDescending(Function(p) Convert.ToInt32(p.Id)).ToList)
            IsOrderedByDescending = True
        End If
    End Sub

    Public Sub SortByDuration()
        If IsOrderedByDescending Then
            Entries = New ObservableCollection(Of EntryViewModel)(Entries.OrderBy(Function(p) Convert.ToInt32(p.Duration)).ToList)
            IsOrderedByDescending = False
        Else
            Entries = New ObservableCollection(Of EntryViewModel)(Entries.OrderByDescending(Function(p) Convert.ToInt32(p.Duration)).ToList)
            IsOrderedByDescending = True
        End If
    End Sub

    Public Sub SortByCost()
        If IsOrderedByDescending Then
            Entries = New ObservableCollection(Of EntryViewModel)(Entries.OrderBy(Function(p) Convert.ToInt32(p.CostPerHour)).ToList)
            IsOrderedByDescending = False
        Else
            Entries = New ObservableCollection(Of EntryViewModel)(Entries.OrderByDescending(Function(p) Convert.ToInt32(p.CostPerHour)).ToList)
            IsOrderedByDescending = True
        End If
    End Sub

End Class
