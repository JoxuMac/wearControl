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

    ' Thread Broadcast
    Private BroadcastThread As Thread

    ' Thread UDP Listener
    Private UDPThread As Thread

    ' Thread Conection 
    Dim ThreadConection As Thread

    ' Socket Listening
    Private socketListener As Int32 = 11000

    ' Socket Broadcast
    Private socketBroadcast As Int32 = 11001

    ' UDP Client
    Dim receivingUdpClient As UdpClient

    ' Language
    Private language, pinError, exitQuestion, exitWarning As String

    ' Conection Protocol
    Private Sub ConectionProtocol()

        'SEND BROADCAST EVERY 30 SECOND
        BroadcastThread = New Thread(New ThreadStart(AddressOf UDPBroadcast))
        BroadcastThread.Start()

        'LISTEN UDP
        UDPThread = New Thread(New ThreadStart(AddressOf UDPListener))
        UDPThread.Start()

    End Sub

    'UDP Broadcast
    Private Sub UDPBroadcast()
        Dim UDPClient As New UdpClient()
        UDPClient.Client.SetSocketOption(SocketOptionLevel.Socket,
         SocketOptionName.ReuseAddress, True)
        UDPClient.Connect(System.Net.IPAddress.Broadcast, socketBroadcast)
        Do
            Try
                Dim bytSent As Byte() = Encoding.ASCII.GetBytes(pin)
                UDPClient.Send(bytSent, bytSent.Length)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            Thread.Sleep(5000)
        Loop While True
        UDPClient.Close()
    End Sub

    ' UDP Listener
    Private Sub UDPListener()
        Dim RemoteIpEndPoint As New _
           System.Net.IPEndPoint(System.Net.IPAddress.Any, 0)
        receivingUdpClient = New System.Net.Sockets.UdpClient(socketListener)

        Dim strMessage As String = String.Empty
        Do
            Dim bytRecieved As Byte() =
            receivingUdpClient.Receive(RemoteIpEndPoint)
            strMessage = Encoding.ASCII.GetString(bytRecieved)
            If ((pin.ToString).Equals(strMessage.Substring(0, strMessage.IndexOf("-")))) Then
                Dim paths(3) As String
                paths(0) = tbxVLC.Text
                paths(1) = tbxSpotify.Text
                paths(2) = tbxiTunes.Text
                pc.sendCommand(strMessage.Substring(strMessage.IndexOf("-") + 1), paths)
            End If
        Loop While True
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
                lblPin.Text = m_xmlr.ReadElementString("pin") + ":"

                ' Get the PIN Error
                pinError = m_xmlr.ReadElementString("pin_error")

                ' Get the Acept Button
                btnAcept.Text = m_xmlr.ReadElementString("acept")

                ' Get the Language label
                lblLanguage.Text = m_xmlr.ReadElementString("language") + ":"

                ' Get the Exit Question Message
                exitQuestion = m_xmlr.ReadElementString("exit_question")

                ' Get the Exit Warning Message
                exitWarning = m_xmlr.ReadElementString("exit_warning")

                ' Get the Configuration label
                ContextMenuStrip1.Items.Item(0).Text = m_xmlr.ReadElementString("configuration")

                ' Get the Exit label
                ContextMenuStrip1.Items.Item(1).Text = m_xmlr.ReadElementString("exit")

                ' Get the Browse Button label
                Dim browse As String = m_xmlr.ReadElementString("browse")
                btniTunes.Text = browse
                btnSpotify.Text = browse
                btnVLC.Text = browse

            Else
                m_xmlr.ReadElementString("pin")
                m_xmlr.ReadElementString("pin_error")
                m_xmlr.ReadElementString("acept")
                m_xmlr.ReadElementString("language")
                m_xmlr.ReadElementString("exit_question")
                m_xmlr.ReadElementString("exit_warning")
                m_xmlr.ReadElementString("configuration")
                m_xmlr.ReadElementString("exit")
                m_xmlr.ReadElementString("browse")

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
            nr.Read()
            nr.Read()
            nr.Read()
            tbxVLC.Text = nr.Value
            nr.Read()
            nr.Read()
            nr.Read()
            tbxSpotify.Text = nr.Value
            nr.Read()
            nr.Read()
            nr.Read()
            tbxiTunes.Text = nr.Value
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
        writer.WriteStartElement("VLC")
        writer.WriteString(tbxVLC.Text)
        writer.WriteEndElement()
        writer.WriteStartElement("spotify")
        writer.WriteString(tbxSpotify.Text)
        writer.WriteEndElement()
        writer.WriteStartElement("itunes")
        writer.WriteString(tbxiTunes.Text)
        writer.WriteEndElement()
        writer.WriteEndDocument()
        writer.Close()
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
            receivingUdpClient.Close()
            UDPThread.Abort()
            BroadcastThread.Abort()
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

    ' VLC Button pressed
    Private Sub btnVLC_Click(sender As Object, e As EventArgs) Handles btnVLC.Click
        If ofdVLC.ShowDialog = DialogResult.OK Then
            tbxVLC.Text = ofdVLC.FileName
        End If
    End Sub

    ' Spotify Button pressed
    Private Sub btnSpotify_Click(sender As Object, e As EventArgs) Handles btnSpotify.Click
        If ofdSpotify.ShowDialog = DialogResult.OK Then
            tbxSpotify.Text = ofdSpotify.FileName
        End If
    End Sub

    ' iTunes Button pressed
    Private Sub btniTunes_Click(sender As Object, e As EventArgs) Handles btniTunes.Click
        If ofdiTunes.ShowDialog = DialogResult.OK Then
            tbxiTunes.Text = ofdiTunes.FileName
        End If
    End Sub
End Class