Module PassWD

    Public Sub SetNewPassWD(file As String)
        GenratePassWD(InputBox("Geben Sie ein neues Passwort ein:", "Passwortabfrage"), file)
    End Sub

    Public Function CheckPassWd(phrase As String, file As String)
        Dim hString As String = String.Concat(phrase, XMLRead("PassAdd", file))
        If hString.GetHashCode = XMLRead("Passwd", file) Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Sub GenratePassWD(phrase As String, file As String)
        phrase = phrase + XMLRead("PassAdd", file)
        XMLWrite("Passwd", phrase.GetHashCode, file)
    End Sub

End Module
