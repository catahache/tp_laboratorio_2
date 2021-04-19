using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Entidades;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
        }

        public void Limpiar()
        {
            //borrará los datos de los TextBox, ComboBox y Label de la pantalla.
            txtBNum1.Text = string.Empty;
            txtBNum2.Text= string.Empty;
            cmbBOperador.Text= string.Empty;
            lblResultado.Text = string.Empty;
        }

        static double Operar(string numero1, string numero2, string operador)
        {
            //llamar al método Operar de Calculadora y retornar el resultado al método de evento del botón btnOperar que reflejará el resultado en el Label txtResultado.
            Numero num1 = new Numero(numero1);
            Numero num2 = new Numero(numero2);
            return Calculadora.Operar(num1, num2, operador);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
            btnConvertirABinario.Enabled = true; // habilito el btn
            btnConvertirADecimal.Enabled = true; // habilito el btn
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            btnConvertirABinario.Enabled = true; // habilito el btn
            btnConvertirADecimal.Enabled = true; // habilito el btn
            if(txtBNum1.Text != string.Empty && txtBNum2.Text != string.Empty)
            {
                lblResultado.Text = Operar(txtBNum1.Text, txtBNum2.Text, cmbBOperador.Text).ToString();
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            //convertirá el resultado, de existir, a binario.
            if (lblResultado.Text != string.Empty)
            {
                Numero num = new Numero();
                lblResultado.Text = num.DecimalBinario(lblResultado.Text);
                btnConvertirABinario.Enabled = false; // deshabilito el btn
                btnConvertirADecimal.Enabled = true; // habilito el btn
            }
        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            if (lblResultado.Text != string.Empty)
            {
                Numero num = new Numero();
                lblResultado.Text = num.BinarioDecimal(lblResultado.Text);
                btnConvertirABinario.Enabled = true; // habilito el btn
                btnConvertirADecimal.Enabled = false; // deshabilido el btn
            }
        }
    }
}
