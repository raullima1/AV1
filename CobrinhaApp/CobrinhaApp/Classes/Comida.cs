using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CobrinhaApp.Classes
{
    public class Comida
    {
        public Rectangle _comidaRetangulo;
        public SolidBrush brushComida;
        public int x, y, largura, altura;

        public Rectangle comidaRetangulo
        {
            get
            {
                return _comidaRetangulo;
            }
        }

        public Comida(Random rand)
        {
            PosicaoComida(rand);

            brushComida = new SolidBrush(Color.OrangeRed);

            largura = 10;
            altura = 10;

            _comidaRetangulo = new Rectangle(x, y, largura, altura);

        }

        public void PosicaoComida(Random rand)
        {
            x = rand.Next(1, 39) * 10;
            y = rand.Next(1, 39) * 10;
        }

        public virtual void DesenharComida(Graphics grafico)
        {
            _comidaRetangulo.X = x;
            _comidaRetangulo.Y = y;

            grafico.FillRectangle(brushComida, _comidaRetangulo);
        }
    }
}
