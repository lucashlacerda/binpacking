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
            bins.Add(new Bin(navio.Largura, navio.Comprimento));

            // Para cada container restante
            for (int i = 1; i < containers.Count; i++)
            {
                // Encontra o bin que cabe no container
                foreach (var bin in bins)
                {
                    if (bin.Largura >= containers[i].Largura && bin.Comprimento >= containers[i].Comprimento)
                    {
                        bin.AddContainer(containers[i]);
                        break;
                    }
                }
            }

            // Retorna o número total de bins usados
            return bins.Count;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Exemplo de uso
            var navio = new Navio(100, 200);
            var containers = new List<Container>
            {
                new Container(50, 80),
                new Container(60, 90),
                // Adicione mais containers aqui conforme necessário
            };

            int numeroDeBins = BinPackingFFD.Resolver(navio, containers);
            Console.WriteLine($"Número de bins usados: {numeroDeBins}");
            Console.ReadLine();
        }
    }
}
