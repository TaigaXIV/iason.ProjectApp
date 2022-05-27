Imports Model

Public Class ProjectViewModel
    Inherits ViewModelBase

    Property Model As Project

    Sub New(Project As Project, IsAdmin As Boolean)
        Me.Model = Project
        Me.IsAdmin = IsAdmin
    End Sub

    ''' <summary>
    ''' gets or sets the Id of project
    ''' </summary>
    ''' <returns></returns>
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

    ''' <summary>
    ''' gets or sets Name of project
    ''' </summary>
    ''' <returns></returns>
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

    ''' <summary>
    ''' gets or sets the creation date of project
    ''' </summary>
    ''' <returns></returns>
    Property DateCreated As DateTimeOffset
        Get
            Return Model.DateCreated
        End Get
        Set
            If Value <> DateCreated Then
                Model.DateCreated = Value
                NotifyPropertyChanged()
                NotifyPropertyChanged(NameOf(DateCreatedExpression))
            End If
        End Set
    End Property

    Public ReadOnly Property DateCreatedExpression As String
        Get
            Return DateCreated.ToString("dd'.'MM'.'yyyy")
        End Get
    End Property

    ''' <summary>
    ''' gets or sets the entries for the specified project
    ''' </summary>
    ''' <returns></returns>
    Property Entries As Entry
        Get
            Return Model.Entries
        End Get
        Set
            If Value IsNot Entries Then
                Model.Entries = Value
                NotifyPropertyChanged()
            End If
        End Set
    End Property

    ''' <summary>
    ''' gets or sets the status of project
    ''' </summary>
    ''' <returns></returns>
    Property Status As ProjectStatus
        Get
            Return Model.Status
        End Get
        Set
            If Value <> Status Then
                Model.Status = Value
                NotifyPropertyChanged()
                NotifyPropertyChanged(NameOf(StatusExpression))
            End If
        End Set
    End Property

    ReadOnly Property StatusExpression As String
        Get
            Return StatusList(Model.Status)
        End Get
    End Property

    Public ReadOnly Property IsAdmin As Boolean

    Private _StatusList As List(Of String) = System.Enum.GetNames(GetType(ProjectStatus)).ToList
    ''' <summary>
    ''' Gets or sets 
    ''' </summary>
    ''' <returns></returns>
    Public Property StatusList() As List(Of String)
        Get
            Return _StatusList
        End Get
        Set
            If _StatusList IsNot Value Then
                _StatusList = Value
                NotifyPropertyChanged()
            End If
        End Set
    End Property

End Class
