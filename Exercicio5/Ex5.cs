using System;
using System.Reflection.Metadata;

namespace IntervaloNamespace
{
    public class Intervalo
    {
        public readonly DateTime dataHoraInicial;
        public readonly DateTime dataHoraFinal;

        public Intervalo(DateTime dataHoraInicial, DateTime dataHoraFinal)
        {
            if (dataHoraInicial > dataHoraFinal)
            {
                throw new ErroDeData("Data inicial nao pode ser antes da data final!");
            }

            this.dataHoraInicial = dataHoraInicial;
            this.dataHoraFinal = dataHoraFinal;
        }

        public bool TemIntersecao(Intervalo i)
        {
            if (this.dataHoraInicial <= i.dataHoraFinal && this.dataHoraFinal >= i.dataHoraInicial)
            {
                return true;
            }
            return false;
        }

        public bool Igual(Intervalo i)
        {
            return (this.dataHoraInicial == i.dataHoraInicial && this.dataHoraFinal == i.dataHoraFinal);
        }

        public TimeSpan Duracao()
        {
            return this.dataHoraFinal - this.dataHoraInicial;
        }
    }

    public class ErroDeData : Exception
    {
        public ErroDeData(String message)
            : base(message)
        {
        }
    }

    public class MainClass
    {
        public static void Main(string[] args)
        {
            DateTime agora = DateTime.Now;
            DateTime mesQueVem = agora.AddDays(30);
            
            Intervalo teste = new Intervalo(agora, mesQueVem);
            Console.WriteLine(teste.Duracao());
        }
    }
}