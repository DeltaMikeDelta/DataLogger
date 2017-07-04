<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DataLogger_Main
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.DateiToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SchließenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProgrammToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EinstellungenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EinstellungLogdateiToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.StartToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VerbindungPauseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StoppUndTrennenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.StatusBox = New System.Windows.Forms.TextBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.AktLog = New System.Windows.Forms.TextBox()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DateiToolStripMenuItem, Me.ProgrammToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(284, 24)
        Me.MenuStrip1.TabIndex = 6
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'DateiToolStripMenuItem
        '
        Me.DateiToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SchließenToolStripMenuItem})
        Me.DateiToolStripMenuItem.Name = "DateiToolStripMenuItem"
        Me.DateiToolStripMenuItem.Size = New System.Drawing.Size(46, 20)
        Me.DateiToolStripMenuItem.Text = "Datei"
        '
        'SchließenToolStripMenuItem
        '
        Me.SchließenToolStripMenuItem.Name = "SchließenToolStripMenuItem"
        Me.SchließenToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.SchließenToolStripMenuItem.Size = New System.Drawing.Size(161, 22)
        Me.SchließenToolStripMenuItem.Text = "Schließen"
        '
        'ProgrammToolStripMenuItem
        '
        Me.ProgrammToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EinstellungenToolStripMenuItem, Me.EinstellungLogdateiToolStripMenuItem, Me.ToolStripSeparator1, Me.StartToolStripMenuItem, Me.VerbindungPauseToolStripMenuItem, Me.StoppUndTrennenToolStripMenuItem})
        Me.ProgrammToolStripMenuItem.Name = "ProgrammToolStripMenuItem"
        Me.ProgrammToolStripMenuItem.Size = New System.Drawing.Size(76, 20)
        Me.ProgrammToolStripMenuItem.Text = "Programm"
        '
        'EinstellungenToolStripMenuItem
        '
        Me.EinstellungenToolStripMenuItem.Name = "EinstellungenToolStripMenuItem"
        Me.EinstellungenToolStripMenuItem.Size = New System.Drawing.Size(197, 22)
        Me.EinstellungenToolStripMenuItem.Text = "Einstellung Verbindung"
        '
        'EinstellungLogdateiToolStripMenuItem
        '
        Me.EinstellungLogdateiToolStripMenuItem.Name = "EinstellungLogdateiToolStripMenuItem"
        Me.EinstellungLogdateiToolStripMenuItem.Size = New System.Drawing.Size(197, 22)
        Me.EinstellungLogdateiToolStripMenuItem.Text = "Einstellung Logdatei"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(194, 6)
        '
        'StartToolStripMenuItem
        '
        Me.StartToolStripMenuItem.Name = "StartToolStripMenuItem"
        Me.StartToolStripMenuItem.Size = New System.Drawing.Size(197, 22)
        Me.StartToolStripMenuItem.Text = "Start und Verbinden"
        '
        'VerbindungPauseToolStripMenuItem
        '
        Me.VerbindungPauseToolStripMenuItem.Name = "VerbindungPauseToolStripMenuItem"
        Me.VerbindungPauseToolStripMenuItem.Size = New System.Drawing.Size(197, 22)
        Me.VerbindungPauseToolStripMenuItem.Text = "Verbindung pausieren"
        '
        'StoppUndTrennenToolStripMenuItem
        '
        Me.StoppUndTrennenToolStripMenuItem.Name = "StoppUndTrennenToolStripMenuItem"
        Me.StoppUndTrennenToolStripMenuItem.Size = New System.Drawing.Size(197, 22)
        Me.StoppUndTrennenToolStripMenuItem.Text = "Stopp und Trennen"
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'TextBox3
        '
        Me.TextBox3.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox3.Location = New System.Drawing.Point(65, 67)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.ReadOnly = True
        Me.TextBox3.Size = New System.Drawing.Size(155, 13)
        Me.TextBox3.TabIndex = 11
        Me.TextBox3.Text = "Watchdog OKAY"
        '
        'TextBox2
        '
        Me.TextBox2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox2.Location = New System.Drawing.Point(66, 40)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.ReadOnly = True
        Me.TextBox2.Size = New System.Drawing.Size(155, 13)
        Me.TextBox2.TabIndex = 10
        Me.TextBox2.Text = "Verbindung zur SPS"
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel3.Location = New System.Drawing.Point(33, 67)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(25, 13)
        Me.Panel3.TabIndex = 9
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Location = New System.Drawing.Point(33, 40)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(25, 13)
        Me.Panel1.TabIndex = 8
        '
        'StatusBox
        '
        Me.StatusBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.StatusBox.Enabled = False
        Me.StatusBox.Location = New System.Drawing.Point(0, 229)
        Me.StatusBox.Multiline = True
        Me.StatusBox.Name = "StatusBox"
        Me.StatusBox.Size = New System.Drawing.Size(284, 40)
        Me.StatusBox.TabIndex = 7
        '
        'TextBox1
        '
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox1.Location = New System.Drawing.Point(33, 96)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(99, 13)
        Me.TextBox1.TabIndex = 12
        Me.TextBox1.Text = "Aktuelle Logdatei:"
        '
        'AktLog
        '
        Me.AktLog.Location = New System.Drawing.Point(127, 93)
        Me.AktLog.Name = "AktLog"
        Me.AktLog.Size = New System.Drawing.Size(145, 20)
        Me.AktLog.TabIndex = 13
        '
        'DataLogger_Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 262)
        Me.Controls.Add(Me.AktLog)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.StatusBox)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.MinimumSize = New System.Drawing.Size(300, 300)
        Me.Name = "DataLogger_Main"
        Me.Text = "DataLogger"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents DateiToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SchließenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ProgrammToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EinstellungenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EinstellungLogdateiToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents StartToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents VerbindungPauseToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents StoppUndTrennenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Timer1 As Timer
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents StatusBox As TextBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents AktLog As TextBox
End Class
