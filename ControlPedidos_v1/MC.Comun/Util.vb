Imports Microsoft.VisualBasic

Namespace MC.Comun
    Public Class Util
        Public Shared Function Encripta(ByVal cClave As String) As String

            'cClave = Trim$(cClave)

            'Dim cRetorno As cRetorno = ""
            'Dim nLetra As Integer

            'For i% = 1 To Len(cClave) - 1
            '    nLetra = Asc(Mid(cClave, i%, 1)) + Asc(Mid(cClave$, i% + 1, 1))
            '    cRetorno$ = cRetorno$ & Chr$(nLetra%)
            'Next i%
            'Encripta = cRetorno$ & Right$(cClave$, 1)

        End Function

        Public Shared Function Desencripta(ByVal cClave As String) As String

            cClave = Trim(cClave)

            Dim cRetorno = Right(cClave, 1)
            Dim i As Integer
            Dim nLetra As Integer

            For i = Len(cClave) - 1 To 1 Step -1
                nLetra = Asc(Mid(cClave, i, 1)) - Asc(Mid(cRetorno, 1, 1))
                cRetorno = Chr(nLetra) & cRetorno
            Next i
            Desencripta = cRetorno

        End Function
    End Class
End Namespace