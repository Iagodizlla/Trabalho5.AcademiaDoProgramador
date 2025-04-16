using Trabalho5.AP.ModuloAmigo;
using Trabalho5.AP.ModuloRevista;

namespace Trabalho5.AP.ModuloEmprestimo;

public class Emprestimo
{
    public int Id { get; set; }
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
    public string Validar()
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
}