Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports ViewModel
Imports Moq
Imports Model

Namespace iason.ProjectApp.Test
    Public Class MockManager
        Property ArmoxInitialized As Boolean
        Property Mocks As New Dictionary(Of Type, Object)



        Function [Get](Of T As Class)() As Mock(Of T)
            If Mocks.ContainsKey(GetType(T)) Then
                Return Mocks(GetType(T))
            Else
                Dim Mock As New Mock(Of T)
                Mocks.Add(GetType(T), Mock)
                Return Mock
            End If
        End Function
    End Class

    <TestClass>
    Public Class LoginPageViewModelTests
        ReadOnly MockManager As New MockManager
        Property ViewModel As New LoginPageViewModel

        Private Sub SetupUserService(User As User)
            Dim Mock = MockManager.Get(Of IUserService)
            Mock.Setup(Of User)(Function(US) US.Login(It.IsAny(Of String), It.IsAny(Of String))).
                Returns(Function() User)
            ViewModel.UserService = Mock.Object
        End Sub

        <TestInitialize>
        Sub Initialize()
            'SetupUserService()
        End Sub
        <TestMethod>
        Sub SubmitLogin_IsLoginRequested_RaisesEventWithTrue()
            ' Arrange. 
            SetupUserService(New User)
            Dim WasEventRaised As Boolean

            AddHandler ViewModel.LoginRequested, Sub()
                                                     WasEventRaised = True
                                                 End Sub

            ' Act. 
            ViewModel.SubmitLogin()

            ' Assert. 
            Assert.IsTrue(WasEventRaised)
        End Sub

        <TestMethod>
        Sub SubmitLogin_IsLoginFailed_RaisesEventWithTrue()
            ' Arrange. 
            SetupUserService(Nothing)
            Dim WasEventRaised As Boolean

            AddHandler ViewModel.LoginFailed, Sub()
                                                  WasEventRaised = True
                                              End Sub

            ' Act. 
            ViewModel.SubmitLogin()

            ' Assert. 
            Assert.IsTrue(WasEventRaised)
        End Sub
    End Class
End Namespace
