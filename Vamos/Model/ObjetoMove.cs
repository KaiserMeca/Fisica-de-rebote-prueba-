using System;
using System.ComponentModel;
using System.Windows.Threading;
using Vamos.Conexion;


namespace Vamos
{
    public class ObjetoMove
    {
        public bool TouchBootomA = false;
        public bool TouchLeftB = false;
        public bool TouchRightC = false;
        public bool TouchTopD = true;

        public bool Derecha = false;
        public bool Izquierda = false;

        #region realMove
        ConexionClass conexion = new ConexionClass();
        public void realMove()
        {
            ReboteEsquina();
            if (conexion.top == 0)
            {
                if (TouchRightC == true)
                {
                    reboteArriba();
                }
                if (TouchLeftB == true)
                {
                    reboteIzquierda();
                }
                if (TouchBootomA == true)
                {
                    if (Derecha == true)
                    {
                        reboteArriba();
                    }
                    else
                    {
                        reboteIzquierda();
                    }
                }
            }
            if (conexion.top == (conexion.heightValue - 50))
            {
                if (TouchLeftB == true)
                {
                    reboteAbajo();
                }
                if (TouchRightC == true)
                {
                    reboteDerecha();
                }
                if (TouchTopD == true)
                {
                    if (Derecha == true)
                    {
                        reboteDerecha();
                    }
                    else
                    {
                        reboteAbajo();
                    }
                }
            }
            if (conexion.left == conexion.widthValue - 22)
            {
                if (TouchBootomA == true)
                {
                    reboteDerecha();
                }
                if (TouchTopD == true)
                {
                    reboteArriba();
                }

            }
            if (conexion.left == 0)
            {
                if (TouchBootomA == true)
                {
                    reboteAbajo();
                }
                if (TouchTopD == true)
                {
                    reboteIzquierda();
                }
            }
        }
        public void reboteIzquierda()
        {
            DispatcherTimer Timer = new DispatcherTimer();
            Timer.Interval = new TimeSpan(0, 0, 0, 0, 1);
            Timer.Tick += (a, b) =>
            {
                if (conexion.top == (conexion.heightValue - 50))
                {
                    TouchBootomA = false;
                    TouchLeftB = true;
                    TouchRightC = false;
                    TouchTopD = false;
                    Timer.Stop();
                    realMove();
                }
                if (conexion.left == conexion.widthValue - 22)
                {
                    TouchBootomA = false;
                    TouchLeftB = false;
                    TouchRightC = false;
                    TouchTopD = true;
                    Timer.Stop();
                    realMove();
                }
                else
                {
                    conexion.Top = conexion.top + 1;
                    conexion.Left = conexion.left + 1;
                    Izquierda = true;
                    Derecha = false;
                }
            };
            Timer.Start();
        }
        public void reboteAbajo()
        {
            DispatcherTimer Timer = new DispatcherTimer();
            Timer.Interval = new TimeSpan(0, 0, 0, 0, 1);
            Timer.Tick += (a, b) =>
            {
                if (conexion.left == conexion.widthValue - 22 || conexion.top == 0)
                {
                    TouchBootomA = true;
                    TouchLeftB = false;
                    TouchRightC = false;
                    TouchTopD = false;
                    Timer.Stop();
                    realMove();
                }
                else
                {
                    conexion.Top = conexion.top - 1;
                    conexion.Left = conexion.left + 1;
                    Izquierda = true;
                    Derecha = false;
                }
            };
            Timer.Start();
        }
        public void reboteDerecha()
        {
            DispatcherTimer Timer = new DispatcherTimer();
            Timer.Interval = new TimeSpan(0, 0, 0, 0, 1);
            Timer.Tick += (a, b) =>
            {
                if (conexion.top == 0)
                {
                    TouchBootomA = false;
                    TouchLeftB = false;
                    TouchRightC = true;
                    TouchTopD = false;
                    Timer.Stop();
                    realMove();
                }
                if (conexion.left == 0)
                {
                    TouchBootomA = true;
                    TouchLeftB = false;
                    TouchRightC = false;
                    TouchTopD = false;
                    Timer.Stop();
                    realMove();
                }
                else
                {
                    conexion.Top = conexion.top - 1;
                    conexion.Left = conexion.left - 1;
                    Derecha = true;
                    Izquierda = false;

                }
            };
            Timer.Start();
        }
        public void reboteArriba()
        {
            DispatcherTimer Timer = new DispatcherTimer();
            Timer.Interval = new TimeSpan(0, 0, 0, 0, 1);
            Timer.Tick += (a, b) =>
            {
                if (conexion.left == 0 || conexion.top == (conexion.heightValue - 50))
                {
                    TouchBootomA = false;
                    TouchLeftB = false;
                    TouchRightC = false;
                    TouchTopD = true;
                    Timer.Stop();
                    realMove();
                }
                if (conexion.left != 0 || conexion.top != (conexion.heightValue - 50))
                {
                    conexion.Top = conexion.top + 1;
                    conexion.Left = conexion.left - 1;
                    Derecha = true;
                    Izquierda = false;
                }
            };
            Timer.Start();
        }
        public void ReboteEsquina()
        {
            if (conexion.top == 0 && conexion.left == 0)
            {
                reboteIzquierda();
            }
            if (conexion.top == conexion.heightValue - 50 && conexion.left == 0)
            {
                reboteAbajo();
            }
            if (conexion.top == conexion.heightValue - 50 && conexion.left == conexion.widthValue - 22)
            {
                reboteDerecha();
            }
            if (conexion.top == 0 && conexion.left == conexion.widthValue - 22)
            {
                reboteArriba();
            }
        }
    }
    #endregion
}

