Imports System.Collections.ObjectModel
Imports Model

Public Class UpdateDialogueViewModel
    Inherits ViewModelBase

    Property ProjectService As New ProjectService
    Property ContractService As New ContractService

    Dim Model As Project

    Sub New(Project As ProjectViewModel)
        Me.Model = Project.Model
        ProjectStatusSelectedIndex = Project.Status
        InitializeContracts()
    End Sub

    Private Sub InitializeContracts()
        Dim ContractList = ContractService.List().AsEnumerable.Select(Function(C) New ContractViewModel(C))
        Contracts = New ObservableCollection(Of ContractViewModel)(ContractList)
        If Me.Model.ProjectContracts Is Nothing Then
            Me.Model.ProjectContracts = New List(Of ProjectContract)
            ProjectContracts = New ObservableCollection(Of ContractViewModel)
        Else
            Dim ContractIds = Me.Model.ProjectContracts.Select(Of Integer)(Function(pc) pc.ContractId)
            ProjectContracts = New ObservableCollection(Of ContractViewModel)(ContractList.Where(Function(c) ContractIds.Contains(c.Model.Id)))
            For Each Contract As ContractViewModel In ProjectContracts
                Contracts.Remove(Contract)
            Next
        End If
    End Sub

    Private _Contracts As ObservableCollection(Of ContractViewModel)
    ''' <summary>
    ''' Gets or sets 
    ''' </summary>
    ''' <returns></returns>
    Public Property Contracts() As ObservableCollection(Of ContractViewModel)
        Get
            Return _Contracts
        End Get
        Set
            If _Contracts IsNot Value Then
                _Contracts = Value
                NotifyPropertyChanged()
            End If
        End Set
    End Property

    Private _ProjectContracts As ObservableCollection(Of ContractViewModel)
    ''' <summary>
    ''' Gets or sets 
    ''' </summary>
    ''' <returns></returns>
    Public Property ProjectContracts() As ObservableCollection(Of ContractViewModel)
        Get
            Return _ProjectContracts
        End Get
        Set
            If _ProjectContracts IsNot Value Then
                _ProjectContracts = Value
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
    ''' Gets or sets the index of projectstatus
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

    Private _ContractSelectedIndex As Integer = -1
    ''' <summary>
    ''' Gets or sets 
    ''' </summary>
    ''' <returns></returns>
    Public Property ContractSelectedIndex() As Integer
        Get
            Return _ContractSelectedIndex
        End Get
        Set
            If _ContractSelectedIndex <> Value Then
                _ContractSelectedIndex = Value
                NotifyPropertyChanged()
            End If
        End Set
    End Property

    Public Function CreateNewProject() As ProjectViewModel
        Dim Project As New Project With {.Name = Name, .Status = ProjectStatus.New, .DateCreated = New DateTimeOffset(Date.Now)}
        Project.Id = ProjectService.Create(Project)
        Model = Project
        Return New ProjectViewModel(Project)
    End Function

    Public Sub AddContract(Contract As ContractViewModel)
        Contracts.Remove(Contracts.FirstOrDefault(Function(c) c.Name = Contract.Name))
        ProjectContracts.Add(Contract)
        Model.ProjectContracts.Add(New ProjectContract With {.ProjectId = Model.Id, .ContractId = Contract.Model.Id})
        ContractSelectedIndex = -1
    End Sub

    Public Sub RemoveContract(Contract As ContractViewModel)
        Contracts.Insert(0, Contract)
        Model.ProjectContracts.Remove(Model.ProjectContracts.FirstOrDefault(Function(pc) pc.ContractId = Contract.Model.Id))
        ProjectContracts.Remove(Contracts.FirstOrDefault(Function(c) c.Name = Contract.Name))
    End Sub
End Class
