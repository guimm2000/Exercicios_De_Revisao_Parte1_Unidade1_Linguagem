using System;

public class Piramide {
    private int _N;

    public Piramide(int N)
    {
        if (N < 1)
        {
            throw (new ValorDeNInvalidoException("Valor de N deve ser maior do que 1!"));
        }
        else
        {
            this._N = N;
        }
    }
    public int N
    {
        get
        {
            return this._N;
        }
    }

    public void Desenha()
    {
        int valorMax = 1;

        while (valorMax <= this.N)
        {
            //Imprime os espaços da pirâmide
            for (int i = 0; i < this.N - valorMax; i++) Console.Write(" ");

            //Imprime a ordem crescente incluindo o meio
            for (int i = 1; i <= valorMax; i++) Console.Write(i);

            //Imprime em ordem decrescente excluindo o meio
            for (int i = valorMax - 1; i >= 1; i--) Console.Write(i);

            Console.WriteLine();
            valorMax++;
        }
    }
}

//Excecao para a piramide
public class ValorDeNInvalidoException : Exception
{
    public ValorDeNInvalidoException(String message)
        : base(message)
    {
    }

}

public class MainClass
{
    public static void Main(string[] args)
    {
        try
        {
            //Pede o input pelo console
            Console.Write("Digite o valor N da piramide: ");
            Piramide p = new Piramide(Convert.ToInt32(Console.ReadLine()));
            Console.WriteLine();
            p.Desenha();
        }
        catch(ValorDeNInvalidoException e)
        {
            Console.WriteLine("Excecao detectada: " + e.Message);
        }
    }
}