using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BitacoraLeo
{
    public class Funciones
    {
		// ----------------- VALIDACIONES GENERALES -----------------
		public bool CamposVacios(params TextBox[] campos)
		{
			foreach (TextBox campo in campos)
			{
				if (string.IsNullOrWhiteSpace(campo.Text)) return true;
			}
			return false;
		}

		public bool ComboBoxVacios(params ComboBox[] campos)
		{
			foreach (ComboBox campo in campos)
			{
				if (string.IsNullOrWhiteSpace(campo.Text)) return true;
			}
			return false;
		}

		// ----------------- LIMPIEZA DE CAMPOS -----------------
		public void LimpiarCampos(params TextBox[] campos)
		{
			foreach (TextBox campo in campos) campo.Clear();
		}

		public void LimpiarComboBox(params ComboBox[] campos)
		{
			foreach (ComboBox campo in campos) campo.ResetText();
		}

		// ----------------- VALIDACIONES DE ENTRADA -----------------

		// Solo números (Cédula, Teléfono)
		public void SoloNumeros(params TextBox[] campos)
		{
			foreach (TextBox campo in campos)
			{
				campo.KeyPress += (s, e) =>
				{
					if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true;
				};
			}
		}

		// Solo letras (Nombre, Apellido)
		public void SoloLetras(params TextBox[] campos)
		{
			foreach (TextBox campo in campos)
			{
				campo.KeyPress += (s, e) =>
				{
					if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != ' ') e.Handled = true;
				};
			}
		}

		// Una sola letra (Sexo)
		public void UnaSolaLetra(params TextBox[] campos)
		{
			foreach (TextBox campo in campos)
			{
				campo.KeyPress += (s, e) =>
				{
					if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar)) e.Handled = true;
					else if (char.IsLetter(e.KeyChar) && campo.Text.Length >= 1) e.Handled = true;
				};
			}
		}
		public void UnaSolaLetra(params ComboBox[] campos)
		{
			foreach (ComboBox campo in campos)
			{
				campo.KeyPress += (s, e) =>
				{
					if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar)) e.Handled = true;
					else if (char.IsLetter(e.KeyChar) && campo.Text.Length >= 1) e.Handled = true;
				};
			}
		}

		// Solo letras sin límite (opcional)
		public void SoloLetra(params ComboBox[] campos)
		{
			foreach (ComboBox campo in campos)
			{
				campo.KeyPress += (s, e) =>
				{
					if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar)) e.Handled = true;
				};
			}
		}

		// Correo electrónico (solo permite caracteres válidos mientras se escribe)
		public void RestringirCorreoElectronico(params TextBox[] campos)
		{
			foreach (TextBox campo in campos)
			{
				campo.KeyPress += (s, e) =>
				{
					if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar) &&
						e.KeyChar != '@' && e.KeyChar != '.' && e.KeyChar != '_' && e.KeyChar != '-') e.Handled = true;
				};

				campo.Leave += (s, e) =>
				{
					if (string.IsNullOrWhiteSpace(campo.Text)) return; // permite vacío
					if (!Regex.IsMatch(campo.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
					{
						MessageBox.Show("Formato de correo no válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
						campo.Focus();
					}
				};
			}
		}

		// Máximo 8 dígitos
		public void MaximoNumeros(params TextBox[] campos)
		{
			foreach (TextBox campo in campos)
			{
				campo.KeyPress += (s, e) =>
				{
					if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true;
					else if (char.IsDigit(e.KeyChar) && campo.Text.Length >= 8) e.Handled = true;
				};
			}
		}
		// Contraseña: letras, números y algunos símbolos (!,@,#,$,%,&,*,_)
		public void RestringirContraseña(params TextBox[] campos)
		{
			foreach (TextBox campo in campos)
			{
				campo.KeyPress += (sender, e) =>
				{
					// Bloquea cualquier carácter que no sea letra, número, control o símbolos permitidos
					if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar) &&
						e.KeyChar != '!' && e.KeyChar != '@' && e.KeyChar != '#' &&
						e.KeyChar != '$' && e.KeyChar != '%' && e.KeyChar != '&' &&
						e.KeyChar != '*' && e.KeyChar != '_')
					{
						e.Handled = true;
					}
				};
			}
		}

		// Mínimo 8 dígitos (solo valida si hay algo escrito)
		public void MinimoOchoNumeros(params TextBox[] campos)
		{
			foreach (TextBox campo in campos)
			{
				campo.Leave += (s, e) =>
				{
					if (string.IsNullOrWhiteSpace(campo.Text)) return; // permite vacío
					if (campo.Text.Length < 8)
					{
						MessageBox.Show("Debe ingresar al menos 8 números.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
						campo.Focus();
					}
				};
			}
		}
	}
}