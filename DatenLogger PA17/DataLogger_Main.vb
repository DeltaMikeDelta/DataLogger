Imports System.String
Imports System.ComponentModel


Public Class DataLogger_Main

    Private Path As String = Nothing
    Private Log_Path As String          'In das DataSet einfügen
    Private absaugung_activ As Boolean  'Entfernen, wenn das mit dem Dataset funktioniert
    Private leck_activ As Boolean       'Entfernen, wenn das mit dem Dataset funktioniert
    Private DataSet As DataSet
    Private ConTable As DataTable
    Private DataTable As DataTable
    Private Worker As BackgroundWorker

    ''' <summary>
    ''' Aufruf 
    ''' </summary>
    Private Sub Form_Load() Handles Me.Load
        If IsNullOrEmpty(XMLRead("Passwd", "ini.xml")) Then
            SetNewPassWD("ini.xml")
        End If

        ConTable = loadIsolatedUser("ConfigSPSCon.xml")

        If IsNothing(ConTable) Then
            'DataSet = New DataSet
            Dim row As DataRow

            ConTable = New DataTable("Parameter")
            ConTable.Columns.Add("id", GetType(Int32))
            ConTable.Columns.Add("Name", GetType(String))
            ConTable.Columns.Add("IP", GetType(String))
            ConTable.Columns.Add("Timeout", GetType(Int32))
            ConTable.Columns.Add("Timer", GetType(Int32))

            row = ConTable.NewRow()
            row("Parameter") = "IP"
            row("Value") = My.Settings.IP

            'ConTable.Rows.Add(row)
            ConTable.Rows.Add({1, "SPS", My.Settings.IP, My.Settings.ConnetionAttemps, My.Settings.ReadCycle})
            SetIP(My.Settings.IP)
            PingTimeout = My.Settings.ConnetionAttemps
            Timer1.Interval = My.Settings.ReadCycle
        End If

        'prepare Conection parameter and Properties
        DaveConS7.SetMessageTextbox(StatusBox)

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

        'Sichern der Einstellungen
        SaveIsolatedUser(ConTable)


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
                    Log_Absaugleistung(StatusBox, Path, AktLog)

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

End Class

