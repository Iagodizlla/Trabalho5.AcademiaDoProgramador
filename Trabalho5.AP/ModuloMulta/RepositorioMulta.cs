using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabalho5.AP.Compartilhado;
using Trabalho5.AP.ModuloEmprestimo;

namespace Trabalho5.AP.ModuloMulta
{
    public class RepositorioMulta
    {
        public Multa[] multas = new Multa[100];
        public int contadorMultas = 0;
        public void AdicionarMulta(Multa multa)
        {
            multa.Id = GeradorId.GerarIdMulta();
            multas[contadorMultas++] = multa;
        }
    }
}