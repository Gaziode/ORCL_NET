Imports System.Data.OleDb
Imports Oracle.ManagedDataAccess.Client

Public Class 管理员端课程信息管理
    Dim constr As String = "USER ID=ST; DATA SOURCE=LOCALHOST:1521/ORCL; PASSWORD=ST;PERSIST SECURITY INFO=true"
    Dim con As New OracleConnection
    Dim adp As New OracleDataAdapter
    Dim dataset As New DataSet
    Dim cmd As OracleCommand
    Dim strsql2 As String
    Dim strsql4 As String
    Dim constr1$, strsql1$
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
        strsql1 = "select wcno,wcname,tea_view.tname,wcnum,wctage from allcourse_view,tea_view where allcourse_view.wtno=tea_view.tno"
        adp = New OracleDataAdapter(strsql1, con)
        dataset.Reset()
        adp.Fill(dataset, "课程")
        DataGridView1.DataSource = dataset.Tables("课程")
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        管理员登陆页面.Show()
        Me.Close()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        登录页面.Close()
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
        添加课程.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim i%
        i = MsgBox("确定要删除此课程:" & DataGridView1.CurrentRow.Cells(1).Value, 1)
        If i = vbOK Then
            strsql4 = "call allcourse_delete('" & DataGridView1.CurrentRow.Cells(0).Value & "')"
            ModiP(strsql4)
            DispP()
        End If
    End Sub

    Private Sub 管理员端课程信息管理_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        con.ConnectionString = constr
        Dim sqlstr = "select wcno,wcname,tea_view.tname,wcnum,wctage from allcourse_view,tea_view where allcourse_view.wtno=tea_view.tno"
        adp = New OracleDataAdapter(sqlstr, con)
        dataset.Reset()
        adp.Fill(dataset, "课程")
        DataGridView1.DataSource = dataset.Tables("课程")
        DataGridView1.Columns(0).Width = 68
        DataGridView1.Columns(0).HeaderText = "课程号"
        DataGridView1.Columns(1).Width = 155
        DataGridView1.Columns(1).HeaderText = "课程名"
        DataGridView1.Columns(2).Width = 78
        DataGridView1.Columns(2).HeaderText = "任课教师"
        DataGridView1.Columns(3).Width = 60
        DataGridView1.Columns(3).HeaderText = "学分"
        DataGridView1.Columns(4).Width = 78
        DataGridView1.Columns(4).HeaderText = "课程状态"
    End Sub
End Class