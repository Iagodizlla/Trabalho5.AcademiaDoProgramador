namespace Trabalho5.AP.ModuloAmigo;

public class TelaAmigo
{
    RepositorioAmigo repositorioAmigo;
    public TelaAmigo(RepositorioAmigo repositorioAmigo)
    {
        this.repositorioAmigo = repositorioAmigo;
    }
    public void CadastrarAmigo()
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
        string erros = amigo.Validar();
        erros += repositorioAmigo.ValidarAmigo(nome, telefone);
        if (erros.Length > 0)
        {
            Console.WriteLine(erros);
            Console.ReadLine();
            CadastrarAmigo();

            return;
        }
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
        if(amigo.Emprestimos.Length > 0)
        {
            Console.WriteLine("Amigo não pode ser removido, pois possui empréstimos ativos.");
            Console.ReadLine();
            return;
        }
        if (amigo != null)
        {
            repositorioAmigo.RemoverAmigo(amigo);
            Console.WriteLine("Amigo removido com sucesso!");
        }
        else
        {
            Console.WriteLine("Amigo não encontrado.");
        }
        Console.ReadLine();
    }
    public void ListarAmigos()
    {
        Console.Clear();
        Console.WriteLine("Lista de Amigos");
        Console.WriteLine("-----------------");
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
        Console.ReadLine();
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
        Console.ReadLine();
    }
}