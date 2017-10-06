Imports System.String
Imports System.ComponentModel


Public Class DataLogger_Main

    Private Path As String = Nothing
    Private Log_Path As String          'In das DataSet einfügen
    Private absaugung_activ As Boolean  'Entfernen, wenn das mit dem Dataset funktioniert
    Private leck_activ As Boolean       'Entfernen, wenn das mit dem Dataset funktioniert
    Private init_Path_String As String = "Adds\ini.xml"
    ' Private ConTable As DataTable
    Private ConfigsetName As String = "ConfigurationSet"

    'Private BGWCollection As Collection

    Public Property Init_Path As String
        Get
            Return init_Path_String
        End Get
        Set(value As String)
            init_Path_String = value
        End Set
    End Property
    'Private Worker As BackgroundWorker

    Public ReadOnly Property GetConDataSet As SPSConnections
        Get
            Return Connections1
        End Get
    End Property

    Private Sub Form_Load() Handles Me.Load
        If IsNullOrEmpty(XMLRead("Passwd", Init_Path)) Then
            SetNewPassWD(init_Path_String)
        End If

        DaveConS7.SetMessageTextbox(StatusBox)
        Init_Interface()

        'Erzeuge Pfad für die Logdatei
        Path = BuildPath()

        'BGWCollection.Add(New BackgroundWorker)

        'ConTable = LoadTableIsolatedUser("ConfigurationTab.xml")

        'If IsNothing(ConTable) Then
        '    'DataSet = New DataSet
        '    Dim row As DataRow

        '    ConTable = New DataTable("Parameter")
        '    ConTable.Columns.Add("id", GetType(Int32))
        '    ConTable.Columns.Add("Name", GetType(String))
        '    ConTable.Columns.Add("IP", GetType(String))
        '    ConTable.Columns.Add("Timeout", GetType(Int32))
        '    ConTable.Columns.Add("Timer", GetType(Int32))

        '    row = ConTable.NewRow()
        '    row("id") = 1
        '    row("Name") = "SPS"
        '    row("IP") = My.Settings.IP
        '    row("Timeout") = My.Settings.ConnetionAttemps
        '    row("Timer") = My.Settings.ReadCycle

        '    ConTable.Rows.Add(row)

        '    'SetIP(ConTable.Rows(ConTable.PrimaryKey.Length).Item("IP").ToString) 'SetIP(ConTable.Rows("id" = 1).Item("IP"))
        '    'PingTimeout = ConTable.Rows(ConTable.PrimaryKey.Length).Item(columnName:="Timeout")
        '    'Timer1.Interval = ConTable.Rows(ConTable.PrimaryKey.Length).Item(columnName:="Timer")
        '    'MessageBox.Show(ConTable.Rows(ConTable.PrimaryKey.Length).Item(columnName:="Timer").ToString)
        'Else
        '    'SetIP(ConTable.Rows(ConTable.Rows(ConTable.PrimaryKey.Length).Item("IP")))
        '    'PingTimeout = ConTable.Rows(ConTable.PrimaryKey.Length).Item("Timeout")
        '    'Timer1.Interval = ConTable.Rows(ConTable.PrimaryKey.Length).Item("Timer")
        'End If

        Connections1 = LoadSetIsolatedUser("ConfigurationSPS.xml", Connections1)

        If (Connections1.SPS.Count = 0) Then

            Dim row As SPSConnections.SPSRow

            row = Connections1.SPS.NewSPSRow()

            row("SPS_Name") = "SPS"
            row("Connection_Type") = "S7-300"

            Connections1.SPS.Rows.Add(row)
            Connections1.AcceptChanges()

            Dim row1 As SPSConnections.SPS_ParameterRow

            row1 = Connections1.SPS_Parameter.NewSPS_ParameterRow()

            'MessageBox.Show(Connections1.SPS.Rows(0).Item("SPS_Name"))
            row1("Name") = Connections1.SPS.Rows(0).Item("SPS_Name")
            row1("IP") = My.Settings.IP
            row1("Timeout") = My.Settings.ConnetionAttemps
            row1("Timer") = My.Settings.ReadCycle
            row1("Watchdog_DB") = My.Settings.WD_DB
            row1("Watchdog_Byte") = My.Settings.WD_Byte
            row1("Watchdog_Bit") = My.Settings.WD_Bit
            row1("SPS_id") = Connections1.SPS.Rows(0).Item("id")

            Connections1.SPS_Parameter.Rows.Add(row1)
            'ConnectionSet = Connections1
            'SaveIsolatedUser(Connections1)

            SetIP(Connections1.SPS_Parameter.Rows(Connections1.SPS_Parameter.PrimaryKey.Length - 1).Item("IP").ToString)
            PingTimeout = Connections1.SPS_Parameter.Rows(Connections1.SPS_Parameter.PrimaryKey.Length - 1).Item("Timeout")
            Timer1.Interval = Connections1.SPS_Parameter.Rows(Connections1.SPS_Parameter.PrimaryKey.Length - 1).Item("Timer")
        Else
            DaveConS7.ShowMessage("Lade Parameter")
            SetIP(Connections1.SPS_Parameter.Rows(Connections1.SPS_Parameter.PrimaryKey.Length - 1).Item("IP").ToString)
            PingTimeout = Connections1.SPS_Parameter.Rows(Connections1.SPS_Parameter.PrimaryKey.Length - 1).Item("Timeout")
            Timer1.Interval = Connections1.SPS_Parameter.Rows(Connections1.SPS_Parameter.PrimaryKey.Length - 1).Item("Timer")
        End If

        DaveConS7.ShowMessage("Laden fertig.")
    End Sub

    Private Sub Init_Interface()
        'Setze Einstellungen für die Bedienoberfläche
        Panel1.BackColor = Color.Empty
        VerbindungPauseToolStripMenuItem.Enabled = False
        StartToolStripMenuItem.Enabled = True
        StoppUndTrennenToolStripMenuItem.Enabled = False
        EinstellungenToolStripMenuItem.Enabled = True
        StatusBox.BackColor = Color.White
    End Sub

    Private Sub Form_Close() Handles MyBase.FormClosing
        Timer1.Stop()
        DaveConS7.DoDisconnectPLC()

        Connections1.SPS_Parameter.Rows(0).Item("IP") = My.Settings.IP
        Connections1.SPS_Parameter.Rows(0).Item("Timeout") = My.Settings.ConnetionAttemps
        Connections1.SPS_Parameter.Rows(0).Item("Timer") = My.Settings.ReadCycle
        Connections1.SPS_Parameter.Rows(0).Item("Watchdog_DB") = My.Settings.WD_DB
        Connections1.SPS_Parameter.Rows(0).Item("Watchdog_Byte") = My.Settings.WD_Byte
        Connections1.SPS_Parameter.Rows(0).Item("Watchdog_Bit") = My.Settings.WD_Bit

        Connections1.AcceptChanges()

        SaveIsolatedUser(Connections1)
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

