<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class wearControl
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(wearControl))
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ConfiguracionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnAcept = New System.Windows.Forms.Button()
        Me.lblPin = New System.Windows.Forms.Label()
        Me.tbxPin = New System.Windows.Forms.TextBox()
        Me.cbxLanguage = New System.Windows.Forms.ComboBox()
        Me.lblLanguage = New System.Windows.Forms.Label()
        Me.btnVLC = New System.Windows.Forms.Button()
        Me.btnSpotify = New System.Windows.Forms.Button()
        Me.btniTunes = New System.Windows.Forms.Button()
        Me.tbxVLC = New System.Windows.Forms.TextBox()
        Me.tbxSpotify = New System.Windows.Forms.TextBox()
        Me.tbxiTunes = New System.Windows.Forms.TextBox()
        Me.lblVLC = New System.Windows.Forms.Label()
        Me.lblSoptify = New System.Windows.Forms.Label()
        Me.lbliTunes = New System.Windows.Forms.Label()
        Me.ofdVLC = New System.Windows.Forms.OpenFileDialog()
        Me.ofdSpotify = New System.Windows.Forms.OpenFileDialog()
        Me.ofdiTunes = New System.Windows.Forms.OpenFileDialog()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.NotifyIcon1.Icon = CType(resources.GetObject("NotifyIcon1.Icon"), System.Drawing.Icon)
        Me.NotifyIcon1.Text = "wearControl"
        Me.NotifyIcon1.Visible = True
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ConfiguracionToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(151, 48)
        '
        'ConfiguracionToolStripMenuItem
        '
        Me.ConfiguracionToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ConfiguracionToolStripMenuItem.Name = "ConfiguracionToolStripMenuItem"
        Me.ConfiguracionToolStripMenuItem.Size = New System.Drawing.Size(150, 22)
        Me.ConfiguracionToolStripMenuItem.Text = "Configuration"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(150, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'btnAcept
        '
        Me.btnAcept.Location = New System.Drawing.Point(284, 262)
        Me.btnAcept.Name = "btnAcept"
        Me.btnAcept.Size = New System.Drawing.Size(75, 23)
        Me.btnAcept.TabIndex = 1
        Me.btnAcept.Text = "Acept"
        Me.btnAcept.UseVisualStyleBackColor = True
        '
        'lblPin
        '
        Me.lblPin.AutoSize = True
        Me.lblPin.Location = New System.Drawing.Point(34, 41)
        Me.lblPin.Name = "lblPin"
        Me.lblPin.Size = New System.Drawing.Size(28, 13)
        Me.lblPin.TabIndex = 2
        Me.lblPin.Text = "PIN:"
        '
        'tbxPin
        '
        Me.tbxPin.Location = New System.Drawing.Point(114, 41)
        Me.tbxPin.MaxLength = 4
        Me.tbxPin.Name = "tbxPin"
        Me.tbxPin.Size = New System.Drawing.Size(89, 20)
        Me.tbxPin.TabIndex = 3
        '
        'cbxLanguage
        '
        Me.cbxLanguage.FormattingEnabled = True
        Me.cbxLanguage.Location = New System.Drawing.Point(114, 82)
        Me.cbxLanguage.Name = "cbxLanguage"
        Me.cbxLanguage.Size = New System.Drawing.Size(89, 21)
        Me.cbxLanguage.TabIndex = 4
        '
        'lblLanguage
        '
        Me.lblLanguage.AutoSize = True
        Me.lblLanguage.Location = New System.Drawing.Point(23, 85)
        Me.lblLanguage.Name = "lblLanguage"
        Me.lblLanguage.Size = New System.Drawing.Size(0, 13)
        Me.lblLanguage.TabIndex = 5
        Me.lblLanguage.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'btnVLC
        '
        Me.btnVLC.Location = New System.Drawing.Point(227, 125)
        Me.btnVLC.Name = "btnVLC"
        Me.btnVLC.Size = New System.Drawing.Size(75, 23)
        Me.btnVLC.TabIndex = 6
        Me.btnVLC.Text = "Browse"
        Me.btnVLC.UseVisualStyleBackColor = True
        '
        'btnSpotify
        '
        Me.btnSpotify.Location = New System.Drawing.Point(227, 166)
        Me.btnSpotify.Name = "btnSpotify"
        Me.btnSpotify.Size = New System.Drawing.Size(75, 23)
        Me.btnSpotify.TabIndex = 7
        Me.btnSpotify.Text = "Browse"
        Me.btnSpotify.UseVisualStyleBackColor = True
        '
        'btniTunes
        '
        Me.btniTunes.Location = New System.Drawing.Point(227, 206)
        Me.btniTunes.Name = "btniTunes"
        Me.btniTunes.Size = New System.Drawing.Size(75, 23)
        Me.btniTunes.TabIndex = 8
        Me.btniTunes.Text = "Browse"
        Me.btniTunes.UseVisualStyleBackColor = True
        '
        'tbxVLC
        '
        Me.tbxVLC.Location = New System.Drawing.Point(115, 125)
        Me.tbxVLC.Name = "tbxVLC"
        Me.tbxVLC.Size = New System.Drawing.Size(88, 20)
        Me.tbxVLC.TabIndex = 9
        '
        'tbxSpotify
        '
        Me.tbxSpotify.Location = New System.Drawing.Point(115, 166)
        Me.tbxSpotify.Name = "tbxSpotify"
        Me.tbxSpotify.Size = New System.Drawing.Size(89, 20)
        Me.tbxSpotify.TabIndex = 10
        Me.tbxSpotify.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbxiTunes
        '
        Me.tbxiTunes.Location = New System.Drawing.Point(115, 208)
        Me.tbxiTunes.Name = "tbxiTunes"
        Me.tbxiTunes.Size = New System.Drawing.Size(89, 20)
        Me.tbxiTunes.TabIndex = 11
        Me.tbxiTunes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblVLC
        '
        Me.lblVLC.AutoSize = True
        Me.lblVLC.Location = New System.Drawing.Point(34, 128)
        Me.lblVLC.Name = "lblVLC"
        Me.lblVLC.Size = New System.Drawing.Size(30, 13)
        Me.lblVLC.TabIndex = 12
        Me.lblVLC.Text = "VLC:"
        '
        'lblSoptify
        '
        Me.lblSoptify.AutoSize = True
        Me.lblSoptify.Location = New System.Drawing.Point(34, 171)
        Me.lblSoptify.Name = "lblSoptify"
        Me.lblSoptify.Size = New System.Drawing.Size(42, 13)
        Me.lblSoptify.TabIndex = 13
        Me.lblSoptify.Text = "Spotify:"
        '
        'lbliTunes
        '
        Me.lbliTunes.AutoSize = True
        Me.lbliTunes.Location = New System.Drawing.Point(34, 211)
        Me.lbliTunes.Name = "lbliTunes"
        Me.lbliTunes.Size = New System.Drawing.Size(42, 13)
        Me.lbliTunes.TabIndex = 14
        Me.lbliTunes.Text = "iTunes:"
        '
        'ofdVLC
        '
        Me.ofdVLC.FileName = "vlc.exe"
        '
        'ofdSpotify
        '
        Me.ofdSpotify.FileName = "Spotify.exe"
        '
        'ofdiTunes
        '
        Me.ofdiTunes.FileName = "OpenFileDialog3"
        '
        'wearControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(371, 297)
        Me.Controls.Add(Me.lbliTunes)
        Me.Controls.Add(Me.lblSoptify)
        Me.Controls.Add(Me.lblVLC)
        Me.Controls.Add(Me.tbxiTunes)
        Me.Controls.Add(Me.tbxSpotify)
        Me.Controls.Add(Me.tbxVLC)
        Me.Controls.Add(Me.btniTunes)
        Me.Controls.Add(Me.btnSpotify)
        Me.Controls.Add(Me.btnVLC)
        Me.Controls.Add(Me.lblLanguage)
        Me.Controls.Add(Me.cbxLanguage)
        Me.Controls.Add(Me.tbxPin)
        Me.Controls.Add(Me.lblPin)
        Me.Controls.Add(Me.btnAcept)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "wearControl"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "wearControl"
        Me.WindowState = System.Windows.Forms.FormWindowState.Minimized
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Private WithEvents NotifyIcon1 As NotifyIcon
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents ConfiguracionToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents btnAcept As Button
    Friend WithEvents lblPin As Label
    Friend WithEvents tbxPin As TextBox
    Friend WithEvents cbxLanguage As ComboBox
    Friend WithEvents lblLanguage As Label
    Friend WithEvents btnVLC As Button
    Friend WithEvents btnSpotify As Button
    Friend WithEvents btniTunes As Button
    Friend WithEvents tbxVLC As TextBox
    Friend WithEvents tbxSpotify As TextBox
    Friend WithEvents tbxiTunes As TextBox
    Friend WithEvents lblVLC As Label
    Friend WithEvents lblSoptify As Label
    Friend WithEvents lbliTunes As Label
    Friend WithEvents ofdVLC As OpenFileDialog
    Friend WithEvents ofdSpotify As OpenFileDialog
    Friend WithEvents ofdiTunes As OpenFileDialog
End Class
