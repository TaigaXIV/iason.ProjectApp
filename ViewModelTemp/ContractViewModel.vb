Imports Model

Public Class ContractViewModel
    Inherits ViewModelBase

    Property Model As Contract
    Property ContractService As New ContractService

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

    Private _StartDate As DateTimeOffset = New DateTimeOffset(Date.Now)
    ''' <summary>
    ''' Gets or sets 
    ''' </summary>
    ''' <returns></returns>
    Public Property StartDate() As DateTimeOffset
        Get
            Return _StartDate
        End Get
        Set
            If _StartDate <> Value Then
                _StartDate = Value
                NotifyPropertyChanged()
            End If
        End Set
    End Property

    Public ReadOnly Property StartDateExpression As String
        Get
            Return StartDate.ToString("dd'.'MM'.'yyyy")
        End Get
    End Property

    Private _EndDate As DateTimeOffset = New DateTimeOffset(Date.Now.AddDays(30))
    ''' <summary>
    ''' Gets or sets 
    ''' </summary>
    ''' <returns></returns>
    Public Property EndDate() As DateTimeOffset
        Get
            Return _EndDate
        End Get
        Set
            If _EndDate <> Value Then
                _EndDate = Value
                NotifyPropertyChanged()
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

    Public Sub CreateNewContract()
        Dim Contract As New Contract With {.Name = Name, .StartDate = StartDate, .EndDate = EndDate}
        ContractService.Create(Contract)
    End Sub

End Class
