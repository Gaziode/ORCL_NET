﻿Imports System.Data.OleDb
Imports Oracle.ManagedDataAccess.Client

Public Class 添加课程
    Dim constr As String = "USER ID=ST; DATA SOURCE=LOCALHOST:1521/ORCL; PASSWORD=ST;PERSIST SECURITY INFO=true"
    Dim con As New OracleConnection
    Dim adp As New OracleDataAdapter
    Dim dataset As New DataSet
    Dim cmd As OracleCommand
    Dim constr1$, strsql$

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        con.ConnectionString = constr
        strsql = "call newcourse_insert('" & TextBox3.Text & "',
        '" & TextBox4.Text & "','" & TextBox5.Text & "','" & Val(TextBox6.Text) & "',
        '" & TextBox7.Text & "')"
        Dim cmd = New OracleCommand(strsql, con)
        con.Open()
        cmd.ExecuteNonQuery()
        MsgBox("成功添加！")
        con.Close()
        管理员端课程信息管理.DispP()
        Me.Close()
        管理员端课程信息管理.Show()
    End Sub

    Private Sub 添加课程_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
        管理员端课程信息管理.Show()
    End Sub

End Class