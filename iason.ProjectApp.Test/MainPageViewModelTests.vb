Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports ViewModel

<TestClass>
Public Class MainPageViewModelTests

    Property ViewModel As MainPageViewModel

    <TestInitialize>
    Sub Initialize()
        ViewModel = New MainPageViewModel
    End Sub

    ''' <summary>
    ''' is the given value filtering projects correctly
    ''' </summary>
    <TestMethod>
    Sub FilteredProjects_IsValueFilteringProjects_True()
        ' Arrange. 
        ViewModel.LoadProjects()

        ' Act. 
        Dim Actual = ViewModel.FilteredProjects("1")

        ' Assert. 
        Assert.AreEqual(2, Actual.Count)
    End Sub

    <DataRow(Nothing)>
    <DataRow(" ")>
    <DataRow("")>
    <TestMethod>
    Sub FilteredProjects_GivesAllProjectsWithNullOrWhiteSpace_True(Value As String)
        ' Arrange. 
        ViewModel.LoadProjects()

        ' Act. 
        Dim Actual = ViewModel.FilteredProjects(Value)

        ' Assert. 
        Assert.AreEqual(ViewModel.Projects.Count, Actual.Count)
    End Sub


    <TestMethod>
    Sub QueryTextChanged_IsCollectionRefreshingIfQueryTextIsDeleted_True()
        ' Arrange. 
        ViewModel.LoadProjects()
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
        ViewModel.LoadProjects()
        Dim IsAdmin As Boolean = True
        Dim ExpectedCounts As Integer = ViewModel.Projects.Count + 1

        ' Act. 
        ViewModel.InsertProjectViewModel(New ProjectViewModel(New Model.Project With {.DateCreated = New DateTimeOffset(Date.Now)}, IsAdmin))

        ' Assert. 
        Assert.AreEqual(ExpectedCounts, ViewModel.Projects.Count)
    End Sub

    <TestMethod>
    Sub UpdateProjectViewModel_WillProjectUpdate_True()
        ViewModel.LoadProjects()
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
        ViewModel.LoadProjects()
        Dim Entry = ViewModel.Projects.First
        Dim ProjectsExpected As Integer = ViewModel.Projects.Count - 1

        ' Act. 
        ViewModel.DeleteProject(Entry)

        ' Assert. 
        Assert.AreEqual(ProjectsExpected, ViewModel.Projects.Count)
    End Sub

End Class
