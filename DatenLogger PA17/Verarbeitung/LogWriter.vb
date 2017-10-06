Module LogWriter

    Dim absaugung_Activ As Boolean
    Dim Log_path As String

    Public Sub CallLog_Active(StatusBox As TextBox, Path As String, aktlog As TextBox, DB_Nr As Int32, Byte_pos As Int32, bit_Pos As Int32, Fkt As String, User As String)
        Dim Log_Active As Boolean
        Dim help As Boolean
        help = GetBit(DB_Nr, Byte_pos, bit_Pos)
        If Not help Then
            Log_Active = False
            StatusBox.Text = "Absaugen ist Aus"
        Else
            'absaugung_activ = True
            If Not Log_Active Then
                StatusBox.Text = "Log An, Logdatei Kopf"
                Log_Kopf_Absaug(StatusBox, Path, aktlog, User)
            Else
                StatusBox.Text = String.Concat("Log An für ", Fkt)
                Log_Absaug()
            End If

        End If

    End Sub

    Public Sub Log_Absaugleistung(StatusBox As TextBox, Path As String, aktlog As TextBox, User As String)
        Dim help As Boolean
        help = GetBit(242, 1, 1)
        If Not help Then
            absaugung_Activ = False
            StatusBox.Text = "Absaugen ist Aus"
        Else
            'absaugung_activ = True
            If Not absaugung_Activ Then
                StatusBox.Text = "Absaugen An, Logdatei Kopf"
                Log_Kopf_Absaug(StatusBox, Path, aktlog, User)
            Else
                StatusBox.Text = "Absaugen An"
                Log_Absaug()
            End If

        End If

    End Sub

    Private Sub Log_Kopf_Absaug(StatusBox As TextBox, Path As String, aktlog As TextBox, User As String)
        'Dim path As String = "D:\Daten\SL_Log\AbsaugProtokoll_"
        Dim byteBuff As Byte()
        Dim count As Integer
        Dim helpDec As Byte
        'Dim ArrByte() As Byte
        'Dim helpString As String
        'Dim Bit As Boolean

        byteBuff = GetBytes(2001, 0, 130)

        absaugung_Activ = True
        count = IntFromBuffer(2)
        Path = BuildPath(My.Settings.Log_Name, count)
        StatusBox.Text = Path
        aktlog.Text = My.Settings.Log_Name + count.ToString
        Log_path = Path

        helpDec = ByteFromBuffer(0)
        'helpString = CByte(helpDec)
        'Bit = System.Convert.ToBoolean(helpDec)
        'byteBuff = GetBytes(242, 80, 88)

        Write_Line(Path, "PA21_Saugleistung_V1.0_PC_Log")
        Write_Line(Path, "char_0; Startdatum: ; " & Date.Now.Date.ToShortDateString & " ; Startzeit: ; " & Now.ToLocalTime.ToShortTimeString & " ;")
        Write_Line(Path, "char_1; Chargendateiname: ; " & My.Settings.Log_Name & " ;") '& path.Substring(10) & " ;")
        Write_Line(Path, "char_2; Benutzername: ; " & User & " ;") 'GetString(200, 38, 14, 14).Substring(2)
        Write_Line(Path, "Kopf_0; Vorpumpe / Pumpenstand; Gasvolumen Stufe1; Soll Zeit Stufe1; Gasvolumen Stufe2; Saugleistung Stufe2; Gasvolumen Stufe3; Soll Zeit Stufe3; Gasvolumen Stufe4; Soll Zeit Stufe4; Gasvolumen Stufe5; Soll Zeit Stufe5;")
        'Write_Line(path, "Kopf_1; " & GetBit(242, 0, 1).ToString & "; " & GetFloat(242, 80).ToString & "; " & GetFloat(242, 84).ToString & "; " & GetFloat(242, 100).ToString & "; " & GetFloat(242, 104).ToString & "; " & GetFloat(242, 120).ToString & "; " & GetFloat(242, 124).ToString & "; " & GetFloat(242, 140).ToString & "; " & GetFloat(242, 144).ToString & "; " & GetFloat(242, 160).ToString & "; " & GetFloat(242, 164).ToString & "; ")
        Write_Line(Path, "Kopf_1; " & BitInInt(helpDec, 0) & "; " & FloatFromBuffer(byteBuff, 0).ToString & "; " & FloatFromBuffer(byteBuff, 4).ToString & "; " & FloatFromBuffer(byteBuff, 20).ToString & "; " & FloatFromBuffer(byteBuff, 24).ToString & "; " & FloatFromBuffer(byteBuff, 40).ToString & "; " & FloatFromBuffer(byteBuff, 44).ToString & "; " & FloatFromBuffer(byteBuff, 60).ToString & "; " & FloatFromBuffer(byteBuff, 64).ToString & "; " & FloatFromBuffer(byteBuff, 80).ToString & "; " & FloatFromBuffer(byteBuff, 84).ToString & "; ")
        Write_Line(Path, "Proz_0; datum; uhrzeit; 162_Pirani; 261_Baratron; 263_Pirani; 181_Butterfly; 285_Gasregler5; Druck Stufe1; Saugleistung Stufe1; Druck Stufe2; Saugleistung Stufe2; Druck Stufe3; Saugleistung Stufe3; Druck Stufe4; Saugleistung Stufe4; Druck Stufe5; Saugleistung Stufe5;")
    End Sub

    Public Sub Log_Absaug()
        Dim Datum, Uhrzeit As String
        Dim _162, _261, _263, _181, _285, DruckS1, DruckS2, DruckS3, DruckS4, DruckS5, Saug1, Saug2, Saug3, Saug4, Saug5 As String
        Dim byteBuff As Byte()

        Datum = Date.Now.Date.ToShortDateString
        Uhrzeit = Now.TimeOfDay.ToString.Substring(0, 8)

        'Dim daveObj As New libnodave()

        byteBuff = GetBytes(25, 102, 124)
        'daveObj.getFloatfrom(byteBuff, 0)

        _162 = FloatFromBuffer(0) 'GetFloat(25, 102).ToString
        _261 = FloatFromBuffer(60) 'GetFloat(25, 162).ToString
        _263 = FloatFromBuffer(120) 'GetFloat(25, 222).ToString

        _181 = GetFloat(94, 8).ToString
        _285 = GetFloat(94, 884).ToString

        byteBuff = GetBytes(242, 92, 88)

        DruckS1 = FloatFromBuffer(0) 'GetFloat(242, 92).ToString
        DruckS2 = FloatFromBuffer(20) 'GetFloat(242, 112).ToString
        DruckS3 = FloatFromBuffer(40) 'GetFloat(242, 132).ToString
        DruckS4 = FloatFromBuffer(60) 'GetFloat(242, 152).ToString
        DruckS5 = FloatFromBuffer(80) 'GetFloat(242, 172).ToString
        Saug1 = FloatFromBuffer(4) 'GetFloat(242, 96).ToString
        Saug2 = FloatFromBuffer(24) 'GetFloat(242, 116).ToString
        Saug3 = FloatFromBuffer(44) 'GetFloat(242, 136).ToString
        Saug4 = FloatFromBuffer(64) 'GetFloat(242, 156).ToString
        Saug5 = FloatFromBuffer(84) 'GetFloat(242, 176).ToString
        Write_Line(Log_Path, "Proz_1;" & Datum & ";" & Uhrzeit & ";" & _162 & ";" & _261 & ";" & _263 & ";" & _181 & ";" & _285 & ";" & DruckS1 & ";" & Saug1 & ";" & DruckS2 & ";" & Saug2 & ";" & DruckS3 & ";" & Saug3 & ";" & DruckS4 & ";" & Saug4 & ";" & DruckS5 & ";" & Saug5 & ";")
    End Sub

    Public Function BitInInt(Value As Integer, position As Integer) As String
        Dim BinaryString As String
        If position > 15 Then
            position = 15
        End If
        position = 15 - position
        BinaryString = Convert.ToString(CInt(Value), 2).PadLeft(16, "0"c) '16 bits
        BinaryString = BinaryString.Substring(position, 1)
        If String.Equals(BinaryString, "1") Then
            Return "1"
        Else
            Return "0"
        End If

    End Function
End Module
