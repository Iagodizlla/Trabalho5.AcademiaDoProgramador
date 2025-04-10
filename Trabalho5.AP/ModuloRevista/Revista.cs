using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabalho5.AP.ModuloCaixa;

namespace Trabalho5.AP.ModuloRevista
{
    internal class Revista
    {
        public string Titulo { get; set; }
        public string StatusEmprestimo { get; set; }
        public Caixa Caixa { get; set; }
        public int NumeroEdicao { get; set; }
        public DateTime AnoPublicacao { get; set; }
    }
}