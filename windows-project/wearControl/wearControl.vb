' Imports
Imports System.IO
Imports System.Net
Imports System.Net.Sockets
Imports System.Text
Imports System.Threading
Imports System.Xml

' wearControl Class
Public Class wearControl

    ' Pin Integer
    Private pin As Int32

    ' System Control
    Private pc As New SystemControl

    ' IP Address
    Private ip As String

    ' Port
    Private port As Int32

    ' Socket
    Private socket As Int32 = 11000

    ' Conection Thread
    Dim ThreadConection As Thread

    ' TCP Listener
    Dim _server As TcpListener

    ' Thread TCP Listener
    Private CommThread As Thread

    ' IsListening TCP Listener
    Public IsListening As Boolean = True

    ' TCP Stream Data
    Shared Stream As NetworkStream

    ' Language
    Private language As String
    Private pinError As String
    Private exitQuestion As String
    Private exitWarning As String

    ' Conection Protocol
    Private Sub ConectionProtocol()
        'Waiting for MSG from Smartwatch and Return Smartwatch IP
        ip = UDPListener(socket)

        ' Creating TCP Server and Return TCP Port
        port = createTCPServer(ip)

        ' Sending TCP Port to Smartwatch
        UDPSender(ip, socket, port)
    End Sub

    ' Load Form
    Private Sub wearControl_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            readConfigXML()
            tbxPin.Text = pin
            readLanguageXML()
        Catch ex As Exception
            MsgBox(ex.Message)
            Close()
        End Try

        ThreadConection = New Thread(AddressOf ConectionProtocol)
        ThreadConection.Start()
    End Sub

    ' Select XML Language from XML
    Private Sub readLanguageXML()
        Dim m_xmlr As XmlTextReader
        m_xmlr = New XmlTextReader("languages.xml")

        m_xmlr.WhitespaceHandling = WhitespaceHandling.None

        m_xmlr.Read()
        m_xmlr.Read()

        cbxLanguage.Items.Clear()

        ' Load the Loop
        While Not m_xmlr.EOF

            m_xmlr.Read()

            If Not m_xmlr.IsStartElement() Then
                Exit While
            End If

            Dim readLanguage = m_xmlr.GetAttribute("language")

            cbxLanguage.Items.Add(readLanguage)
            m_xmlr.Read()
            If (readLanguage.Equals(language)) Then

                cbxLanguage.SelectedIndex = cbxLanguage.FindStringExact(readLanguage)

                ' Get the PIN label
                lblPin.Text = m_xmlr.ReadElementString("pin")

                ' Get the PIN Error
                pinError = m_xmlr.ReadElementString("pin_error")

                ' Get the Acept Button
                btnAcept.Text = m_xmlr.ReadElementString("acept")

                ' Get the Language label
                lblLanguage.Text = m_xmlr.ReadElementString("language")

                ' Get the Exit Question Message
                exitQuestion = m_xmlr.ReadElementString("exit_question")

                ' Get the Exit Warning Message
                exitWarning = m_xmlr.ReadElementString("exit_warning")

                ' Get the Configuration label
                ContextMenuStrip1.Items.Item(0).Text = m_xmlr.ReadElementString("configuration")

                ' Get the Exit label
                ContextMenuStrip1.Items.Item(1).Text = m_xmlr.ReadElementString("exit")
            Else
                m_xmlr.ReadElementString("pin")
                m_xmlr.ReadElementString("pin_error")
                m_xmlr.ReadElementString("acept")
                m_xmlr.ReadElementString("language")
                m_xmlr.ReadElementString("exit_question")
                m_xmlr.ReadElementString("exit_warning")
                m_xmlr.ReadElementString("configuration")
                m_xmlr.ReadElementString("exit")

            End If
        End While
        m_xmlr.Close()
    End Sub

    ' Read Configuration from XML
    Private Sub readConfigXML()
        Dim doc As New XmlDocument()
        doc.Load("configuration.xml")
        Dim child As XmlNode = doc.SelectSingleNode("/configuration")
        If Not (child Is Nothing) Then
            Dim nr As New XmlNodeReader(child)
            nr.Read()
            nr.Read()
            nr.Read()
            pin = nr.Value
            nr.Read()
            nr.Read()
            nr.Read()
            language = nr.Value
        End If
    End Sub

    ' Save Configuration from XML
    Private Sub saveConfigXML()
        Dim writer As New XmlTextWriter("configuration.xml", System.Text.Encoding.UTF8)
        writer.WriteStartDocument(True)
        writer.Formatting = Formatting.Indented
        writer.Indentation = 2
        writer.WriteStartElement("configuration")
        writer.WriteStartElement("pin")
        writer.WriteString(pin)
        writer.WriteEndElement()
        writer.WriteStartElement("language")
        writer.WriteString(language)
        writer.WriteEndElement()
        writer.WriteEndDocument()
        writer.Close()
    End Sub

    ' Create TCP Server
    Private Function createTCPServer(ip As String)
        Try
            _server = New TcpListener(IPAddress.Parse(ip), 0)
            _server.Start()

            Me.port = CType(_server.LocalEndpoint, IPEndPoint).Port()

            CommThread = New Thread(New ThreadStart(AddressOf Listening))
            CommThread.Start()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return port
    End Function

    ' TCP Listener
    Private Sub Listening()
        'Client TCP Data and Client
        Dim ClientData As StreamReader
        Dim client As TcpClient

        ' Listening Loop
        Do Until IsListening = False

            ' New Connection
            If _server.Pending = True Then
                client = _server.AcceptTcpClient
                ClientData = New StreamReader(client.GetStream)

                pc.sendCommand(ClientData.ReadToEnd)
            End If
        Loop
    End Sub

    ' UDP Listener
    Private Function UDPListener(socket As Int32)
        Dim receivingUdpClient As UdpClient
        Dim RemoteIpEndPoint As New _
              System.Net.IPEndPoint(System.Net.IPAddress.Any, 0)

        receivingUdpClient = New System.Net.Sockets.UdpClient(socket)

        Dim strMessage As String = String.Empty
        Do
            Dim bytRecieved As Byte() =
        receivingUdpClient.Receive(RemoteIpEndPoint)
            strMessage = Encoding.ASCII.GetString(bytRecieved)
        Loop While (Convert.ToInt32(strMessage) <> pin)
        receivingUdpClient.Close()
        Return RemoteIpEndPoint.Address.ToString
    End Function

    ' UDP Sender
    Private Sub UDPSender(ip As String, socket As Int32, port As Int32)
        Dim UDPClient As New UdpClient()
        UDPClient.Client.SetSocketOption(SocketOptionLevel.Socket,
         SocketOptionName.ReuseAddress, True)
        UDPClient.Connect(ip, socket)
        Try
            Dim bytSent As Byte() = Encoding.ASCII.GetBytes(port)
            UDPClient.Send(bytSent, bytSent.Length)
            UDPClient.Close()
        Catch e As Exception
            Console.WriteLine(e.ToString())
        End Try
    End Sub

    ' Double Click ToolStrip
    Private Sub NotifyIcon1_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles NotifyIcon1.MouseDoubleClick
        Try
            Me.Visible = True
            tbxPin.Text = pin
            Me.WindowState = FormWindowState.Normal
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    ' Config Button ToolStrip
    Private Sub ConfiguracionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConfiguracionToolStripMenuItem.Click
        Try
            Me.Visible = True
            Me.WindowState = FormWindowState.Normal
            tbxPin.Text = pin
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    ' Exit Button ToolStrip
    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Dim msg As String
        Dim style As MsgBoxStyle
        Dim response As MsgBoxResult
        msg = exitQuestion & vbNewLine & exitWarning
        style = MsgBoxStyle.DefaultButton2 Or
        MsgBoxStyle.Question Or MsgBoxStyle.YesNo
        response = MsgBox(msg, style, "wearControl")
        If response = MsgBoxResult.No Then
            ThreadConection.Abort()
            Me.Close()
        Else
            Close()
            End
        End If
    End Sub

    ' Acept Button Config Form
    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAcept.Click
        pin = tbxPin.Text
        language = cbxLanguage.Text
        saveConfigXML()
        readLanguageXML()
        Me.Visible = False
    End Sub

    ' Exit Button Config Form
    Private Sub wearControl_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        e.Cancel = True
        tbxPin.Text = pin
        cbxLanguage.SelectedIndex = cbxLanguage.FindStringExact(language)
        Me.Visible = False
    End Sub

    ' Pin Textbox key pressed
    Private Sub tbxPin_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbxPin.KeyPress
        If Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso Not IsNumeric(e.KeyChar) Then
            MessageBox.Show(pinError)
            e.Handled = True
        End If
    End Sub
End Class