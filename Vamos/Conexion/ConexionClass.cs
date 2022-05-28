using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace Vamos.Conexion
{
    public class ConexionClass : INotifyPropertyChanged
    {
        public double heightValue;
        public double widthValue;
        public double top, left;

        public double WindowHeightValue
        {
            get
            {
                return heightValue;
            }
            set
            {
                heightValue = value;
                OnPropertyChanged("HeightValue");
            }
        }
        public double WindowWidthValue
        {
            get
            {
                return widthValue;
            }
            set
            {
                widthValue = value;
                OnPropertyChanged("WidthValue");
            }
        }
        public double Top
        {
            get
            {
                return top;
            }
            set
            {
                top = value;
                OnPropertyChanged("MoveTop");
            }
        }
        public double Left
        {
            get
            {
                return left;
            }
            set
            {
                left = value;
                OnPropertyChanged("MoveLeft");
            }
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged(string property)
        {

            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
        public double MoveTop
        {
            get
            {
                return Top;
            }
        }
        public double MoveLeft
        {
            get
            {
                return Left;
            }
        }
        public double HeightValue
        {
            get
            {
                return WindowHeightValue;
            }
            set
            {
                WindowHeightValue = value;
            }
        }
        public double WidthValue
        {
            get
            {
                return WindowWidthValue;
            }
            set
            {
                WindowWidthValue = value;
            }
        }
        public bool TouchBootomA = false;
        public bool TouchLeftB = false;
        public bool TouchRightC = false;
        public bool TouchTopD = true;

        public bool Derecha = false;
        public bool Izquierda = false;

        public bool A = true;
        public bool B = true;
        public bool C = true;
        public bool D = true;

        public bool X = false;

        #region realMove
        public void realMove()
        {
            ReboteEsquina();
            if (top == 0 && X == false)
            {
                if (TouchRightC == true)
                {
                    A = false;
                    B = true;
                    C = false;
                    D = false;
                    reboteArriba();
                }
                if (TouchLeftB == true)
                {
                    A = false;
                    B = false;
                    D = false;
                    C = true;
                    reboteIzquierda();
                }
                if (TouchBootomA == true)
                {
                    if (Derecha == true)
                    {
                        A = false;
                        B = true;
                        C = false;
                        D = false;
                        reboteArriba();
                    }
                    else
                    {
                        A = false;
                        B = false;
                        C = true;
                        D = false;
                        reboteIzquierda();
                    }
                }
            }
            if (top == (heightValue - 50) && X == false)
            {
                if (TouchLeftB == true)
                {
                    A = true;
                    B = false;
                    C = false;
                    D = false;
                    reboteAbajo();
                }
                if (TouchRightC == true)
                {
                    A = false;
                    B = false;
                    C = false;
                    D = true;
                    reboteDerecha();
                }
                if (TouchTopD == true)
                {
                    if (Derecha == true)
                    {
                        A = false;
                        B = false;
                        C = false;
                        D = true;
                        reboteDerecha();
                    }
                    else
                    {
                        A = true;
                        B = false;
                        C = false;
                        D = false;
                        reboteAbajo();
                    }
                }
            }
            if (left == widthValue - 20 && X == false)
            {
                if (TouchBootomA == true)
                {
                    A = false;
                    B = false;
                    C = false;
                    D = true;
                    reboteDerecha();
                }
                if (TouchTopD == true)
                {
                    A = false;
                    B = true;
                    C = false;
                    D = false;
                    reboteArriba();
                }

            }
            if (left == 0 && X == false)
            {
                if (TouchBootomA == true)
                {
                    A = true;
                    B = false;
                    C = false;
                    D = false;
                    reboteAbajo();
                }
                if (TouchTopD == true)
                {
                    A = false; B = false;
                    C = true; D = false;
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
                if (top == (heightValue - 50))
                {
                    TouchBootomA = false;
                    TouchLeftB = true;
                    TouchRightC = false;
                    TouchTopD = false;
                    Timer.Stop();
                    C = false;
                    realMove();
                }
                if (left == widthValue - 20 && X == false)
                {
                    TouchBootomA = false;
                    TouchLeftB = false;
                    TouchRightC = false;
                    TouchTopD = true;
                    Timer.Stop();
                    C = false;
                    realMove();
                }
                if (C == true)
                {
                    Top = top + 10;
                    Left = left + 10;
                    Izquierda = true;
                    Derecha = false;
                    X = false;
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
                if (left == widthValue - 20 || top == 0)
                {
                    TouchBootomA = true;
                    TouchLeftB = false;
                    TouchRightC = false;
                    TouchTopD = false;
                    Timer.Stop();
                    A = false;
                    realMove();
                }
                if (A == true)
                {
                    Top = top - 10;
                    Left = left + 10;
                    Izquierda = true;
                    Derecha = false;
                    X = false;
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
                if (top == 0)
                {
                    TouchBootomA = false;
                    TouchLeftB = false;
                    TouchRightC = true;
                    TouchTopD = false;
                    Timer.Stop();
                    D = false;
                    realMove();
                }
                if (left == 0 && X == false)
                {
                    TouchBootomA = true;
                    TouchLeftB = false;
                    TouchRightC = false;
                    TouchTopD = false;
                    Timer.Stop();
                    D = false;
                    realMove();
                }
                if (D == true)
                {
                    Top = top - 10;
                    Left = left - 10;
                    Derecha = true;
                    Izquierda = false;
                    X = false;

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
                if (left == 0 || top == (heightValue - 50))
                {
                    TouchBootomA = false;
                    TouchLeftB = false;
                    TouchRightC = false;
                    TouchTopD = true;
                    Timer.Stop();
                    B = false;
                    realMove();
                }
                if (B == true)
                {
                    Top = top + 10;
                    Left = left - 10;
                    Derecha = true;
                    Izquierda = false;
                    X = false;

                }
            };
            Timer.Start();
        }
        public void ReboteEsquina()
        {
            if (top == 0 && left == 0)
            {
                C = true;
                X = true;
                reboteIzquierda();
            }
            if (top == heightValue - 50 && left == 0)
            {
                A = true;
                X = true;
                reboteAbajo();
            }
            if (top == heightValue - 50 && left == widthValue - 20)
            {
                D = true;
                X = true;
                reboteDerecha();
            }
            if (top == 0 && left == widthValue - 20)
            {
                B = true;
                X = true;
                reboteArriba();
            }
        }
    }
    #endregion
}
