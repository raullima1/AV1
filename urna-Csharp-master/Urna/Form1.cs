using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Urna
{
    public partial class Form1 : Form
    {
        int[] votos = new int[9];

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtNumeracao.Text += "1";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            txtNumeracao.Text += "7";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblCandidato.ResetText();
            lblNumero.ResetText();
            lblPartido.ResetText();

            
  

        }

        

        private void lblNome_Click(object sender, EventArgs e)
        {

        }

        private void txtNumeracao_TextChanged(object sender, EventArgs e)
        {
            string candidato;
            candidato = Convert.ToString(txtNumeracao.Text);

            switch (candidato)
            {
                case "17":
                    lblCandidato.Text = "Jair Messias Bolsonaro";
                    lblNumero.Text = "17";
                    lblPartido.Text = "PSL";
                    foto.Load("bolsonaro.jpg");
                    
                    break;
                case "13":
                    lblCandidato.Text = "Fernando Haddad";
                    lblNumero.Text = "13";
                    lblPartido.Text = "PT";
                    foto.Load("haddad.jpg");
                    break;
                case "12":
                    lblCandidato.Text = "Ciro Gomes";
                    lblNumero.Text = "12";
                    lblPartido.Text = "PDT";
                    foto.Load("ciro.jpg");
                    break;
                case "51":
                    lblCandidato.Text = "Cabo Daciolo";
                    lblNumero.Text = "51";
                    lblPartido.Text = "PATRIOTA";
                    foto.Load("cabo.png");
                    break;
                case "45":
                    lblCandidato.Text = "Geraldo Alckmin";
                    lblNumero.Text = "45";
                    lblPartido.Text = "PSDB";
                    foto.Load("alckmin.jpg");
                    break;
                case "50":
                    lblCandidato.Text = "Guilherme Boulos";
                    lblNumero.Text = "50";
                    lblPartido.Text = "PSOL";
                    foto.Load("boulos.jpeg");
                    break;
                case "30":
                    lblCandidato.Text = "João Amoedo";
                    lblNumero.Text = "30";
                    lblPartido.Text = "NOVO";
                    foto.Load("amoedo.jpg");
                    break;
                case "18":
                    lblCandidato.Text = "Marina Silva";
                    lblNumero.Text = "18";
                    lblPartido.Text = "REDE";
                    foto.Load("marina.jpeg");
                    break;
                default:
                    lblCandidato.Text = "Voto Nulo";
                    lblNumero.Text = "";
                    lblPartido.Text = "";
                    foto.Load("default.jpg");
                    break;
            }
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            txtNumeracao.Text +="2";
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            txtNumeracao.Text += "3";
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            txtNumeracao.Text += "4";
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            txtNumeracao.Text += "5";
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            txtNumeracao.Text += "6";
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            txtNumeracao.Text += "8";
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            txtNumeracao.Text += "9";
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            txtNumeracao.Text += "0";
        }

        private void btnCorrige_Click(object sender, EventArgs e)
        {
            txtNumeracao.Text = "";
        }

        private void btnBranco_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Voto em Branco");
            votos[8] += 1;

        }

        private void btnConfirma_Click(object sender, EventArgs e)
        {
            string candidato;
            candidato = Convert.ToString(txtNumeracao.Text);

            switch (candidato)
            {
                case "17":
                    votos[0] += 1;
                    MessageBox.Show("VOTOU");
                    txtNumeracao.Text = "";
                    break;
                case "13":
                    votos[1] += 1;
                    MessageBox.Show("VOTOU");
                    txtNumeracao.Text = "";
                    break;
                case "12":
                    votos[2] += 1;
                    MessageBox.Show("VOTOU");
                    txtNumeracao.Text = "";
                    break;
                case "51":
                    votos[3] += 1;
                    MessageBox.Show("VOTOU");
                    txtNumeracao.Text = "";
                    break; ;
                case "45":
                    votos[4] += 1;
                    MessageBox.Show("VOTOU");
                    txtNumeracao.Text = "";
                    break;

                case "50":
                    votos[5] += 1;
                    MessageBox.Show("VOTOU");
                    txtNumeracao.Text = "";
                    break;

                case "30":
                    votos[6] += 1;
                    MessageBox.Show("VOTOU");
                    txtNumeracao.Text = "";
                    break;

                case "18":
                    votos[7] += 1;
                    MessageBox.Show("VOTOU");
                    txtNumeracao.Text = "";
                    break;

                default:
                    votos[8] += 1;
                    MessageBox.Show("VOTO NULO");
                    txtNumeracao.Text = "";
                    break;

            }


        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            MessageBox.Show(
                "Bolsonaro: " + votos[0] +
                "\nHaddad: " + votos[1] +
                "\nCiro: " + votos[2] +
                "\nCabo: " + votos[3] +
                "\nAlckmin: " + votos[4] +
                "\nBoulos: " + votos[5] +
                "\nAmoedo: " + votos[6] +
                "\nMarina: " + votos[7] +
                "\nNulos e Brancos: " + votos[8]
                );
        }
    }
}
