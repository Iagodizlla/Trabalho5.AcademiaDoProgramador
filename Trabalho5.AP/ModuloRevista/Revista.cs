using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabalho5.AP.ModuloCaixa;

namespace Trabalho5.AP.ModuloRevista;

public class Revista
{
    public int Id { get; set; }
    public string Titulo { get; set; }
    public string StatusEmprestimo { get; set; }
    public Caixa Caixa { get; set; }
    public int NumeroEdicao { get; set; }
    public DateTime AnoPublicacao { get; set; }
    public Revista(string titulo, string statusEmprestimo, Caixa caixa, int numeroEdicao, DateTime anoPublicacao)
    {
        Titulo = titulo;
        StatusEmprestimo = statusEmprestimo;
        Caixa = caixa;
        NumeroEdicao = numeroEdicao;
        AnoPublicacao = anoPublicacao;
    }
}