' The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

Imports ViewModel
''' <summary>
''' An empty page that can be used on its own or navigated to within a Frame.
''' </summary>
Public NotInheritable Class MainPage
    Inherits Page

    Dim ViewModel As New MainPageViewModel

    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Protected Overrides Sub OnNavigatedTo(e As NavigationEventArgs)
        ViewModel.IsAdmin = e.Parameter
        ViewModel.LoadProjects()
    End Sub

    Private Sub AutoSuggestBox_QuerySubmitted(sender As AutoSuggestBox, args As AutoSuggestBoxQuerySubmittedEventArgs)
        ViewModel.FilteredProjects(args.QueryText)
    End Sub

    Private Sub AutoSuggestBox_TextChanged(sender As AutoSuggestBox, args As AutoSuggestBoxTextChangedEventArgs)
        ViewModel.QueryTextChanged(sender.Text)
    End Sub

    Private Async Sub NewProjectButton_Click(sender As Object, e As RoutedEventArgs)
        Dim ProjectDialog As New NewProjectDialogue(ViewModel.CreateProjectViewModel())
        Dim Result As ContentDialogResult = Await ProjectDialog.ShowAsync()
        If Result = ContentDialogResult.Primary Then
            ViewModel.InsertProjectViewModel(ProjectDialog.Project)
        End If
    End Sub

    Private Sub ListViewDetailsButton_Click(sender As Object, e As RoutedEventArgs)
        Dim Project As ProjectViewModel = CType(sender, MenuFlyoutItem).DataContext
        Frame.Navigate(GetType(DetailsPage), Project)
    End Sub

    Private Async Sub ListViewUpdateButton_Click(sender As Object, e As RoutedEventArgs)
        Dim ProjectUpdate As ProjectViewModel = CType(sender, MenuFlyoutItem).DataContext
        Dim UpdateProjectDialogue As New UpdateDialogue(ProjectUpdate)
        Dim Result As ContentDialogResult = Await UpdateProjectDialogue.ShowAsync()
        If Result = ContentDialogResult.Primary Then
            ViewModel.UpdateProjectViewModel(ProjectUpdate)
        End If
    End Sub

    Private Async Sub ListViewDeleteButton_Click(sender As Object, e As RoutedEventArgs)
        Dim Project As ProjectViewModel = CType(sender, MenuFlyoutItem).DataContext
        Dim Dialog As New ContentDialog With {
            .Title = "Warning!",
            .Content = "Are you sure you want to delete this Project?",
            .PrimaryButtonText = "Yes",
            .SecondaryButtonText = "No"
        }
        Dim Result As ContentDialogResult = Await Dialog.ShowAsync()
        If Result = ContentDialogResult.Primary Then
            ViewModel.DeleteProject(Project)
        End If
    End Sub

    Private Sub SortIdButton_Click(sender As Object, e As RoutedEventArgs)
        ViewModel.SortById()
    End Sub

    Private Sub SortProjectButton_Click(sender As Object, e As RoutedEventArgs)
        ViewModel.SortByProject()
    End Sub

    Private Sub SortDateButton_Click(sender As Object, e As RoutedEventArgs)
        ViewModel.SortByDate()
    End Sub

    Private Sub SortStatusButton_Click(sender As Object, e As RoutedEventArgs)
        ViewModel.SortByStatus()
    End Sub
End Class
