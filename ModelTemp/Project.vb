Public Class Project

    Property Id As Integer
    Property Name As String
    Property DateCreated As DateTimeOffset
    Property Entries As Entry
    Property Status As ProjectStatus

End Class

Public Enum ProjectStatus
    [New]
    Active
    Closed
End Enum
