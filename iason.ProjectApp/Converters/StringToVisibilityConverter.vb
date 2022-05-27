Public Class StringToVisibilityConverter
    Implements IValueConverter

    Public Function Convert(value As Object, targetType As Type, parameter As Object, language As String) As Object Implements IValueConverter.Convert
        If TypeOf value IsNot String Then
            Throw New ArgumentException("Value is not type of String.")
        End If

        If String.IsNullOrWhiteSpace(value) OrElse value = 0 Then
            Return Visibility.Collapsed
        Else
            Return Visibility.Visible
        End If
    End Function

    Public Function ConvertBack(value As Object, targetType As Type, parameter As Object, language As String) As Object Implements IValueConverter.ConvertBack
        'If String.IsNullOrWhiteSpace(value) Then
        '    Return Visibility.Collapsed
        'Else
        '    Return Visibility.Visible
        'End If
    End Function
End Class
