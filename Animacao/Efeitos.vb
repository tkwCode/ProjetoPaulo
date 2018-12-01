Imports System.Windows.Forms

Public Class Efeitos
    Public Shared Sub Letreiro(ByVal control As Control)
        control.Text = Mid(control.Text, 2, Len(control.Text)) & Mid(control.Text, 1, 1)
    End Sub
End Class
