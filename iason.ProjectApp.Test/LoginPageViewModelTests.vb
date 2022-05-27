Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports ViewModel

Namespace iason.ProjectApp.Test
    <TestClass>
    Public Class LoginPageViewModelTests

        ''' <summary>
        ''' email and password is invalid (false)
        ''' </summary>
        <TestMethod>
        Sub IsLoginValid_EmailAndPasswordIsInvalid_False()
            ' Arrange.
            Dim ViewModel As New LoginPageViewModel

            ' Act.
            Dim Actual As Boolean = ViewModel.IsLoginValid("x@x.com", "xxx")

            ' Assert.
            Assert.IsFalse(Actual)
        End Sub

        ''' <summary>
        ''' email and password is valid (true)
        ''' </summary>
        <TestMethod>
        Sub IsLoginValid_EmailAndPasswordIsValid_True()
            ' Arrange. 
            Dim ViewModel As New LoginPageViewModel

            ' Act. 
            Dim Actual As Boolean = ViewModel.IsLoginValid("k.user@online.com", "userpassword")

            ' Assert. 
            Assert.IsTrue(Actual)
        End Sub

        ''' <summary>
        ''' email and password is null or whitespace (false)
        ''' </summary>
        <DataRow(Nothing, Nothing)>
        <DataRow(" ", " ")>
        <TestMethod>
        Sub IsLoginValid_EmailAndPasswordIsNullOrWhitespace_False(Email As String, Password As String)
            ' Arrange. 
            Dim ViewModel As New LoginPageViewModel

            ' Act. 
            Dim Actual As Boolean = ViewModel.IsLoginValid(Email, Password)

            ' Assert. 
            Assert.IsFalse(Actual)
        End Sub

        ''' <summary>
        ''' email and password is empty (false)
        ''' </summary>
        <TestMethod>
        Sub IsLoginValid_EmailAndPasswordIsEmpty_False()
            ' Arrange. 
            Dim ViewModel As New LoginPageViewModel

            ' Act. 
            Dim Actual As Boolean = ViewModel.IsLoginValid("", "")

            ' Assert. 
            Assert.IsFalse(Actual)
        End Sub

        ''' <summary>
        ''' passwordcheck is casesensitive
        ''' </summary>
        <TestMethod>
        Sub IsLoginValid_PasswordCheckIsCaseSensitive_False()
            ' Arrange. 
            Dim ViewModel As New LoginPageViewModel

            ' Act. 
            Dim Actual As Boolean = ViewModel.IsLoginValid("k.admin@online.com", "admiNp4ssword".ToUpper)

            ' Assert. 
            Assert.IsFalse(Actual)
        End Sub

        ''' <summary>
        ''' email whitespaces trimmed (true)
        ''' </summary>
        <TestMethod>
        Sub IsLoginValid_EmailWhitespacesAreTrimmed_True()
            ' Arrange. 
            Dim ViewModel As New LoginPageViewModel

            ' Act. 
            Dim Actual As Boolean = ViewModel.IsLoginValid(" k.admin@online.com ", "admiNp4sswoRd")


            ' Assert. 
            Assert.IsTrue(Actual)
        End Sub

        ''' <summary>
        ''' email is lowerCase (true)
        ''' </summary>
        <TestMethod>
        Sub IsLoginValid_EmailIsLowerCase_True()
            ' Arrange. 
            Dim ViewModel As New LoginPageViewModel

            ' Act. 
            Dim Actual As Boolean = ViewModel.IsLoginValid("k.AdMiN@oNlInE.CoM", "admiNp4sswoRd")

            ' Assert. 
            Assert.IsTrue(Actual)
        End Sub


        <TestMethod>
        Sub SubmitLogin_IsUserAdmin_RaisesEventWithTrue()
            ' Arrange. 
            Dim ViewModel As New LoginPageViewModel
            ViewModel.Email = "k.admin@online.com"
            ViewModel.Password = "admiNp4sswoRd"

            Dim WasEventRaised As Boolean
            Dim EventParameter As Boolean

            AddHandler ViewModel.LoginRequested, Sub(Value As Boolean)
                                                     WasEventRaised = True
                                                     EventParameter = Value
                                                 End Sub

            ' Act. 
            ViewModel.SubmitLogin()

            ' Assert. 
            Assert.IsTrue(WasEventRaised)
            Assert.IsTrue(EventParameter)
        End Sub

        <TestMethod>
        Sub SubmitLogin_IsNotUserAdmin_RaisesEventWithFalse()
            ' Arrange. 
            Dim ViewModel As New LoginPageViewModel
            ViewModel.Email = "k.user@online.com"
            ViewModel.Password = "userpassword"

            Dim WasEventRaised As Boolean
            Dim EventParameter As Boolean

            AddHandler ViewModel.LoginRequested, Sub(Value As Boolean)
                                                     WasEventRaised = True
                                                     EventParameter = Value
                                                 End Sub

            ' Act. 
            ViewModel.SubmitLogin()

            ' Assert. 
            Assert.IsTrue(WasEventRaised)
            Assert.IsFalse(EventParameter)
        End Sub

        <TestMethod>
        Sub SubmitLogin_IsLoginFailed_RaisesEventWithTrue()
            ' Arrange. 
            Dim ViewModel As New LoginPageViewModel
            ViewModel.Email = ""
            ViewModel.Password = ""

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
