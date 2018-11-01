using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CobrinhaApp.Classes
{

    public class ComidaEspecial : Comida
    {
        //public const int pontos = 10;

        public ComidaEspecial(Random rand) : base(rand)
        {
            PosicaoComida(rand);

            brushComida = new SolidBrush(Color.Gold);

            largura = 10;
            altura = 10;
            _comidaRetangulo = new Rectangle(x, y, largura, altura);
        }

        public int Pontos
        {
            get
            {
                return 10;
            }
        }

        public int Tempo
        {
            get
            {
                return 20;
            }
        }


    }
}
