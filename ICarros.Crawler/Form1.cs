using ICarros.Crawler.Robo;
using ICarros.Persistencia.DataContext;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ICarros.Crawler
{
    public partial class Form1 : Form
    {
        public Contexto db { get; set; }
        public Form1()
        {
            InitializeComponent();

            db = new Contexto();
            //db.CriarBase();
            //db.DropBase();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var servico = new ServicoICarros();

            var carros = servico.ExtrairDadosCarros();

            Cadastrar(carros);
        }

        private void Cadastrar(List<Persistencia.Model.Carro> carros)
        {
            foreach (var item in carros)
            {
                db.Carros.Add(item);
            }

            db.SaveChanges();
        }
    }
}
