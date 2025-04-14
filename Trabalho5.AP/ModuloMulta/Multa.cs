using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabalho5.AP.ModuloEmprestimo;

namespace Trabalho5.AP.ModuloMulta
{
    public class Multa
    {
        public int Id {  get; set; }
        public int QuantidadeAPagar { get; set; }
        public string SituacaoAtual { get; set; }
        public Emprestimo Emprestimo { get; set; }
        public Multa(int quantidadeAPagar, string situacaoAtual, Emprestimo emprestimo)
        {
            QuantidadeAPagar = quantidadeAPagar;
            SituacaoAtual = situacaoAtual;
            Emprestimo = emprestimo;
        }
    }
}