using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimuladorCorrida
{
    public class Cao
    {
        public int PosicaoInicial { get; set; }
        public int ComprimentoPista { get; set; }
        public PictureBox MinhaPictureBox { get; set; }
        public int Posicao { get; set; }
        public Random MeuRandom { get; set; }
        
        public bool Correr()
        {
            // Mover para frente 1, 2, 3 ou 4 espaços aleatoriamente
            // Atualizar a posição da PictureBox na tela
            // Retorna TRUE se eu ganhei a corrida

            //Point p = MinhaPictureBox.Location;
            //p.X = distance;
            //MinhaPictureBox.Location = p;

            return false;
        }

        public void VoltarInicio()
        {
            Posicao = PosicaoInicial;
        }
    }
}
