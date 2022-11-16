using System;
using Vertices;

public enum TipoDeTriangulo
{
    Equilatero,
    Isosceles,
    Escaleno
}

public class Triangulo
{
    //Propriedades para os vertices do triangulo
    public Vertice A { get; private set; }
    public Vertice B { get; private set; }
    public Vertice C { get; private set; }

    public double Perimetro { get; private set; }
    public TipoDeTriangulo Tipo { get; private set; }
    public double Area { get; private set; }

    public Triangulo(Vertice A, Vertice B, Vertice C)
    {
        //Verifica as condicoes de existencia de um triangulo
        if (A.Distancia(B) + B.Distancia(C) < C.Distancia(A) || B.Distancia(C) + C.Distancia(A) < A.Distancia(B) || C.Distancia(A) + A.Distancia(B) < B.Distancia(C))
        {
            throw (new NaoETrianguloException("Esse Triangulo nao existe!"));
        }
        else
        {
            this.A = A;
            this.B = B;
            this.C = C;

            this.Perimetro = this.A.Distancia(B) + this.B.Distancia(C) + this.C.Distancia(A);

            if (this.A.Distancia(B) == this.B.Distancia(C) || this.A.Distancia(B) == this.C.Distancia(A))
            {
                if (this.A.Distancia(B) == this.B.Distancia(C) && this.A.Distancia(B) == this.C.Distancia(A))
                {
                    this.Tipo = TipoDeTriangulo.Equilatero;
                }
                else this.Tipo = TipoDeTriangulo.Isosceles;
            }
            else if (this.B.Distancia(C) == this.C.Distancia(A))
            {
                this.Tipo = TipoDeTriangulo.Isosceles;
            }
            else this.Tipo = TipoDeTriangulo.Escaleno;

            double S = Perimetro / 2;
            this.Area = Math.Sqrt(S*(S - A.Distancia(B))*(S - B.Distancia(C))*(S - C.Distancia(A)));
        }
    }

    public bool Igual(Triangulo T) 
    {
        double[] ladosA = new double[3];
        double[] ladosT = new double[3];

        //Organiza os vertice em lados e depois ordena em ordem crescente para facilitar a checagem
        ladosA[0] = this.A.Distancia(B);
        ladosA[1] = this.B.Distancia(C);
        ladosA[2] = this.C.Distancia(A);
        Array.Sort(ladosA);

        ladosT[0] = T.A.Distancia(T.B);
        ladosT[1] = T.B.Distancia(T.C);
        ladosT[2] = T.C.Distancia(T.A);
        Array.Sort(ladosT);

        for (int i = 0; i < 3; i++) 
        {
            if (ladosA[i] != ladosT[i]) return false;
        }

        return true;
    }
}

public class NaoETrianguloException : Exception
{
    public NaoETrianguloException(String message)
        : base(message)
    {
    }

}

public class MainClass
{
    public static void Main(string[] args)
    {
        Vertice A = new Vertice(0, 0);
        Vertice B = new Vertice(12.039, 0);
        Vertice C = new Vertice(6.020, 18.058);

        Vertice D = new Vertice(-2 * Math.Sqrt(3), 3);
        Vertice E = new Vertice(2*Math.Sqrt(3), 3);
        Vertice F = new Vertice(0, 0);

        Triangulo t1 = new Triangulo(A, B, C);
        Triangulo t2 = new Triangulo(D, E, F);


        Console.WriteLine(t2.Tipo);
    }
}   