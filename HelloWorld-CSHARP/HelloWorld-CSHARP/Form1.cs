using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HelloWorld_CSHARP
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}

		private void label1_Click(object sender, EventArgs e)
		{

		}

		private void bsaludar_Click(object sender, EventArgs e)
		{
			string nombre;
			nombre = this.tbsaludo.Text; //No llamar a Fernando hast hacer un breakpoint
			MessageBox.Show("Hola " + nombre);
			//Tambien vale--> MessageBox.show($"Hola {nombre}");

			/*En VBasic Para declarar:
				Dim nombre As String
				nombre = Me.TextBox1.Text
				MessageBox.Show("Hola " + nombre)
			 */

			/*clsPersona oPersona = new clsPersona;
			oPersona.nombre = "SaM";
			oPersona.apellido = "Garcia";
			MessageBox.Show($"Soy el objeto {oPersona.nombre} {oPersona.apellido}");*/
		}
	}
}
