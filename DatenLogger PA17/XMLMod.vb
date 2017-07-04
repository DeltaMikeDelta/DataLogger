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
End Module
