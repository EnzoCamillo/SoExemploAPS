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
            try
            {
                FormaGeometrica trianguloI = new TI()
                {
                    Base = Convert.ToDouble(txtBase.Text),
                    Altura = Convert.ToDouble(txtAltura.Text)
                };
                cmbObjetos.Items.Add(trianguloI);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro:\n" + ex.Message, "Erro:", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cmbEqui()
        {
            try
            {
                FormaGeometrica trianguloE = new TE()
                {
                    Base = Convert.ToDouble(txtBase.Text)
                };
                cmbObjetos.Items.Add(trianguloE);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro:\n" + ex.Message, "Erro:", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cmbReto()
        {
            try
            {
                FormaGeometrica trianguloR = new TR()
                {
                    BaseT = Convert.ToDouble(txtBase.Text),
                    AlturaT = Convert.ToDouble(txtAltura.Text)
                };
                cmbObjetos.Items.Add(trianguloR);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro:\n" + ex.Message, "Erro:", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnQuadrado()
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro:\n" + ex.Message, "Erro:", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnRetangulo()
        {
            try
            {
                if (cmbForma.Text.Equals("Retangulo"))
                {
                    FormaGeometrica retangulo = new Retangulo()
                    {
                        Base = Convert.ToDouble(txtBase.Text),
                        Altura = Convert.ToDouble(txtAltura.Text)
                    };
                    cmbObjetos.Items.Add(retangulo);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro:\n" + ex.Message, "Erro:", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnCircunferencia()
        {
            try
            {
                if (cmbForma.Text.Equals("Circunferencia"))
                {
                    FormaGeometrica circunferencia = new Circunferencia()
                    {
                        Raio = Convert.ToDouble(txtRaio.Text)
                    };
                    cmbObjetos.Items.Add(circunferencia);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro:\n" + ex.Message, "Erro:", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    LimparCampos();
                    break;
                case "Isosceles":
                    ExibirBase(true);
                    ExibirAltura(true);
                    LimparCampos();
                    break;
                case "Equilatero":
                    ExibirBase(true);
                    ExibirAltura(false);
                    LimparCampos();
                    break;
            }
        }
    }
}
