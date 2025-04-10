using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho5.AP.ModuloCaixa
{
    public class Caixa
    {
        public int Id { get; set; }
        public string Etiqueta { get; set; }
        public string Cor { get; set; }
        public DateTime DiasDeEmprestimo { get; set; }
        public Caixa(string etiqueta, string cor, DateTime diasDeEmprestimo)
        {
            Etiqueta = etiqueta;
            Cor = cor;
            DiasDeEmprestimo = diasDeEmprestimo;
        }
    }
}