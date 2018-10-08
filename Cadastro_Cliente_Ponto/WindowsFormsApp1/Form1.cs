using FastReport;
using Cadastro_Cliente_Ponto.ADO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cadastro_Cliente_Ponto.Models;


namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var report = new Report();
            var dados = new List<Cadastro_Cliente_Ponto.Models.RelatorioPonto>();
            //register the business object
            //report.Load(@"C:\Relatorios\RelacaoDePastel.frx");
            report.RegisterData(dados, "Dados", 10);
            report.GetDataSource("Dados").Enabled = true;
            // design the report
            report.Design();

            // free resources used by report
            report.Dispose();
        }
    }
}
