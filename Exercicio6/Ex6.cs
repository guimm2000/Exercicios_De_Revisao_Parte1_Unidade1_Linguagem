using System;
using IntervaloNamespace;

public class ListaIntervalo
{
    List<Intervalo> intervalos;
    public ListaIntervalo() 
    {
        intervalos = new List<Intervalo>();
    }

    public bool Add(Intervalo i)
    {
        if (intervalos.Count > 0)
        {
            foreach (Intervalo intervalo in intervalos)
            {
                if (i.TemIntersecao(intervalo))
                {
                    Console.WriteLine("Nao foi possivel adicionar intervalo, pois ha intersecao com intervalo ja existente!");
                    return false;
                }
            }
            for(int j = 0; j < intervalos.Count; j++)
            {
                if (intervalos[j].dataHoraInicial > i.dataHoraInicial)
                {
                    intervalos.Insert(j, i);
                    return true;
                }
            }
        }
        intervalos.Add(i);
        return true;
    }

    public void Imprime()
    {
        foreach(Intervalo intervalo in intervalos)
        {
            Console.WriteLine(intervalo.dataHoraInicial);
        }
    }
}

public class MainClass
{
    public static void Main(string[] args)
    {
        try
        {
            DateTime a = DateTime.Now;
            DateTime b = a.AddDays(20);
            Intervalo i = new Intervalo(a, b);

            DateTime c = DateTime.Now.AddDays(30);
            DateTime d = c.AddDays(200);
            Intervalo j = new Intervalo(c, d);

            DateTime e = DateTime.Now.AddDays(-30);
            DateTime f = e.AddDays(10);
            Intervalo k = new Intervalo(e, f);

            ListaIntervalo lista = new ListaIntervalo();
            lista.Add(i);
            lista.Add(j);
            lista.Add(k);
            lista.Imprime();
        }
        catch (ErroDeData e)
        {
            Console.WriteLine(e.Message);
        }
    }
}