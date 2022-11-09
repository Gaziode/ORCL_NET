Imports System.Data.OleDb
Imports Oracle.ManagedDataAccess.Client

Public Class 教师端学生成绩管理
    Dim con As New OracleConnection
    Dim adp As New OracleDataAdapter
    Dim adp2 As New OracleDataAdapter
    Dim adp3 As New OracleDataAdapter
    Dim cmd As New OracleCommand()
    Dim cmd2 As New OracleCommand()
    Dim dr As OracleDataReader
    Dim dataset As New DataSet
    Dim dataset2 As New DataSet
    Dim constr$, sqlstr$
    Dim constr1$, strsql1$
    Dim sqlstr2 As String

    'Public Sub ModiP(ByVal Sql$)
    '    cmd = New OracleCommand(Sql, con)
    '    con.Open()
    '    cmd.ExecuteNonQuery()
    '    MsgBox("成功！")
    '    con.Close()
    '    dataset.Clear()
    'End Sub
    'Public Sub DispP()
    '    'strsql1 = "select *from sc where 学号='" & scno & "'"
    '    'adp = New OracleDataAdapter(strsql1, con)
    '    'dataset.Reset()
    '    'adp.Fill(dataset, "成绩")
    '    'DataGridView1.DataSource = dataset.Tables("成绩")
    'End Sub
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        教师端登录页面.Show()
        Me.Close()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Me.Close()
        登录页面.Close()
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Dim i As Integer
        For i = 0 To DataGridView1.RowCount - 1
            sqlstr2 = "call course_update('" & DataGridView1.Item(0, i).Value & "',
                                          '" & DataGridView1.Item(2, i).Value & "',
                                          '" & DataGridView1.Item(3, i).Value & "',
                                          '" & Val(DataGridView1.Item(4, i).Value) & "',
                                          '" & DataGridView1.Item(5, i).Value & "',
                                          '" & DataGridView1.Item(6, i).Value & "')"
            cmd = New OracleCommand(sqlstr2, con)
            con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Next
        MsgBox("成功！")
    End Sub

    Private Sub Form11_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        constr = "USER ID=ST; DATA SOURCE=LOCALHOST:1521/ORCL; PASSWORD=ST;PERSIST SECURITY INFO=true"
        con.ConnectionString = constr
        con.Open()
        sqlstr = "select wcname from allcourse_view where wtno='" & 登录页面.TextBox1.Text & "'"
        cmd = New OracleCommand(sqlstr, con)
        dr = cmd.ExecuteReader
        While dr.Read
            ComboBox1.Items.Add(dr("wcname"))
        End While
        con.Close()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Dim sqlstr2 = "select csno,stu_view.sname,cno,cname,cnum,ctage,score from course_view ,stu_view where cname='" & ComboBox1.Text & "' and course_view.csno=stu_view.sno"
        adp2 = New OracleDataAdapter(sqlstr2, con)
        dataset2.Reset()
        adp2.Fill(dataset2, "课程2")
        DataGridView1.DataSource = dataset2.Tables("课程2")
        DataGridView1.Columns(0).Width = 68
        DataGridView1.Columns(0).HeaderText = "学号"
        DataGridView1.Columns(1).Width = 60
        DataGridView1.Columns(1).HeaderText = "姓名"
        DataGridView1.Columns(2).Width = 80
        DataGridView1.Columns(2).HeaderText = "课程号"
        DataGridView1.Columns(3).Width = 120
        DataGridView1.Columns(3).HeaderText = "课程名"
        DataGridView1.Columns(4).Width = 60
        DataGridView1.Columns(4).HeaderText = "学分"
        DataGridView1.Columns(5).Width = 80
        DataGridView1.Columns(5).HeaderText = "课程状态"
        DataGridView1.Columns(6).Width = 60
        DataGridView1.Columns(6).HeaderText = "成绩"
    End Sub
End Class