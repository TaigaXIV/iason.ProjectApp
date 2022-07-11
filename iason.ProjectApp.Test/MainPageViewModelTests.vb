Imports System.Collections.ObjectModel
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Model
Imports ViewModel

<TestClass>
Public Class MainPageViewModelTests
    Dim ViewModel As New MainPageViewModel

    Function GetProjects() As ObservableCollection(Of ProjectViewModel)
        AppViewModel.CurrentUser = New UserViewModel(New User With {.IsAdmin = True})
        ViewModel.Projects = New ObservableCollection(Of ProjectViewModel)
        ViewModel.Projects.Add(New ProjectViewModel(New Project With {.Name = "Test"}))
        ViewModel.Projects.Add(New ProjectViewModel(New Project With {.Name = "Test2"}))
        ViewModel.Projects.Add(New ProjectViewModel(New Project With {.Name = "Test1"}))
        ViewModel.AllProjects = ViewModel.Projects
        Return ViewModel.Projects
    End Function

    ''' <summary>
    ''' is the given value filtering projects correctly
    ''' </summary>
    <TestMethod>
    Sub FilteredProjects_IsValueFilteringProjects_True()
        ' Arrange. 
        GetProjects()

        ' Act. 
        Dim Actual = ViewModel.FilteredProjects("Test")

        ' Assert. 
        Assert.AreEqual(3, Actual.Count)
    End Sub

    <DataRow(Nothing)>
    <DataRow(" ")>
    <DataRow("")>
    <TestMethod>
    Sub FilteredProjects_GivesAllProjectsWithNullOrWhiteSpace_True(Value As String)
        ' Arrange. 
        GetProjects()

        ' Act. 
        Dim Actual = ViewModel.FilteredProjects(Value)

        ' Assert. 
        Assert.AreEqual(ViewModel.Projects.Count, Actual.Count)
    End Sub


    <TestMethod>
    Sub QueryTextChanged_IsCollectionRefreshingIfQueryTextIsDeleted_True()
        ' Arrange. 
        GetProjects()
        ViewModel.QueryTextChanged("u")
        Dim Expected = ViewModel.Projects.Count

        ' Act. 
        ViewModel.QueryTextChanged("")

        ' Assert. 
        Assert.AreNotEqual(Expected, ViewModel.Projects.Count)
    End Sub

    <TestMethod>
    Sub InserProjectViewModel_IsNewProjectInserted_True()
        ' Arrange. 
        GetProjects()
        Dim IsAdmin As Boolean = True
        Dim ExpectedCounts As Integer = ViewModel.Projects.Count + 1

        ' Act. 
        ViewModel.InsertProjectViewModel(New ProjectViewModel(New Model.Project With {.DateCreated = New DateTimeOffset(Date.Now)}))

        ' Assert. 
        Assert.AreEqual(ExpectedCounts, ViewModel.Projects.Count)
    End Sub

    <TestMethod>
    Sub UpdateProjectViewModel_WillProjectUpdate_True()
        GetProjects()
        Dim Project As ProjectViewModel = ViewModel.Projects.First
        Project.Name = "Yeetus Deletus"

        ' Act. 
        ViewModel.UpdateProjectViewModel(Project)

        ' Assert. 
        Assert.AreEqual(Project.Name, ViewModel.Projects.First.Name)

    End Sub

    <TestMethod>
    Sub DeleteProject_IsProjectDeleted_True()
        ' Arrange. 
        GetProjects()
        Dim Entry = ViewModel.Projects.First
        Dim ProjectsExpected As Integer = ViewModel.Projects.Count - 1

        ' Act. 
        ViewModel.DeleteProject(Entry)

        ' Assert. 
        Assert.AreEqual(ProjectsExpected, ViewModel.Projects.Count)
    End Sub

End Class
