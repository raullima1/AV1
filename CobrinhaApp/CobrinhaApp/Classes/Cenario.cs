using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace CobrinhaApp.Classes
{
    public class Cenario
    {
        private Rectangle _retanguloCenario;
        private SolidBrush brushCenario;
        private int x, y, altura, largura;
        

        public ColidirComAsBordas colidir;

        public enum ColidirComAsBordas
        {
            sim = 1,
            nao = 0
        };

        public Rectangle retanguloCenario
        {
            get
            {
                return _retanguloCenario;
            }
        }

        public Cenario()
        {
            brushCenario = new SolidBrush(Color.LightGray);

            x = 10;
            y = 10;
            altura = 400;
            largura = 400;

            _retanguloCenario = new Rectangle(x, y, altura, largura);

        }

        public void desenharCenario(Graphics grafico)
        {
            _retanguloCenario.X = 10;
            _retanguloCenario.Y = 10;

            grafico.FillRectangle(brushCenario, _retanguloCenario);
        }

    }
}
