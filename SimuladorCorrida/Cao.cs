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
        public int Numero { get; set; }
        public int PosicaoInicial { get; set; }
        public int ComprimentoPista { get; set; }
        public PictureBox MinhaPictureBox { get; set; }
        public int TamanhoPista { get; set; }
        public Random MeuRandom { get; set; }

        public bool Correr()
        {
            // Mover para frente 1, 2, 3 ou 4 espaços aleatoriamente
            // Atualizar a posição da PictureBox na tela
            // Retorna TRUE se eu ganhei a corrida

            Point p = MinhaPictureBox.Location;
            MeuRandom = new Random();

            p.X = p.X + MeuRandom.Next(10);
            MinhaPictureBox.Location = p;

            if (p.X >= (TamanhoPista - this.MinhaPictureBox.Size.Width))
            {
                return true;
            }
            return false;
        }

        public void VoltarInicio()
        {
            Point p = this.MinhaPictureBox.Location;
            p.X = PosicaoInicial;
            this.MinhaPictureBox.Location = p;
        }
    }
}
