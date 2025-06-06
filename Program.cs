using System;
using System.Linq;

class Program
{
    static Random random = new Random();

    // Função para rolar 4d6, descartando o menor valor
    static int RolarAtributo()
    {
        // Rolar 4 dados de 6 faces
        int[] dados = new int[4];
        for (int i = 0; i < 4; i++)
        {
            dados[i] = random.Next(1, 7);
        }

        // Ordenar os dados e descartar o menor
        Array.Sort(dados);
        return dados[1] + dados[2] + dados[3]; // Soma dos 3 maiores
    }

    // Função para calcular o modificador do atributo
    static int CalcularModificador(int atributo)
    {
        return (atributo - 10) / 2; // Modificador é (valor - 10) / 2
    }

    static void Main(string[] args)
    {
        int[] atributos = new int[6]; // Para armazenar os 6 atributos

        // Gerar os 6 atributos
        for (int i = 0; i < 6; i++)
        {
            int atributo;
            do
            {
                atributo = RolarAtributo();
            } while (atributo < 7); // Repetir até que o valor seja 7 ou mais

            atributos[i] = atributo;
        }

        // Exibir os atributos e modificadores
        for (int i = 0; i < 6; i++)
        {
            int modificador = CalcularModificador(atributos[i]);
            Console.WriteLine($"Atributo {i + 1}: {atributos[i]} (Modificador: {modificador})");
        }

        // Encontrar o maior e o menor atributo
        int maiorAtributo = atributos.Max();
        int menorAtributo = atributos.Min();

        // Exibir o maior e o menor atributo
        Console.WriteLine($"\nMaior atributo: {maiorAtributo}");
        Console.WriteLine($"Menor atributo: {menorAtributo}");
    }
}