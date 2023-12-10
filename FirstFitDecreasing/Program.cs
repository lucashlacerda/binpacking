using System;
using System.Collections.Generic;

namespace BinPacking
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

        public class Bin
        {
            public int Largura { get; set; }
            public int Comprimento { get; set; }

            public List<Container> Containers { get; set; }

            public Bin(int largura, int comprimento)
            {
                Largura = largura;
                Comprimento = comprimento;
                Containers = new List<Container>();
            }

            public void AddContainer(Container container)
            {
                if (Largura >= container.Largura && Comprimento >= container.Comprimento)
                {
                    Containers.Add(container);
                }
            }
        }

        public class BinPackingFFD
        {
            public static int Resolver(Navio navio, List<Container> containers)
            {
                // Ordena os containers em ordem decrescente de tamanho
                containers.Sort((a, b) => b.Largura * b.Comprimento - a.Largura * a.Comprimento);

                // Lista de bins
                List<Bin> bins = new List<Bin>();

                // Adiciona o primeiro container em um novo bin
                bins.Add(new Bin(containers[0].Largura, containers[0].Comprimento));

                // Para cada container restante
                for (int i = 1; i < containers.Count; i++)
                {
                    // Encontra o bin que cabe no container
                    Bin bin = bins.Find(b => b.Largura >= containers[i].Largura && b.Comprimento >= containers[i].Comprimento);

                    // Se não encontrar nenhum bin, cria um novo
                    if (bin == null)
                    {
                        bin = new Bin(containers[i].Largura, containers[i].Comprimento);
                        bins.Add(bin);
                    }

                    // Adiciona o container ao bin
                    bin.AddContainer(containers[i]);
                }

                // Retorna a quantidade de bins
                return bins.Count;
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
                int solucao = BinPackingFFD.Resolver(navio, containers);

                // Imprimindo a solução
                Console.WriteLine("Solução: {0}", solucao);
            }
        }
    }
}
