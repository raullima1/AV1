using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CobrinhaApp.Classes
{
    public class Cobrinha
    {
        private Rectangle[] _retanguloCobrinha;
        private SolidBrush brushCobrinha;
        private int x, y, altura, largura;

        public enum Direcao
        {
            DIREITA,
            ESQUERDA,
            CIMA,
            BAIXO
        };


        public Rectangle[] retanguloCobrinha
        {
            get
            {
                return _retanguloCobrinha;
            }
        }

        public Cobrinha()
        {
            _retanguloCobrinha = new Rectangle[3];
            brushCobrinha = new SolidBrush(Color.Green);

            x = 190;
            y = 200;

            altura = 10;
            largura = 10;

            for (int i = 0; i < _retanguloCobrinha.Length; i++)
            {
                _retanguloCobrinha[i] = new Rectangle(x, y, altura, largura);
                x -= 10;
            }
        }

        public void desenhaCobrinha(Graphics grafico)
        {
            foreach(Rectangle item in _retanguloCobrinha)
            {
                grafico.FillRectangle(brushCobrinha, item);
            }
        }

        public void desenhaCobrinha()
        {
            for(int i = _retanguloCobrinha.Length - 1; i > 0; i--)
            {
                _retanguloCobrinha[i] = _retanguloCobrinha[i - 1];
            }
        }

        public void MovimentarCobrinha(Direcao direcao)
        {
            desenhaCobrinha();
            switch(direcao)
            {
                case Direcao.DIREITA:
                    {
                        _retanguloCobrinha[0].X += 10;
                    }
                    break;
                case Direcao.ESQUERDA:
                    {
                        _retanguloCobrinha[0].X -= 10;
                    }
                    break;
                case Direcao.CIMA:
                    {
                        _retanguloCobrinha[0].Y -= 10;
                    }
                    break;
                case Direcao.BAIXO:
                    {
                        _retanguloCobrinha[0].Y += 10;
                    }
                    break;
                default:
                    break;
            }

        }

        public void AlimentarCobrinha()
        {
            List<Rectangle> retangulos = _retanguloCobrinha.ToList();

            retangulos.Add(new Rectangle(
                                          _retanguloCobrinha[_retanguloCobrinha.Length - 1].X,
                                          _retanguloCobrinha[_retanguloCobrinha.Length - 1].Y,
                                          _retanguloCobrinha[_retanguloCobrinha.Length - 1].Width,
                                          _retanguloCobrinha[_retanguloCobrinha.Length - 1].Height ));

            _retanguloCobrinha = retangulos.ToArray();

        }
    }
}
