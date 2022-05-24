﻿Imports Model

Public Class EntryViewModel
    Inherits ViewModelBase

    Property Model As Entry

    Sub New(Entry As Entry)
        Me.Model = Entry
        SelectedUser = New UserViewModel(Entry.User)
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

    Property StartTime As TimeSpan
        Get
            Return Model.StartTime
        End Get
        Set
            If Value <> StartTime Then
                Model.StartTime = Value
                NotifyPropertyChanged()
                NotifyPropertyChanged(NameOf(StartTimeExpression))
                NotifyPropertyChanged(NameOf(Duration))
            End If
        End Set
    End Property

    Public ReadOnly Property StartTimeExpression As String
        Get
            Return StartTime.ToString("hh\:mm")
        End Get
    End Property

    Property EndTime As TimeSpan
        Get
            Return Model.EndTime
        End Get
        Set
            If Value <> EndTime Then
                Model.EndTime = Value
                NotifyPropertyChanged()
                NotifyPropertyChanged(NameOf(EndTimeExpression))
                NotifyPropertyChanged(NameOf(Duration))
            End If
        End Set
    End Property

    Property User As UserViewModel
        Get
            Return New UserViewModel(Model.User)
        End Get
        Set
            If Value IsNot User Then
                Model.User = Value.Model
                NotifyPropertyChanged()
            End If
        End Set
    End Property

    Public ReadOnly Property EndTimeExpression As String
        Get
            Return EndTime.ToString("hh\:mm")
        End Get
    End Property

    Public ReadOnly Property Duration As Integer
        Get
            Return EndTime.Hours - StartTime.Hours
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

    Private _SelectedUser As UserViewModel
    ''' <summary>
    ''' Gets or sets 
    ''' </summary>
    ''' <returns></returns>
    Public Property SelectedUser() As UserViewModel
        Get
            Return _SelectedUser
        End Get
        Set
            If _SelectedUser IsNot Value Then
                _SelectedUser = Value
                NotifyPropertyChanged()
            End If
        End Set
    End Property

End Class
