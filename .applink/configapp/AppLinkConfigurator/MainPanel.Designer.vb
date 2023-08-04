<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainPanel
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
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

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainPanel))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.Label3 = New System.Windows.Forms.Label()
        Me.active = New System.Windows.Forms.Label()
        Me.inactive = New System.Windows.Forms.Label()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 14.25!)
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(21, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(193, 25)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "AppLink Configurator"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(23, 57)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "version 1 BETA"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(26, 275)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(155, 27)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Manage apps"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Button2.Location = New System.Drawing.Point(26, 308)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(155, 27)
        Me.Button2.TabIndex = 3
        Me.Button2.Text = "Manage commands"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Button3.Location = New System.Drawing.Point(26, 341)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(155, 27)
        Me.Button3.TabIndex = 4
        Me.Button3.Text = "Start/Restart Server"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.ForeColor = System.Drawing.Color.White
        Me.CheckBox1.Location = New System.Drawing.Point(187, 347)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(122, 17)
        Me.CheckBox1.TabIndex = 5
        Me.CheckBox1.Text = "Enable Log Window"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(26, 209)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(155, 27)
        Me.Button4.TabIndex = 6
        Me.Button4.Text = "Exit AppLink"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.NotifyIcon1.Icon = CType(resources.GetObject("NotifyIcon1.Icon"), System.Drawing.Icon)
        Me.NotifyIcon1.Text = "AppLink"
        Me.NotifyIcon1.Visible = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 10.25!)
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(23, 117)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(89, 19)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Server Status"
        '
        'active
        '
        Me.active.AutoSize = True
        Me.active.Font = New System.Drawing.Font("Segoe UI", 12.25!)
        Me.active.ForeColor = System.Drawing.Color.Green
        Me.active.Location = New System.Drawing.Point(23, 141)
        Me.active.Name = "active"
        Me.active.Size = New System.Drawing.Size(66, 23)
        Me.active.TabIndex = 8
        Me.active.Text = "ACTIVE"
        Me.active.Visible = False
        '
        'inactive
        '
        Me.inactive.AutoSize = True
        Me.inactive.Font = New System.Drawing.Font("Segoe UI", 12.25!)
        Me.inactive.ForeColor = System.Drawing.Color.Red
        Me.inactive.Location = New System.Drawing.Point(23, 141)
        Me.inactive.Name = "inactive"
        Me.inactive.Size = New System.Drawing.Size(84, 23)
        Me.inactive.TabIndex = 9
        Me.inactive.Text = "INACTIVE"
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(118, 116)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(63, 23)
        Me.Button5.TabIndex = 10
        Me.Button5.Text = "Refresh"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(383, 353)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(49, 29)
        Me.Button6.TabIndex = 11
        Me.Button6.Text = "Github"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'MainPanel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(24, Byte), Integer), CType(CType(24, Byte), Integer), CType(CType(24, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(444, 394)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.inactive)
        Me.Controls.Add(Me.active)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.Name = "MainPanel"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "AppLink Configurator"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents Button4 As Button
    Friend WithEvents NotifyIcon1 As NotifyIcon
    Friend WithEvents Label3 As Label
    Friend WithEvents active As Label
    Friend WithEvents inactive As Label
    Friend WithEvents Button5 As Button
    Friend WithEvents Button6 As Button
End Class
