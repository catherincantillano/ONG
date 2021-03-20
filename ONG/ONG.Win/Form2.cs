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
    public partial class Form2 : Form

    {
        ReportePorBeneficioBL _reportePorBeneficioBL;

        public Form2()
        {

            InitializeComponent();
            _reportePorBeneficioBL = new ReportePorBeneficioBL();
            RefrescarDatos();
        }

        private void listaPorBeneficioDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            RefrescarDatos();

        }
        private void RefrescarDatos()
        {
            var listaPorBeneficio = _reportePorBeneficioBL.ObtenerBeneficio();
            listaPorBeneficioBindingSource.DataSource = listaPorBeneficio;
            listaPorBeneficioBindingSource.ResetBindings(false);
        }
    
    }
}
