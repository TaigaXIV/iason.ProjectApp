' The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

Imports ViewModel
''' <summary>
''' An empty page that can be used on its own or navigated to within a Frame.
''' </summary>
Public NotInheritable Class DetailsPage
    Inherits Page

    Dim ViewModel As DetailsViewModel

    Protected Overrides Sub OnNavigatedTo(e As NavigationEventArgs)
        ViewModel = New DetailsViewModel(e.Parameter)
    End Sub

    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Private Sub BackButton_Click(sender As Object, e As RoutedEventArgs)
        ViewModel.TryGoBack()
    End Sub

    Private Async Sub CreateEntryButton_Click(sender As Object, e As RoutedEventArgs)
        Dim EntryDialogue As New NewEntryDialogue(ViewModel.CreateEntryViewModel())
        Dim Result As ContentDialogResult = Await EntryDialogue.ShowAsync()
        If Result = ContentDialogResult.Primary Then
            ViewModel.InsertEntryViewModel(EntryDialogue.ViewModel.NewEntry)
            ViewModel.CalculateTotalCosts()
        End If
    End Sub

    Private Sub SortEndButton_Click(sender As Object, e As RoutedEventArgs)
        ViewModel.SortByEnd()
    End Sub

    Private Sub SortStartButton_Click(sender As Object, e As RoutedEventArgs)
        ViewModel.SortByStart()
    End Sub

    Private Sub SortDescriptionButton_Click(sender As Object, e As RoutedEventArgs)
        ViewModel.SortByDescription()
    End Sub

    Private Sub SortIdButton_Click(sender As Object, e As RoutedEventArgs)
        ViewModel.SortById()
    End Sub

    Private Sub SortDurationButton_Click(sender As Object, e As RoutedEventArgs)
        ViewModel.SortByDuration()
    End Sub

    Private Sub SortCostButton_Click(sender As Object, e As RoutedEventArgs)
        ViewModel.SortByCost()
    End Sub
End Class
