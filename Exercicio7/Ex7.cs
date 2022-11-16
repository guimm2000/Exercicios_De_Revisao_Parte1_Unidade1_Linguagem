using System;
using System.Text.RegularExpressions;

public class Cliente
{
    public string Nome { get; private set; }
    public long CPF { get; private set; }
    public DateTime DataDeNascimento { get; private set; }
    public float RendaMensal { get; private set; }
    public char EstadoCivil { get; private set; }
    public int Dependentes { get; private set; }

    public Cliente(string nome, string cpf, string dataDeNascimento, string rendaMensal, string estadoCivil, string dependentes)
    {
        //Criando expressoes regulares para verificar a formatacao da string e checando as excecoes
        Regex regexData = new Regex(@"^\d{2}\/\d{2}\/\d{4}");
        Regex regexRenda = new Regex(@"^\d+\,{1}\d{2}");
        if(nome.Length < 5)
        {
            throw new ClienteException("Nome deve conter pelo menos 5 caracteres!");
        }

        if(cpf.Length != 11)
        {
            throw new ClienteException("CPF deve conter exatamente 11 caracteres!");
        }

        if(!regexData.IsMatch(dataDeNascimento))
        {
            throw new ClienteException("Data de nascimente em formato invalido!");
        }

        //Checando a idade
        DateTime datatemp = DateTime.ParseExact(dataDeNascimento, "dd/MM/yyyy", null);
        int idade = DateTime.Now.Year - datatemp.Year;
        
        if(DateTime.Now.Month > datatemp.Month)
        {
            idade--;
        }
        else
        {
            if(DateTime.Now.Month == datatemp.Month)
            {
                if(DateTime.Now.Day > datatemp.Day)
                {
                    idade--;
                }
            }
        }

        if(idade < 18) 
        {
            throw new ClienteException("Idade deve ser maior que 18 anos!");
        }

        if(!regexRenda.IsMatch(rendaMensal))
        {
            throw new ClienteException("Renda Invalida!");
        }

        if(!estadoCivil.Equals("C") && !estadoCivil.Equals("S") && !estadoCivil.Equals("V") && !estadoCivil.Equals("D")) {
            throw new ClienteException("Estado Civil invalido!");
        }

        if(int.Parse(dependentes) > 10 || int.Parse(dependentes) < 0)
        {
            throw new ClienteException("O total de dependentes nao pode ser menor que 0 ou maior que 10!");
        }

        Nome = nome;
        CPF = long.Parse(cpf);
        DataDeNascimento = DateTime.ParseExact(dataDeNascimento, "dd/MM/yyyy", null);
        //Trocando a virgula por ponto para o funcionamento da variavel float de forma adequada
        RendaMensal = float.Parse(Regex.Replace(rendaMensal, ",", "."));
        EstadoCivil = char.Parse(estadoCivil);
        Dependentes = int.Parse(dependentes);

        //Imprimindo os dados
        this.Imprime();
    }

    public void Imprime()
    {
        Console.WriteLine("\nNome: " + Nome);
        Console.WriteLine("CPF: " + CPF);
        Console.WriteLine("Data de nascimento: " + DataDeNascimento.ToString("dd/MM/yyyy"));
        //Trocando o ponto para virgula para facilitar a leitura
        Console.WriteLine("Renda Mensal: " + Regex.Replace(RendaMensal.ToString("0.00"), "\\.", ","));
        Console.WriteLine("Estado Civil: " + EstadoCivil);
        Console.WriteLine("Dependentes: " + Dependentes);
    }
}

public class ClienteException : Exception
{
    public ClienteException(String message) 
        :base(message)
    { 

    }
}

public class MainClass
{
    public static void Main(string[] args)
    {
        bool continuar = true;
        //Executando um loop para que possa digitar novamente em caso de informacao errada
        while(continuar) 
        { 
            try
            {
                Console.WriteLine("Digite seu nome:");
                string nome = Console.ReadLine();

                Console.WriteLine("Digite seu CPF(Sem espacos, sem ponto e sem hifen):");
                string cpf = Console.ReadLine();

                Console.WriteLine("Digite sua data de nascimento(Formato dd/mm/aaaa):");
                string data = Console.ReadLine();

                Console.WriteLine("Digite sua renda mensal(Com duas casas decimais e separa por virgula):");
                string renda = Console.ReadLine();

                Console.WriteLine("Digite seu estado civil(C, S, V, D):");
                string estadocivil = Console.ReadLine();

                Console.WriteLine("Digite o total de dependentes(De 0 a 10):");
                string dependentes = Console.ReadLine();

                Cliente c = new Cliente(nome, cpf, data, renda, estadocivil.ToUpper(), dependentes);
                continuar = false;
            }
            catch (ClienteException e)
            {
                Console.WriteLine();
                Console.WriteLine(e.Message);
                Console.WriteLine("Tente Novamente\n\n");
            }
        } 
    }
}