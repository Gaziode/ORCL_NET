Imports System.Data.OleDb
Imports Oracle.ManagedDataAccess.Client

Public Class 教师端个人信息
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
    Private Sub 教师端个人信息_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        constr = "USER ID=ST; DATA SOURCE=LOCALHOST:1521/ORCL; PASSWORD=ST;PERSIST SECURITY INFO=true"
        con.ConnectionString = constr
        sqlstr = "select * from tea_view"
        Dim cmd As New OracleCommand(sqlstr, con)
        adp.SelectCommand = cmd
        dataset.Reset()
        adp.Fill(dataset, "教师端")
        Dim i As Integer
        For i = 0 To dataset.Tables("教师端").Rows.Count - 1 Step 1
            If (登录页面.tnostr = dataset.Tables("教师端").Rows(i).Item(0)) Then
                IDbx.Text = dataset.Tables("教师端").Rows(i).Item(0)
                NMbx.Text = dataset.Tables("教师端").Rows(i).Item(2)
                GDbx.Text = dataset.Tables("教师端").Rows(i).Item(3)
                BRbx.Text = dataset.Tables("教师端").Rows(i).Item(4)
                AGbx.Text = dataset.Tables("教师端").Rows(i).Item(5)
                CObx.Text = dataset.Tables("教师端").Rows(i).Item(6)
                MJbx.Text = dataset.Tables("教师端").Rows(i).Item(7)
            End If
        Next
        IDbx.Enabled = False
        NMbx.Enabled = False
        GDbx.Enabled = False
        BRbx.Enabled = False
        AGbx.Enabled = False
        CObx.Enabled = False
        MJbx.Enabled = False
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        con.Close()
        Dim STcmd As New Oracle.ManagedDataAccess.Client.OracleCommand("ST.tea_update", con)
        STcmd.CommandType = CommandType.StoredProcedure
        Try
            Dim paras(6) As Oracle.ManagedDataAccess.Client.OracleParameter
            paras(0) = New OracleParameter("var_tno", OracleDbType.Varchar2, IDbx.Text, ParameterDirection.Input)
            paras(1) = New OracleParameter("var_tname", OracleDbType.Varchar2, NMbx.Text, ParameterDirection.Input)
            paras(2) = New OracleParameter("var_tsex", OracleDbType.Varchar2, GDbx.Text, ParameterDirection.Input)
            paras(3) = New OracleParameter("var_tbir", OracleDbType.Varchar2, BRbx.Text, ParameterDirection.Input)
            paras(4) = New OracleParameter("num_tage", OracleDbType.Int32, ParameterDirection.Input)
            paras(4).Value = Val(AGbx.Text)
            paras(5) = New OracleParameter("var_tcol", OracleDbType.Varchar2, CObx.Text, ParameterDirection.Input)
            paras(6) = New OracleParameter("var_tmaj", OracleDbType.Varchar2, MJbx.Text, ParameterDirection.Input)
            STcmd.Parameters.Add(paras(0))
            STcmd.Parameters.Add(paras(1))
            STcmd.Parameters.Add(paras(2))
            STcmd.Parameters.Add(paras(3))
            STcmd.Parameters.Add(paras(4))
            STcmd.Parameters.Add(paras(5))
            STcmd.Parameters.Add(paras(6))
            con.Open()
            STcmd.ExecuteNonQuery()
            MsgBox("成功!")
        Catch ex As Exception
            MsgBox("信息输入有误，请重试")
        Finally
            con.Close()
            STcmd.Dispose()
            IDbx.Enabled = False
            NMbx.Enabled = False
            GDbx.Enabled = False
            AGbx.Enabled = False
            BRbx.Enabled = False
            CObx.Enabled = False
            MJbx.Enabled = False
        End Try




        'sqlstr = "call tea_update('" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "'," & Val(TextBox5.Text) & ",'" & TextBox6.Text & "','" & TextBox7.Text & "','" & TextBox1.Text & "')"
        'ModiP(sqlstr)
        'Dim i As Integer
        'For i = 0 To dataset.Tables("教师端").Rows.Count - 1 Step 1
        '    If (登录页面.snostr = dataset.Tables("教师端").Rows(i).Item(0)) Then
        '        TextBox1.Text = dataset.Tables("教师端").Rows(i).Item(0)
        '        TextBox2.Text = dataset.Tables("教师端").Rows(i).Item(2)
        '        TextBox3.Text = dataset.Tables("教师端").Rows(i).Item(3)
        '        TextBox4.Text = dataset.Tables("教师端").Rows(i).Item(4)
        '        TextBox5.Text = dataset.Tables("教师端").Rows(i).Item(5)
        '        TextBox6.Text = dataset.Tables("教师端").Rows(i).Item(6)
        '        TextBox7.Text = dataset.Tables("教师端").Rows(i).Item(7)
        '    End If
        'Next

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        教师端登录页面.Show()
        Me.Close()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        登录页面.Close()
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        教师端修改密码.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        NMbx.Enabled = True
        GDbx.Enabled = True
        BRbx.Enabled = True
        AGbx.Enabled = True
        CObx.Enabled = True
        MJbx.Enabled = True
    End Sub
End Class