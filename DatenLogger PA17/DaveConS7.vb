Imports Microsoft.VisualBasic.Devices.Network

Module DaveConS7
    Private textbox As TextBox = Nothing

    Private ip As String
    Private port As Integer = 102

    Private daveSerial As libnodave.daveOSserialType
    Private daveConection As libnodave.daveConnection
    Private daveInterface As libnodave.daveInterface
    Private connStatus As Boolean
    Private pingcounter As Integer
    Property pingTimeout As Integer
    Private state As Integer

    Private rack As Integer = 0
    Private slot As Integer = 2

    Public Function SetMessageTextbox(Box As TextBox)
        textbox = Box
    End Function

    Public Function SetIP(IPString)
        ip = IPString
    End Function

    Public Function GetIP() As String
        Return (ip)
    End Function

    Public Function GetPort() As Integer
        Return port
    End Function

    Public Function GetConnStatus()
        GetConnStatus = connStatus
    End Function

    ''' <summary>
    ''' Allocates Interface for Ethernet Connection with given Port an IP.
    ''' </summary>
    ''' <returns>Integer Value of the established Socket</returns>
    Private Function allocateInterface() As Integer
        daveSerial.rfd = libnodave.openSocket(GetPort, GetIP) '(GetPort(), GetIP())
        daveSerial.wfd = daveSerial.rfd
        Return (daveSerial.rfd)
    End Function

    ''' <summary>
    ''' Defines Interface for Connection to PLC with Values set for Interface, Protokoll and transmission speed.
    ''' </summary>
    Private Sub newInterface()
        daveInterface = New libnodave.daveInterface(daveSerial, "IF1", 0, libnodave.daveProtoISOTCP, libnodave.daveSpeed187k)
        daveInterface.setTimeout(1000)
    End Sub

    ''' <summary>
    ''' Defines Connection based on parameter for PLC as Rack, Slot and Interface.
    ''' </summary>
    ''' <returns>dave Connection Objekt</returns>
    Private Function newConnection()
        daveConection = New libnodave.daveConnection(daveInterface, 0, rack, slot)
        Return (daveConection)
    End Function

    ''' <summary>
    ''' Tries to parse a given String as an IP and returns the result as Integer.
    ''' Also check on white spaces or empty String.
    ''' </summary>
    ''' <param name="ipArg">IP Address String</param>
    ''' <returns>Integer 1 on succsessfully parsed IP Address, 0 on Error</returns>
    Private Function AssertIP(ipArg) As Integer
        Dim address As Net.IPAddress = Nothing
        If (System.String.IsNullOrEmpty(ipArg)) Then
            Return (-1)
        ElseIf System.Net.IPAddress.TryParse(ipArg, address) Then
            Return (1)
        End If
        Return -1
    End Function

    ''' <summary>
    ''' Establishes Connection to PLC.
    ''' Executes <see cref="AssertIP(Object)"/> to check IP String as valid IP Adress.
    ''' Ping Test asserts connectivity to PLC.
    ''' 
    ''' Errortext is shown if IP String ist not valid or an Error occours while connecting to PLC.
    ''' </summary>
    ''' <returns>Bollean connection status</returns>
    Public Function ConnectPLC()
        On Error GoTo error_PLC
        connStatus = False
        If AssertIP(ip) = -1 Then
            ShowMessage("IP is not valid or null!")
        Else
            ConnectPLC = pingtest(ip)
            If ConnectPLC = 1 Then
                ShowMessage("Trying to establish connection to Host.")
                If allocateInterface() > 0 Then
                    newInterface()
                    state = daveInterface.initAdapter
                    If state = 0 Then
                        newConnection()
                        state = daveConection.connectPLC
                        If state = 0 Then
                            ShowMessage("Connection established.")
                            connStatus = True
                            Return (connStatus)
                        End If
                    End If
                End If
            ElseIf ConnectPLC = 0 Then
                '    ShowMessage("Connection Error")
            End If
        End If
        Exit Function

error_PLC:
        ShowMessage("Error on Connection to PLC!")
    End Function

    ''' <summary>
    ''' Pings the host every 30 Ticks and returns result as true or false.
    ''' Assert IP String ist valid. See there for: <see cref="AssertIP(Object)"/>
    ''' </summary>
    ''' <param name="ipArg">Host IP Address as String</param>
    ''' <returns>Ping result as Boolean</returns>
    Public Function pingtest(ipArg As String) As Integer
        Dim ethernetConnection As New Microsoft.VisualBasic.Devices.Network
        ' Verzögerung des Pingtest und des Verbindungsaufbaus
        If pingcounter = pingTimeout Then ' 30 Ticks
            pingcounter = 0
            If Not ethernetConnection.Ping(ipArg) Then
                ShowMessage("Host with IP: " & ipArg.ToString & " can't be pinged!")
                Return 0
            Else
                Return 1
            End If
        Else
            pingcounter = pingcounter + 1
            Return -1
        End If
    End Function

    ''' <summary>
    ''' Disconnect from PLC and resets allocated port.
    ''' </summary>
    ''' <returns>State as boolean</returns>
    Public Function disconnectPLC()
        If connStatus Then
            daveConection.disconnectPLC()       ' Trenne Verbindung
            daveInterface.disconnectAdapter()   ' Gebe reservierten Port frei
            connStatus = False                  ' Setze Verbindungsstatus zurück
            ShowMessage("Verbindug zum PLC getrennt.")
            Return (True)
        End If
        ShowMessage("Keine Verbindung zum Schließen vorhanden.")
        Return (True)
    End Function

    Public Function setWatchDog(dbNr, byteStart, bitNr)
        Dim mybuf(1) As Byte
        Dim Adress As Integer
        Adress = byteStart * 8 + bitNr
        setWatchDog = -1
        If connStatus Then
            mybuf(0) = 0
            state = daveConection.writeBits(libnodave.daveDB, dbNr, Adress, 1, mybuf)
            Return 1
        End If
    End Function

    Public Function getWatchDogBit(dbNr, byteStart, bitNr)
        Dim mybuf(1) As Byte
        Dim Adress As Integer
        Adress = byteStart * 8 + bitNr
        If connStatus Then
            mybuf(0) = 0
            state = daveConection.readBits(libnodave.daveDB, dbNr, Adress, 1, mybuf)
            If state = 0 Then
                Return daveConection.getS8
            Else
                Return -1
            End If
        Else
            Return -1
        End If
    End Function

    ''' <summary>
    ''' Reads a specific Bit out of a Byte
    ''' </summary>
    ''' <param name="dbNr">DB Number</param>
    ''' <param name="byteStart">Byteadress</param>
    ''' <param name="bitNr">Number of Bit within Byte</param>
    ''' <returns></returns>
    Public Function getBit(dbNr, byteStart, bitNr)
        Dim mybuf(1) As Byte
        Dim Adress As Integer
        Adress = byteStart * 8 + bitNr
        If connStatus Then
            mybuf(0) = 0
            state = daveConection.readBits(libnodave.daveDB, dbNr, Adress, 1, mybuf)
            If state = 0 Then
                Return daveConection.getS8
            Else
                Return -1
            End If
        Else
            Return -1
        End If
    End Function

    ''' <summary>
    ''' Reads an Byte Value from an DB. Number of Byte as Startadress have to be even.
    ''' </summary>
    ''' <param name="dbNr">Integer Value DB Number</param>
    ''' <param name="byteStart">Integer Value of Byte Startadress</param>
    ''' <returns>Byte Value read from DB</returns>
    Public Function getByte(dbNr, byteStart) As Integer
        Dim buf(1) As Byte
        getByte = 1
        state = daveConection.readBytes(libnodave.daveDB, dbNr, byteStart, 1, buf)
        If state = 0 Then
            getByte = daveConection.getS8
        End If
    End Function

    ''' <summary>
    ''' Reads Up to 222 Bytes in a Row out of the PLC
    ''' </summary>
    ''' <param name="dbNr">DB Nr</param>
    ''' <param name="byteStart">Byte Start Adress</param>
    ''' <param name="length">Count of Bytes</param>
    ''' <returns></returns>
    Public Function getBytes(dbNr As Integer, byteStart As Integer, length As Integer) As Byte()
        Dim buf(length) As Byte
        'getBytes(0) = -1
        state = daveConection.readBytes(libnodave.daveDB, dbNr, byteStart, length, buf)
        If state = 0 Then
            Return buf
        End If
    End Function

    Public Function floatFromBuffer(pos As Integer) As Single
        Return daveConection.getFloatAt(pos)
    End Function

    Public Function floatFromBuffer(buf As Byte(), pos As Integer) As Single
        Return libnodave.getFloatfrom(buf, pos)
    End Function

    Public Function IntFromBuffer(pos As Integer) As Single
        Return daveConection.getFloatAt(pos)
    End Function

    Public Function ByteFromBuffer(pos As Integer) As Single
        Return daveConection.getFloatAt(pos)
    End Function

    ''' <summary>
    ''' Reads an Integer Value from an DB. Number of Byte as Startadress have to be even.
    ''' </summary>
    ''' <param name="dbNr">Integer Value DB Number</param>
    ''' <param name="byteStart">Integer Value of Byte Startadress</param>
    ''' <returns>Integer Value read from DB</returns>
    Public Function getInteger(dbNr, byteStart) As Integer
        Dim buf(2) As Byte
        getInteger = 1
        state = daveConection.readBytes(libnodave.daveDB, dbNr, byteStart, 2, buf)
        If state = 0 Then
            getInteger = daveConection.getS16
        End If
    End Function

    ''' <summary>
    ''' Reads an Double Integer Value from an DB. Number of Byte as Startadress have to be even.
    ''' </summary>
    ''' <param name="dbNr">Integer Value DB Number</param>
    ''' <param name="byteStart">Integer Value of Byte Startadress</param>
    ''' <returns>DInteger Value read from DB</returns>
    Public Function getDInteger(dbNr, byteStart) As Integer
        Dim buf(4) As Byte
        getDInteger = 0
        state = daveConection.readBytes(libnodave.daveDB, dbNr, byteStart, 4, buf)
        If state = 0 Then
            getDInteger = daveConection.getS32
        End If
    End Function

    ''' <summary>
    ''' Reads a String from PLC
    ''' </summary>
    ''' <param name="dbNr">DB Nr</param>
    ''' <param name="byteStart">Byte start Adress</param>
    ''' <param name="byteLength">Length of String in Bytes</param>
    ''' <param name="buffLength">Length of String</param>
    ''' <returns></returns>
    Public Function getString(dbNr, byteStart, byteLength, buffLength) As String
        Dim buf(buffLength) As Byte
        getString = ""
        Dim wert As String = ""
        state = daveConection.readManyBytes(libnodave.daveDB, dbNr, byteStart, byteLength, buf)
        If state = 0 Then
            wert = ""
            For i = 1 To buffLength
                wert = wert & Chr(daveConection.getU8)
            Next
            getString = wert
        End If
    End Function

    ''' <summary>
    ''' Reads a Float from DB.
    ''' </summary>
    ''' <param name="dbNr">DB Nr</param>
    ''' <param name="byteStart">Byte start Adress</param>
    ''' <returns></returns>
    Public Function getFloat(dbNr, byteStart)
        Dim mybuf(4) As Byte
        getFloat = -1.0
        If connStatus Then
            mybuf(0) = 0
            state = daveConection.readBytes(libnodave.daveDB, dbNr, byteStart, 4, mybuf)
            If state = 0 Then
                Return daveConection.getFloat
            End If
        End If
    End Function

    ''' <summary>
    ''' Writes a specific Bit out of a Byte
    ''' </summary>
    ''' <param name="dbNr">DB Number</param>
    ''' <param name="byteStart">Byteadress</param>
    ''' <param name="bitNr">Number of Bit within Byte</param>
    ''' <returns></returns>
    Public Function setBit(dbNr, byteStart, bitNr)
        Dim mybuf(1) As Byte
        Dim Adress As Integer
        Adress = byteStart * 8 + bitNr
        If connStatus Then
            mybuf(0) = 1
            state = daveConection.writeBits(libnodave.daveDB, dbNr, Adress, 1, mybuf)
            If state = 0 Then
                Return state
            Else
                ShowMessage("Fehler beim Schreiben: Bit")
            End If
        Else
            Return -1
        End If
    End Function

    '''' <summary>
    '''' Reads an Byte Value from an DB. Number of Byte as Startadress have to be even.
    '''' </summary>
    '''' <param name="dbNr">Integer Value DB Number</param>
    '''' <param name="byteStart">Integer Value of Byte Startadress</param>
    '''' <returns>Byte Value read from DB</returns>
    'Public Function SetByte(dbNr, byteStart) As Integer
    '    Dim buf(1) As Byte
    '    getByte = 1
    '    state = daveConection.readBytes(libnodave.daveDB, dbNr, byteStart, 1, buf)
    '    If state = 0 Then
    '        getByte = daveConection.getS8
    '    End If
    'End Function

    ''' <summary>
    ''' Writes an Integer Value from an DB. Number of Byte as Startadress have to be even.
    ''' </summary>
    ''' <param name="dbNr">Integer Value DB Number</param>
    ''' <param name="byteStart">Integer Value of Byte Startadress</param>
    ''' <returns>Integer Value read from DB</returns>
    Public Function SetInteger(dbNr, byteStart, Value)
        Dim buf(2) As Byte
        buf(1) = 1
        state = daveConection.writeBytes(libnodave.daveDB, dbNr, byteStart, 2, buf)
        If state = 0 Then
            ShowMessage("Fehler beim Schreiben")
        End If
    End Function

    '''' <summary>
    '''' Writes a String from PLC
    '''' </summary>
    '''' <param name="dbNr">DB Nr</param>
    '''' <param name="byteStart">Byte start Adress</param>
    '''' <param name="byteLength">Length of String in Bytes</param>
    '''' <param name="buffLength">Length of String</param>
    '''' <returns></returns>
    'Public Function SetString(dbNr, byteStart, byteLength, buffLength) As String
    '    Dim buf(buffLength) As Byte
    '    getString = ""
    '    Dim wert As String = ""
    '    state = daveConection.readManyBytes(libnodave.daveDB, dbNr, byteStart, byteLength, buf)
    '    If state = 0 Then
    '        wert = ""
    '        For i = 1 To buffLength
    '            wert = wert & Chr(daveConection.getU8)
    '        Next
    '        getString = wert
    '    End If
    'End Function

    ''' <summary>
    ''' Writes a Float from DB.
    ''' </summary>
    ''' <param name="dbNr">DB Nr</param>
    ''' <param name="byteStart">Byte start Adress</param>
    ''' <param name="byteLength">Length of String in Bytes</param>
    ''' <returns></returns>
    Public Function SetFloat(dbNr, byteStart, byteLength)
        Dim mybuf(4) As Byte
        '   mybuf(0) = -1.0
        If connStatus Then
            mybuf(0) = 0
            state = daveConection.writeBytes(libnodave.daveDB, dbNr, byteStart, byteLength, mybuf)
            If state = 0 Then
                ' Return daveConection.getFloat
            End If
        End If
    End Function

    Private Function ShowMessage(messageString)
        If IsNothing(textbox) Then
            Return -1
        Else
            textbox.Text = messageString
            Return 0
        End If
    End Function
End Module
