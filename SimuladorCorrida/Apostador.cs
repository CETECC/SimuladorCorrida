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

        public Apostador()
        {
            MinhaAposta = null;
            AtualizarLabels();
        }

        public void AtualizarLabels()
        {
            //TODO: Atribua ao meu Label a descrição da minha aposta, e ao Label do 
            // meu RadioButton o meu dinheiro (Ex.: "João tem 45 reais")
        }

        public void LimparAposta()
        {
            MinhaAposta.Valor = 0;
        }

        public bool NovaAposta(int valor, int numCachorro)
        {
            //TODO: Crie uma nova aposta e armazene no meu campo MinhaAposta

            return false;
        }

        public void Coletar(int vencedor)
        {
            //TODO: Cobre minha aposta se eu ganhei
        }
    }
}
