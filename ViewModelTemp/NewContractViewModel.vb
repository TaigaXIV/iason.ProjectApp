Imports Model

Public Class NewContractViewModel
    Inherits ViewModelBase

    Property Model As Contract

    Sub New()

    End Sub

    Property Name As String
        Get
            Return Model.Name
        End Get
        Set
            If Value <> Name Then
                Model.Name = Value
                NotifyPropertyChanged()
            End If
        End Set
    End Property

    Property StartDate As DateTimeOffset
        Get
            Return Model.StartDate
        End Get
        Set
            If Value <> StartDate Then
                Model.StartDate = Value
                NotifyPropertyChanged()
            End If
        End Set
    End Property

    Property EndDate As DateTimeOffset
        Get
            Return Model.EndDate
        End Get
        Set
            If Value <> EndDate Then
                Model.EndDate = Value
                NotifyPropertyChanged()
            End If
        End Set
    End Property

End Class
