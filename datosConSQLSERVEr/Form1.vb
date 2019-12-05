Imports System.Data.SqlClient
Imports System.Data.SqlClient.SqlException
Imports System.Data.DataTableReader
Imports System.Data.Odbc
Public Class Form1
    Dim conexion As String = "Server=localhost\SQLEXPRESS02;Database=master;Initial Catalog=persona;Trusted_Connection=True;"

    Private Sub actualizarTabla()
        Try
            Dim dt As New DataTable

            Dim cn As New SqlConnection
            cn.ConnectionString = conexion
            Using adaptador As New SqlDataAdapter("SELECT codigo, nombre, apellido_paterno, apellido_materno, sexo from persona", conexion)
                adaptador.Fill(dt)
            End Using
            DataGrid.DataSource = dt
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        actualizarTabla()
        MsgBox("Ejecutado correctamente")
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Dim dt As New DataTable
            Dim cn As New SqlConnection
            cn.ConnectionString = conexion
            Using adaptador As New SqlDataAdapter("SELECT codigo, nombre, apellido_paterno, apellido_materno, sexo from persona where codigo='" + txtbuscar.Text() + "'", conexion)
                adaptador.Fill(dt)
            End Using
            DataGrid.DataSource = dt
            MsgBox("Ejecutado correctamente")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try
            Dim cn As New SqlConnection
            cn.ConnectionString = conexion
            Dim adaptador As New SqlCommand("delete from persona where codigo='" + txteliminar.Text() + "';", cn)
            cn.Open()
            adaptador.ExecuteNonQuery()
            MsgBox("Ejecutado correctamente")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Dim auxiliar As String
        auxiliar = " "
        Try
            Dim cn As New SqlConnection
            cn.ConnectionString = conexion
            Dim adaptador1 As New SqlCommand("select nombre from persona where codigo = '" + txtcodigoeditar.Text() + "';", cn)
            cn.Open()
            auxiliar = adaptador1.ExecuteScalar()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        nombre.Text = auxiliar
        Try
            Dim cn As New SqlConnection
            cn.ConnectionString = conexion
            Dim adaptador1 As New SqlCommand("select apellido_paterno from persona where codigo = '" + txtcodigoeditar.Text() + "';", cn)
            cn.Open()
            auxiliar = adaptador1.ExecuteScalar()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        apepa.Text = auxiliar
        Try
            Dim cn As New SqlConnection
            cn.ConnectionString = conexion
            Dim adaptador1 As New SqlCommand("select apellido_materno from persona where codigo = '" + txtcodigoeditar.Text() + "';", cn)
            cn.Open()
            auxiliar = adaptador1.ExecuteScalar()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        apema.Text = auxiliar
        Try
            Dim cn As New SqlConnection
            cn.ConnectionString = conexion
            Dim adaptador1 As New SqlCommand("select sexo from persona where codigo = '" + txtcodigoeditar.Text() + "';", cn)
            cn.Open()
            auxiliar = adaptador1.ExecuteScalar()
            MsgBox("Ejecutado correctamente")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        sexo.Text = auxiliar
    End Sub


    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Try
            Dim cn As New SqlConnection
            cn.ConnectionString = conexion
            Dim adaptador As New SqlCommand("UPDATE persona SET nombre = @nombre ,apellido_paterno = @apepa ,apellido_materno = @apema, sexo= @sexo WHERE codigo =" + txtcodigoeditar.Text, cn)
            adaptador.Parameters.Add("@nombre", SqlDbType.VarChar).Value = nombre.Text()
            adaptador.Parameters.Add("@apepa", SqlDbType.VarChar).Value = apepa.Text()
            adaptador.Parameters.Add("@apema", SqlDbType.VarChar).Value = apema.Text()
            adaptador.Parameters.Add("@sexo", SqlDbType.VarChar).Value = sexo.Text()
            cn.Open()
            adaptador.ExecuteNonQuery()
            MsgBox("Ejecutado correctamente")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Try
            Dim cn As New SqlConnection
            cn.ConnectionString = conexion
            Dim adaptador As New SqlCommand("insert into persona values('" + addcodigo.Text() + "','" + addnombre.Text() + "','" + addapepa.Text() + "','" + addapema.Text() + "','" + addsexo.Text + "')", cn)
            cn.Open()
            adaptador.ExecuteNonQuery()
            MsgBox("Ejecutado correctamente")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class
