Imports System.Data.OleDb
Imports Oracle.ManagedDataAccess.Client

Public Class 教师端课程管理
    Dim con As New OracleConnection
    Dim adp As New OracleDataAdapter
    Dim adp2 As New OracleDataAdapter
    Dim adp3 As New OracleDataAdapter
    Dim cmd As New OracleCommand()
    Dim dr As OracleDataReader
    Dim dataset As New DataSet
    Dim dataset2 As New DataSet
    Dim dataset3 As New DataSet
    Dim constr$, sqlstr$


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim sqlstr2 = "select wcno,wcname,tea_view.tname,wcnum,wctage from allcourse_view ,tea_view where wcname='" & ComboBox1.Text & "' and allcourse_view.wtno=tea_view.tno"
        adp2 = New OracleDataAdapter(sqlstr2, con)
        dataset2.Reset()
        adp2.Fill(dataset2, "课程2")
        DataGridView1.DataSource = dataset2.Tables("课程2")
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

        Dim sqlstr3 = "select sno,sname,ssex,scol,smaj from stu_view2 ,course_view where sno=course_view.csno and course_view.cname='" & ComboBox1.Text & "'"
        adp3 = New OracleDataAdapter(sqlstr3, con)
        dataset3.Reset()
        adp3.Fill(dataset3, "学生")
        DataGridView2.DataSource = dataset3.Tables("学生")
        DataGridView2.Columns(0).Width = 68
        DataGridView2.Columns(0).HeaderText = "学号"
        DataGridView2.Columns(1).Width = 60
        DataGridView2.Columns(1).HeaderText = "姓名"
        DataGridView2.Columns(2).Width = 60
        DataGridView2.Columns(2).HeaderText = "性别"
        DataGridView2.Columns(3).Width = 120
        DataGridView2.Columns(3).HeaderText = "学院"
        DataGridView2.Columns(4).Width = 100
        DataGridView2.Columns(4).HeaderText = "专业"
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        教师端登录页面.Show()
        Me.Close()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Me.Close()
        登录页面.Close()
    End Sub

    Private Sub 教师端课程管理_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        constr = "USER ID=ST; DATA SOURCE=LOCALHOST:1521/ORCL; PASSWORD=ST;PERSIST SECURITY INFO=true"
        con.ConnectionString = constr
        con.Open()
        sqlstr = "select wcname from allcourse_view where wtno='" & 登录页面.TextBox1.Text & "'"
        cmd = New OracleCommand(sqlstr, con)
        dr = cmd.ExecuteReader
        While dr.Read
            ComboBox1.Items.Add(dr("wcname"))
        End While
    End Sub
End Class