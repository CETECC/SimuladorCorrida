using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimuladorCorrida
{
    public partial class Form1 : Form
    {
        private Apostador[] apostadores { get; set; }
        private Cao[] cachorros { get; set; }

        public Form1()
        {
            InitializeComponent();
            apostadores = new Apostador[3];
            apostadores[0] = new Apostador();
            apostadores[0].Nome = "João";
            apostadores[0].Dinheiro = 50;
            apostadores[0].MeuLabel = lblApostaJoao;
            apostadores[0].MeuRadioButton = rbtJoao;

            apostadores[1] = new Apostador();
            apostadores[1].Nome = "Beto";
            apostadores[1].Dinheiro = 75;
            apostadores[1].MeuLabel = lblApostaBeto;
            apostadores[1].MeuRadioButton = rbtBeto;

            apostadores[2] = new Apostador();
            apostadores[2].Nome = "Alfredo";
            apostadores[2].Dinheiro = 45;
            apostadores[2].MeuLabel = lblApostaAlfredo;
            apostadores[2].MeuRadioButton = rbtAlfredo;

            cachorros = new Cao[4];
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (Apostador apostador in apostadores)
            {
                apostador.AtualizarLabels();
            }

            lblApostaMinima.Text = ((int)numValor.Minimum).ToString();
        }

        private void rbt_CheckedChanged(object sender, EventArgs e)
        {
            foreach (Apostador apostador in apostadores)
            {
                if ((RadioButton)sender == apostador.MeuRadioButton)
                {
                    lblApostaNome.Text = apostador.Nome;
                    break;
                }
            }
        }

        private void btnAposta_Click(object sender, EventArgs e)
        {
            foreach(Apostador apostador in apostadores)
            {
                if (apostador.Nome == lblApostaNome.Text)
                {
                    if (apostador.NovaAposta((int)numValor.Value, (int)numCachorro.Value))
                    {
                        apostador.AtualizarLabels();
                    }
                    else
                    {
                        MessageBox.Show("Não há saldo suficiente para esta aposta!", "Seu trouxa!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
        }
    }
}
