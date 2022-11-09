Imports System.Data.OleDb
Imports Oracle.ManagedDataAccess.Client

Public Class 登录页面
    Dim con As New OracleConnection
    Dim adp As New OracleDataAdapter
    Dim adp2 As New OracleDataAdapter
    Dim adp3 As New OracleDataAdapter
    Dim dataset As New DataSet
    Dim dataset2 As New DataSet
    Dim dataset3 As New DataSet
    Dim constr$, sqlstr$
    Dim sqlstr2$
    Dim sqlstr3$
    Public snostr As String
    Public tnostr As String
    Public teaname As String
    Public passstr As String
    Public passstr2 As String
    Public Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        con.Close()
        constr = "USER ID=ST; DATA SOURCE=LOCALHOST:1521/ORCL; PASSWORD=ST;PERSIST SECURITY INFO=true"
        con.ConnectionString = constr
        con.Open()
        sqlstr = "select * from stu_view"
        Dim cmd As New OracleCommand(sqlstr, con)
        adp.SelectCommand = cmd
        dataset.Reset()
        adp.Fill(dataset, "学生端")
        sqlstr2 = "select * from tea_view"
        Dim cmd2 As New OracleCommand(sqlstr2, con)
        adp2.SelectCommand = cmd2
        dataset2.Reset()
        adp2.Fill(dataset2, "教师端")
        sqlstr3 = "select * from adm_view"
        Dim cmd3 As New OracleCommand(sqlstr3, con)
        adp3.SelectCommand = cmd3
        dataset3.Reset()
        adp3.Fill(dataset3, "管理端")
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        If TextBox2.PasswordChar = "*" Then
            PictureBox1.BackgroundImage = Image.FromFile("显示.png")
            TextBox2.PasswordChar = ""
        Else
            PictureBox1.BackgroundImage = Image.FromFile("隐藏.png")
            TextBox2.PasswordChar = "*"
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim flag As Integer = 0
        Dim flag2 As Integer = 0
        Dim i As Integer
        Dim j As Integer
        If TextBox1.Text = "" Then
            MsgBox("未输入学号，请输入学号！")
        ElseIf TextBox1.Text <> "" Then
            For i = 0 To dataset.Tables("学生端").Rows.Count - 1 Step 1
                If (TextBox1.Text = dataset.Tables("学生端").Rows(i).Item(0)) Then
                    flag = 1
                    snostr = TextBox1.Text
                End If
            Next
            If flag = 0 Then
                MsgBox("不存在此学号，请重新输入！")
                TextBox1.Text = ""
                TextBox2.Text = ""
            ElseIf flag = 1 Then
                If TextBox2.Text = "" Then
                    MsgBox("未输入密码，请输入密码！")
                ElseIf TextBox2.Text <> "" Then
                    For j = 0 To dataset.Tables("学生端").Rows.Count - 1 Step 1
                        If (TextBox2.Text = dataset.Tables("学生端").Rows(j).Item(1)) Then
                            flag2 = 1
                            passstr = TextBox2.Text
                        End If
                    Next
                    If flag2 = 0 Then
                        MsgBox("密码输入错误，请重新输入！")
                        TextBox2.Text = ""
                    ElseIf flag2 = 1 Then
                        学生端登陆页面.Show()
                        Me.Hide()
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim flag As Integer = 0
        Dim flag2 As Integer = 0
        Dim i As Integer
        Dim j As Integer
        If TextBox1.Text = "" Then
            MsgBox("未输入工号，请输入工号！")
        ElseIf TextBox1.Text <> "" Then
            For i = 0 To dataset2.Tables("教师端").Rows.Count - 1 Step 1
                If (TextBox1.Text = dataset2.Tables("教师端").Rows(i).Item(0)) Then
                    flag = 1
                    tnostr = TextBox1.Text
                End If
            Next
            If flag = 0 Then
                MsgBox("不存在此工号，请重新输入！")
                TextBox1.Text = ""
                TextBox2.Text = ""
            ElseIf flag = 1 Then
                If TextBox2.Text = "" Then
                    MsgBox("未输入密码，请输入密码！")
                ElseIf TextBox2.Text <> "" Then
                    For j = 0 To dataset2.Tables("教师端").Rows.Count - 1 Step 1
                        If (TextBox2.Text = dataset2.Tables("教师端").Rows(j).Item(1)) Then
                            flag2 = 1
                            passstr2 = TextBox2.Text
                            teaname = dataset2.Tables("教师端").Rows(j).Item(2)
                        End If
                    Next
                    If flag2 = 0 Then
                        MsgBox("密码输入错误，请重新输入！")
                        TextBox2.Text = ""
                    ElseIf flag2 = 1 Then
                        Me.Hide()
                        教师端登录页面.Show()
                    End If
                End If
            End If
        End If
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim flag As Integer = 0
        Dim flag2 As Integer = 0
        Dim i As Integer
        Dim j As Integer
        If TextBox1.Text = "" Then
            MsgBox("未输入工号，请输入工号！")
        ElseIf TextBox1.Text <> "" Then
            For i = 0 To dataset3.Tables("管理端").Rows.Count - 1 Step 1
                If (TextBox1.Text = dataset3.Tables("管理端").Rows(i).Item(0)) Then
                    flag = 1
                End If
            Next
            If flag = 0 Then
                MsgBox("不存在此工号，请重新输入！")
                TextBox1.Text = ""
                TextBox2.Text = ""
            ElseIf flag = 1 Then
                If TextBox2.Text = "" Then
                    MsgBox("未输入密码，请输入密码！")
                ElseIf TextBox2.Text <> "" Then
                    For j = 0 To dataset3.Tables("管理端").Rows.Count - 1 Step 1
                        If (TextBox2.Text = dataset3.Tables("管理端").Rows(j).Item(1)) Then
                            flag2 = 1
                        End If
                    Next
                    If flag2 = 0 Then
                        MsgBox("密码输入错误，请重新输入！")
                        TextBox2.Text = ""
                    ElseIf flag2 = 1 Then
                        Me.Hide()
                        管理员登陆页面.Show()
                    End If
                End If
            End If
        End If
    End Sub
End Class
