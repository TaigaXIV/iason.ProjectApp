Imports System.Collections.Specialized
Imports Model

Public Class MainPageViewModel
    Inherits ViewModelBase

    Sub New()

    End Sub

    Private Sub Projects_CollectionChanged(sender As Object, e As NotifyCollectionChangedEventArgs)
        NotifyPropertyChanged(NameOf(Projects))
    End Sub

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

    Private _Projects As ObservableCollection(Of ProjectViewModel)
    ''' <summary>
    ''' Gets or sets 
    ''' </summary>
    ''' <returns></returns>
    Public Property Projects() As ObservableCollection(Of ProjectViewModel)
        Get
            Return _Projects
        End Get
        Set
            If _Projects IsNot Value Then
                _Projects = Value
                NotifyPropertyChanged()
            End If
        End Set
    End Property

    Dim AllProjects As ObservableCollection(Of ProjectViewModel)

    Public Sub LoadProjects()
        Projects = New ObservableCollection(Of ProjectViewModel)(ProjectManager.GetProjects().Select(Function(p) New ProjectViewModel(p, IsAdmin)))
        AddHandler Projects.CollectionChanged, AddressOf Projects_CollectionChanged
        AllProjects = New ObservableCollection(Of ProjectViewModel)(ProjectManager.GetProjects().Select(Function(p) New ProjectViewModel(p, IsAdmin)))
    End Sub

    Public Function FilteredProjects(Value As String) As ObservableCollection(Of ProjectViewModel)
        Dim NewList As New List(Of ProjectViewModel)
        For Each Project As ProjectViewModel In AllProjects
            If Project.Id.ToString.Contains(Value) OrElse Project.Name.ToLower.Contains(Value.ToLower) Then
                NewList.Add(Project)
            End If
        Next
        Projects = New ObservableCollection(Of ProjectViewModel)(NewList)

        Return Projects
    End Function

    Public Sub QueryTextChanged(Value As String)
        If String.IsNullOrWhiteSpace(Value) Then
            Projects = AllProjects
            Dim Suggestions = Projects.Select(Function(p) p.Name).ToList()
        Else
            Dim Suggestions = Projects.Where(Function(p) p.Id.ToString.Contains(Value) OrElse p.Name.ToLower.Contains(Value.ToLower)).Select(Function(p) p.Id OrElse p.Name).ToList()
            FilteredProjects(Value.ToLower)
        End If
    End Sub

    Public Function CreateProjectViewModel()
        Return New ProjectViewModel(New Project, IsAdmin) With {.Status = ProjectStatus.[New], .DateCreated = New DateTimeOffset(Date.Now)}
    End Function

    Public Sub InsertProjectViewModel(NewProject As ProjectViewModel)
        Projects.Insert(0, NewProject)
        AllProjects = Projects
    End Sub

    Public Sub UpdateProjectViewModel(NewProject As ProjectViewModel)
        Projects.Remove(Projects.First(Function(p) p.Id = NewProject.Id))
        Projects.Insert(0, NewProject)
        AllProjects = Projects
    End Sub

    Public Sub DeleteProject(Project As ProjectViewModel)
        Projects.Remove(Project)
        AllProjects.Remove(Project)
    End Sub

    Dim IsOrderedByDescending As Boolean

    Public Sub SortById()
        If IsOrderedByDescending Then
            Projects = New ObservableCollection(Of ProjectViewModel)(Projects.OrderBy(Function(p) Convert.ToInt32(p.Id)).ToList)
            IsOrderedByDescending = False
        Else
            Projects = New ObservableCollection(Of ProjectViewModel)(Projects.OrderByDescending(Function(p) Convert.ToInt32(p.Id)).ToList)
            IsOrderedByDescending = True
        End If
    End Sub

    Public Sub SortByProject()
        If IsOrderedByDescending Then
            Projects = New ObservableCollection(Of ProjectViewModel)(Projects.OrderBy(Function(p) p.Name).ToList)
            IsOrderedByDescending = False
        Else
            Projects = New ObservableCollection(Of ProjectViewModel)(Projects.OrderByDescending(Function(p) p.Name).ToList)
            IsOrderedByDescending = True
        End If
    End Sub

    Public Sub SortByStatus()
        If IsOrderedByDescending Then
            Projects = New ObservableCollection(Of ProjectViewModel)(Projects.OrderBy(Function(p) p.Status).ToList)
            IsOrderedByDescending = False
        Else
            Projects = New ObservableCollection(Of ProjectViewModel)(Projects.OrderByDescending(Function(p) p.Status).ToList)
            IsOrderedByDescending = True
        End If
    End Sub

End Class
