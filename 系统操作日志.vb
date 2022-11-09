Imports System.Data.OleDb
Imports Oracle.ManagedDataAccess.Client

Public Class 系统操作日志
    Dim constr As String = "USER ID=ST; DATA SOURCE=LOCALHOST:1521/ORCL; PASSWORD=ST;PERSIST SECURITY INFO=true"
    Dim con As New OracleConnection
    Dim adp As New OracleDataAdapter
    Dim dataset As New DataSet
    Dim cmd As OracleCommand
    Dim strsql2 As String
    Dim strsql4 As String
    Dim constr1$, strsql1$

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Me.Close()
        管理员登陆页面.Show()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Me.Close()
        登录页面.Close()
    End Sub

    Private Sub 系统操作日志_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        con.ConnectionString = constr
        Dim sqlstr = "select * from course_log"
        adp = New OracleDataAdapter(sqlstr, con)
        dataset.Reset()
        adp.Fill(dataset, "日志")
        DataGridView1.DataSource = dataset.Tables("日志")
        DataGridView1.Columns(0).Width = 100
        DataGridView1.Columns(0).HeaderText = "操作名称"
        DataGridView1.Columns(1).Width = 100
        DataGridView1.Columns(1).HeaderText = "操作时间"
    End Sub
End Class