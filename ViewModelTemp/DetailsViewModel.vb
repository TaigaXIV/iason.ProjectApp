Imports System.Collections.ObjectModel
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
                NotifyPropertyChanged(NameOf(EntryTotalCostsExpression))
            End If
        End Set
    End Property

    Public ReadOnly Property EntryTotalCostsExpression As String
        Get
            Return $"{EntryTotalCosts:C}"
        End Get
    End Property

    Public ReadOnly Property Name As String

    ''' <summary>
    ''' loads all entries of the project in a ListView
    ''' </summary>
    ''' <param name="Id"></param>
    Public Sub LoadEntries(Id As Integer)
        Entries = New ObservableCollection(Of EntryViewModel)(Entry.GetEntries(Id).Select(Function(e) New EntryViewModel(e)))
    End Sub

    ''' <summary>
    ''' back button on DetailsPage
    ''' </summary>
    ''' <returns></returns>
    Public Function TryGoBack() As Boolean
        Throw New NotImplementedException
        'Dim rootFrame As Frame = TryCast(Window.Current.Content, Frame)
        'If rootFrame.CanGoBack Then
        '    rootFrame.GoBack()
        '    Return True
        'End If

        'Return False
    End Function

    ''' <summary>
    ''' creates a new object of EntryViewModel
    ''' </summary>
    ''' <returns></returns>
    Public Function CreateEntryViewModel()
        Dim NewEntry = New EntryViewModel(New Entry)
        NewEntry.SelectedUser = Nothing
        Return NewEntry
    End Function

    ''' <summary>
    ''' creates an entry with Data from NewEntryDialogue
    ''' </summary>
    ''' <param name="NewEntry"></param>
    Public Sub InsertEntryViewModel(NewEntry As EntryViewModel)
        If (NewEntry.EndTime.Hours - NewEntry.StartTime.Hours) >= 0 Then
            Entries.Insert(0, NewEntry)
        End If
    End Sub

    ''' <summary>
    ''' updates the selected entry
    ''' </summary>
    ''' <param name="NewEntry"></param>
    Public Sub UpdateEntryViewModel(NewEntry As EntryViewModel)
        Dim i As Integer = Entries.IndexOf(NewEntry)
        If (NewEntry.EndTime.Hours - NewEntry.StartTime.Hours) >= 0 Then
            Entries.Remove(Entries.First(Function(p) p.Id = NewEntry.Id))
            NewEntry.SelectedUser = NewEntry.User
            Entries.Insert(i, NewEntry)
            CalculateTotalCosts()
        End If
    End Sub

    ''' <summary>
    ''' removes entry from list
    ''' </summary>
    ''' <param name="Entry"></param>
    Public Sub DeleteEntry(Entry As EntryViewModel)
        Entries.Remove(Entry)
    End Sub

    ''' <summary>
    ''' calculates the total costs of all entries inside the project
    ''' </summary>
    ''' <returns></returns>
    Public Function CalculateTotalCosts()
        EntryTotalCosts = 0
        For Each Entry As EntryViewModel In Entries
            EntryTotalCosts += Entry.CostPerHour * (Entry.EndTime.Hours - Entry.StartTime.Hours)
        Next

        Return EntryTotalCosts
    End Function


    ''' <summary>
    ''' sorts different columns
    ''' </summary>
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
