using CobrinhaApp.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CobrinhaApp
{
    public partial class Form1 : Form
    {

        Cobrinha cobra = new Cobrinha();
        Cenario cenario = new Cenario();
        Comida comida;
        ComidaEspecial comidaEsp;

        Vida vida;
        
        //cria uma parede
        Paredes paredes = new Paredes(2);

        Random rand = new Random();

        bool esquerda = false;
        bool direita = false;
        bool cima = false;
        bool baixo = false;

        int pontos = 0;

        int fase = 0;

        int tempo = 0;

        int contadorPontos = 0; //quando chega a 10, adiciona a comida especial no cenário

        public Form1()
        {
            InitializeComponent();

            comida = new Comida(rand);
            comidaEsp = new ComidaEspecial(rand);
            vida = new Vida(rand);

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.Left:
                    {
                        if(!direita)
                        {
                            direita = false;
                            esquerda = true;
                            cima = false;
                            baixo = false;
                        }
                    }
                    break;
                case Keys.Right:
                    {
                        if (!esquerda)
                        {
                            direita = true;
                            esquerda = false;
                            cima = false;
                            baixo = false;
                        }
                    }
                    break;
                case Keys.Down:
                    {
                        if (!cima)
                        {
                            direita = false;
                            esquerda = false;
                            cima = false;
                            baixo = true;
                        }
                    }
                    break;
                case Keys.Up:
                    {
                        if (!baixo)
                        {
                            direita = false;
                            esquerda = false;
                            cima = true;
                            baixo = false;
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (direita)
                cobra.MovimentarCobrinha(Cobrinha.Direcao.DIREITA);
            if (esquerda)
                cobra.MovimentarCobrinha(Cobrinha.Direcao.ESQUERDA);
            if (cima)
                cobra.MovimentarCobrinha(Cobrinha.Direcao.CIMA);
            if (baixo)
                cobra.MovimentarCobrinha(Cobrinha.Direcao.BAIXO);

            if(cobra.retanguloCobrinha[0].IntersectsWith(comida.comidaRetangulo))
            {
                pontos++;
                contadorPontos++;
                cobra.AlimentarCobrinha();
                comida.PosicaoComida(rand);

            }
            if (cobra.retanguloCobrinha[0].IntersectsWith(comidaEsp.comidaRetangulo))
            {
                pontos += comidaEsp.Pontos;
                cobra.AlimentarCobrinha();
                comidaEsp.PosicaoComida(rand);

                vida.PosicaoComida(rand);

            }

            if (cobra.retanguloCobrinha[0].IntersectsWith(vida.comidaRetangulo))
            {
                cobra.AlimentarCobrinha();
                vida.PosicaoComida(rand);

            }
            
            //muda a comida especial de lugar
            if (tempo < comidaEsp.Tempo)
            {
                tempo++;
            }
            else
            {
                tempo = 0;
            }

            if (tempo == comidaEsp.Tempo)
            {
                comidaEsp.PosicaoComida(rand);
            }

            if (contadorPontos > 10)
            {
                contadorPontos = 0;
            }

            
            

            DetectarColisoes();

            CPontos.Text = "Pontuação: " + pontos;

            this.Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            cenario.desenharCenario(e.Graphics);

            cobra.desenhaCobrinha(e.Graphics);

            comida.DesenharComida(e.Graphics);

            if (contadorPontos == 5)
            {
                comidaEsp.DesenharComida(e.Graphics);
            }

            if(pontos >= 10)
            {
                vida.DesenharComida(e.Graphics);
            }

            //desenha a parede
            paredes.desenhaParedes(e.Graphics);
            
        }

        private void DetectarColisoes()
        {
            #region colidir com as paredes

            //verifica a colisão com as paredes
            if (paredes.retanguloParedes.Length > 0)
            {
                for (int i = 0; i < paredes.retanguloParedes.Length; i++)
                {
                    if (cobra.retanguloCobrinha[0].IntersectsWith(paredes.retanguloParedes[i]))
                    {
                        ResetarGame();
                    }
                }
            }
            #endregion

            #region Auto Colisão

            for (int i = 1; i < cobra.retanguloCobrinha.Length; i++)
                {
                    if(cobra.retanguloCobrinha[0].IntersectsWith(cobra.retanguloCobrinha[i]))
                    {
                    ResetarGame();
                    }

                }
            #endregion

            #region Colidir com as Bordas

                switch(cenario.colidir)
                {
                case Cenario.ColidirComAsBordas.nao:
                    {
                        UltrapassarBordas();
                    }
                    break;
                case Cenario.ColidirComAsBordas.sim:
                    {
                        ColidirCenario();
                    }

                    break;
                default:
                    break;

                }

            #endregion

        }
        private void UltrapassarBordas()
        {
            for (int i = 0; i < cobra.retanguloCobrinha.Length; i++)
            {
                //Ultrapassar a borda esquerda
                if (cobra.retanguloCobrinha[i].X < cenario.retanguloCenario.Left)
                {
                    cobra.retanguloCobrinha[i].X = cenario.retanguloCenario.Right - cobra.retanguloCobrinha[i].Width;
                }

                //Ultrapassar a borda direita
                if (cobra.retanguloCobrinha[i].X > cenario.retanguloCenario.Right)
                {
                    cobra.retanguloCobrinha[i].X = cenario.retanguloCenario.Left;
                }

                //Ultrapassar a borda superior
                if (cobra.retanguloCobrinha[i].Y < cenario.retanguloCenario.Top)
                {
                    cobra.retanguloCobrinha[i].Y = cenario.retanguloCenario.Bottom - cobra.retanguloCobrinha[i].Height;
                }

                //Ultrapassar a borda inferior
                if (cobra.retanguloCobrinha[i].Y > cenario.retanguloCenario.Bottom - cobra.retanguloCobrinha[i].Height)
                {
                    cobra.retanguloCobrinha[i].Y = cenario.retanguloCenario.Top;
                }
            }
        }
        private void ColidirCenario()
        {
            if (
                 cobra.retanguloCobrinha[0].X < cenario.retanguloCenario.Left ||
                 cobra.retanguloCobrinha[0].X > (cenario.retanguloCenario.Right - cobra.retanguloCobrinha[0].Width) ||
                 cobra.retanguloCobrinha[0].Y < cenario.retanguloCenario.Top ||
                 cobra.retanguloCobrinha[0].Y > (cenario.retanguloCenario.Bottom - cobra.retanguloCobrinha[0].Height)
                )
            {
                ResetarGame();
            }
        }

        private void ResetarGame()
        {
            timer1.Enabled = false;
            MessageBox.Show("Pontuação: " + pontos, "GAME OVER!");

            cobra = new Cobrinha();

            //cria uma parede
            paredes = new Paredes(2);

            direita = false;
            esquerda = false;
            cima = false;
            baixo = false;

            pontos = 0;

            contadorPontos = 0;

            fase = 0;

            comida.PosicaoComida(rand);

            timer1.Enabled = true;
        }

        private void PassarDeFase()
        {
            timer1.Enabled = false;

            fase += 1;

            cobra = new Cobrinha();
            
            //cria uma parede
            paredes = new Paredes(fase);

            direita = false;
            esquerda = false;
            cima = false;
            baixo = false;
            
            comida.PosicaoComida(rand);

            timer1.Enabled = true;
        }
    }
}







