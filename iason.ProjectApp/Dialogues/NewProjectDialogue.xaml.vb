' The Content Dialog item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

Imports ViewModel

Public NotInheritable Class NewProjectDialogue
    Inherits ContentDialog

    Implements INotifyPropertyChanged
#Region "INotifyPropertyChanged"
    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged
    Public Sub NotifyPropertyChanged(<CallerMemberName> Optional ByVal PropertyName As String = Nothing)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(PropertyName))
    End Sub
#End Region

    Sub New(Project As ProjectViewModel)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.Project = Project
    End Sub


    Private _Project As ProjectViewModel
    ''' <summary>
    ''' Gets or sets 
    ''' </summary>
    ''' <returns></returns>
    Public Property Project() As ProjectViewModel
        Get
            Return _Project
        End Get
        Set
            If _Project IsNot Value Then
                _Project = Value
                NotifyPropertyChanged()
            End If
        End Set
    End Property

    Private Sub ContentDialog_PrimaryButtonClick(sender As ContentDialog, args As ContentDialogButtonClickEventArgs)

    End Sub

    Private Sub ContentDialog_SecondaryButtonClick(sender As ContentDialog, args As ContentDialogButtonClickEventArgs)

    End Sub
End Class
