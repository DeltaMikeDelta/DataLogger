﻿Imports System
Imports System.IO
Imports System.IO.IsolatedStorage

Module FileFunctions



    Public Function checkFile(path As String)
        Return File.Exists(path)
    End Function

    ''' <summary>
    ''' Request for overwirting an existing File
    ''' </summary>
    ''' <returns>Dialogresult from Dialog YesNo</returns>
    Public Function DialogOverwrite() As DialogResult
        Return MessageBox.Show("Die Datei ist bereits vorhanden. Soll sie überschrieben werden?", "Datei bereits vorhanden",
                               MessageBoxButtons.YesNo, MessageBoxIcon.Question)
    End Function

    ''' <summary>
    ''' Checks if File is ReadOnly. Shows Dialog if True
    ''' </summary>
    ''' <param name="path">File with Path to check</param>
    ''' <returns></returns>
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

    ''' <summary>
    ''' Creates new file with given Filename, Extesion in Path
    ''' </summary>
    ''' <param name="Filename">Filename</param>
    ''' <param name="type">Extension as txt</param>
    ''' <param name="Path">Path</param>
    ''' <returns></returns>
    Public Function newFile(Filename As String, type As String, Path As String)
        Dim loc_Path = String.Concat(Path, Filename)
        loc_Path = String.Concat(loc_Path, ".", type)
        Return File.Create(loc_Path)
    End Function

    ''' <summary>
    ''' Creates File in Path
    ''' </summary>
    ''' <param name="Filename">Filename</param>
    ''' <param name="Path">Path</param>
    ''' <returns></returns>
    Public Function newFile(Filename As String, Path As String)
        Dim loc_Path = String.Concat(Path, Filename)
        Return File.Create(loc_Path)
    End Function

    ''' <summary>
    ''' Creates File In Path of Application or in an other Directory if Path is included within Parameter Filename
    ''' </summary>
    ''' <param name="Filename">Filename (optional with Path)</param>
    ''' <returns></returns>
    Public Function newFile(Filename As String)
        Return File.Create(Filename)
    End Function

    ''' <summary>
    ''' Save a Dataset in User Filesystem
    ''' </summary>
    ''' <param name="dset">Dataset of Parameter</param>
    Public Sub saveIsolatedUser(dset As DataSet)
        Dim isoFile = IsolatedStorageFile.GetStore(IsolatedStorageScope.User Or IsolatedStorageScope.Assembly, Nothing)
        Dim isoStream = New IsolatedStorageFileStream("ConfigurationSet.xml", FileMode.Append, isoFile)

        dset.WriteXml(isoStream, XmlWriteMode.WriteSchema)

        isoStream.Close()
        isoFile.Close()
    End Sub

    ''' <summary>
    ''' Save a Dataset in User Filesystem with unique Filename
    ''' 
    ''' </summary>
    ''' <param name="dset">Dataset</param>
    ''' <param name="Filename">Filename</param>
    Public Sub saveIsolatedUser(dset As DataSet, Filename As String)
        Filename = String.Concat(Filename, ".xml")

        Dim isoFile = IsolatedStorageFile.GetStore(IsolatedStorageScope.User Or IsolatedStorageScope.Assembly, Nothing)
        Dim isoStream = New IsolatedStorageFileStream(Filename, FileMode.Append, isoFile)

        dset.WriteXml(isoStream, XmlWriteMode.WriteSchema)

        isoStream.Close()
        isoFile.Close()
    End Sub

    ''' <summary>
    ''' Save a DataTable of Data to User Filesystem
    ''' </summary>
    ''' <param name="dtab">DataTabele to save</param>
    Public Sub saveIsolatedUser(dtab As DataTable)
        Dim isoFile = IsolatedStorageFile.GetStore(IsolatedStorageScope.User Or IsolatedStorageScope.Assembly, Nothing)
        Dim isoStream = New IsolatedStorageFileStream("ConfigurationTab.xml", FileMode.Append, isoFile)

        dtab.WriteXml(isoStream, XmlWriteMode.WriteSchema)

        isoStream.Close()
        isoFile.Close()
    End Sub

    ''' <summary>
    ''' Save a DataTable in User Filesystem with unique Filename
    ''' </summary>
    ''' <param name="dtab">Datatable</param>
    ''' <param name="Filename">Filename</param>
    Public Sub saveIsolatedUser(dtab As DataTable, Filename As String)
        Filename = String.Concat(Filename, ".xml")

        Dim isoFile = IsolatedStorageFile.GetStore(IsolatedStorageScope.User Or IsolatedStorageScope.Assembly, Nothing)
        Dim isoStream = New IsolatedStorageFileStream(Filename, FileMode.Append, isoFile)

        dtab.WriteXml(isoStream, XmlWriteMode.WriteSchema)

        isoStream.Close()
        isoFile.Close()
    End Sub

    ''' <summary>
    ''' Read Out Configuration out of File in User Storage and returns it as Datatable
    ''' </summary>
    ''' <param name="Filename">Name of Configurationfile</param>
    ''' <returns>Returns Datatable or Messagebox on Error</returns>
    Public Function loadIsolatedUser(Filename As String)
        Dim isoFile = IsolatedStorageFile.GetStore(IsolatedStorageScope.User Or IsolatedStorageScope.Assembly, Nothing)
        Dim isoStream
        Dim dataTable = New DataTable

        Try
            isoStream = New IsolatedStorageFileStream(Filename, FileMode.Open, isoFile)
            Return dataTable.ReadXml(isoStream)
            isoStream.Close()
        Catch ex As Exception
            Return MessageBox.Show("Fehler: Konfigurationsdatei nicht vorhanden!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try

        isoFile.Close()
    End Function

End Module
