using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace MonitoramentoSensores
{
    class Program
    {
        static async Task Main(string[] args)
        {
            List<Sensor> sensores = new List<Sensor>
            {
                new Sensor(),
                new Sensor(),
                new Sensor()
            };

            while (true)
            {
                foreach (var sensor in sensores)
                {
                    sensor.AtualizarValor();
                    Console.WriteLine(sensor);
                }

                await Task.Delay(5000); // Espera 5 segundos antes de atualizar novamente
            }
        }
    }

    public class Sensor
    {
        private static readonly Random Random = new Random();
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Tipo { get; private set; }
        public double ValorAtual { get; private set; }

        private static string[] tiposDisponiveis = { "Temperatura", "Pressão", "Umidade" };
        private static string[] nomesBase = { "Alpha", "Beta", "Gamma", "Delta", "Epsilon" };

        public Sensor()
        {
            Id = Random.Next(1000, 9999);
            Nome = $"Sensor {nomesBase[Random.Next(nomesBase.Length)]}";
            Tipo = tiposDisponiveis[Random.Next(tiposDisponiveis.Length)];
        }

        public void AtualizarValor()
        {
            switch (Tipo.ToLower())
            {
                case "temperatura":
                    ValorAtual = Random.Next(20, 100) + Random.NextDouble();
                    break;
                case "pressão":
                    ValorAtual = Random.Next(1, 10) + Random.NextDouble();
                    break;
                case "umidade":
                    ValorAtual = Random.Next(30, 90) + Random.NextDouble();
                    break;
                default:
                    ValorAtual = 0;
                    break;
            }
        }

        public override string ToString()
        {
            return $"[Sensor ID: {Id}] {Nome} ({Tipo}) -> Valor Atual: {ValorAtual:F2}";
        }
    }
}