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
                case "Retangulo":
                    SelecionarRetangulo();
                    break;
                case "Circunferencia":
                    SelecionarCircunferencia();
                    break;
                default:
                    break;
            }
        }

        private void SelecionarQuadrado()
        {
            ExibirBase(true);
            ExibirAltura(false);
            ExibirRaio(false);
            cmbTriangulo.Visible = false;
            LimparCampos();
        }


        private void SelecionarRetangulo()
        {
            ExibirBase(true);
            ExibirAltura(true);
            ExibirRaio(false);
            cmbTriangulo.Visible = false;
            LimparCampos();
        }
        private void SelecionarCircunferencia()
        {
            ExibirBase(false);
            ExibirAltura(false);
            ExibirRaio(true);
            cmbTriangulo.Visible = false;
            LimparCampos();
        }

        private void ExibirAltura(bool visivel)
        {
            lblAltura.Visible = txtAltura.Visible = visivel;
        }
        private void ExibirRaio(bool visivel)
        {
            lblRaio.Visible = txtRaio.Visible = visivel;
        }

        private void ExibirBase(bool visivel)
        {
            lblBase.Visible = txtBase.Visible = visivel;
        }
        private void LimparCampos()
        {
            txtAltura.Text = "";
            txtBase.Text = "";
            txtRaio.Text = "";
        }

        private void SelecionarTriangulo()
        {
            cmbTriangulo.Visible = cmbForma.Text.Equals("Triangulo");
            ExibirBase(false);
            ExibirAltura(false);
            ExibirRaio(false);
            LimparCampos();
        }

        private void btnCriar_Click(object sender, EventArgs e)
        {
            switch (cmbForma.Text)
            {
                case "Quadrado":
                    btnQuadrado();
                    break;
                case "Triangulo":
                    break;
                case "Retangulo":
                    btnRetangulo();
                    break;
                case "Circunferencia":
                    btnCircunferencia();
                    break;
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
                    case "Isosceles":
                        cmbIso();
                        break;
                    case "Equilatero":
                        cmbEqui();
                        break;
                    default:
                        MessageBox.Show("Selecione o tipo do triângulo!", "Atenção:", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                }
                
            }
        }

        private void cmbIso()
        {
            double baseV = 0, alturaV = 0;
            if (txtBase.Text != ""){baseV = Convert.ToDouble(txtBase.Text);}
            if (txtAltura.Text != "") { alturaV = Convert.ToDouble(txtAltura.Text); }
            FormaGeometrica trianguloI = new TI()
            {
                Base = baseV,
                Altura = alturaV
            };
            cmbObjetos.Items.Add(trianguloI);
        }
        private void cmbEqui()
        {
            double baseV = 0;
            if (txtBase.Text != ""){baseV = Convert.ToDouble(txtBase.Text);}
            FormaGeometrica trianguloE = new TE()
            {
                Base = baseV
            };
            cmbObjetos.Items.Add(trianguloE);
        }
        private void cmbReto()
        {
            double baseV = 0, alturaV = 0;
            if (txtBase.Text != "") { baseV = Convert.ToDouble(txtBase.Text); }
            if (txtAltura.Text != "") { alturaV = Convert.ToDouble(txtAltura.Text); }
            FormaGeometrica trianguloR = new TR()
            {
                BaseT = baseV,
                AlturaT = alturaV
            };
            cmbObjetos.Items.Add(trianguloR);
        }

        private void btnQuadrado()
        {
            if (cmbForma.Text.Equals("Quadrado"))
            {
                double baseV = 0;
                if (txtBase.Text != "") { baseV = Convert.ToDouble(txtBase.Text); }
                FormaGeometrica quadrado = new Quadrado()
                {
                    Base = baseV
                };
                cmbObjetos.Items.Add(quadrado);
            }
        }
        private void btnRetangulo()
        {
            if (cmbForma.Text.Equals("Retangulo"))
            {
                double baseV = 0, alturaV = 0;
                if (txtBase.Text != "") { baseV = Convert.ToDouble(txtBase.Text); }
                if (txtAltura.Text != "") { alturaV = Convert.ToDouble(txtAltura.Text); }
                FormaGeometrica retangulo = new Retangulo()
                {
                    Base = baseV,
                    Altura = alturaV
                };
                cmbObjetos.Items.Add(retangulo);
            }
        }
        private void btnCircunferencia()
        {
            if (cmbForma.Text.Equals("Circunferencia"))
            {
                double raioV = 0;
                if (txtRaio.Text != "") { raioV = Convert.ToDouble(txtRaio.Text); }
                FormaGeometrica circunferencia = new Circunferencia()
                {
                    Raio = raioV
                };
                cmbObjetos.Items.Add(circunferencia);
            }
        }

        private void cmbObjetos_SelectedIndexChanged(object sender, EventArgs e)
        {
            FormaGeometrica obj = cmbObjetos.SelectedItem as FormaGeometrica;
            txtArea.Text = obj.CalcularArea().ToString();
            txtPerimetro.Text = obj.CalcularPerimetro().ToString();
        }

        private void cmbTriangulo_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbTriangulo.Text)
            {
                case "Reto":
                    ExibirBase(true);
                    ExibirAltura(true);
                    break;
                case "Isosceles":
                    ExibirBase(true);
                    ExibirAltura(true);
                    break;
                case "Equilatero":
                    ExibirBase(true);
                    ExibirAltura(false);
                    break;
            }
        }
    }
}
