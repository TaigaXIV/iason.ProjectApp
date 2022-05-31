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
                NotifyPropertyChanged(NameOf(StartDateExpression))
            End If
        End Set
    End Property

    Public ReadOnly Property StartDateExpression As String
        Get
            Return StartDate.ToString("dd'.'MM'.'yyyy")
        End Get
    End Property

    Property EndDate As DateTimeOffset
        Get
            Return Model.EndDate
        End Get
        Set
            If Value <> EndDate Then
                Model.EndDate = Value
                NotifyPropertyChanged()
                NotifyPropertyChanged(NameOf(EndDateExpression))

            End If
        End Set
    End Property

    Public ReadOnly Property EndDateExpression As String
        Get
            Return EndDate.ToString("dd'.'MM'.'yyyy")
        End Get
    End Property

    Public Overrides Function Equals(obj As Object) As Boolean
        Return Me.Name = CType(obj, ContractViewModel).Name
    End Function

End Class
