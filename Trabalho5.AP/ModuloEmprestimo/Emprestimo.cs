using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabalho5.AP.ModuloAmigo;
using Trabalho5.AP.ModuloCaixa;
using Trabalho5.AP.ModuloRevista;

namespace Trabalho5.AP.ModuloEmprestimo;

public class Emprestimo
{
    public int Id { get; set; }
    public Amigo Amigo { get; set; }
    public Revista Revista { get; set; }
    //public DateTime Data { get; set; }
    public string Situacao { get; set; }
    public Emprestimo(Amigo amigo, Revista revista/*, DateTime data*/, string situacao)
    {
        Amigo = amigo;
        Revista = revista;
        //Data = data;
        Situacao = situacao;
    }
}