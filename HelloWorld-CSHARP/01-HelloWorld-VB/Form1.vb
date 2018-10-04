Imports HelloWorld_CSHARP
Public Class Form1
	Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
		Dim oPersona As New clsPersona
		oPersona = New clsPersona
		oPersona.nombre = "Sam"
		oPersona.apellido = "Garcia"
		MessageBox.Show($"Soy {oPersona.nombre} {oPersona.apellido}")
	End Sub

	Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

	End Sub
End Class
