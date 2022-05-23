Public Class BooleanInverterConverter
    Implements IValueConverter

    Public Function Convert(value As Object, targetType As Type, parameter As Object, language As String) As Object Implements IValueConverter.Convert
        If TypeOf value IsNot Boolean Then
            Throw New ArgumentException("Value is not of type bool. Check the source property. Maybe still String?")
        End If

        If value Is Nothing Then
            Return Nothing
        Else
            Return Not value
        End If
    End Function

    Public Function ConvertBack(value As Object, targetType As Type, parameter As Object, language As String) As Object Implements IValueConverter.ConvertBack
        If value Is Nothing Then
            Return Nothing
        Else
            Return Not value
        End If
    End Function
End Class
