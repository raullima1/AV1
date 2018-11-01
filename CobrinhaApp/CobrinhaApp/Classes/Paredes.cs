using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CobrinhaApp.Classes
{
    class Paredes
    {

        private Rectangle[] _retanguloParedes;
        private SolidBrush brushParedes;
        private int x, y, altura, largura;

        Random rand = new Random();


        public Rectangle[] retanguloParedes
        {
            get
            {
                return _retanguloParedes;
            }
        }

        public Paredes(int fase)
        {
            _retanguloParedes = new Rectangle[0];

            preDefinicaoParedes(fase);
        }

        public void desenhaParedes(Graphics grafico)
        {
            foreach (Rectangle item in _retanguloParedes)
            {
                grafico.FillRectangle(brushParedes, item);
            }
        }

        public void desenhaParedes()
        {
            for (int i = _retanguloParedes.Length - 1; i > 0; i--)
            {
                _retanguloParedes[i] = _retanguloParedes[i - 1];
            }
        }

        public void preDefinicaoParedes(int fase)
        {
            switch (fase)
            {
                case 0:
                    {
                        #region sem paredes

                        _retanguloParedes = new Rectangle[0];
                        brushParedes = new SolidBrush(Color.Brown);


                        altura = 10;
                        largura = 10;
                        
                        #endregion
                    }
                    break;
                case 1:
                    {
                        #region parede completa

                        _retanguloParedes = new Rectangle[164];
                        brushParedes = new SolidBrush(Color.Brown);


                        altura = 10;
                        largura = 10;

                        x = 0;
                        y = 0;

                        int auxX = 0;
                        int auxY = 0;

                        for (int i = 0; i < _retanguloParedes.Length; i++)
                        {
                            if (x == 0)
                            {
                                _retanguloParedes[i] = new Rectangle(x, y, altura, largura);
                            }
                            if (x <= 400)
                            {
                                x += 10;
                                y = 0;
                                _retanguloParedes[i] = new Rectangle(x, y, altura, largura);
                            }
                            else if (y < 410)
                            {
                                y += 10;
                                _retanguloParedes[i] = new Rectangle(x, y, altura, largura);
                            }

                            else if (y <= 410)
                            {
                                if (auxY < 410)
                                {
                                    _retanguloParedes[i] = new Rectangle(auxX, auxY, altura, largura);

                                    auxY += 10;
                                }
                                else if (auxY <= 410)
                                {
                                    _retanguloParedes[i] = new Rectangle(auxX, auxY, altura, largura);
                                    auxX += 10;
                                }
                            }
                        }
                            #endregion
                    }
                    break;
                case 2:
                    {
                        #region Paredes aleatórias

                        _retanguloParedes = new Rectangle[rand.Next(10)];
                        brushParedes = new SolidBrush(Color.Black);


                        altura = 10;
                        largura = 10;

                        x = rand.Next(10, 400);
                        y = rand.Next(10, 400);



                        for (int i = 0; i < _retanguloParedes.Length; i++)
                        {

                            x = rand.Next(10, 400);
                            y = rand.Next(10, 400);

                            if (y == 200)
                            {
                                y = rand.Next(10, 400);
                            }

                            _retanguloParedes[i] = new Rectangle(x, y, altura, largura);
                        }
                        #endregion
                    }
                    break;
                        default:
                    break;

            }


        }
    }
}
