<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EinstellungLogdatei
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
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.RadioSemikolon = New System.Windows.Forms.RadioButton()
        Me.RadioKomma = New System.Windows.Forms.RadioButton()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Dateiname = New System.Windows.Forms.TextBox()
        Me.CheckDatum = New System.Windows.Forms.CheckBox()
        Me.CheckUhrzeit = New System.Windows.Forms.CheckBox()
        Me.Check_LogName = New System.Windows.Forms.CheckBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.DateiPfad = New System.Windows.Forms.TextBox()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Profil_Auswahl = New System.Windows.Forms.GroupBox()
        Me.ProfilAuswahlBox = New System.Windows.Forms.ComboBox()
        Me.GroupBox2.SuspendLayout()
        Me.Profil_Auswahl.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.RadioButton1)
        Me.GroupBox2.Controls.Add(Me.RadioSemikolon)
        Me.GroupBox2.Controls.Add(Me.RadioKomma)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Dateiname)
        Me.GroupBox2.Controls.Add(Me.CheckDatum)
        Me.GroupBox2.Controls.Add(Me.CheckUhrzeit)
        Me.GroupBox2.Controls.Add(Me.Check_LogName)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Button3)
        Me.GroupBox2.Controls.Add(Me.DateiPfad)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 165)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(786, 134)
        Me.GroupBox2.TabIndex = 13
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "CSV Dateipfad"
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Checked = True
        Me.RadioButton1.Location = New System.Drawing.Point(673, 40)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(74, 17)
        Me.RadioButton1.TabIndex = 25
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "Semikolon"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'RadioSemikolon
        '
        Me.RadioSemikolon.AutoSize = True
        Me.RadioSemikolon.Checked = True
        Me.RadioSemikolon.Location = New System.Drawing.Point(927, 33)
        Me.RadioSemikolon.Name = "RadioSemikolon"
        Me.RadioSemikolon.Size = New System.Drawing.Size(74, 17)
        Me.RadioSemikolon.TabIndex = 23
        Me.RadioSemikolon.TabStop = True
        Me.RadioSemikolon.Text = "Semikolon"
        Me.RadioSemikolon.UseVisualStyleBackColor = True
        '
        'RadioKomma
        '
        Me.RadioKomma.AutoSize = True
        Me.RadioKomma.Location = New System.Drawing.Point(597, 40)
        Me.RadioKomma.Name = "RadioKomma"
        Me.RadioKomma.Size = New System.Drawing.Size(60, 17)
        Me.RadioKomma.TabIndex = 22
        Me.RadioKomma.TabStop = True
        Me.RadioKomma.Text = "Komma"
        Me.RadioKomma.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(595, 23)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(72, 13)
        Me.Label7.TabIndex = 21
        Me.Label7.Text = "Trennzeichen"
        '
        'Dateiname
        '
        Me.Dateiname.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.DatenLogger_PA21.My.MySettings.Default, "Log_Name", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Dateiname.Location = New System.Drawing.Point(378, 41)
        Me.Dateiname.Name = "Dateiname"
        Me.Dateiname.Size = New System.Drawing.Size(164, 20)
        Me.Dateiname.TabIndex = 20
        Me.Dateiname.Text = Global.DatenLogger_PA21.My.MySettings.Default.Log_Name
        '
        'CheckDatum
        '
        Me.CheckDatum.AutoSize = True
        Me.CheckDatum.Location = New System.Drawing.Point(304, 64)
        Me.CheckDatum.Name = "CheckDatum"
        Me.CheckDatum.Size = New System.Drawing.Size(57, 17)
        Me.CheckDatum.TabIndex = 19
        Me.CheckDatum.Text = "Datum"
        Me.CheckDatum.UseVisualStyleBackColor = True
        '
        'CheckUhrzeit
        '
        Me.CheckUhrzeit.AutoSize = True
        Me.CheckUhrzeit.Location = New System.Drawing.Point(409, 64)
        Me.CheckUhrzeit.Name = "CheckUhrzeit"
        Me.CheckUhrzeit.Size = New System.Drawing.Size(59, 17)
        Me.CheckUhrzeit.TabIndex = 18
        Me.CheckUhrzeit.Text = "Uhrzeit"
        Me.CheckUhrzeit.UseVisualStyleBackColor = True
        '
        'Check_LogName
        '
        Me.Check_LogName.AutoSize = True
        Me.Check_LogName.Checked = True
        Me.Check_LogName.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Check_LogName.Location = New System.Drawing.Point(304, 41)
        Me.Check_LogName.Name = "Check_LogName"
        Me.Check_LogName.Size = New System.Drawing.Size(54, 17)
        Me.Check_LogName.TabIndex = 17
        Me.Check_LogName.Text = "Name"
        Me.Check_LogName.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(301, 23)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(58, 13)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "Dateiname"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 23)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(39, 13)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "Ordner"
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(155, 67)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(82, 22)
        Me.Button3.TabIndex = 10
        Me.Button3.Text = "Auswählen"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'DateiPfad
        '
        Me.DateiPfad.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.DatenLogger_PA21.My.MySettings.Default, "CSVPfad", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.DateiPfad.Location = New System.Drawing.Point(15, 41)
        Me.DateiPfad.Name = "DateiPfad"
        Me.DateiPfad.Size = New System.Drawing.Size(222, 20)
        Me.DateiPfad.TabIndex = 9
        Me.DateiPfad.Text = Global.DatenLogger_PA21.My.MySettings.Default.CSVPfad
        '
        'FolderBrowserDialog1
        '
        Me.FolderBrowserDialog1.RootFolder = System.Environment.SpecialFolder.MyComputer
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button2.Location = New System.Drawing.Point(946, 493)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(80, 24)
        Me.Button2.TabIndex = 14
        Me.Button2.Text = "Schließen"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Profil_Auswahl
        '
        Me.Profil_Auswahl.Controls.Add(Me.ProfilAuswahlBox)
        Me.Profil_Auswahl.Location = New System.Drawing.Point(12, 12)
        Me.Profil_Auswahl.Name = "Profil_Auswahl"
        Me.Profil_Auswahl.Size = New System.Drawing.Size(783, 136)
        Me.Profil_Auswahl.TabIndex = 15
        Me.Profil_Auswahl.TabStop = False
        Me.Profil_Auswahl.Text = "Profil"
        '
        'ProfilAuswahlBox
        '
        Me.ProfilAuswahlBox.FormattingEnabled = True
        Me.ProfilAuswahlBox.Location = New System.Drawing.Point(15, 19)
        Me.ProfilAuswahlBox.Name = "ProfilAuswahlBox"
        Me.ProfilAuswahlBox.Size = New System.Drawing.Size(353, 21)
        Me.ProfilAuswahlBox.TabIndex = 0
        '
        'EinstellungLogdatei
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1038, 529)
        Me.Controls.Add(Me.Profil_Auswahl)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Button2)
        Me.Name = "EinstellungLogdatei"
        Me.Text = "EinstellungLogdatei"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.Profil_Auswahl.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents RadioSemikolon As RadioButton
    Friend WithEvents RadioKomma As RadioButton
    Friend WithEvents Label7 As Label
    Friend WithEvents Dateiname As TextBox
    Friend WithEvents CheckDatum As CheckBox
    Friend WithEvents CheckUhrzeit As CheckBox
    Friend WithEvents Check_LogName As CheckBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Button3 As Button
    Friend WithEvents DateiPfad As TextBox
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
    Friend WithEvents Button2 As Button
    Friend WithEvents RadioButton1 As RadioButton
    Friend WithEvents Profil_Auswahl As GroupBox
    Friend WithEvents ProfilAuswahlBox As ComboBox
End Class
