
NotInheritable Class DllImportAttribute
    Inherits Attribute

    Private _p2 As Object
    Private _p3 As Object
    Private _p1 As String

    Sub New(p1 As String, p2 As Object, p3 As Object)
        ' TODO: Complete member initialization 
        _p1 = p1
        _p2 = p2
        _p3 = p3
    End Sub

End Class
