using System;
using System.Xml.Schema;
using Vertices;

public class Poligono
{
    private List<Vertice> vertices = new List<Vertice>();
    public int QuantidadeVertices { get; private set; }
    public Poligono(params Vertice[] vertices) 
    {
        if (vertices.Length < 3) throw new NaoEPoligonoException("O poligono deve conter pelo menos 3 vertices!");
        
        else
        {
            for(int i = 0; i < vertices.Length; i++) 
            {
                this.vertices.Add(vertices[i]);
                QuantidadeVertices++;
            }
        }
    }

    public bool AddVertice(Vertice v)
    {
        //Verifica se o vertice ja existe atraves do metodo Igual de Vertice
        foreach(Vertice vertice in vertices)
        {
            if (vertice.Igual(v)) return false;
        }
        vertices.Add(v);
        return true;
    }

    //Metodo e do tipo void pois nao ha necessidade de retorno, mas fiquei na duvida sobre deixar em bool
    public void RemoveVertice(Vertice v)
    {
        if(QuantidadeVertices == 3)
        {
            throw new NaoEPoligonoException("Nao e possivel remover o vertice pois o poligono teria menos do que 3 vertices!");
        }
        //Assim como na funcao AddVertice verifica se o vertice existe com o metodo Igual de Vertice
        for(int i = 0; i < vertices.Count; i++)
        {
            if (vertices[i].Igual(v))
            {
                vertices.RemoveAt(i);
                break;
            }
        }
        QuantidadeVertices--;
    }

    public double Perimetro()
    {
        double perimetro = 0;
        Vertice verticeAtual = vertices[0];

        for(int i = 1; i < vertices.Count; i++)
        {
            perimetro += verticeAtual.Distancia(vertices[i]);
            verticeAtual = vertices[i];
            
        }

        return perimetro;
    }
}

public class NaoEPoligonoException : Exception
{
    public NaoEPoligonoException(String message)
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

        try
        {
            Poligono p = new Poligono(A, B, C);
            p.RemoveVertice(new Vertice(0, 0));
            Console.WriteLine(p.QuantidadeVertices);
        }

        catch(NaoEPoligonoException e)
        {
            Console.WriteLine("Excecao detectada: " + e.Message);
        }
    }
}
