<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.TxtIP = New System.Windows.Forms.TextBox()
        Me.TxtPort = New System.Windows.Forms.TextBox()
        Me.LBOnLine = New System.Windows.Forms.ListBox()
        Me.TxtMsg = New System.Windows.Forms.RichTextBox()
        Me.TxtSendMsg = New System.Windows.Forms.TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.ButListen = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextName = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'TxtIP
        '
        Me.TxtIP.Location = New System.Drawing.Point(53, 12)
        Me.TxtIP.Name = "TxtIP"
        Me.TxtIP.Size = New System.Drawing.Size(99, 21)
        Me.TxtIP.TabIndex = 0
        Me.TxtIP.Text = "192.168.12.114"
        '
        'TxtPort
        '
        Me.TxtPort.Location = New System.Drawing.Point(53, 38)
        Me.TxtPort.Name = "TxtPort"
        Me.TxtPort.Size = New System.Drawing.Size(99, 21)
        Me.TxtPort.TabIndex = 0
        Me.TxtPort.Text = "5555"
        '
        'LBOnLine
        '
        Me.LBOnLine.FormattingEnabled = True
        Me.LBOnLine.ItemHeight = 12
        Me.LBOnLine.Location = New System.Drawing.Point(425, 10)
        Me.LBOnLine.Name = "LBOnLine"
        Me.LBOnLine.Size = New System.Drawing.Size(215, 292)
        Me.LBOnLine.TabIndex = 1
        '
        'TxtMsg
        '
        Me.TxtMsg.Location = New System.Drawing.Point(12, 66)
        Me.TxtMsg.Name = "TxtMsg"
        Me.TxtMsg.Size = New System.Drawing.Size(384, 250)
        Me.TxtMsg.TabIndex = 2
        Me.TxtMsg.Text = ""
        '
        'TxtSendMsg
        '
        Me.TxtSendMsg.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TxtSendMsg.Location = New System.Drawing.Point(12, 324)
        Me.TxtSendMsg.Name = "TxtSendMsg"
        Me.TxtSendMsg.Size = New System.Drawing.Size(309, 21)
        Me.TxtSendMsg.TabIndex = 3
        '
        'Button2
        '
        Me.Button2.ForeColor = System.Drawing.Color.Red
        Me.Button2.Location = New System.Drawing.Point(327, 322)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(69, 23)
        Me.Button2.TabIndex = 4
        Me.Button2.Text = "发送"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'ButListen
        '
        Me.ButListen.Font = New System.Drawing.Font("微软雅黑", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.ButListen.ForeColor = System.Drawing.Color.Fuchsia
        Me.ButListen.Location = New System.Drawing.Point(158, 12)
        Me.ButListen.Name = "ButListen"
        Me.ButListen.Size = New System.Drawing.Size(74, 47)
        Me.ButListen.TabIndex = 5
        Me.ButListen.Text = "开始监听"
        Me.ButListen.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(23, 12)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "IP:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 12)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "端口:"
        '
        'TextName
        '
        Me.TextName.Location = New System.Drawing.Point(241, 39)
        Me.TextName.Name = "TextName"
        Me.TextName.Size = New System.Drawing.Size(155, 21)
        Me.TextName.TabIndex = 7
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(338, 11)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(58, 27)
        Me.Button1.TabIndex = 9
        Me.Button1.Text = "置顶"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(241, 11)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(50, 27)
        Me.Button3.TabIndex = 9
        Me.Button3.Text = "老板键"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(669, 30)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(65, 36)
        Me.Button4.TabIndex = 10
        Me.Button4.Text = "闪烁"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(408, 349)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.TextName)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ButListen)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.TxtSendMsg)
        Me.Controls.Add(Me.TxtMsg)
        Me.Controls.Add(Me.LBOnLine)
        Me.Controls.Add(Me.TxtPort)
        Me.Controls.Add(Me.TxtIP)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form1"
        Me.Text = "服务器 0.1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TxtIP As TextBox
    Friend WithEvents TxtPort As TextBox
    Friend WithEvents LBOnLine As ListBox
    Friend WithEvents TxtMsg As RichTextBox
    Friend WithEvents TxtSendMsg As TextBox
    Friend WithEvents Button2 As Button
    Friend WithEvents ButListen As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents TextName As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button4 As Button
End Class
