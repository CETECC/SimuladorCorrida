using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimuladorCorrida
{
    public class Aposta
    {
        public int Valor { get; set; }
        public int NumCachorro { get; set; }
        public Apostador MeuApostador { get; set; }
        
        public string ObterDescricao() 
        {
            if (Valor == 0)
            {
                return string.Format("{0} não apostou", MeuApostador.Nome);
            }

            return string.Format("{0} apostou {1} no cachorro {2}",
                                 MeuApostador.Nome,
                                 Valor,
                                 NumCachorro);
        }

        public int ObterValorPagamento (int vencedor)
        {
            if (vencedor == NumCachorro)
            {
                return Valor * 2;
            }
            else
            {
                return 0;
            }
        }
    }
}
