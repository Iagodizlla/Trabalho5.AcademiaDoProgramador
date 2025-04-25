using System.Collections;
using Trabalho5.AP.Compartilhado;
using Trabalho5.AP.Util;

namespace Trabalho5.AP.ModuloAmigo;

public class TelaAmigo : TelaBase<Amigo>
{
    RepositorioAmigo repositorioAmigo;
    public TelaAmigo(RepositorioAmigo repositorioAmigo) : base("Amigo", repositorioAmigo)
    {
        this.repositorioAmigo = repositorioAmigo;
    }
    public override void CadastrarRegistro()
    {
        ExibirCabecalho();

        Console.WriteLine();

        Console.WriteLine("Cadastrando Amigo...");
        Console.WriteLine("--------------------------------------------");

        Console.WriteLine();

        Amigo novoAmigo = (Amigo)ObterDados();

        string erros = novoAmigo.Validar();

        if (erros.Length > 0)
        {
            Notificador.ExibirMensagem(erros, ConsoleColor.Red);

            CadastrarRegistro();

            return;
        }

        repositorioAmigo.CadastrarRegistro(novoAmigo);

        Notificador.ExibirMensagem("O registro foi concluído com sucesso!", ConsoleColor.Green);
    }
    public override Amigo ObterDados()
    {
        Console.WriteLine("Adicionar Amigo");
        Console.Write("Nome: ");
        string nome = Console.ReadLine()!;
        Console.Write("Telefone: ");
        string telefone = Console.ReadLine()!;
        Console.Write("Responsável: ");
        string responsavel = Console.ReadLine()!;


        Amigo amigo = new Amigo(nome, telefone, responsavel);

        return amigo;
    }
    public override void EditarRegistro()
    {
        ExibirCabecalho();

        Console.WriteLine();

        Console.WriteLine("Editando Amigo...");
        Console.WriteLine("--------------------------------------------");

        VisualizarRegistros(false);

        Console.Write("Digite o ID do registro que deseja selecionar: ");
        int idSelecionado = Convert.ToInt32(Console.ReadLine());

        Amigo amigoAntigo = (Amigo)repositorioAmigo.SelecionarRegistroPorId(idSelecionado);

        Console.WriteLine();

        Amigo amigoEditado = (Amigo)ObterDados();

        bool conseguiuEditar = repositorioAmigo.EditarRegistro(idSelecionado, amigoEditado);

        if (!conseguiuEditar)
        {
            Notificador.ExibirMensagem("Houve um erro durante a edição de um registro...", ConsoleColor.Red);

            return;
        }

        Notificador.ExibirMensagem("O registro foi editado com sucesso!", ConsoleColor.Green);
    }
    public override void ExcluirRegistro()
    {
        ExibirCabecalho();

        Console.WriteLine();

        Console.WriteLine("Excluindo Amigo...");
        Console.WriteLine("--------------------------------------------");

        VisualizarRegistros(false);

        Console.Write("Digite o ID do registro que deseja selecionar: ");
        int idSelecionado = Convert.ToInt32(Console.ReadLine());

        Amigo amigoSelecionado = (Amigo)repositorioAmigo.SelecionarRegistroPorId(idSelecionado);

        bool conseguiuExcluir = repositorioAmigo.ExcluirRegistro(idSelecionado);

        if (!conseguiuExcluir)
        {
            Notificador.ExibirMensagem("Houve um erro durante a exclusão de um registro...", ConsoleColor.Red);

            return;
        }

        Notificador.ExibirMensagem("O registro foi excluído com sucesso!", ConsoleColor.Green);
    }
    public override void VisualizarRegistros(bool exibirTitulo)
    {
        if (exibirTitulo)
            ExibirCabecalho();

        Console.WriteLine();

        Console.WriteLine("Visualizando Amigos...");
        Console.WriteLine("--------------------------------------------");

        Console.WriteLine();

        Console.WriteLine(
            "{0, -6} | {1, -20} | {2, -20} | {3, -20}",
            "ID", "Nome", "Telefone", "Responsável"
        );

        List<Amigo> registros = repositorioAmigo.SelecionarRegistros();

        foreach (var amigos in registros)
        {
            Console.WriteLine(
                "{0, -6} | {1, -20} | {2, -20} | {3, -20}",
                amigos.Id, amigos.Nome, amigos.Telefone, amigos.Responsavel
            );
        }

        Console.WriteLine();

        Notificador.ExibirMensagem("Pressione ENTER para continuar...", ConsoleColor.DarkYellow);
    }
}