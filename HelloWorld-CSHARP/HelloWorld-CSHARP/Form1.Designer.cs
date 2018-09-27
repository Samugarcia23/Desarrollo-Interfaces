namespace HelloWorld_CSHARP
{
	partial class Form1
	{
		/// <summary>
		/// Variable del diseñador necesaria.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Limpiar los recursos que se estén usando.
		/// </summary>
		/// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Código generado por el Diseñador de Windows Forms

		/// <summary>
		/// Método necesario para admitir el Diseñador. No se puede modificar
		/// el contenido de este método con el editor de código.
		/// </summary>
		private void InitializeComponent()
		{
			this.bsaludar = new System.Windows.Forms.Button();
			this.lb1 = new System.Windows.Forms.Label();
			this.tbsaludo = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// bsaludar
			// 
			this.bsaludar.Location = new System.Drawing.Point(357, 196);
			this.bsaludar.Name = "bsaludar";
			this.bsaludar.Size = new System.Drawing.Size(59, 23);
			this.bsaludar.TabIndex = 0;
			this.bsaludar.Text = "Pulsame";
			this.bsaludar.UseVisualStyleBackColor = true;
			this.bsaludar.Click += new System.EventHandler(this.bsaludar_Click);
			// 
			// lb1
			// 
			this.lb1.AutoSize = true;
			this.lb1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lb1.Location = new System.Drawing.Point(275, 84);
			this.lb1.Name = "lb1";
			this.lb1.Size = new System.Drawing.Size(250, 25);
			this.lb1.TabIndex = 1;
			this.lb1.Text = "Mi primer Hola Mundo!";
			this.lb1.Click += new System.EventHandler(this.label1_Click);
			// 
			// tbsaludo
			// 
			this.tbsaludo.Location = new System.Drawing.Point(337, 143);
			this.tbsaludo.Name = "tbsaludo";
			this.tbsaludo.Size = new System.Drawing.Size(100, 20);
			this.tbsaludo.TabIndex = 2;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.tbsaludo);
			this.Controls.Add(this.lb1);
			this.Controls.Add(this.bsaludar);
			this.Name = "Form1";
			this.Text = "Hola Mundo";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button bsaludar;
		private System.Windows.Forms.Label lb1;
		private System.Windows.Forms.TextBox tbsaludo;
	}
}

