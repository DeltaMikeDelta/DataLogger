Imports System.IO
Imports DatenLogger_PA21.FileFunctions

Module XMLMod

    Public Function XMLRead(Element As String, File As String) As String
        XMLRead = ""
        Dim lDoc As XDocument = XDocument.Load(File)
        Dim lNode = (From e In lDoc.Descendants Where e.Name = Element).Single()
        XMLRead = lNode.Value
    End Function

    Public Sub XMLWrite(Position As String, Wert As String, File As String)
        Dim xmldoc As XElement = XElement.Load(File)
        Dim lNode = (From e In xmldoc.Descendants Where e.Name = Position)
        lNode.Value = Wert
        xmldoc.Save(File)
    End Sub

    Public Function XMLSave(Position As String, paramDataSet As DataSet, FileINI As String)
        Dim xmldoc As XElement = XElement.Load(FileINI)

        Dim lNode = AttributeExists(Position, xmldoc)

        If (IsNothing(lNode)) Then
            If checkFile("DataSet.xml") Then
            End If

        End If

        Dim stream As New System.IO.FileStream(FileDataSet, System.IO.FileMode.OpenOrCreate)

        ' Create an XmlTextWriter with the fileStream.
        Dim xmlWriter As New System.Xml.XmlTextWriter(stream, System.Text.Encoding.Unicode)

        ' Write to the file with the WriteXml method.
        paramDataSet.WriteXml(xmlWriter)
        xmlWriter.Close()

    End Function

    Private Function AttributeExists(attribute As String, xmldoc As XElement)
        Dim lNode = (From e In xmldoc.Descendants Where e.Name = attribute)
        If IsNothing(lNode) Then
            xmldoc.Descendants.Nodes.Last.AddAfterSelf(attribute)

            lNode = (From e In xmldoc.Descendants Where e.Name = attribute)
            Return vbNull
        End If
        Return lNode
    End Function

    Private Function 
End Module
