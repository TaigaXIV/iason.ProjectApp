Imports Model

Public Class UpdateDialogueViewModel
    Inherits ViewModelBase

    Dim Model As Project

    Sub New(Project As ProjectViewModel)
        Me.Model = Project.Model
        ProjectStatusSelectedIndex = Project.Status
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

    Property Status As ProjectStatus
        Get
            Return Model.Status
        End Get
        Set
            If Value <> Status Then
                Model.Status = Value
                NotifyPropertyChanged()
            End If
        End Set
    End Property

    Property DateCreated As DateTimeOffset
        Get
            Return Model.DateCreated
        End Get
        Set
            If Value <> DateCreated Then
                Model.DateCreated = Value
                NotifyPropertyChanged()
            End If
        End Set
    End Property

    Public ReadOnly Property ProjectStatuses As String() = EnumToComboBoxItems(Of ProjectStatus)()

    Private _ProjectStatusSelectedIndex As Integer = -1
    ''' <summary>
    ''' Gets or sets 
    ''' </summary>
    ''' <returns></returns>
    Public Property ProjectStatusSelectedIndex() As Integer
        Get
            Return _ProjectStatusSelectedIndex
        End Get
        Set
            If _ProjectStatusSelectedIndex <> Value Then
                _ProjectStatusSelectedIndex = Value
                NotifyPropertyChanged()
                Model.Status = ProjectStatusSelectedIndex
            End If
        End Set
    End Property

End Class
