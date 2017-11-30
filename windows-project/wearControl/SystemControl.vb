Public Class SystemControl
    Public Sub sendCommand(command As String)
        Try
            Select Case command
                'Play/Pausa
                Case "0000"
                    mediaPlay_Pause()
                'Stop
                Case "0001"
                    mediaStop()
                'Next
                Case "0010"
                    mediaNext()
                'Foward
                Case "0011"
                    mediaFoward()
                'Volume Mute/Unmute
                Case "0100"
                    volumeMute_Unmute()
                'Volume Up
                Case "0101"
                    volumeUp()
                'Volume Down
                Case "0110"
                    volumeDown()
                'Open Spotify
                Case "0111"
                    openSpotify()
                'Open iTunes
                Case "1000"
                    openiTunes()
                'Open VLC
                Case "1001"
                    openVLC()
                Case Else
                    Throw New System.Exception("Command not found")
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    'Open iTunes
    Private Sub openiTunes()
        'My.Computer.Keyboard.SendKeys(Keys.MediaPlayPause)
    End Sub

    'Open VLC
    Private Sub openVLC()
        'My.Computer.Keyboard.SendKeys(Keys.MediaPlayPause)
    End Sub

    'Open Spotify
    Private Sub openSpotify()
        'My.Computer.Keyboard.SendKeys(Keys.MediaPlayPause)
    End Sub

    'Play/Pause Execution
    Private Sub mediaPlay_Pause()
        Call keybd_event(System.Windows.Forms.Keys.MediaPlayPause, 0, 0, 0)
        '  My.Computer.Keyboard.SendKeys(Keys.MediaPlayPause)
    End Sub

    'Stop Execution
    Private Sub mediaStop()
        Call keybd_event(System.Windows.Forms.Keys.MediaStop, 0, 0, 0)
        '  My.Computer.Keyboard.SendKeys(Keys.MediaStop)
    End Sub

    'Next Execution
    Private Sub mediaNext()
        Call keybd_event(System.Windows.Forms.Keys.MediaNextTrack, 0, 0, 0)
        ' My.Computer.Keyboard.SendKeys(Keys.MediaNextTrack)
    End Sub

    'Foward Execution
    Private Sub mediaFoward()
        Call keybd_event(System.Windows.Forms.Keys.MediaPreviousTrack, 0, 0, 0)
        '   My.Computer.Keyboard.SendKeys(Keys.MediaPreviousTrack)
    End Sub

    'Mute/Unmute Execution
    Private Sub volumeMute_Unmute()
        Call keybd_event(System.Windows.Forms.Keys.VolumeMute, 0, 0, 0)
    End Sub

    'Volume Up Execution
    Private Sub volumeUp()
        Call keybd_event(System.Windows.Forms.Keys.VolumeUp, 0, 0, 0)
        ' My.Computer.Keyboard.SendKeys(Keys.VolumeUp)
    End Sub

    'Volume Down Execution
    Private Sub volumeDown()
        Call keybd_event(System.Windows.Forms.Keys.VolumeDown, 0, 0, 0)
        ' My.Computer.Keyboard.SendKeys(Keys.VolumeDown)
    End Sub

    Private Declare Sub keybd_event Lib "user32" (ByVal bVk As Byte, ByVal bScan As Byte, ByVal dwFlags As Integer, ByVal dwExtraInfo As Integer)
    Const KEYEVENTF_KEYUP As Long = &H2
End Class