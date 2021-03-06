' The Content Dialog item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

Imports ViewModel

Public NotInheritable Class NewContractDialogue
    Inherits ContentDialog

    Property ViewModel As ContractViewModel

    Sub New(Contract As ContractViewModel)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.ViewModel = Contract
    End Sub

    Private Sub ContentDialog_PrimaryButtonClick(sender As ContentDialog, args As ContentDialogButtonClickEventArgs)
        ViewModel.CreateNewContract()
    End Sub

    Private Sub ContentDialog_SecondaryButtonClick(sender As ContentDialog, args As ContentDialogButtonClickEventArgs)

    End Sub
End Class
