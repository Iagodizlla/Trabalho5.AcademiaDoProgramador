using Trabalho5.AP.ModuloAmigo;
using Trabalho5.AP.ModuloRevista;
using Trabalho5.AP.Compartilhado;

namespace Trabalho5.AP.ModuloEmprestimo;

public class Emprestimo : EntidadeBase<Emprestimo>
{
    public Amigo Amigo { get; set; }
    public Revista Revista { get; set; }
    public DateTime DataFinal { get; set; }
    public string Situacao { get; set; }
    public int Multa { get; set; }
    public Emprestimo(Amigo amigo, Revista revista, string situacao, DateTime dataFinal, int multa)
    {
        Amigo = amigo;
        Revista = revista;
        Situacao = situacao;
        DataFinal = dataFinal;
        Multa = multa;
    }
    public override string Validar()
    {
        string erros = "";

        if (Situacao.Length < 5)
            erros += "O campo 'Situacao' precisa conter ao menos 5 caracteres.\n";

        if (Amigo == null)
            erros += "O campo 'Amigo' é obrigatório.\n";

        if (Revista == null)
            erros += "O campo 'Revista' é obrigatório.\n";

        return erros;
    }
    public override void AtualizarRegistro(Emprestimo registroAtualizado)
    {
        Emprestimo emprestimoAtualizado = (Emprestimo)registroAtualizado;

        Amigo = emprestimoAtualizado.Amigo;
        Revista = emprestimoAtualizado.Revista;
    }
}