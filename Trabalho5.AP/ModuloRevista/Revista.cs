using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
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
    public string Validar()
    {
        string erros = "";

        if (Titulo.Length < 3)
            erros += "O campo 'Titulo' precisa conter ao menos 3 caracteres.\n";

        if (StatusEmprestimo.Length < 5)
            erros += "O campo 'Status de Emprestimo' precisa conter ao menos 5 caracteres.\n";

        if (Caixa == null)
            erros += "O campo 'Caixa' é obrigatório.\n";

        if (NumeroEdicao < 5)
            erros += "O campo 'Numero de Edicao' deve seguir o formato 00000.";

        return erros;
    }
}