using System;
using System.Collections.Generic;

namespace ProgramacaoDinamica
{
    public class Navio
    {
        public int Largura { get; set; }
        public int Comprimento { get; set; }

        public Navio(int largura, int comprimento)
        {
            Largura = largura;
            Comprimento = comprimento;
        }
    }

    public class Container
    {
        public int Largura { get; set; }
        public int Comprimento { get; set; }

        public Container(int largura, int comprimento)
        {
            Largura = largura;
            Comprimento = comprimento;
        }
    }

    public class BinPackingDP
    {
        public static int Resolver(Navio navio, List<Container> containers)
        {
            // Matriz de soluções
            int[,] solucoes = new int[navio.Largura + 1, navio.Comprimento + 1];

            // Preenchendo a matriz de soluções
            for (int i = 0; i <= navio.Largura; i++)
            {
                for (int j = 0; j <= navio.Comprimento; j++)
                {
                    // Se o navio estiver vazio, a solução é 0
                    if (i == 0 || j == 0)
                    {
                        solucoes[i, j] = 0;
                    }
                    // Se o container não cabe no navio, a solução é a mesma da célula anterior
                    else if (containers[i].Largura > i || containers[i].Comprimento > j)
                    {
                        solucoes[i, j] = solucoes[i - 1, j];
                    }
                    // Se o container cabe no navio, a solução é a menor entre:
                    // 1 - A solução da célula anterior
                    // 2 - A solução da célula (i - containers[i].Largura, j - containers[i].Comprimento) + 1 (adicionando o container)
                    else
                    {
                        solucoes[i, j] = Math.Min(solucoes[i - 1, j], solucoes[i - containers[i].Largura, j - containers[i].Comprimento] + 1);
                    }
                }
            }

            // Retorna a solução
            return solucoes[navio.Largura, navio.Comprimento];
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Navio
            Navio navio = new Navio(10, 10);

            // Containers
            List<Container> containers = new List<Container>();
            containers.Add(new Container(5, 5));
            containers.Add(new Container(3, 3));
            containers.Add(new Container(2, 2));

            // Resolvendo o problema
            int solucao = BinPackingDP.Resolver(navio, containers);

            // Imprimindo a solução
            Console.WriteLine("Solução: {0}", solucao);
        }
    }
}
