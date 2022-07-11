Imports System.Collections.ObjectModel
Imports System.Collections.Specialized
Imports Model
Imports Newtonsoft.Json

Public Class MainPageViewModel
    Inherits ViewModelBase

    Property ProjectService As New ProjectService

    Sub New()
        Initialize()
    End Sub

    Private Sub Initialize()
        LoadProjects()
    End Sub

    Private _JsonText As String
    ''' <summary>
    ''' Gets or sets 
    ''' </summary>
    ''' <returns></returns>
    Public Property JsonText() As String
        Get
            Return _JsonText
        End Get
        Set
            If _JsonText <> Value Then
                _JsonText = Value
                NotifyPropertyChanged()
            End If
        End Set
    End Property

    Public ReadOnly Property IsAdmin As Boolean = AppViewModel.CurrentUser.IsAdmin

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

    Property AllProjects As ObservableCollection(Of ProjectViewModel)

    ''' <summary>
    ''' Loads projects into Observablecollection and sets the UserState(IsAdmin true/false) for logged-in user
    ''' </summary>
    Public Sub LoadProjects()
        Dim FetchProjects = ProjectService.LoadFullProjects().AsEnumerable
        Projects = New ObservableCollection(Of ProjectViewModel)(FetchProjects.Select(Function(P) New ProjectViewModel(P)))
        AllProjects = Projects
    End Sub

    ''' <summary>
    ''' filters projects based on given Value
    ''' </summary>
    ''' <param name="Value"></param>
    ''' <returns></returns>
    Public Function FilteredProjects(Value As String) As ObservableCollection(Of ProjectViewModel)
        Dim NewList As New List(Of ProjectViewModel)
        If Value Is Nothing Then
            Value = ""
        End If
        For Each Project As ProjectViewModel In AllProjects
            If Project.Id.ToString.Contains(Value) OrElse Project.Name.ToLower.Contains(Value.ToLower) Then
                NewList.Add(Project)
            End If
        Next
        Projects = New ObservableCollection(Of ProjectViewModel)(NewList)

        Return Projects
    End Function

    ''' <summary>
    ''' checks if the text in AutoSuggestBox has changed
    ''' </summary>
    ''' <param name="Value"></param>
    Public Sub QueryTextChanged(Value As String)
        If String.IsNullOrWhiteSpace(Value) Then
            Projects = AllProjects
        Else
            FilteredProjects(Value.ToLower)
        End If
    End Sub

    ''' <summary>
    ''' creates a new ProjectViewModel with specified variables set
    ''' </summary>
    ''' <returns></returns>
    Public Function CreateProjectViewModel()
        Return New ProjectViewModel(New Project) With {.Status = ProjectStatus.New, .DateCreated = New DateTimeOffset(Date.Now)}
    End Function

    ''' <summary>
    ''' removes a project from list
    ''' </summary>
    ''' <param name="NewProject"></param>
    Public Sub InsertProjectViewModel(NewProject As ProjectViewModel)
        Projects.Insert(0, NewProject)
        AllProjects = Projects
    End Sub

    ''' <summary>
    ''' updates a project in list
    ''' </summary>
    ''' <param name="NewProject"></param>
    Public Sub UpdateProjectViewModel(NewProject As ProjectViewModel)
        Dim I As Integer = Projects.IndexOf(NewProject)

        ProjectService.Update(NewProject.Model)

        Projects.Remove(Projects.First(Function(p) p.Id = NewProject.Id))
        Projects.Insert(I, NewProject)
        AllProjects = Projects
    End Sub

    ''' <summary>
    ''' removes a project from list
    ''' </summary>
    ''' <param name="Project"></param>
    Public Sub DeleteProject(Project As ProjectViewModel)
        Projects.Remove(Project)
        AllProjects.Remove(Project)
        ProjectService.Delete(Project.Id)
    End Sub

    ''' <summary>
    ''' Creates a new Contract.
    ''' </summary>
    Public Function CreateNewContractViewModel()
        Return New ContractViewModel(New Contract) With {.StartDate = New DateTimeOffset(Date.Now), .EndDate = New DateTimeOffset(Date.Now.AddDays(30))}
    End Function

    Public Sub ConvertProjectToJson(ProjectId As Integer)
        Dim SerializerSettings As JsonSerializerSettings = New JsonSerializerSettings()
        SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        Dim Project = ProjectService.LoadFullProject(ProjectId)
        JsonText = JsonConvert.SerializeObject(Project, Formatting.Indented, SerializerSettings)
    End Sub

    ''' <summary>
    ''' sorting different columns
    ''' </summary>
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

    Public Sub SortByDate()
        If IsOrderedByDescending Then
            Projects = New ObservableCollection(Of ProjectViewModel)(Projects.OrderBy(Function(p) p.DateCreated).ToList)
            IsOrderedByDescending = False
        Else
            Projects = New ObservableCollection(Of ProjectViewModel)(Projects.OrderByDescending(Function(p) p.DateCreated).ToList)
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
