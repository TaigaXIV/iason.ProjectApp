Imports Model

Public Class ContractViewModel
    Inherits ViewModelBase

    Property Model As Contract

    Sub New(Contract As Contract)
        Me.Model = Contract
    End Sub

    Public Overrides Function ToString() As String
        Return Name
    End Function

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
