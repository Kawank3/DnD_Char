using System;
using System.Linq;

class Program
{
    static Random random = new Random();

    static void Main(string[] args)
    {
        string[] nomesAtributos = {
            "Força", "Destreza", "Constituição", "Inteligência", "Sabedoria", "Carisma"
        };

        int[] atributos = new int[6];

        for (int i = 0; i < 6; i++)
        {
            int atributo;
            do
            {
                atributo = RolarAtributo();
            } while (atributo < 7);

            atributos[i] = atributo;
        }

        for (int i = 0; i < 6; i++)
        {
            int modificador = CalcularModificador(atributos[i]);
            string sinal = modificador >= 0 ? "+" : "";
            Console.WriteLine($"{nomesAtributos[i]}: {atributos[i]} (Modificador: {sinal}{modificador})");
        }

        int maiorAtributo = atributos.Max();
        int menorAtributo = atributos.Min();

        Console.WriteLine($"\nMaior atributo: {maiorAtributo}");
        Console.WriteLine($"Menor atributo: {menorAtributo}");
    }

    static int RolarAtributo()
    {
        int[] dados = new int[4];
        for (int i = 0; i < 4; i++)
        {
            dados[i] = random.Next(1, 7);
        }

        Array.Sort(dados);
        return dados[1] + dados[2] + dados[3];
    }

    static int CalcularModificador(int atributo)
    {
        return (atributo - 10) / 2;
    }
}
