Public Class SystemControl
    Public Sub sendCommand(command As String)
        Try
            Select Case command
                'Play/Pausa
                Case "000"
                    mediaPlay_Pause()
                'Stop
                Case "001"
                    mediaStop()
                'Next
                Case "010"
                    mediaNext()
                'Foward
                Case "011"
                    mediaFoward()
                'Volume Mute/Unmute
                Case "100"
                    volumeMute_Unmute()
                'Volume Up
                Case "101"
                    volumeUp()
                'Volume Down
                Case "110"
                    volumeDown()
                Case Else
                    Throw New System.Exception("Command not found")
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    'Play/Pause Execution
    Private Sub mediaPlay_Pause()
        My.Computer.Keyboard.SendKeys(Keys.MediaPlayPause)
    End Sub

    'Stop Execution
    Private Sub mediaStop()
        My.Computer.Keyboard.SendKeys(Keys.MediaStop)
    End Sub

    'Next Execution
    Private Sub mediaNext()
        My.Computer.Keyboard.SendKeys(Keys.MediaNextTrack)
    End Sub

    'Foward Execution
    Private Sub mediaFoward()
        My.Computer.Keyboard.SendKeys(Keys.MediaPreviousTrack)
    End Sub

    'Mute/Unmute Execution
    Private Sub volumeMute_Unmute()
        My.Computer.Keyboard.SendKeys(Keys.VolumeMute)
    End Sub

    'Volume Up Execution
    Private Sub volumeUp()
        My.Computer.Keyboard.SendKeys(Keys.VolumeUp)
    End Sub

    'Volume Down Execution
    Private Sub volumeDown()
        My.Computer.Keyboard.SendKeys(Keys.VolumeDown)
    End Sub
End Class