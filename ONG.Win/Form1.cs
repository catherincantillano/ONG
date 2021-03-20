using ONG.BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ONG.Win
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            var desaparecidosBL = new DesaparecidosBL();
            var listadeDesaparecidos = desaparecidosBL.ObtenerDesaparecidos();

            listadeDesaparecidosBindingSource.DataSource = listadeDesaparecidos;
        }
    }
}
