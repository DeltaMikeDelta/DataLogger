Imports System
Imports System.IO

Module FileFunctions

    Public Function checkFile(path As String)
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

    Public Function newFile(Filename As String, type As String, Path As String)
        Dim loc_Path = String.Concat(Path, Filename)
        loc_Path = String.Concat(loc_Path, ".", type)
        Return File.Create(loc_Path)
    End Function

    Public Function newFile(Filename As String, Path As String)
        Dim loc_Path = String.Concat(Path, Filename)
        Return File.Create(loc_Path)
    End Function

    Public Function newFile(Filename As String)
        Return File.Create(Filename)
    End Function
End Module
