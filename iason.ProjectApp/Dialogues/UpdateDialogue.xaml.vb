' The Content Dialog item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

Imports ViewModel

Public NotInheritable Class UpdateDialogue
    Inherits ContentDialog

    Dim ViewModel As UpdateDialogueViewModel

    Sub New(Project As ProjectViewModel)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.ViewModel = New UpdateDialogueViewModel(Project)
    End Sub

    Private Sub ContentDialog_PrimaryButtonClick(sender As ContentDialog, args As ContentDialogButtonClickEventArgs)

    End Sub

    Private Sub ContentDialog_SecondaryButtonClick(sender As ContentDialog, args As ContentDialogButtonClickEventArgs)

    End Sub

    Private Sub ContractComboBox_SelectionChanged(sender As Object, e As SelectionChangedEventArgs)
        Dim Contract As ContractViewModel = CType(sender, ComboBox).SelectedItem
        If Contract IsNot Nothing Then
            ViewModel.AddContract(Contract)
        End If
    End Sub

    Private Sub ListView_ItemClick(sender As Object, e As ItemClickEventArgs)
        Dim Contract As ContractViewModel = e.ClickedItem
        ViewModel.RemoveContract(Contract)
    End Sub
End Class
