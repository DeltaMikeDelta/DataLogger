Public Class EinstellungLogdatei

    Private Sub Einstellung_Logdatei_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If CheckPassWd(InputBox("Geben Sie das Passwort ein:", "Passwortabfrage"), "ini.xml") Then

            DateiPfad.Text = My.Settings.CSVPfad
            Dateiname.Text = My.Settings.Log_Name
            Check_LogName.Checked = My.Settings.Select_LogName
            CheckUhrzeit.Checked = My.Settings.Select_LogUhrzeit
            CheckDatum.Checked = My.Settings.Select_LogDatum
            RadioKomma.Checked = My.Settings.Select_LogSepKomma
            RadioSemikolon.Checked = My.Settings.Select_LogSepSemikolon

            Me.Location = Owner.Location
            Owner.Enabled = False
        Else
            MessageBox.Show("Password falsch.")
            Button2_Click(Me, EventArgs.Empty)
        End If

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        'SaveFileDialog1.ShowDialog()
        Dim result As DialogResult = FolderBrowserDialog1.ShowDialog()

        If result = DialogResult.OK Then
            My.Settings.CSVPfad = FolderBrowserDialog1.SelectedPath
            DateiPfad.Text = FolderBrowserDialog1.SelectedPath
        End If
    End Sub


    Private Sub Check_LogName_CheckedChanged(sender As Object, e As EventArgs) Handles Check_LogName.CheckedChanged
        Dateiname.Enabled = Check_LogName.Checked
        My.Settings.Select_LogName = Check_LogName.Checked
        BuildPath()
    End Sub

    Private Sub CheckDatum_CheckedChanged(sender As Object, e As EventArgs) Handles CheckDatum.CheckedChanged
        My.Settings.Select_LogDatum = CheckDatum.Checked
        BuildPath()
    End Sub

    Private Sub CheckUhrzeit_CheckedChanged(sender As Object, e As EventArgs) Handles CheckDatum.CheckedChanged
        My.Settings.Select_LogUhrzeit = CheckUhrzeit.Checked
        BuildPath()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        BuildPath()
        Owner.Enabled = True
        Close()
    End Sub

    Private Sub Dateiname_TextChanged(sender As Object, e As EventArgs) Handles Dateiname.TextChanged
        My.Settings.Log_Name = Dateiname.Text
    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles Profil_Auswahl.Enter

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ProfilAuswahlBox.SelectedIndexChanged

    End Sub

    Private Sub DateiPfad_TextChanged(sender As Object, e As EventArgs) Handles DateiPfad.TextChanged

    End Sub
End Class