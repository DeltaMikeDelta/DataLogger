Imports System
Imports System.IO

Module CSVExport
    ' Private File_test As FileSystem
    Private Filename As String = Nothing

    Public Function GetFilename() As String
        Return Filename
    End Function

    Public Sub write_data(Path As String, data_line As String)
        Dim sw As StreamWriter = File.CreateText(Path)
        sw.WriteLine(data_line)
        sw.Close()
    End Sub

    Public Sub Write_Line(Path As String, data_line As String)
        Dim SW As StreamWriter = New StreamWriter(Path, True)
        SW.WriteLine(data_line)
        'SW.WriteLine("")
        SW.Close()
    End Sub

    Public Function BuildPath()
        Filename = Nothing
        If My.Settings.Select_LogName Then
            Filename = My.Settings.Log_Name
        End If

        If My.Settings.Select_LogDatum Then
            If IsNothing(Filename) Then
                Filename = Date.Today.ToString("yyyy/MM/dd").Replace("/", "")
            Else
                Filename = Filename + "_" + Date.Today.ToString("yyyy/MM/dd").Replace("/", "")
            End If
        End If

        If My.Settings.Select_LogUhrzeit Then
            If IsNothing(Filename) Then
                Filename = Date.Now.ToString("hhmm")
            Else
                Filename = Filename + "_" + Date.Now.ToString("hhmm")
            End If
        End If
        Return My.Settings.CSVPfad + "\" + Filename + ".csv"
    End Function

    Public Function BuildPath(Filename As String, Index As Integer)
        'Filename = Nothing
        If My.Settings.Select_LogName Then
            'Filename = My.Settings.Log_Name
            Filename = Filename + Index.ToString
        End If

        If My.Settings.Select_LogDatum Then
            If IsNothing(Filename) Then
                Filename = Date.Today.ToString("yyyy/MM/dd").Replace("/", "")
            Else
                Filename = Filename + "_" + Date.Today.ToString("yyyy/MM/dd").Replace("/", "")
            End If
        End If

        If My.Settings.Select_LogUhrzeit Then
            If IsNothing(Filename) Then
                Filename = Date.Now.ToString("hhmm")
            Else
                Filename = Filename + "_" + Date.Now.ToString("hhmm")
            End If
        End If
        Return My.Settings.CSVPfad + "\" + Filename + ".csv"
    End Function

    Private Function BuildPath(FileString As String) As String
        Dim hString As String
        hString = Replace(FileString, "%D", Date.Today.ToString("yyyy/MM/dd").Replace("/", ""))
        hString = Replace(hString, "%T", Date.Now.ToString("hhmm"))
        hString = Replace(hString, " ", "_")
        Console.WriteLine(hString + ".csv")
        Return My.Settings.CSVPfad + hString + ".csv"
    End Function
End Module
