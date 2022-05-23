Imports Model

Public Class EntryViewModel
    Inherits ViewModelBase

    Property Model As Entry

    Sub New(Entry As Entry)
        Me.Model = Entry
    End Sub

    Property Id As Integer
        Get
            Return Model.Id
        End Get
        Set
            If Value <> Id Then
                Model.Id = Value
                NotifyPropertyChanged()
            End If
        End Set
    End Property

    Property Description As String
        Get
            Return Model.Description
        End Get
        Set
            If Value <> Description Then
                Model.Description = Value
                NotifyPropertyChanged()
            End If
        End Set
    End Property

    Property StartTime As DateTimeOffset
        Get
            Return Model.StartTime
        End Get
        Set
            If Value <> StartTime Then
                Model.StartTime = Value
                NotifyPropertyChanged()
            End If
        End Set
    End Property

    Public ReadOnly Property StartTimeExpression As String
        Get
            Return StartTime.ToString("HH':'mm")
        End Get
    End Property

    Property EndTime As DateTimeOffset
        Get
            Return Model.EndTime
        End Get
        Set
            If Value <> EndTime Then
                Model.EndTime = Value
                NotifyPropertyChanged()
            End If
        End Set
    End Property

    Public ReadOnly Property EndTimeExpression As String
        Get
            Return EndTime.ToString("HH':'mm")
        End Get
    End Property

    Property CostPerHour As Integer
        Get
            Return Model.CostPerHour
        End Get
        Set
            If Value <> CostPerHour Then
                Model.CostPerHour = Value
                NotifyPropertyChanged()
            End If
        End Set
    End Property

End Class
