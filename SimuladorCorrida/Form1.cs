using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimuladorCorrida
{
    public partial class Form1 : Form
    {
        private Apostador[] apostadores { get; set; }
        private Cao[] caes { get; set; }

        public Form1()
        {
            InitializeComponent();

            int tamanhoPista = picPista.Size.Width;

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

            caes = new Cao[4];
            caes[0] = new Cao();
            caes[0].Numero = 1;
            caes[0].TamanhoPista = tamanhoPista;
            caes[0].MinhaPictureBox = pic1;

            caes[1] = new Cao();
            caes[1].Numero = 2;
            caes[1].TamanhoPista = tamanhoPista;
            caes[1].MinhaPictureBox = pic2;

            caes[2] = new Cao();
            caes[2].Numero = 3;
            caes[2].TamanhoPista = tamanhoPista;
            caes[2].MinhaPictureBox = pic3;

            caes[3] = new Cao();
            caes[3].Numero = 4;
            caes[3].TamanhoPista = tamanhoPista;
            caes[3].MinhaPictureBox = pic4;
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
            foreach (Apostador apostador in apostadores)
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

        private void btnCorram_Click(object sender, EventArgs e)
        {
            // Desabilita todos os controles do Form
            this.Enabled = false;

            // Faz os cachorros andarem na pista, até terminarem o
            // circuito e haver um vencedor.
            int vencedor = Correr();

            foreach (Apostador apostador in apostadores)
            {
                // Pagar de acordo com o vencedor
                apostador.Coletar(vencedor);

                // Limpa a aposta realizada
                apostador.LimparAposta();

                // Atualizar os rótulos
                apostador.AtualizarLabels();
            }

            foreach (Cao cao in caes)
            {
                cao.VoltarInicio();
            }

            MessageBox.Show(string.Format("O cão número {0} venceu a corrida!", vencedor), "Fim de corrida", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Habilita todos os controles do Form
            this.Enabled = true;
        }

        private int Correr()
        {
            int vencedor = 0;
            while (vencedor == 0)
            {
                foreach (Cao cao in caes)
                {
                    bool ehVencedor = cao.Correr();

                    if (ehVencedor)
                    {
                        vencedor = cao.Numero;
                    }
                    Thread.Sleep(50);
                }
                Application.DoEvents();
            }

            return vencedor;
        }
    }
}
