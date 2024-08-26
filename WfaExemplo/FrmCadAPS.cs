using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WfaExemplo
{
    public partial class FrmCadAPS : Form
    {
        public FrmCadAPS()
        {
            InitializeComponent();
        }

        private void cmbForma_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbForma.Text)
            {
                case "Quadrado":
                    SelecionarQuadrado();
                    break;
                case "Triangulo":
                    SelecionarTriangulo();
                    break;

                default:
                    break;
            }
        }

        private void SelecionarQuadrado()
        {
            ExibirBase(true);
            ExibirAltura(false);
            lblRaio.Visible = txtRaio.Visible = false;
            cmbTriangulo.Visible = false;
        }

        private void ExibirAltura(bool visivel)
        {
            lblAltura.Visible = txtAltura.Visible = visivel;
        }

        private void ExibirBase(bool visivel)
        {
            lblBase.Visible = txtBase.Visible = visivel;
        }

        private void SelecionarTriangulo()
        {
            cmbTriangulo.Visible = cmbForma.Text.Equals("Triangulo");
            ExibirBase(true);
            ExibirAltura(true);
        }

        private void btnCriar_Click(object sender, EventArgs e)
        {
            switch (cmbForma.Text)
            {
                case "Quadrado":
                    btnQuadrado();
                    break;
                case "Triangulo":
                default:
                    break;
            }

            
            if (cmbForma.Text.Equals("Triangulo"))
            {
                switch (cmbTriangulo.Text)
                {
                    case "Reto":
                        cmbReto();
                        break;
                }
                
            }
        }

        private void cmbReto()
        {
            FormaGeometrica trianguloR = new TR()
            {
                BaseT = Convert.ToDouble(txtBase.Text),
                AlturaT = Convert.ToDouble(txtAltura.Text)
            };
            cmbObjetos.Items.Add(trianguloR);
        }

        private void btnQuadrado()
        {
            if (cmbForma.Text.Equals("Quadrado"))
            {
                FormaGeometrica quadrado = new Quadrado()
                {
                    Base = Convert.ToDouble(txtBase.Text)
                };
                cmbObjetos.Items.Add(quadrado);
            }
        }

        private void cmbObjetos_SelectedIndexChanged(object sender, EventArgs e)
        {
            FormaGeometrica obj = cmbObjetos.SelectedItem as FormaGeometrica;
            txtArea.Text = obj.CalcularArea().ToString();
            txtPerimetro.Text = obj.CalcularPerimetro().ToString();
        }
    }
}
