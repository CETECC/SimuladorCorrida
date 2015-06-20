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
        private CaoCinza[] cachorros { get; set; }

        public Form1()
        {
            InitializeComponent();
            apostadores = new Apostador[3];
            apostadores[0] = new Apostador();
            apostadores[0].Nome = "João";
            apostadores[0].Dinheiro = 50;

            apostadores[1] = new Apostador();
            apostadores[1].Nome = "Beto";
            apostadores[1].Dinheiro = 75;

            apostadores[2] = new Apostador();
            apostadores[2].Nome = "Alfredo";
            apostadores[2].Dinheiro = 45;

            cachorros = new CaoCinza[4];
        }
    }
}
