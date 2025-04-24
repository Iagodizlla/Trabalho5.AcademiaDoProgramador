using Trabalho5.AP.Compartilhado;
using Trabalho5.AP.ModuloEmprestimo;
namespace Trabalho5.AP.ModuloAmigo;

public class Amigo : EntidadeBase
{
    public string Nome { get; set; }
    public string Telefone { get; set; }
    public string Responsavel { get; set; }
    public Emprestimo[] Emprestimos { get; set; }
    public Amigo(string nome, string telefone, string responsavel)
    {
        Nome = nome;
        Telefone = telefone;
        Responsavel = responsavel;
        Emprestimos = new Emprestimo[100];
    }
    public override void AtualizarRegistro(EntidadeBase registroAtualizado)
    {
        Amigo amigoAtualizado = (Amigo)registroAtualizado;

        Nome = amigoAtualizado.Nome;
        Telefone = amigoAtualizado.Telefone;
        Responsavel = amigoAtualizado.Responsavel;
    }
    public void AdicionarEmprestimo(Emprestimo emprestimo)
    {
        for (int i = 0; i < Emprestimos.Length; i++)
        {
            if (Emprestimos[i] == null)
            {
                Emprestimos[i] = emprestimo;
                break;
            }
        }
    }
    public void RemoverEmprestimo(Emprestimo emprestimo)
    {
        for (int i = 0; i < Emprestimos.Length; i++)
        {
            if (Emprestimos[i] == emprestimo)
            {
                Emprestimos[i] = null!;
                break;
            }
        }
    }
    public int ObterQuantidadeEmprestimos()
    {
        int contador = 0;

        for (int i = 0; i < Emprestimos.Length; i++)
        {
            if (Emprestimos[i] != null)
                contador++;
        }
        return contador;
    }
    public override string Validar()
    {
        string erros = "";

        if (Nome.Length < 3)
            erros += "O campo 'Nome' precisa conter ao menos 3 caracteres.\n";

        if (Nome.Length > 100)
            erros += "O campo 'Nome' precisa conter ao maximo 100 caracteres.\n";

        if (Responsavel.Length < 3)
            erros += "O campo 'Responsavel' precisa conter ao menos 3 caracteres.\n";

        if (Responsavel.Length > 100)
            erros += "O campo 'Responsavel' precisa conter ao maximo 100 caracteres.\n";

        if (Telefone.Length < 12)
            erros += "O campo 'Telefone' deve seguir o formato 00 0000-0000.";

        return erros;
    }
}