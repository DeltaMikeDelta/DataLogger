Imports System.String

Public Class DataLogger_Main
    Private Path As String = Nothing
    Private Log_Path As String          'In das DataSet einfügen
    Private absaugung_activ As Boolean  'Entfernen, wenn das mit dem Dataset funktioniert
    Private leck_activ As Boolean       'Entfernen, wenn das mit dem Dataset funktioniert
    Private DataSet As DataSet

    Private Sub Form_Load() Handles Me.Load
        If IsNullOrEmpty(XMLRead("Passwd", "ini.xml")) Then
            SetNewPassWD("ini.xml")
        End If

        'prepare Conection parameter and Properties
        DaveConS7.SetMessageTextbox(StatusBox)
        SetIP(My.Settings.IP)
        pingTimeout = My.Settings.ConnetionAttemps
        Timer1.Interval = My.Settings.ReadCycle
        'Setze Einstellungen für die Bedienoberfläche
        Panel1.BackColor = Color.Empty
        VerbindungPauseToolStripMenuItem.Enabled = False
        StartToolStripMenuItem.Enabled = True
        StoppUndTrennenToolStripMenuItem.Enabled = False
        EinstellungenToolStripMenuItem.Enabled = True
        StatusBox.BackColor = Color.White
        'Erzeuge Pfad für die Logdatei
        Path = BuildPath()
    End Sub

    Private Sub Form_Close() Handles MyBase.FormClosing
        Timer1.Stop()
        DaveConS7.DoDisconnectPLC()
        DataSet.WriteXml()

    End Sub

    Private Sub SchließenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SchließenToolStripMenuItem.Click
        Close()
    End Sub

    Private Sub EinstellungenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EinstellungenToolStripMenuItem.Click
        AddOwnedForm(EinstellungenVerbindung)
        EinstellungenVerbindung.Show()
    End Sub

    Private Sub EinstellungLogdateiToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EinstellungLogdateiToolStripMenuItem.Click
        AddOwnedForm(EinstellungLogdatei)
        EinstellungLogdatei.Show()
    End Sub

    Private Sub StartToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StartToolStripMenuItem.Click
        If (IsNullOrEmpty(Path)) Then
            MessageBox.Show("Legen sie einen Dateipfad und Dateiname in den Einstellung fest.", "Dateifehler", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            'Zugriff auf die Einstellungen Sperren
            EinstellungenToolStripMenuItem.Enabled = False
            EinstellungLogdateiToolStripMenuItem.Enabled = False
            'Steuerfunktionen für Pause und Stopp freigeben und Start sperren
            VerbindungPauseToolStripMenuItem.Enabled = True
            StartToolStripMenuItem.Enabled = False
            StoppUndTrennenToolStripMenuItem.Enabled = True
            'Timer starten
            Timer1.Enabled = True
            Timer1.Start()
            'Path = BuildPath()
            Write_Line("D:\Debug.csv", Now.ToLocalTime.ToString & "; Verbindugsaufbau zu:;" & GetIP() & ";")
            Write_Line("D:\Debug.csv", Now.ToLocalTime.ToString & "; Logdatei:;" & Path.ToString & ";")

        End If
    End Sub

    Private Sub PauseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VerbindungPauseToolStripMenuItem.Click
        Timer1.Enabled = False
        Timer1.Stop()
        VerbindungPauseToolStripMenuItem.Enabled = False
        StartToolStripMenuItem.Enabled = True
        StoppUndTrennenToolStripMenuItem.Enabled = True
        Panel3.BackColor = Color.OrangeRed
        Write_Line("D:\Debug.csv", Now.ToLocalTime.ToString & "; Verbindung Pausiert;")

    End Sub

    Private Sub StoppUndTrennenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StoppUndTrennenToolStripMenuItem.Click
        Timer1.Stop()
        'DaveConS7.DoDisconnectPLC()
        VerbindungPauseToolStripMenuItem.Enabled = False
        StartToolStripMenuItem.Enabled = True
        StoppUndTrennenToolStripMenuItem.Enabled = False
        EinstellungenToolStripMenuItem.Enabled = True
        EinstellungLogdateiToolStripMenuItem.Enabled = True
        Verbindung_Trennen()
        'Panel1.BackColor = Color.Red
        'Panel3.BackColor = Color.Red
        'Write_Line("D:\Debug.csv", Now.ToLocalTime.ToString & "; Verbindung getrennt;")
    End Sub


    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If DaveConS7.GetConnStatus Then
            Panel1.BackColor = Color.Green
            If GetWatchDogBit(My.Settings.WD_DB, My.Settings.WD_Byte, My.Settings.WD_Bit) Then
                SetWatchDog(My.Settings.WD_DB, My.Settings.WD_Byte, My.Settings.WD_Bit)

                If Not GetWatchDogBit(My.Settings.WD_DB, My.Settings.WD_Byte, My.Settings.WD_Bit) Then
                    Panel3.BackColor = Color.Green
                    'StatusBox.Text = " Watchdog Status: " & GetWatchDogBit(My.Settings.WD_DB, My.Settings.WD_Byte, My.Settings.WD_Bit).ToString

                    'If checkFile(Path) Then
                    '    If Not FileReadOnly(Path) Then
                    '        Write_Line(Path, Now.ToUniversalTime.ToString & " ; immer mehr")
                    '    Else
                    '        Return
                    '    End If
                    'Else
                    '    write_data(Path, Now.ToUniversalTime.ToString & " ; Ein Eintrag")
                    'End If
                    Log_Absaugleistung()

                Else
                    Panel3.BackColor = Color.HotPink
                    StatusBox.Text = " Watchdog Status: " & GetWatchDogBit(My.Settings.WD_DB, My.Settings.WD_Byte, My.Settings.WD_Bit).ToString
                    Write_Line("D:\Debug.csv", Now.ToLocalTime.ToString & "; Watchdog Fehler;")
                    Verbindung_Trennen()
                End If

            Else
                Panel3.BackColor = Color.HotPink
            End If
        Else
            Panel1.BackColor = Color.HotPink
            ConnectPLC()
        End If
    End Sub

    Private Sub Verbindung_Trennen()
        DaveConS7.DoDisconnectPLC()
        Panel1.BackColor = Color.Red
        Panel3.BackColor = Color.Red
        Write_Line("D:\Debug.csv", Now.ToLocalTime.ToString & "; Verbindung getrennt;")
    End Sub

    Private Sub Log_Absaugleistung()
        Dim help As Boolean
        help = GetBit(242, 1, 1)
        If Not help Then
            absaugung_activ = False
            StatusBox.Text = "Absaugen ist Aus"
        Else
            'absaugung_activ = True
            If Not absaugung_activ Then
                StatusBox.Text = "Absaugen An, Logdatei Kopf"
                Log_Kopf_Absaug()
            Else
                StatusBox.Text = "Absaugen An"
                Log_Absaug()
            End If

        End If

    End Sub

    Private Sub Log_Kopf_Absaug()
        'Dim path As String = "D:\Daten\SL_Log\AbsaugProtokoll_"
        Dim byteBuff As Byte()
        Dim count As Integer

        absaugung_activ = True
        count = GetDInteger(299, 30)
        Path = BuildPath(My.Settings.Log_Name, count)
        StatusBox.Text = Path
        AktLog.Text = My.Settings.Log_Name + count.ToString
        Log_Path = Path

        byteBuff = GetBytes(242, 80, 88)

        Write_Line(path, "PA17_Saugleistung_V1.0_PC_Log")
        Write_Line(path, "char_0; Startdatum: ; " & Date.Now.Date.ToShortDateString & " ; Startzeit: ; " & Now.ToLocalTime.ToShortTimeString & " ;")
        Write_Line(Path, "char_1; Chargendateiname: ; " & My.Settings.Log_Name & " ;") '& path.Substring(10) & " ;")
        Write_Line(path, "char_2; Benutzername: ; " & GetString(200, 38, 14, 14).Substring(2) & " ;")
        Write_Line(path, "Kopf_0; Vorpumpe / Pumpenstand; Gasvolumen Stufe1; Soll Zeit Stufe1; Gasvolumen Stufe2; Saugleistung Stufe2; Gasvolumen Stufe3; Soll Zeit Stufe3; Gasvolumen Stufe4; Soll Zeit Stufe4; Gasvolumen Stufe5; Soll Zeit Stufe5;")
        'Write_Line(path, "Kopf_1; " & GetBit(242, 0, 1).ToString & "; " & GetFloat(242, 80).ToString & "; " & GetFloat(242, 84).ToString & "; " & GetFloat(242, 100).ToString & "; " & GetFloat(242, 104).ToString & "; " & GetFloat(242, 120).ToString & "; " & GetFloat(242, 124).ToString & "; " & GetFloat(242, 140).ToString & "; " & GetFloat(242, 144).ToString & "; " & GetFloat(242, 160).ToString & "; " & GetFloat(242, 164).ToString & "; ")
        Write_Line(Path, "Kopf_1; " & GetBit(242, 0, 1).ToString & "; " & FloatFromBuffer(byteBuff, 0).ToString & "; " & FloatFromBuffer(byteBuff, 4).ToString & "; " & FloatFromBuffer(byteBuff, 20).ToString & "; " & FloatFromBuffer(byteBuff, 24).ToString & "; " & FloatFromBuffer(byteBuff, 40).ToString & "; " & FloatFromBuffer(byteBuff, 44).ToString & "; " & FloatFromBuffer(byteBuff, 60).ToString & "; " & FloatFromBuffer(byteBuff, 64).ToString & "; " & FloatFromBuffer(byteBuff, 80).ToString & "; " & FloatFromBuffer(byteBuff, 84).ToString & "; ")
        Write_Line(Path, "Proz_0; datum; uhrzeit; 162_Pirani; 261_Baratron; 263_Pirani; 181_Butterfly; 285_Gasregler5; Druck Stufe1; Saugleistung Stufe1; Druck Stufe2; Saugleistung Stufe2; Druck Stufe3; Saugleistung Stufe3; Druck Stufe4; Saugleistung Stufe4; Druck Stufe5; Saugleistung Stufe5;")
    End Sub

    Private Sub Log_Absaug()
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


End Class

