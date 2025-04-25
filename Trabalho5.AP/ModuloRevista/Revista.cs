using Trabalho5.AP.Compartilhado;
using Trabalho5.AP.ModuloCaixa;

namespace Trabalho5.AP.ModuloRevista;

public class Revista : EntidadeBase<Revista>
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
    public override string Validar()
    {
        string erros = "";

        if (Titulo.Length < 3)
            erros += "O campo 'Titulo' precisa conter ao menos 3 caracteres.\n";

        if (Titulo.Length > 100)
            erros += "O campo 'Titulo' precisa conter ao maximo 100 caracteres.\n";

        if (StatusEmprestimo.Length < 5)
            erros += "O campo 'Status de Emprestimo' precisa conter ao menos 5 caracteres.\n";

        if (Caixa == null)
            erros += "O campo 'Caixa' é obrigatório.\n";

        if (NumeroEdicao < 0)
            erros += "O campo 'Numero de Edicao' deve ser positivo.";

        return erros;
    }
    public override void AtualizarRegistro(Revista registroAtualizado)
    {
        Revista revistaAtualizado = (Revista)registroAtualizado;

        Titulo = revistaAtualizado.Titulo;
        NumeroEdicao = revistaAtualizado.NumeroEdicao;
        Caixa = revistaAtualizado.Caixa;
        AnoPublicacao = revistaAtualizado .AnoPublicacao;
    }
}