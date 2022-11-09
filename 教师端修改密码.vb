Imports System.Data.OleDb
Imports Oracle.ManagedDataAccess.Client

Public Class 教师端修改密码
    Dim con As New OracleConnection
    Dim adp As New OracleDataAdapter
    Dim cmd As New OracleCommand()
    Dim dataset As New DataSet
    Dim constr$, sqlstr$
    Public Sub ModiP(ByVal Sql$)
        cmd = New OracleCommand(Sql, con)
        con.Open()
        cmd.ExecuteNonQuery()
        MsgBox("成功！")
        con.Close()
        dataset.Clear()
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
        教师端个人信息.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
        登录页面.Close()
    End Sub

    Private Sub Form10_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        constr = "USER ID=ST; DATA SOURCE=LOCALHOST:1521/ORCL; PASSWORD=ST;PERSIST SECURITY INFO=true"
        con.ConnectionString = constr
        sqlstr = "select * from tea_view"
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text <> 登录页面.passstr2 Then
            MsgBox("旧密码输入错误，请重新输入！")
            TextBox1.Text = ""
        Else
            If TextBox2.Text <> TextBox3.Text Then
                MsgBox("两次密码输入不一致，请重新输入！")
                TextBox2.Text = ""
                TextBox3.Text = ""
            Else
                sqlstr = "UPDATE teacher set tpwd= '" & TextBox2.Text & "'where tno='" & 登录页面.TextBox1.Text & "'"
                ModiP(sqlstr)
                con.Close()
                TextBox1.Text = ""
                TextBox2.Text = ""
                TextBox3.Text = ""
                MsgBox("用户已过期，请重新登录！")
                Me.Close()
                登录页面.Show()
                登录页面.Form1_Load(Nothing, Nothing)
            End If
        End If
    End Sub
End Class