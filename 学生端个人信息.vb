Imports System.Data.OleDb
Imports Oracle.ManagedDataAccess.Client

Public Class 学生端个人信息
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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TextBox2.Enabled = True
        TextBox3.Enabled = True
        TextBox4.Enabled = True
        TextBox5.Enabled = True
        TextBox6.Enabled = True
        TextBox7.Enabled = True
        TextBox8.Enabled = True
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        学生端登陆页面.Show()
        Me.Close()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        登录页面.Close()
        Me.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        sqlstr = "call stu_update('" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "'," & Val(TextBox5.Text) & ",'" & TextBox6.Text & "','" & TextBox7.Text & "','" & TextBox8.Text & "','" & TextBox1.Text & "')"
        ModiP(sqlstr)
        Dim i As Integer
        For i = 0 To dataset.Tables("学生端").Rows.Count - 1 Step 1
            If (登录页面.snostr = dataset.Tables("学生端").Rows(i).Item(0)) Then
                TextBox1.Text = dataset.Tables("学生端").Rows(i).Item(0)
                TextBox2.Text = dataset.Tables("学生端").Rows(i).Item(2)
                TextBox3.Text = dataset.Tables("学生端").Rows(i).Item(3)
                TextBox4.Text = dataset.Tables("学生端").Rows(i).Item(4)
                TextBox5.Text = dataset.Tables("学生端").Rows(i).Item(5)
                TextBox6.Text = dataset.Tables("学生端").Rows(i).Item(6)
                TextBox7.Text = dataset.Tables("学生端").Rows(i).Item(7)
                TextBox8.Text = dataset.Tables("学生端").Rows(i).Item(8)
            End If
        Next
        TextBox1.Enabled = False
        TextBox2.Enabled = False
        TextBox3.Enabled = False
        TextBox4.Enabled = False
        TextBox5.Enabled = False
        TextBox6.Enabled = False
        TextBox7.Enabled = False
        TextBox8.Enabled = False
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        学生端修改密码.Show()
    End Sub

    Private Sub Form5_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
                TextBox1.Text = dataset.Tables("学生端").Rows(i).Item(0)
                TextBox2.Text = dataset.Tables("学生端").Rows(i).Item(2)
                TextBox3.Text = dataset.Tables("学生端").Rows(i).Item(3)
                TextBox4.Text = dataset.Tables("学生端").Rows(i).Item(4)
                TextBox5.Text = dataset.Tables("学生端").Rows(i).Item(5)
                TextBox6.Text = dataset.Tables("学生端").Rows(i).Item(6)
                TextBox7.Text = dataset.Tables("学生端").Rows(i).Item(7)
                TextBox8.Text = dataset.Tables("学生端").Rows(i).Item(8)
            End If
        Next
        TextBox1.Enabled = False
        TextBox2.Enabled = False
        TextBox3.Enabled = False
        TextBox4.Enabled = False
        TextBox5.Enabled = False
        TextBox6.Enabled = False
        TextBox7.Enabled = False
        TextBox8.Enabled = False
    End Sub
End Class