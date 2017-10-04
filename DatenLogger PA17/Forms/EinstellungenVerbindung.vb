Public Class EinstellungenVerbindung


    Private helpString As String
    Private Conn As SPSConnections

    Private Sub Einstellungen_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If CheckPassWd(InputBox("Geben Sie das Passwort ein:", "Passwortabfrage"), My.Forms.DataLogger_Main.Init_Path) Then
            'MaskedIPBox.Text = My.Settings.IP
            MaskedIPBox.ValidatingType = GetType(String)
            TextBox1.Text = "Aktuelle IP: " & GetIP()
            ' Watchdog_DB_Nr.Text = My.Settings.WD_DB.ToString
            Watchdog_Byte.Text = My.Settings.WD_Byte.ToString
            Watchdog_Bit.Text = My.Settings.WD_Bit.ToString
            ReadCyc.Text = My.Settings.ReadCycle.ToString
            ConAttempts.Text = My.Settings.ConnetionAttemps.ToString

            Conn = My.Forms.DataLogger_Main.GetConDataSet
            DataGridView2.DataSource = Conn.SPS
            DataGridView2.Update()
            DataGridView2.FirstDisplayedCell.Selected = True

            TextBox1.Text = "Aktuelle IP: " + Conn.SPS_Parameter.First.IP.ToString
            Me.Location = Owner.Location
            Owner.Enabled = False
        Else
            MessageBox.Show("Password falsch.")
            BtSchliessen_Click(Me, EventArgs.Empty)
        End If
    End Sub


    Private Sub MaskedTextBox1_MaskInputRejected(sender As Object, e As MaskInputRejectedEventArgs) Handles MaskedIPBox.MaskInputRejected
        ' Button1.Enabled = False
        If (MaskedIPBox.MaskFull) Then
            ToolTip1.ToolTipTitle = "Input Rejected - Too Much Data"
            ToolTip1.Show("You cannot enter any more data into the date field. \n Delete some characters in order to insert more data.", MaskedIPBox, MaskedIPBox.Location.X, MaskedIPBox.Location.Y, 5000)
        ElseIf (e.Position = MaskedIPBox.Mask.Length) Then
            ToolTip1.ToolTipTitle = "Input Rejected - End of Field"
            ToolTip1.Show("You cannot add extra characters to the end of this date field.", MaskedIPBox, MaskedIPBox.Location.X, MaskedIPBox.Location.Y, 5000)
        Else
            ToolTip1.ToolTipTitle = "Input Rejected"
            ToolTip1.Show("You can only add numeric characters (0-9) into this date field.", MaskedIPBox, MaskedIPBox.Location.X, MaskedIPBox.Location.Y, 5000)
        End If
    End Sub

    Private Sub MaskedTextBox1_TypeValidationCompleted(sender As Object, e As TypeValidationEventArgs) Handles MaskedIPBox.TypeValidationCompleted
        If (e.IsValidInput) Then
            helpString = e.ReturnValue
            helpString = Replace(helpString, " ", "")
            'SetIP(helpString)
            'Button1.Enabled = True
        End If
    End Sub

    Private Sub BtSchliessen_Click(sender As Object, e As EventArgs) Handles Bt_Schließen.Click
        Owner.Enabled = True
        Close()
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        MaskedIPBox.ValidateText()
        SetIP(helpString)
        TextBox1.Text = "Aktuelle IP: " & GetIP()
        My.Settings.IP = helpString
    End Sub

    Private Sub WatchdogDBNr_TextChanged(sender As Object, e As EventArgs) Handles Watchdog_DB_Nr.TextChanged

        If IsNumericInteger(Watchdog_DB_Nr.Text) Then
            My.Settings.WD_DB = CInt(Watchdog_DB_Nr.Text)
        Else
            ShowTooltip(ToolTip1, "Eingabe ist keine Ganzzahl!", "Die Eingabe darf keine Buchstaben oder Sonderzeichen enthalten.", Watchdog_DB_Nr, Watchdog_DB_Nr.Location.X, Watchdog_DB_Nr.Location.Y, 5000)
            Watchdog_DB_Nr.Text = My.Settings.WD_DB
        End If

    End Sub

    Private Sub Watchdog_Byte_TextChanged(sender As Object, e As EventArgs) Handles Watchdog_Byte.TextChanged
        If IsNumericInteger(Watchdog_Byte.Text) Then
            My.Settings.WD_Byte = CInt(Watchdog_Byte.Text)
        Else
            ShowTooltip(ToolTip1, "Eingabe ist keine Ganzzahl!", "Die Eingabe darf keine Buchstaben oder Sonderzeichen enthalten.", Watchdog_Byte, Watchdog_Byte.Location.X, Watchdog_Byte.Location.Y, 5000)
            Watchdog_Byte.Text = My.Settings.WD_Byte
        End If
    End Sub

    Private Sub Watchdog_Bit_TextChanged(sender As Object, e As EventArgs) Handles Watchdog_Bit.TextChanged
        If IsNumericInteger(Watchdog_Bit.Text) Then
            My.Settings.WD_Bit = CInt(Watchdog_Bit.Text)
        Else
            ShowTooltip(ToolTip1, "Eingabe ist keine Ganzzahl!", "Die Eingabe darf keine Buchstaben oder Sonderzeichen enthalten.", Watchdog_Bit, Watchdog_Bit.Location.X, Watchdog_Bit.Location.Y, 5000)
            Watchdog_Bit.Text = My.Settings.WD_Bit
        End If
    End Sub

    Private Sub ReadCyc_TextChanged(sender As Object, e As EventArgs) Handles ReadCyc.TextChanged
        FalseInputInteger(My.Settings.ReadCycle, ReadCyc)
    End Sub

    Private Sub ConAttempts_TextChanged(sender As Object, e As EventArgs) Handles ConAttempts.TextChanged
        FalseInputInteger(My.Settings.ConnetionAttemps, ConAttempts)
    End Sub

    Private Function IsNumericInteger(stringArg As String) As Boolean
        If IsNumeric(stringArg) Then Return True
        Dim parts() As String = stringArg.Split("/"c)
        If parts.Length <> 1 Then Return False
        Return IsNumeric(parts(0)) 'AndAlso IsNumeric(parts(1))
    End Function

    Private Sub FalseInputInteger(setting As Object, element As Object)
        If IsNumericInteger(element.Text) Then
            setting = CInt(element.Text)
        Else
            ShowTooltip(ToolTip1, "Eingabe ist keine Ganzzahl!", "Die Eingabe darf keine Buchstaben oder Sonderzeichen enthalten.", element, element.Location.X, element.Location.Y, 5000)
            element.Text = setting
        End If
    End Sub

    Private Sub ShowTooltip(Tolltipp As ToolTip, titel As String, text As String, fielt As IWin32Window, x As Integer, y As Integer, duration As Integer)
        Tolltipp.ToolTipTitle = titel
        Tolltipp.Show(text, fielt, x, y, duration)
    End Sub

    Private Sub Load_Click(sender As Object, e As EventArgs) Handles LoadSPS.Click
        Dim selectedCellCount As Integer = DataGridView2.GetCellCount(DataGridViewElementStates.Selected)

        If selectedCellCount > 0 Then
            Dim i As Integer = 0
            Dim sb As New System.Text.StringBuilder()

            i = 1 + i
            sb.Append("SPS: ")
            sb.Append(DataGridView2.SelectedCells(i).Value)
            i = 1 + i
            sb.Append("; Connection Type: ")
            sb.Append(DataGridView2.SelectedCells(i).Value)

            MessageBox.Show(sb.ToString + vbNewLine + DataGridView2.SelectedCells(0).Value.ToString + " hat den Typ: " + DataGridView2.SelectedCells(0).Value.GetType.ToString, "Test")
            'MessageBox.Show(DataGridView2.SelectedCells(0).Value.ToString + " hat den Typ: " + DataGridView2.SelectedCells(0).Value.GetType.ToString, "Test")

            Watchdog_DB_Nr.Text = Connections.SPS_Parameter.FindByid(DataGridView2.SelectedCells(0).Value).Watchdog_DB

        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

    End Sub

    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick

    End Sub

End Class