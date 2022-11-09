Imports System.Data.OleDb
Imports Oracle.ManagedDataAccess.Client

Public Class 教师端登录页面
    Dim con As New OracleConnection
    Dim adp As New OracleDataAdapter
    Dim dataset As New DataSet
    Dim constr$, sqlstr$

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        登录页面.Close()
        Me.Close()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        登录页面.Show()
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
        教师端个人信息.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
        教师端学生成绩管理.Show()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Me.Close()
        教师端课程管理.Show()
    End Sub

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        constr = "USER ID=ST; DATA SOURCE=LOCALHOST:1521/ORCL; PASSWORD=ST;PERSIST SECURITY INFO=true"
        con.ConnectionString = constr
        sqlstr = "select * from tea_view"
        Dim cmd As New OracleCommand(sqlstr, con)
        adp.SelectCommand = cmd
        dataset.Reset()
        adp.Fill(dataset, "教师端")
        Label3.Text = 登录页面.teaname
    End Sub
End Class