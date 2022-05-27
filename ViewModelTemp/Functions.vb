Imports System.ComponentModel
Imports System.Reflection

Public Module Functions
    ''' <summary>
    ''' Returns a new string array that represents the descriptions of a enumeration object.
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    ''' <returns></returns>
    ''' <exception cref="ArgumentException">Thrown if the passed generic type is not an <see cref="System.Enum"/></exception>
    Public Function EnumToComboBoxItems(Of T)() As String()
        If Not GetType(T).IsEnum Then
            Throw New ArgumentException(NameOf(T), "The passed type is not an Enumeration type.")
        Else
            Dim Descriptions = [Enum].GetValues(GetType(T))
            Dim List As New List(Of String)
            For Each Description As [Enum] In Descriptions
                List.Add(GetEnumDescription(Description))
            Next Description
            Return List.ToArray
        End If
    End Function

    Public Function GetEnumDescription(ByVal Enumeration As [Enum]) As String
        Dim FieldInfo As FieldInfo = Enumeration.[GetType]().GetField(Enumeration.ToString())
        Dim Attributes As DescriptionAttribute() = CType(FieldInfo.GetCustomAttributes(GetType(DescriptionAttribute), False), DescriptionAttribute())
        If Attributes IsNot Nothing AndAlso Attributes.Length > 0 Then
            Return Attributes(0).Description
        Else
            Return Enumeration.ToString()
        End If
    End Function
End Module
