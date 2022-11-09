Imports System.Data.OleDb
Imports Oracle.ManagedDataAccess.Client

Public Class 管理员端系统用户管理
    Dim constr As String = "USER ID=ST; DATA SOURCE=LOCALHOST:1521/ORCL; PASSWORD=ST;PERSIST SECURITY INFO=true"
    Dim con As New OracleConnection
    Dim adp As New OracleDataAdapter
    Dim dataset As New DataSet
    Dim cmd As OracleCommand
    Dim constr1$, strsql1$

    Dim adp2 As New OracleDataAdapter
    Dim strsql2 As String
    Dim strsql3 As String
    Dim strsql4 As String
    Dim dataset2 As New DataSet
    Dim scno As String

    Public Sub ModiP(ByVal Sql$)
        cmd = New OracleCommand(Sql, con)
        con.Open()
        cmd.ExecuteNonQuery()
        MsgBox("成功！")
        con.Close()
        dataset.Clear()
    End Sub
    Public Sub DispP()
        Dim constr As String = "USER ID=ST; DATA SOURCE=LOCALHOST:1521/ORCL; PASSWORD=ST;PERSIST SECURITY INFO=true"
        Dim con As New OracleConnection
        con.ConnectionString = constr
        strsql1 = "select *from student"
        adp = New OracleDataAdapter(strsql1, con)
        dataset.Reset()
        adp.Fill(dataset, "学生")
        DataGridView1.DataSource = dataset.Tables("学生")
        strsql2 = "select *from teacher"
        adp2 = New OracleDataAdapter(strsql2, con)
        dataset2.Reset()
        adp2.Fill(dataset2, "教师")
        DataGridView2.DataSource = dataset2.Tables("教师")
    End Sub

    Public Sub DispP2()
        Dim constr As String = "USER ID=ST; DATA SOURCE=LOCALHOST:1521/ORCL; PASSWORD=ST;PERSIST SECURITY INFO=true"
        Dim con As New OracleConnection
        con.ConnectionString = constr
        strsql1 = "select *from stu_view"
        adp = New OracleDataAdapter(strsql1, con)
        dataset.Reset()
        adp.Fill(dataset, "学生")
        DataGridView1.DataSource = dataset.Tables("学生")
        strsql2 = "select *from tea_view"
        adp2 = New OracleDataAdapter(strsql2, con)
        dataset2.Reset()
        adp2.Fill(dataset2, "教师")
        DataGridView2.DataSource = dataset2.Tables("教师")
    End Sub
    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        con.ConnectionString = constr
        Dim sqlstr = "select * from stu_view"
        adp = New OracleDataAdapter(sqlstr, con)
        dataset.Reset()
        adp.Fill(dataset, "学生")
        DataGridView1.DataSource = dataset.Tables("学生")
        DataGridView1.Columns(0).Width = 68
        DataGridView1.Columns(0).HeaderText = "学号"
        DataGridView1.Columns(1).Width = 80
        DataGridView1.Columns(1).HeaderText = "密码"
        DataGridView1.Columns(2).Width = 78
        DataGridView1.Columns(2).HeaderText = "姓名"
        DataGridView1.Columns(3).Width = 70
        DataGridView1.Columns(3).HeaderText = "性别"
        DataGridView1.Columns(4).Width = 78
        DataGridView1.Columns(4).HeaderText = "生日"
        DataGridView1.Columns(5).Width = 55
        DataGridView1.Columns(5).HeaderText = "年龄"
        DataGridView1.Columns(6).Width = 55
        DataGridView1.Columns(6).HeaderText = "学院"
        DataGridView1.Columns(7).Width = 55
        DataGridView1.Columns(7).HeaderText = "专业"
        DataGridView1.Columns(8).Width = 55
        DataGridView1.Columns(8).HeaderText = "宿舍号"

        con.ConnectionString = constr
        Dim sqlstr2 = "select * from tea_view"
        adp = New OracleDataAdapter(sqlstr2, con)
        dataset2.Reset()
        adp.Fill(dataset2, "教师")
        DataGridView2.DataSource = dataset2.Tables("教师")
        DataGridView2.Columns(0).Width = 68
        DataGridView2.Columns(0).HeaderText = "工号"
        DataGridView2.Columns(1).Width = 80
        DataGridView2.Columns(1).HeaderText = "密码"
        DataGridView2.Columns(2).Width = 78
        DataGridView2.Columns(2).HeaderText = "姓名"
        DataGridView2.Columns(3).Width = 60
        DataGridView2.Columns(3).HeaderText = "性别"
        DataGridView2.Columns(4).Width = 78
        DataGridView2.Columns(4).HeaderText = "生日"
        DataGridView2.Columns(5).Width = 55
        DataGridView2.Columns(5).HeaderText = "年龄"
        DataGridView2.Columns(6).Width = 55
        DataGridView2.Columns(6).HeaderText = "学院"
        DataGridView2.Columns(7).Width = 55
        DataGridView2.Columns(7).HeaderText = "专业"
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        管理员登陆页面.Show()
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
        添加学生.Show()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Me.Close()
        添加教师.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim i%
        i = MsgBox("确定要删除此学生:" & DataGridView1.CurrentRow.Cells(2).Value, 1)
        If i = vbOK Then
            strsql3 = "call stu_delete('" & DataGridView1.CurrentRow.Cells(0).Value & "')"
            ModiP(strsql3)
            DispP()
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim i%
        i = MsgBox("确定要删除此教师:" & DataGridView2.CurrentRow.Cells(2).Value, 1)
        If i = vbOK Then
            strsql4 = "call tea_delete('" & DataGridView2.CurrentRow.Cells(0).Value & "')"
            ModiP(strsql4)
            DispP2()
        End If
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        登录页面.Close()
        Me.Close()
    End Sub

    'Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
    '    Dim i%, strsql$
    '    i = MsgBox("确定要删除此学生信息:  学号：" & DataGridView1.CurrentRow.Cells(0).Value & " ?", 1)
    '    If i = vbOK Then
    '        strsql = "Delete  from student where sno='" & DataGridView1.CurrentRow.Cells(0).Value & "'"
    '        ModiP(strsql)
    '        DispP()
    '    End If
    'End Sub

    'Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
    '    Dim i%, strsql$
    '    i = MsgBox("确定要删除此教师信息:  工号：" & DataGridView2.CurrentRow.Cells(0).Value & " ?", 1)
    '    If i = vbOK Then
    '        strsql = "Delete  from teacher where tno='" & DataGridView2.CurrentRow.Cells(0).Value & "'"
    '        ModiP(strsql)
    '        DispP2()
    '        DispP()
    '    End If
    'End Sub


End Class