' The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

Imports ViewModel
''' <summary>
''' An empty page that can be used on its own or navigated to within a Frame.
''' </summary>
Public NotInheritable Class DetailsPage
    Inherits Page

    Implements INotifyPropertyChanged
#Region "INotifyPropertyChanged"
    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged
    Public Sub NotifyPropertyChanged(<CallerMemberName> Optional ByVal PropertyName As String = Nothing)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(PropertyName))
    End Sub
#End Region


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
End Class
