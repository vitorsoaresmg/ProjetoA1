using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoA1
{
    internal class Despesa
    {
        private string _nomeDespesa;
        private double _valorDespesa;
        private int _dataVencimento;

        private static List<Despesa> _listaDespesas = new List<Despesa>();

        public Despesa(string nome, double valor, int vencimento)
        {
            _nomeDespesa = nome;
            _valorDespesa = valor;
            _dataVencimento = vencimento;
        }

        public static void AdicionarDespesa()
        {
            bool adicionarMaisDespesas = true;

            while (adicionarMaisDespesas)
            {
                Console.Write("Nome da despesa: ");
                string nome = Console.ReadLine().ToUpper();

                Console.Write("Valor da despesa: ");
                double valor = double.Parse(Console.ReadLine());

                Console.Write("Data de vencimento da despesa: ");
                int vencimento = int.Parse(Console.ReadLine());

                _listaDespesas.Add(new Despesa(nome, valor, vencimento));

                Console.Write("Deseja adicionar mais despesas? (S/N): ");
                adicionarMaisDespesas = Console.ReadLine().ToUpper() == "S";
            }
        }

        public static void RemoverDespesa()
        {
            Console.Write("Digite o nome da despesa a ser removida: ");
            string nome = Console.ReadLine();
            Console.WriteLine();

            Despesa despesaRemover = _listaDespesas.FirstOrDefault(d => d._nomeDespesa == nome);
            if (despesaRemover != null)
            {
                _listaDespesas.Remove(despesaRemover);
                Console.WriteLine($"Despesa '{nome}' removida com sucesso!");
            }
            else
            {
                Console.WriteLine($"Despesa '{nome}' não encontrada!");
            }
        }

        public static List<Despesa> ListarDespesas()
        {
            List<Despesa> despesasOrdenadas = _listaDespesas.OrderBy(d => d._valorDespesa).ToList();

            Console.WriteLine("Lista de Despesas Ordenadas por Valor:");
            foreach (var despesa in despesasOrdenadas)
            {
                Console.WriteLine($"Nome: {despesa._nomeDespesa}, Valor: {despesa._valorDespesa.ToString("C2")}, Vencimento: dia {despesa._dataVencimento}");
            }

            return despesasOrdenadas;
        }

        
    }
}

