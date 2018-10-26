Imports System.Threading
Imports System.Net
Imports System.Net.Sockets

Public Class Form1
    Dim ListenSocket As New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp) '创建监听的套接字
    Dim Dict As New Dictionary(Of String, Socket) '用于保存连接的客户的套接字的键值对集合
    Dim DictThre As New Dictionary(Of String, Thread) '用于保存通信线程的键值对集合
    '判断窗口目前的显示或是隐藏的变量
    Dim ShowOrHide As Integer = 0
    '声明注册热键API函数
    Public Declare Function RegisterHotKey Lib "user32" (ByVal hWnd As Integer, ByVal id As Integer, ByVal fsModifiers As Integer, ByVal vk As Integer) As Integer
    '声明注销热键API函数
    Public Declare Function UnregisterHotKey Lib "user32" (ByVal hWnd As Integer, ByVal id As Integer) As Integer
    Public Const WM_HOTKEY As Short = &H312S '热键消息ID，此值固定，不能修改
    Public Const MOD_ALT As Short = &H1S  'ALT按键ID
    Public Const MOD_CONTROL As Short = &H2S  'Ctrl
    Public Const MOD_SHIFT As Short = &H4S  'Shift
    Public uVirtKey1, Modifiers, idHotKey As Integer

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TextName.Text = Environment.MachineName '获取计算名称
        idHotKey = 1 '注册的热键的消息ID，这个值可以随便定义，只要与下面两个参数对应即可
        Modifiers = MOD_SHIFT '辅助键为Shift
        '注册热键
        RegisterHotKey(Me.Handle.ToInt32, idHotKey, Modifiers, Keys.Q) '注册的热键为Shift+Q
        RegisterHotKey(Me.Handle.ToInt32, 2, MOD_ALT, Keys.Q) '注册的热键为Ctrl+Q。这里和上步一样，我把参数直接写了，没有先赋值，相信大家都明白
    End Sub
    '窗体的消息处理函数
    Protected Overrides Sub WndProc(ByRef m As Message)
        If m.Msg = WM_HOTKEY Then '判断是否为热键消息
            Select Case m.WParam.ToInt32 '判断热键消息的注册ID
                Case 1
                    Button4_Click(Nothing, Nothing) 'Shift+Q
                Case 2
                    Button3_Click(Nothing, Nothing) 'Ctrl+Q
            End Select
        End If
        MyBase.WndProc(m) '循环监听消息
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click '隐藏或显示窗口
        If ShowOrHide = 1 Then
            Me.Show()
            ShowOrHide = 0
        ElseIf ShowOrHide = 0 Then
            Me.Hide()
            ShowOrHide = 1
        End If
    End Sub

    Private Sub ButListen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButListen.Click '开始监听的按钮
        TextBox.CheckForIllegalCrossThreadCalls = False '取消文本框的跨线程检查
        Dim Address As IPAddress = IPAddress.Parse(TxtIP.Text.Trim)
        Dim EndPoint As New IPEndPoint(Address, TxtPort.Text) '创建一个网络节点对象
        ListenSocket.Bind(EndPoint) '给负责监听的套接字绑定一个网络节点
        ListenSocket.Listen(2)
        ShowRecMsg("正在监听……")
        Dim thre As New Thread(AddressOf Connect) '创建一个新的线程用于处理客户端发来的连接请求
        thre.IsBackground = True '设为后台线程
        thre.Start() '开启线程
    End Sub

    Sub Connect() '处理客户端的连接请求的过程
        While True
            Dim SockConect As Socket = ListenSocket.Accept
            ShowRecMsg("连接成功！" & "（连接信息：" & SockConect.RemoteEndPoint.ToString & "）")
            Dict.Add(SockConect.RemoteEndPoint.ToString, SockConect) '将连接成功的套接字添加到键值对集合
            LBOnLine.Items.Add(SockConect.RemoteEndPoint.ToString) '添加到列表
            Dim Thre As New Thread(AddressOf RecClient) '创建一个新的线程用于和链接成功的套接字通信
            Thre.IsBackground = True '设为后台线程
            Thre.Start(SockConect)
            DictThre.Add(SockConect.RemoteEndPoint.ToString, Thre) '将创建的通信线程添加到键值对集合
        End While
    End Sub

    Sub RecClient(ByVal SockTelNet As Socket) '处理客户端发来的数据
        While True
            Dim AryMsg(1024) As Byte
            Dim RecLen As Int32

            Try '捕获异常
                RecLen = SockTelNet.Receive(AryMsg) '接受客户端发来得信息
            Catch ss As SocketException
                ShowRecMsg(ss.NativeErrorCode & vbCrLf & ss.Message) '显示错误信息
                Dict.Remove(SockTelNet.RemoteEndPoint.ToString) '移除断开连接的套接字
                LBOnLine.Items.Remove(SockTelNet.RemoteEndPoint.ToString) '从列表中移除
                Return
            Catch s As Exception
                ShowRecMsg(s.Message)
                Return
            End Try

            Dim StrMsg As String
            StrMsg = System.Text.Encoding.UTF8.GetChars(AryMsg, 0, RecLen)
            ShowRecMsg(StrMsg)
            TxtMsg.ScrollToCaret()
            Button4.PerformClick()
        End While
    End Sub

    Sub ShowRecMsg(ByVal Msg As String) '显示接收信息绿色
        TxtMsg.SelectionColor = Color.Green
        TxtMsg.AppendText(Format(DateTime.Now, "F") & vbCrLf & "   " & Msg & vbCrLf) 'TxtMsg用途显示消息记录
    End Sub
    Sub ShowSendMsg(ByVal Msg As String) '显示接收信息红色
        TxtMsg.SelectionColor = Color.Red
        TxtMsg.AppendText(Format(DateTime.Now, "F") & vbCrLf & "   " & Msg & vbCrLf) 'TxtMsg用途显示消息记录
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click 'Button2群发的按钮
        For Each a In Dict.Values '遍历通信套接字键值对集合，群发消息
            Dim AryMsg() = System.Text.Encoding.UTF8.GetBytes(TextName.Text & " Say: " & TxtSendMsg.Text.Trim)
            Try '捕获异常
                a.Send(AryMsg) '发送消息
            Catch ss As SocketException
                ShowRecMsg(ss.NativeErrorCode & vbCrLf & ss.Message)
            Catch s As Exception
                ShowRecMsg(s.Message)
            End Try
        Next
        ShowSendMsg(TextName.Text & " Say: " & TxtSendMsg.Text.Trim)
        TxtSendMsg.Clear()
        TxtMsg.ScrollToCaret()
    End Sub

    Private Sub TxtSendMsg_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtSendMsg.KeyPress '判断按确定键自动发出
        If e.KeyChar = ChrW(13) Then
            Me.Button2.PerformClick()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Me.TopMost = False Then
            Me.TopMost = True
        ElseIf Me.TopMost = True Then
            Me.TopMost = False
        End If
    End Sub
    '以下是窗口通知闪烁，True是代表前台闪烁，FALSE代表后台闪烁
    Declare Function FlashWindow Lib "user32" Alias "FlashWindow" (ByVal hwnd As Long, ByVal bInvert As Long) As Long
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.FlashWindow(Me.Handle, False)
    End Sub

End Class