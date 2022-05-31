' The Content Dialog item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

Imports ViewModel

Public NotInheritable Class UpdateDialogue
    Inherits ContentDialog

    Dim ViewModel As UpdateDialogueViewModel

    Sub New(Project As ProjectViewModel, Optional Contracts As List(Of ContractViewModel) = Nothing)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.ViewModel = New UpdateDialogueViewModel(Project, Contracts)
    End Sub

    Private Sub ContentDialog_PrimaryButtonClick(sender As ContentDialog, args As ContentDialogButtonClickEventArgs)

    End Sub

    Private Sub ContentDialog_SecondaryButtonClick(sender As ContentDialog, args As ContentDialogButtonClickEventArgs)

    End Sub
End Class
