Imports System.Collections.ObjectModel
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Model
Imports ViewModel

<TestClass>
Public Class DetailsViewModelTests
    Dim ViewModel As DetailsViewModel

    <TestInitialize>
    Sub Initialize()
        AppViewModel.CurrentUser = New UserViewModel(New User With {.IsAdmin = True})
        Dim Project As New Project With {.Id = 1}
        Dim IsAdmin As Boolean = True
        Dim ProjectViewModel As New ProjectViewModel(Project)
        ViewModel = New DetailsViewModel(ProjectViewModel)
        ViewModel.Entries = New ObservableCollection(Of EntryViewModel)
        ViewModel.Entries.Add(New EntryViewModel(New Entry With {.StartTime = New TimeSpan(15, 30, 0), .EndTime = New TimeSpan(14, 30, 0)}))
        ViewModel.Entries.Add(New EntryViewModel(New Entry With {.StartTime = New TimeSpan(15, 30, 0), .EndTime = New TimeSpan(14, 30, 0)}))
        ViewModel.Entries.Add(New EntryViewModel(New Entry With {.StartTime = New TimeSpan(15, 30, 0), .EndTime = New TimeSpan(14, 30, 0)}))
    End Sub

    <TestMethod>
    Sub InsertEntryViewModel_CanEndTimeBeNegativeToStartTime_False()
        ' Arrange. 
        Dim Entry As New EntryViewModel(New Entry With {.StartTime = New TimeSpan(15, 30, 0), .EndTime = New TimeSpan(14, 30, 0)})
        Dim Expected As Integer = ViewModel.Entries.Count

        ' Act. 
        ViewModel.InsertEntryViewModel(Entry)

        ' Assert. 
        Assert.AreEqual(Expected, ViewModel.Entries.Count)
    End Sub

    <TestMethod>
    Sub CreateEntryViewModel_IsEntryViewModelCreatedProperly_True()
        ' Arrange. 
        Dim Entry = New EntryViewModel(New Entry)
        Entry.SelectedUser = Nothing
        Dim Expected = Entry.SelectedUser

        ' Act. 
        Dim Actual As EntryViewModel = ViewModel.CreateEntryViewModel()

        ' Assert. 
        Assert.AreEqual(Expected, Actual.SelectedUser)
    End Sub

    <TestMethod>
    Sub UpdateEntryViewModel_WillEntryUpdate_True()
        ' Arrange. 
        Dim Entry As EntryViewModel = ViewModel.Entries.First
        Entry.Description = "A Second Test"

        ' Act. 
        ViewModel.UpdateEntryViewModel(Entry)

        ' Assert. 
        Assert.AreEqual(Entry.Description, ViewModel.Entries.First.Description)
    End Sub

    <TestMethod>
    Sub UpdateEntryViewModel_WillEntryUpdate_False()
        ' Arrange. 
        Dim Entry = New EntryViewModel(New Entry)
        Entry.Description = "A Second Test"
        Entry.StartTime = TimeSpan.FromTicks(DateTime.Now.Ticks)
        Entry.EndTime = New TimeSpan(Entry.StartTime.Hours - 1, 0, 0)

        ' Act. 
        ViewModel.UpdateEntryViewModel(Entry)

        ' Assert. 
        Assert.AreNotEqual(ViewModel.Entries.First.Description, Entry.Description)
    End Sub

    <TestMethod>
    Sub DeleteEntry_IsEntryDeleted_True()
        ' Arrange. 
        Dim Entry = ViewModel.Entries.First
        Dim EntriesExpected As Integer = ViewModel.Entries.Count - 1

        ' Act. 
        ViewModel.DeleteEntry(Entry)

        ' Assert. 
        Assert.AreEqual(EntriesExpected, ViewModel.Entries.Count)
    End Sub

    <TestMethod>
    Sub CalculateTotalCosts_AreTotalCostsCalculatedProperly_True()
        ' Arrange. 
        Dim Entry = ViewModel.Entries.First
        Entry.EndTime = New TimeSpan(Entry.StartTime.Hours + 3, 0, 0)
        Dim Expected As Integer = Entry.CostPerHour * 3

        ' Act. 
        ViewModel.CalculateTotalCosts()

        ' Assert. 
        Assert.AreEqual(Expected, ViewModel.EntryTotalCosts)
    End Sub
End Class
