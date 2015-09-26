using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimuladorCorrida
{
    public class Apostador
    {
        public string Nome { get; set; }
        public Aposta MinhaAposta { get; set; }
        public int Dinheiro { get; set; }
        public RadioButton MeuRadioButton { get; set; }
        public Label MeuLabel { get; set; }

        public void AtualizarLabels()
        {
            //TODO: Atribua ao meu Label a descrição da minha aposta, e ao Label do 
            // meu RadioButton o meu dinheiro (Ex.: "João tem 45 reais")

            if (this.MinhaAposta != null)
            {
                this.MeuLabel.Text = this.MinhaAposta.ObterDescricao();
            }
            else
            {
                this.MeuLabel.Text = string.Format("{0} não fez nenhuma aposta.", this.Nome);
            }
            this.MeuRadioButton.Text = string.Format("{0} tem {1} reais", this.Nome, this.Dinheiro);
        }

        public void LimparAposta()
        {
            if (this.MinhaAposta != null)
                this.MinhaAposta.Valor = 0;
        }

        public bool NovaAposta(int valor, int numCachorro)
        {
            // Crie uma nova aposta e armazene no campo MinhaAposta.
            // Retorne VERDADEIRO se o apostador tem dinheiro para a aposta.
            if (valor > this.Dinheiro)
            {
                return false;
            }

            this.MinhaAposta = new Aposta();
            this.MinhaAposta.MeuApostador = this;
            this.MinhaAposta.NumCachorro = numCachorro;
            this.MinhaAposta.Valor = valor;

            this.Dinheiro = this.Dinheiro - valor;

            return true;
        }

        public void Coletar(int vencedor)
        {
            if (this.MinhaAposta != null)
            {
                // Cobre minha aposta se eu ganhei
                this.Dinheiro = this.Dinheiro + this.MinhaAposta.ObterValorPagamento(vencedor);
            }
        }
    }
}
