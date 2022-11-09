Imports System.Data.OleDb
Imports Oracle.ManagedDataAccess.Client

Public Class 学生端选课
    Dim constr As String = "USER ID=ST; DATA SOURCE=LOCALHOST:1521/ORCL; PASSWORD=ST;PERSIST SECURITY INFO=true"
    Dim con As New OracleConnection
    Dim adp As New OracleDataAdapter
    Dim dataset As New DataSet
    Dim cmd As OracleCommand
    Dim strsql2 As String
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
        strsql1 = "select distinct allcourse_view.wcno,wcname,tea_view.tname,wcnum,wctage from allcourse_view,stu_view,tea_view where sno='" & 登录页面.TextBox1.Text & "' and allcourse_view.wtno=tea_view.tno and allcourse_view.wcno not in (select course_view.cno from course_view  where csno='" & 登录页面.TextBox1.Text & "')"
        adp = New OracleDataAdapter(strsql1, con)
        dataset.Reset()
        adp.Fill(dataset, "课程")
        DataGridView1.DataSource = dataset.Tables("课程")
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        学生端已选课程.Show()
        Me.Close()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        登录页面.Close()
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim i%, strsql$
        i = MsgBox("确定要添加此课程:" & DataGridView1.CurrentRow.Cells(1).Value, 1)
        If i = vbOK Then
            strsql = "call allcourse_insert('" & 登录页面.snostr & "','" & DataGridView1.CurrentRow.Cells(0).Value & "','" & DataGridView1.CurrentRow.Cells(1).Value & "'
                        ,'" & DataGridView1.CurrentRow.Cells(5).Value & "','" & Val(DataGridView1.CurrentRow.Cells(3).Value) & "'
                        ,'" & DataGridView1.CurrentRow.Cells(4).Value & "','')"
            ModiP(strsql)
            DispP()
            'strsql = "call allcoursetno_update('" & DataGridView1.CurrentRow.Cells(2).Value & "')"
            'con.Open()
            'cmd.ExecuteNonQuery()
            con.Close()
        End If
    End Sub

    Private Sub 学生端选课_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        con.ConnectionString = constr
        Dim sqlstr = "select distinct allcourse_view.wcno,wcname,tea_view.tname,wcnum,wctage,wtno from allcourse_view,stu_view,tea_view where sno='" & 登录页面.TextBox1.Text & "' and allcourse_view.wtno=tea_view.tno and allcourse_view.wcno not in (select course_view.cno from course_view where csno='" & 登录页面.TextBox1.Text & "')"
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
        DataGridView1.Columns(5).Visible = False
    End Sub
End Class