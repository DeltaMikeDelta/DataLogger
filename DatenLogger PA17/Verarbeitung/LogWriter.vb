Module LogWriter

    Dim absaugung_Activ As Boolean
    Dim Lecktest_Activ As Boolean
    Dim Prozess_Activ As Boolean
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

    Public Sub Log_Absaugleistung(StatusBox As TextBox, Path As String, aktlog As TextBox, User As String, Active As Boolean)
        'Dim help As Boolean
        'help = GetBit(242, 1, 1)
        If Not Active Then
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

    Public Sub Log_Lecktest(StatusBox As TextBox, Path As String, aktlog As TextBox, User As String, Active As Boolean)
        'Dim help As Boolean
        'help = GetBit(242, 1, 1)
        If Not Active Then
            Lecktest_Activ = False
            StatusBox.Text = "Lecktest ist Aus"
        Else
            'absaugung_activ = True
            If Not Lecktest_Activ Then
                StatusBox.Text = "Lecktest An, Logdatei Kopf"
                Log_Kopf_Leck(StatusBox, aktlog, User)
            Else
                StatusBox.Text = "Lecktest An"
                Log_Leck()
            End If

        End If

    End Sub

    Private Sub Log_Kopf_Absaug(StatusBox As TextBox, Path As String, aktlog As TextBox, User As String)
        'Dim path As String = "D:\Daten\SL_Log\AbsaugProtokoll_"
        Dim byteBuff As Byte()
        Dim count As Integer
        Dim helpDec As Byte

        byteBuff = GetBytes(2001, 0, 58)

        absaugung_Activ = True
        count = IntFromBuffer(2)
        Path = BuildPath(My.Settings.Log_Name, count)
        StatusBox.Text = Path
        aktlog.Text = My.Settings.Log_Name + count.ToString
        Log_path = Path

        helpDec = ByteFromBuffer(0)

        Write_Line(Path, "PA21_Saugleistung_V1.0_PC_Log")
        Write_Line(Path, "char_0; Startdatum: ; " & Date.Now.Date.ToShortDateString & " ; Startzeit: ; " & Now.ToLocalTime.ToShortTimeString & " ;")
        Write_Line(Path, "char_1; Chargendateiname: ; " & aktlog.Text & " ;") '& path.Substring(10) & " ;")
        Write_Line(Path, "char_2; Benutzername: ; " & User & " ;") 'GetString(200, 38, 14, 14).Substring(2)
        Write_Line(Path, "Kopf_0; Vorpumpe / Pumpenstand; Strang A; Strang B; Wartezeit [sek]; Gasvolumen Stufe1 [sccm]; Soll Zeit Stufe1 [sek]; Gasvolumen Stufe2 [sccm]; Soll Zeit Stufe2 [sek]; Gasvolumen Stufe3 [sccm]; Soll Zeit Stufe3 [sek]; Gasvolumen Stufe4 [sccm]; Soll Zeit Stufe4 [sek]; Gasvolumen Stufe5 [sccm]; Soll Zeit Stufe5 [sek];")
        'Write_Line(path, "Kopf_1; " & GetBit(242, 0, 1).ToString & "; " & GetFloat(242, 80).ToString & "; " & GetFloat(242, 84).ToString & "; " & GetFloat(242, 100).ToString & "; " & GetFloat(242, 104).ToString & "; " & GetFloat(242, 120).ToString & "; " & GetFloat(242, 124).ToString & "; " & GetFloat(242, 140).ToString & "; " & GetFloat(242, 144).ToString & "; " & GetFloat(242, 160).ToString & "; " & GetFloat(242, 164).ToString & "; ")
        Write_Line(Path, "Kopf_1; " & BitInInt(helpDec, 0) & "; " & BitInInt(helpDec, 1) & "; " & BitInInt(helpDec, 2) & "; " & FloatFromBuffer(byteBuff, 10).ToString & "; " & FloatFromBuffer(byteBuff, 18).ToString & "; " & FloatFromBuffer(byteBuff, 38).ToString & "; " & FloatFromBuffer(byteBuff, 22).ToString & "; " & FloatFromBuffer(byteBuff, 42).ToString & "; " & FloatFromBuffer(byteBuff, 26).ToString & "; " & FloatFromBuffer(byteBuff, 46).ToString & "; " & FloatFromBuffer(byteBuff, 30).ToString & "; " & FloatFromBuffer(byteBuff, 50).ToString & "; " & FloatFromBuffer(byteBuff, 34).ToString & "; " & FloatFromBuffer(byteBuff, 54).ToString & "; ")
        Write_Line(Path, "Proz_0; datum; uhrzeit; 162_Pirani_A [mbar]; 163_Pirani_B [mbar]; 261_Baratron [mbar]; 262_Pirani Mess [mbar]; 263_Pirani Referenz [mbar]; 181_Butterfly [%]; 191_Butterfly [%]; 284_Gasregler5 [sccm]; Druck Stufe1  [mbar]; Saugleistung Stufe1; Druck Stufe2 [mbar]; Saugleistung Stufe2; Druck Stufe3 [mbar]; Saugleistung Stufe3; Druck Stufe4 [mbar]; Saugleistung Stufe4; Druck Stufe5 [mbar]; Saugleistung Stufe5;")
    End Sub

    Public Sub Log_Absaug()
        Dim Datum, Uhrzeit As String
        Dim _162, _163, _261, _262, _263, _181, _191, _285, DruckS1, DruckS2, DruckS3, DruckS4, DruckS5, Saug1, Saug2, Saug3, Saug4, Saug5 As String
        Dim byteBuff As Byte()

        Datum = Date.Now.Date.ToShortDateString
        Uhrzeit = Now.TimeOfDay.ToString.Substring(0, 8)

        byteBuff = GetBytes(2001, 58, 72)

        _162 = FloatFromBuffer(0)
        _163 = FloatFromBuffer(4)
        _261 = FloatFromBuffer(12)
        _262 = FloatFromBuffer(8)
        _263 = FloatFromBuffer(16)

        _181 = FloatFromBuffer(20)
        _191 = FloatFromBuffer(24)
        _285 = FloatFromBuffer(28)

        DruckS1 = FloatFromBuffer(32)
        DruckS2 = FloatFromBuffer(40)
        DruckS3 = FloatFromBuffer(48)
        DruckS4 = FloatFromBuffer(56)
        DruckS5 = FloatFromBuffer(64)
        Saug1 = FloatFromBuffer(36)
        Saug2 = FloatFromBuffer(44)
        Saug3 = FloatFromBuffer(52)
        Saug4 = FloatFromBuffer(60)
        Saug5 = FloatFromBuffer(68)

        Write_Line(Log_path, "Proz_1;" & Datum & ";" & Uhrzeit & ";" & _162 & ";" & _163 & ";" & _261 & ";" & _262 & ";" & _263 & ";" & _181 & ";" & _191 & ";" & _285 & ";" & DruckS1 & ";" & Saug1 & ";" & DruckS2 & ";" & Saug2 & ";" & DruckS3 & ";" & Saug3 & ";" & DruckS4 & ";" & Saug4 & ";" & DruckS5 & ";" & Saug5 & ";")
    End Sub

    Private Sub Log_Kopf_Leck(StatusBox As TextBox, aktlog As TextBox, User As String)
        Dim path As String = "D:\Daten\SL_Log\LeckrateProtokoll_"
        Dim byteBuff As Byte()
        Dim count As Integer
        Dim helpDec As Int16

        byteBuff = GetBytes(2002, 0, 30)

        absaugung_Activ = True
        count = IntFromBuffer(2)
        path = String.Concat(path, count)
        StatusBox.Text = path
        aktlog.Text = path 'My.Settings.Log_Name + count.ToString
        Log_path = path

        helpDec = IntFromBuffer(0)

        Write_Line(path, "PA21_Leckrate_V1.0_PC_Log")
        Write_Line(Path, "char_0; Startdatum: ; " & Date.Now.Date.ToShortDateString & " ; Startzeit: ; " & Now.ToLocalTime.ToShortTimeString & " ;")
        Write_Line(Path, "char_1; Chargendateiname: ; " & aktlog.Text & " ;") '& path.Substring(10) & " ;")
        Write_Line(Path, "char_2; Benutzername: ; " & User & " ;") 'GetString(200, 38, 14, 14).Substring(2)
        Write_Line(path, "Kopf_0; Druck / Zeit; Abpumpzeit [sek]; Basisdruck [mbar]; Kammervolumen [cm³]; Wartezeit [min]; RegelventilZu;")
        Write_Line(path, "Kopf_1; " & BitInInt(helpDec, 0) & "; " & FloatFromBuffer(byteBuff, 10).ToString & "; " & FloatFromBuffer(byteBuff, 18).ToString & "; " & FloatFromBuffer(byteBuff, 22).ToString & "; " & FloatFromBuffer(byteBuff, 14).ToString & "; " & BitInInt(helpDec, 1) & "; ")
        Write_Line(path, "Proz_0; datum; uhrzeit; 162_Pirani_A [mbar]; 163_Pirani_B [mbar]; 261_Baratron [mbar]; 262_Pirani Mess [mbar]; 263_Pirani Referenz [mbar]; 181_Butterfly [%]; 191_Butterfly [%]; Druck_P1 [mbar]; Druck_P2 [mbar]; Leckrate;")
    End Sub

    Public Sub Log_Leck()
        Dim Datum, Uhrzeit As String
        Dim _162, _163, _261, _262, _263, _181, _191, DruckS1, DruckS2, Leckrate As String
        Dim byteBuff As Byte()

        Datum = Date.Now.Date.ToShortDateString
        Uhrzeit = Now.TimeOfDay.ToString.Substring(0, 8)

        byteBuff = GetBytes(2002, 58, 40)

        _162 = FloatFromBuffer(0)
        _163 = FloatFromBuffer(4)
        _261 = FloatFromBuffer(12)
        _262 = FloatFromBuffer(8)
        _263 = FloatFromBuffer(16)

        _181 = FloatFromBuffer(20)
        _191 = FloatFromBuffer(24)

        DruckS1 = FloatFromBuffer(28)
        DruckS2 = FloatFromBuffer(32)

        Leckrate = FloatFromBuffer(36)

        Write_Line(Log_path, "Proz_1;" & Datum & ";" & Uhrzeit & ";" & _162 & ";" & _163 & ";" & _261 & ";" & _262 & ";" & _263 & ";" & _181 & ";" & _191 & ";" & DruckS1 & ";" & DruckS2 & ";" & Leckrate & ";")
    End Sub

    Private Sub Log_Kopf_Prozess(StatusBox As TextBox, aktlog As TextBox, User As String)
        Dim path As String = "D:\Daten\SL_Log\ChargenProtokoll_"
        Dim byteBuff As Byte()
        Dim SegBuff As Byte()
        Dim count As Integer
        Dim helpDec As Int16


        byteBuff = GetBytes(2003, 0, 30)
        SegBuff = GetBytes(104, 200, 8600)

        absaugung_Activ = True
        count = IntFromBuffer(2)
        path = String.Concat(path, count)
        StatusBox.Text = path
        aktlog.Text = path 'My.Settings.Log_Name + count.ToString
        Log_path = path

        helpDec = IntFromBuffer(0)

        Write_Line(path, "PA21_Prozess_V1.0_PC_Log")
        Write_Line(path, "char_0; Startdatum: ; " & Date.Now.Date.ToShortDateString & " ; Startzeit: ; " & Now.ToLocalTime.ToShortTimeString & " ;")
        Write_Line(path, "char_1; Chargendateiname: ; " & aktlog.Text & " ;") '& path.Substring(10) & " ;")
        Write_Line(path, "char_2; Benutzername: ; " & User & " ;") 'GetString(200, 38, 14, 14).Substring(2)
        Write_Line(path, "char_3; Angebotsnummer: ; " & User & " ;") 'GetString(200, 38, 14, 14).Substring(2)
        Write_Line(path, "char_4; Kunde/ProjektNr: ; " & User & " ;") 'GetString(200, 38, 14, 14).Substring(2)
        Write_Line(path, "char_5; Chargendokumentationstext_1: ; " & User & " ;") 'GetString(200, 38, 14, 14).Substring(2)
        Write_Line(path, "char_6; Chargendokumentationstext_2: ; " & User & " ;") 'GetString(200, 38, 14, 14).Substring(2)
        Write_Line(path, "char_9; Rezepturname: ; " & User & " ;") 'GetString(200, 38, 14, 14).Substring(2)
        Write_Line(path, "Kopf_0; Basisdruck [mbar]; Schnell_Belüften; Langsam_Belüften; HF-Regelungsart; Rampe_EinAus; RampenStartwert; RampenZeit; ToleranzAusblendzeit_Gasregelung; ToleranzAusblendzeit_HFRegelung; ToleranzAusblendzeit_Druckregelung; Service; ")
        Write_Line(path, "Kopf_1; " & BitInInt(helpDec, 0) & "; " & FloatFromBuffer(byteBuff, 10).ToString & "; " & FloatFromBuffer(byteBuff, 18).ToString & "; " & FloatFromBuffer(byteBuff, 22).ToString & "; " & FloatFromBuffer(byteBuff, 14).ToString & "; " & BitInInt(helpDec, 1) & "; ")
        For i = 1 To 5
            Write_Line(path, "Kopf_" & (i * 2) & "; Gasdurchflussregler_" & i & " [sccm]; Gasart_" & i & "; Gasart_" & i & "_GKF; Gasart_" & i & "_Toleranz; Gasart_" & i & "_Explosiv;")
            Write_Line(path, "Kopf_" & (i * 2 + 1) & "; " & BitInInt(helpDec, 0) & "; " & FloatFromBuffer(byteBuff, 10).ToString & "; " & FloatFromBuffer(byteBuff, 18).ToString & "; " & FloatFromBuffer(byteBuff, 22).ToString & "; " & FloatFromBuffer(byteBuff, 14).ToString & "; " & BitInInt(helpDec, 1) & "; ")
        Next
        Write_Line(path, "Seg_00; Gas1; Gas2; Gas3; Gas4; Gas5; Gas6; HF_Sollwert; HF_Toleranz; HF_Regelungseinstg(0=A/1=M/2=F); HF-Zeit(M/F); C-Load; C-Tune; Druck; Druck_Toleranz; Segmentzeit; 101_Vorpumpe_01; 141_AbsperrV; 241_SchutzV; 103_WKP; 249_AbsperrV, 181_PosAnFahren; 181_Position;")
        For i = 1 To 20
            Dim si As String
            If i <= 9 Then
                si = "0" & i.ToString
            Else
                si = i.ToString
            End If
            Write_Line(path, "Seg_" & si & "; " & BitInInt(helpDec, 0) & "; " & FloatFromBuffer(byteBuff, 10).ToString & "; " & FloatFromBuffer(byteBuff, 18).ToString & "; " & FloatFromBuffer(byteBuff, 22).ToString & "; " & FloatFromBuffer(byteBuff, 14).ToString & "; " & BitInInt(helpDec, 1) & "; ")
        Next
        Write_Line(path, "Proz_0; datum; uhrzeit; Segment; 162_Pirani_A [mbar]; 163_Pirani_B [mbar]; 261_Baratron [mbar]; 262_Pirani Mess [mbar]; 263_Pirani Referenz [mbar]; 181_Butterfly [%]; 191_Butterfly [%]; 281_Gas_1; 282_Gas_2; 283_Gas_3; 284_Gas_4; 285_Gas_5; 286_Gas_6; HF1_Bias; HF1_Leistung; HF1_Reflektierteleistung; HF1_RFPeak; HF1_CLoad; HF1_CTune; Kurvenwert_19; Kurvenwert_20; Kurvenwert_21; Kurvenwert_22; Kurvenwert_23; Kurvenwert_24; Kurvenwert_25; Kurvenwert_26; Kurvenwert_27; Kurvenwert_28; Kurvenwert_29; Kurvenwert_30;")
    End Sub

    Public Sub Log_Prozess()
        Dim Datum, Uhrzeit As String
        Dim _162, _163, _261, _262, _263, _181, _191, DruckS1, DruckS2, Leckrate As String
        Dim byteBuff As Byte()

        Datum = Date.Now.Date.ToShortDateString
        Uhrzeit = Now.TimeOfDay.ToString.Substring(0, 8)

        byteBuff = GetBytes(2003, 58, 40)

        _162 = FloatFromBuffer(0)
        _163 = FloatFromBuffer(4)
        _261 = FloatFromBuffer(12)
        _262 = FloatFromBuffer(8)
        _263 = FloatFromBuffer(16)

        _181 = FloatFromBuffer(20)
        _191 = FloatFromBuffer(24)

        DruckS1 = FloatFromBuffer(28)
        DruckS2 = FloatFromBuffer(32)

        Leckrate = FloatFromBuffer(36)

        Write_Line(Log_path, "Proz_1;" & Datum & ";" & Uhrzeit & ";" & _162 & ";" & _163 & ";" & _261 & ";" & _262 & ";" & _263 & ";" & _181 & ";" & _191 & ";" & DruckS1 & ";" & DruckS2 & ";" & Leckrate & ";")
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
