using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guloso
{
    // Classe para representar um container
    class Container
    {
        public int largura { get; set; }
        public int altura { get; set; }
    }

    // Classe para representar um navio
    class Navio
    {
        public int largura { get; set; }
        public int altura { get; set; }
        public int capacidade { get; set; }
        public List<Container> containers { get; set; }

        public Navio(int largura, int altura, int capacidade)
        {
            this.largura = largura;
            this.altura = altura;
            this.capacidade = capacidade;
            this.containers = new List<Container>();
        }
    }

    // Função para resolver o problema de bin packing com paradigma guloso
    class Program
    {
        static void Main(string[] args)
        {
            // Cria um navio
            Navio navio = new Navio(100, 50, 1000);

            // Cria uma lista de containers
            List<Container> containers = new List<Container>();
            containers.Add(new Container { largura = 50, altura = 25 });
            containers.Add(new Container { largura = 25, altura = 25 });
            containers.Add(new Container { largura = 25, altura = 25 });

            // Resolve o problema de bin packing
            List<Container> solucao = binPacking(navio, containers);

            // Imprime a solução
            foreach (Container container in solucao)
            {
                Console.WriteLine("Largura: {0}, Altura: {1}, Tamanho: {2}", container.largura, container.altura, container.largura * container.altura);
            }
        }

        // Função para resolver o problema de bin packing com paradigma guloso
        public static List<Container> binPacking(Navio navio, List<Container> containers)
        {
            // Ordena os containers pelo tamanho, do menor para o maior
            containers.Sort((a, b) => a.largura * a.altura - b.largura * b.altura);

            // Adiciona os containers ao navio, um a um
            for (int i = 0; i < containers.Count; i++)
            {
                // Verifica se o container cabe no navio
                if (navio.largura >= containers[i].largura && navio.altura >= containers[i].altura)
                {
                    navio.containers.Add(containers[i]);
                    navio.largura -= containers[i].largura;
                    navio.altura -= containers[i].altura;
                }
            }

            return navio.containers;
        }
    }
}

