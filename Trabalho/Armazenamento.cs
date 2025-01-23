using System;
using System.Collections.Generic;

namespace MonitoramentoSensores
{
    public class RepositorioDeDados
    {
        private List<string> historico = new List<string>();

        public void AdicionarRegistro(string registro)
        {
            historico.Add(registro);
        }

        public void ExibirHistorico()
        {
            foreach (var registro in historico)
            {
                Console.WriteLine(registro);
            }
        }
    }
}