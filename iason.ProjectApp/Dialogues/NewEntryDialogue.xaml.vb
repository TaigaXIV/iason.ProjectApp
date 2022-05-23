' The Content Dialog item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

Imports ViewModel

Public NotInheritable Class NewEntryDialogue
    Inherits ContentDialog

    Implements INotifyPropertyChanged
#Region "INotifyPropertyChanged"
    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged
    Public Sub NotifyPropertyChanged(<CallerMemberName> Optional ByVal PropertyName As String = Nothing)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(PropertyName))
    End Sub
#End Region

    Sub New(Entry As EntryViewModel)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.Entry = Entry
    End Sub


    Private _Entry As EntryViewModel
    ''' <summary>
    ''' Gets or sets 
    ''' </summary>
    ''' <returns></returns>
    Public Property Entry() As EntryViewModel
        Get
            Return _Entry
        End Get
        Set
            If _Entry IsNot Value Then
                _Entry = Value
                NotifyPropertyChanged()
            End If
        End Set
    End Property

    Private Sub ContentDialog_PrimaryButtonClick(sender As ContentDialog, args As ContentDialogButtonClickEventArgs)

    End Sub

    Private Sub ContentDialog_SecondaryButtonClick(sender As ContentDialog, args As ContentDialogButtonClickEventArgs)

    End Sub
End Class
