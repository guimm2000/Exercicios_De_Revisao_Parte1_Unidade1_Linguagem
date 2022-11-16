using System;

namespace Vertices
{
    public class Vertice
    {
        private double _X, _Y;

        public Vertice(double X, double Y)
        {
            this._X = X;
            this._Y = Y;
        }

        public double X
        {
            get
            {
                return _X;
            }
            private set
            {
                _X = value;
            }
        }

        public double Y
        {
            get
            {
                return _Y;
            }
            private set
            {
                _Y = value;
            }
        }

        public double Distancia(Vertice A)
        {
            //Calcula a distancia euclidiana com as funcoes raiz quadrada e potencia do namespace Math
            return Math.Sqrt((Math.Pow((this.X - A.X), 2) + Math.Pow((this.Y - A.Y), 2)));
        }

        public void Move(double novoX, double novoY)
        {
            this.X = novoX;
            this.Y = novoY;
        }

        //Fiquei na duvida sobre fazer um metodo estatico mas optei ppor fazer assim
        public bool Igual(Vertice A)
        {
            return (this.X == A.X && this.Y == A.Y);
        }
    }

    public class MainClass
    {
        public static void Main(string[] args)
        {
            Vertice A = new Vertice(2, 5);
            Vertice B = new Vertice(3, 4);

            Console.WriteLine(A.Distancia(B));
        }
    }
}