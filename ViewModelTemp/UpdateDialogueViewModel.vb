Imports System.Collections.ObjectModel
Imports Model

Public Class UpdateDialogueViewModel
    Inherits ViewModelBase

    Dim Model As Project

    Sub New(Project As ProjectViewModel, Optional Contracts As List(Of ContractViewModel) = Nothing)
        Me.Model = Project.Model
        If Me.Model.Contracts Is Nothing Then
            Me.Model.Contracts = New List(Of Contract)
        End If
        ProjectStatusSelectedIndex = Project.Status
        Me.Contracts = Contracts
        If Project.Contracts IsNot Nothing AndAlso Project.Contracts.Any Then
            ContractSelectedIndex = Contracts.IndexOf(Project.Contracts.First)
        End If
        If ProjectContracts Is Nothing Then
            ProjectContracts = New ObservableCollection(Of ContractViewModel)
        End If
    End Sub

    Public ReadOnly Property Contracts As List(Of ContractViewModel)

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

    Public Sub SetContract()
        Model.Contracts.Add(ProjectContracts(ContractSelectedIndex).Model)
    End Sub

    Public Sub AddContract(Contract As ContractViewModel)
        Contracts.Remove(Contracts.FirstOrDefault(Function(c) c.Name = Contract.Name))
        ProjectContracts.Add(Contract)
    End Sub

    Public Sub RemoveContract(Contract As ContractViewModel)
        Contracts.Insert(0, Contract)
        ProjectContracts.Remove(Contracts.FirstOrDefault(Function(c) c.Name = Contract.Name))
    End Sub
End Class
