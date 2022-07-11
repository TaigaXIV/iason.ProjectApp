' The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

Imports ViewModel
''' <summary>
''' An empty page that can be used on its own or navigated to within a Frame.
''' </summary>
Public NotInheritable Class LoginPage
    Inherits Page

    Dim ViewModel As New LoginPageViewModel

    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        AddHandler ViewModel.LoginRequested, AddressOf ViewModel_LoginRequested
        AddHandler ViewModel.LoginFailed, AddressOf ViewModel_LoginFailed
    End Sub

    Private Async Sub ViewModel_LoginFailed()
        Dim Dialog As New ContentDialog With {
            .Title = "Error!",
            .Content = "Something went wrong. Check Email or Password!",
            .PrimaryButtonText = "Close"
        }
        Await Dialog.ShowAsync()
    End Sub

    Private Sub ViewModel_LoginRequested()
        Frame.Navigate(GetType(MainPage))
    End Sub

    Private Async Sub NewUserButton_Click(sender As Object, e As RoutedEventArgs)
        Dim Dialogue As New NewUserDialogue()
        Dim Result As ContentDialogResult = Await Dialogue.ShowAsync()
        If Result = ContentDialogResult.Primary Then
            Frame.Navigate(GetType(MainPage))
        End If
    End Sub
End Class
