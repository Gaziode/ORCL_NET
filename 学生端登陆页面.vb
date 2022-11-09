Imports System.Data.OleDb
Imports Oracle.ManagedDataAccess.Client

Public Class 学生端登陆页面
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
        学生端个人信息.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
        学生端已选课程.Show()
    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        constr = "USER ID=ST; DATA SOURCE=LOCALHOST:1521/ORCL; PASSWORD=ST;PERSIST SECURITY INFO=true"
        con.ConnectionString = constr
        sqlstr = "select * from stu_view"
        Dim cmd As New OracleCommand(sqlstr, con)
        adp.SelectCommand = cmd
        dataset.Reset()
        adp.Fill(dataset, "学生端")
        Dim i As Integer
        For i = 0 To dataset.Tables("学生端").Rows.Count - 1 Step 1
            If (登录页面.snostr = dataset.Tables("学生端").Rows(i).Item(0)) Then
                Label3.Text = dataset.Tables("学生端").Rows(i).Item(2)
            End If
        Next
    End Sub

End Class