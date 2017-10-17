'ap escucha udp
'reloj envia pin por broadcast y se pone a la escucha 
'app comprueba pin, si correcto, envia puerto por udp a la ip del reloj y activa servidor tcp con ip del reloj
'reloj escucha puerto y se conecta por tcp a la ip de la app

'createTCPServer NotInheritable se si cambiar port = .... por un return, comprobar si funcionaria

'Imports
Imports System.Net
Imports System.Net.Sockets
Imports System.Text
Imports System.Threading

Public Class wearControl

    'Pin Integer
    Private pin As Int32 = 1234

    'System Control
    Private pc As New SystemControl

    'IP Address
    Private ip As String

    'Port
    Private port As Int32

    'Conection Thread
    Dim ThreadConection As Thread

    'TCP Conection
    Dim _server As TcpListener
    Dim _listOfClients As New List(Of TcpClient)

    'Conection Protocol
    Private Sub ConectionProtocol()
        ip = UDPListener()

        createTCPServer(ip)

        'puerto aleatorio de momento en port

        UDPSender(ip, port)


        'generar puerto aleatorio

        'crear servidor tcp por puerto aleatorio y a la escucha de la ip

        ' enviar puerto aleatorio por ip



    End Sub

    'Load Form
    Private Sub wearControl_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tbxPin.Text = pin
        ThreadConection = New Thread(AddressOf ConectionProtocol)
        ThreadConection.Start()
    End Sub

    'Create TCP Server
    Private Sub createTCPServer(ip As String)
        Try
            Dim port As Integer = 5432

            _server = New TcpListener(IPAddress.Parse(ip), port)
            _server.Start()

            Me.port = CType(_server.LocalEndpoint, IPEndPoint).Port()

            Threading.ThreadPool.QueueUserWorkItem(AddressOf NewTCPConection)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    'New TCP Conection
    Private Sub NewTCPConection(state As Object)
        Dim client As TcpClient = _server.AcceptTcpClient()
        Try
            '  _listOfClients.Add(client)
            ' Threading.ThreadPool.QueueUserWorkItem(AddressOf NewTCPConection)

            While True
                Dim ns As NetworkStream = client.GetStream()

                '  Dim toReceive(3) As Byte
                Dim toReceive(100000) As Byte
                ns.Read(toReceive, 0, toReceive.Length)
                Dim msg As String = Encoding.ASCII.GetString(toReceive)

                pc.sendCommand(msg)

                '   For Each c As TcpClient In _listOfClients
                'If c IsNot client Then
                ' Dim nns As NetworkStream = c.GetStream()
                '         nns.Write(Encoding.ASCII.GetBytes(txt), 0, txt.Length)
                ' End If
                '  Next
            End While

        Catch ex As Exception
            '   If _listOfClients.Contains(client) Then
            '   _listOfClients.Remove(client)
            '   End If
            MsgBox(ex.Message)
        End Try
    End Sub

    'UDP Sender
    Private Sub UDPSender(ip As String, port As Int32)
        Dim UDPClient As New UdpClient()
        UDPClient.Client.SetSocketOption(SocketOptionLevel.Socket,
           SocketOptionName.ReuseAddress, True)
        UDPClient.Connect(ip, 11000)
        Try
            Dim bytSent As Byte() = Encoding.ASCII.GetBytes(port)
            UDPClient.Send(bytSent, bytSent.Length)
            UDPClient.Close()
        Catch e As Exception
            Console.WriteLine(e.ToString())
        End Try
    End Sub

    'UDP Listener
    Private Function UDPListener()
        Dim UDPClient As UdpClient = New UdpClient()
        UDPClient.Client.SetSocketOption(SocketOptionLevel.Socket,
         SocketOptionName.ReuseAddress, True)
        UDPClient.Client.Bind(New IPEndPoint(IPAddress.Any, 11000))
        Dim clockip As String = ""
        Try
            Dim iepRemoteEndPoint As IPEndPoint = New _
            IPEndPoint(IPAddress.Any, 11000)
            Dim strMessage As String = String.Empty
            Do
                Dim bytRecieved As Byte() =
                UDPClient.Receive(iepRemoteEndPoint)
                strMessage = Encoding.ASCII.GetString(bytRecieved)

                Dim bytes As [Byte]() = iepRemoteEndPoint.Address.GetAddressBytes()

                clockip = bytes(0) & "." & bytes(1) & "." & bytes(2) & "." & bytes(3)
            Loop While (Convert.ToInt32(strMessage) <> pin)

            UDPClient.Close()
        Catch e As Exception
            Console.WriteLine(e.ToString())
        End Try
        Return clockip
    End Function

    'Double Click ToolStrip
    Private Sub NotifyIcon1_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles NotifyIcon1.MouseDoubleClick
        Try
            Me.Visible = True
            tbxPin.Text = pin
            Me.WindowState = FormWindowState.Normal
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    'Config Button ToolStrip
    Private Sub ConfiguracionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConfiguracionToolStripMenuItem.Click
        Try
            Me.Visible = True
            Me.WindowState = FormWindowState.Normal
            tbxPin.Text = pin
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    'Exit Button ToolStrip
    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Dim msg As String
        Dim style As MsgBoxStyle
        Dim response As MsgBoxResult
        msg = "¿Seguro que deseas cerrar wearControl?" & vbNewLine & "Se dejara de escuchar a tu smartwatch"
        style = MsgBoxStyle.DefaultButton2 Or
        MsgBoxStyle.Question Or MsgBoxStyle.YesNo
        response = MsgBox(msg, style, "wearControl")
        If response = MsgBoxResult.Yes Then
            ThreadConection.Abort()
            Me.Close()
        End If
    End Sub

    'Acept Button Config Form
    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAcept.Click
        tbxPin.Text = pin
        Me.Visible = False
    End Sub

    'Exit Button Config Form
    Private Sub wearControl_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        e.Cancel = True
        Me.Visible = False
    End Sub

    'Pin Textbox key pressed
    Private Sub tbxPin_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbxPin.KeyPress
        If Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso Not IsNumeric(e.KeyChar) Then
            MessageBox.Show("Por favor, introduce un PIN numerico de 4 cifras")
            e.Handled = True
        End If
    End Sub
End Class