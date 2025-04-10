using Trabalho5.AP.Compartilhado;

namespace Trabalho5.AP.ModuloAmigo;

public class TelaAmigo
{
    RepositorioAmigo repositorioAmigo;
    public TelaAmigo(RepositorioAmigo repositorioAmigo)
    {
        this.repositorioAmigo = repositorioAmigo;
    }

    public char MostrarMenu()
    {
        Console.Clear();
        Console.WriteLine("Menu de Amigos");
        Console.WriteLine("1. Adicionar Amigo");
        Console.WriteLine("2. Remover Amigo");
        Console.WriteLine("3. Listar Amigos");
        Console.WriteLine("4. Editar Amigo");
        Console.WriteLine("S. Voltar");
        Console.Write("Escolha uma opção: ");

        char opcao = Console.ReadLine()!.ToUpper()[0];
        return opcao;
    }
    public void Inserir()
    {
        Console.Clear();
        Console.WriteLine("Adicionar Amigo");
        Console.Write("Nome: ");
        string nome = Console.ReadLine()!;
        Console.Write("Telefone: ");
        string telefone = Console.ReadLine()!;
        Console.Write("Responsável: ");
        string responsavel = Console.ReadLine()!;

        Amigo amigo = new Amigo(nome, telefone, responsavel);
        repositorioAmigo.AdicionarAmigo(amigo);
    }
    public void RemoverAmigo()
    {
        Console.Clear();
        Console.WriteLine("Remover Amigo");
        ListarAmigos();
        Console.Write("ID: ");
        int id = Convert.ToInt16(Console.ReadLine()!);
        Amigo amigo = repositorioAmigo.BuscarAmigo(id);
        if (amigo != null)
        {
            repositorioAmigo.RemoverAmigo(amigo);
            Console.WriteLine("Amigo removido com sucesso!");
        }
        else
        {
            Console.WriteLine("Amigo não encontrado.");
        }
    }
    public void ListarAmigos()
    {
        Console.Clear();
        Console.WriteLine("Lista de Amigos");
        Amigo[] amigos = repositorioAmigo.ListarAmigos();
        Console.WriteLine(
            "{0, -6} | {1, -20} | {2, -20} | {3, -20}",
            "ID", "Nome", "Telefone", "Responsável"
            );
        for (int i = 0; i < amigos.Length; i++)
        {
            if (amigos[i] == null) continue;
            Console.WriteLine(
                "{0, -6} | {1, -20} | {2, -20} | {3, -20}",
                amigos[i].Id, amigos[i].Nome, amigos[i].Telefone, amigos[i].Responsavel
            );
        }
    }
    public void EditarAmigo()
    {
        Console.Clear();
        Console.WriteLine("Editar Amigo");
        ListarAmigos();
        Console.Write("ID: ");
        int id = Convert.ToInt16(Console.ReadLine()!);
        Amigo amigo = repositorioAmigo.BuscarAmigo(id);
        if (amigo != null)
        {
            Console.Write("Novo Nome: ");
            string novoNome = Console.ReadLine()!;
            Console.Write("Novo Telefone: ");
            string novoTelefone = Console.ReadLine()!;
            Console.Write("Novo Responsável: ");
            string novoResponsavel = Console.ReadLine()!;

            repositorioAmigo.EditarAmigo(amigo, novoNome, novoTelefone, novoResponsavel);
            Console.WriteLine("Amigo editado com sucesso!");
        }
        else
        {
            Console.WriteLine("Amigo não encontrado.");
        }
    }
}