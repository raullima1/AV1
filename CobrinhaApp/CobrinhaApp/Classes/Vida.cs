using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CobrinhaApp.Classes
{
    public class Vida: Comida
    {
        public Vida(Random rand): base(rand)
        {
            PosicaoComida(rand);

            brushComida = new SolidBrush(Color.Red);

            largura = 2;
            altura = 2;

            _comidaRetangulo = new Rectangle(x, y, largura, altura);

        }

        public void DesenharComida(Graphics grafico)
        {
            // ponta superior 1
            for (int i = 0; i < 3; i++)
            {
                _comidaRetangulo.X = x + i * 2;
                _comidaRetangulo.Y = y;
                grafico.FillRectangle(brushComida, _comidaRetangulo);
                
            }
            _comidaRetangulo.X = x + 2;
            _comidaRetangulo.Y = y - 2;
            grafico.FillRectangle(brushComida, _comidaRetangulo);

            // ponta superior 2
            for (int i = 4; i < 7; i++)
            {
                _comidaRetangulo.X = x + i * 2;
                _comidaRetangulo.Y = y;
                grafico.FillRectangle(brushComida, _comidaRetangulo);
            }
            _comidaRetangulo.X = x + 10;
            _comidaRetangulo.Y = y - 2;
            grafico.FillRectangle(brushComida, _comidaRetangulo);

            //corpo
            for (int i = 0; i < 9; i++)
            {
                _comidaRetangulo.X = (x - 2) + i * 2;
                _comidaRetangulo.Y = y + 2;
                grafico.FillRectangle(brushComida, _comidaRetangulo);
            }

            for (int i = 0; i < 7; i++)
            {
                _comidaRetangulo.X = x + i * 2;
                _comidaRetangulo.Y = y + 4;
                grafico.FillRectangle(brushComida, _comidaRetangulo);
            }

            for (int i = 1; i < 6; i++)
            {
                _comidaRetangulo.X = x + i * 2;
                _comidaRetangulo.Y = y + 6;
                grafico.FillRectangle(brushComida, _comidaRetangulo);
            }

            for (int i = 2; i < 5; i++)
            {
                _comidaRetangulo.X = x + i * 2;
                _comidaRetangulo.Y = y + 8;
                grafico.FillRectangle(brushComida, _comidaRetangulo);
            }

            //ponta inferior
            for (int i = 3; i < 4; i++)
            {
                _comidaRetangulo.X = x + i * 2;
                _comidaRetangulo.Y = y + 10;
                grafico.FillRectangle(brushComida, _comidaRetangulo);
            }






        }

    }
}
