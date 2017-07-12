Imports System
Imports System.IO

Module FileFunctions

    Public Function checkFile(path)
        Return File.Exists(path)
    End Function

    Public Function DialogOverwrite() As DialogResult
        Return MessageBox.Show("Die Datei ist bereits vorhanden. Soll sie überschrieben werden?", "Datei bereits vorhanden",
                               MessageBoxButtons.YesNo, MessageBoxIcon.Question)
    End Function

    Public Function FileReadOnly(path As String) As Boolean
        Dim checkFile As FileInfo = New FileInfo(path)
        Dim state As Boolean = checkFile.IsReadOnly()
        If checkFile.IsReadOnly() Then
            MessageBox.Show("Auf Datei " + path.ToString + " kann nicht schreibend zugegriffen werden. Bitte schließen sie die Datei und versuchen es erneut.")
            Return True
        Else
            Return False
        End If
    End Function

End Module
