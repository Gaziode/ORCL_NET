Imports System.Data.OleDb
Imports Oracle.ManagedDataAccess.Client

Public Class 添加学生
    Dim constr As String = "USER ID=ST; DATA SOURCE=LOCALHOST:1521/ORCL; PASSWORD=ST;PERSIST SECURITY INFO=true"
    Dim con As New OracleConnection
    Dim adp As New OracleDataAdapter
    Dim dataset As New DataSet
    Dim cmd As OracleCommand
    Dim constr1$, strsql$

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        con.ConnectionString = constr
        strsql = "insert into student values(stuno_seq.nextval,'123456','" & TextBox3.Text & "',
        '" & TextBox4.Text & "','" & TextBox5.Text & "','" & Val(TextBox6.Text) & "',
        '" & TextBox7.Text & "','" & TextBox8.Text & "','" & TextBox9.Text & "')"
        Dim cmd = New OracleCommand(strsql, con)
        con.Open()
        cmd.ExecuteNonQuery()
        MsgBox("成功添加！")
        con.Close()
        管理员端系统用户管理.DispP()
        Me.Close()
        管理员端系统用户管理.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
        管理员端系统用户管理.Show()
    End Sub

    Private Sub 添加学生_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'con.ConnectionString = constr
        'Dim sqlstr = "select * from stu_view"
        'adp = New OracleDataAdapter(sqlstr, con)
        'dataset.Reset()
        'adp.Fill(dataset, "学生")
    End Sub
End Class