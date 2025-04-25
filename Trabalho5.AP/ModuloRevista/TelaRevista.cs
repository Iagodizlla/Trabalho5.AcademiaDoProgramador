using Trabalho5.AP.Compartilhado;
using Trabalho5.AP.ModuloCaixa;
using Trabalho5.AP.Util;
using System.Collections;

namespace Trabalho5.AP.ModuloRevista;

public class TelaRevista : TelaBase
{
    RepositorioRevista repositorioRevista;
    RepositorioCaixa repositorioCaixa;
    public TelaRevista(RepositorioRevista repositorioRevista, RepositorioCaixa repositorioCaixa) : base("Revista", repositorioRevista)
    {
        this.repositorioRevista = repositorioRevista;
        this.repositorioCaixa = repositorioCaixa;
    }
    public override EntidadeBase ObterDados()
    {
        Console.Write("Titulo: ");
        string titulo = Console.ReadLine()!;

        string statusEmprestimo = repositorioRevista.EditarSituacao();

        Console.Write("Numero de edicao: ");
        int numeroEdicao = Convert.ToInt32(Console.ReadLine()!);

        Console.Write("Data de publicacao: ");
        DateTime anoPublicacao = Convert.ToDateTime(Console.ReadLine()!);

        VisualizarCaixas();
        Console.Write("Id da Caixa: ");
        int idCaixa = Convert.ToInt16(Console.ReadLine()!);
        Caixa caixaSelecionado = (Caixa)repositorioCaixa.SelecionarRegistroPorId(idCaixa);


        Revista revista = new Revista(titulo, statusEmprestimo, caixaSelecionado, numeroEdicao, anoPublicacao);

        return revista;
    }
    public override void CadastrarRegistro()
    {
        ExibirCabecalho();

        Console.WriteLine();

        Console.WriteLine("Cadastrando Revista...");
        Console.WriteLine("--------------------------------------------");

        Console.WriteLine();

        Revista novoRevista = (Revista)ObterDados();

        string erros = novoRevista.Validar();

        if (erros.Length > 0)
        {
            Notificador.ExibirMensagem(erros, ConsoleColor.Red);
            CadastrarRegistro();
            return;
        }

        repositorioRevista.CadastrarRegistro(novoRevista);

        Notificador.ExibirMensagem("O registro foi concluído com sucesso!", ConsoleColor.Green);
    }
    public override void EditarRegistro()
    {
        ExibirCabecalho();

        Console.WriteLine();

        Console.WriteLine("Editando Revista...");
        Console.WriteLine("--------------------------------------------");

        VisualizarRegistros(false);

        Console.Write("Digite o ID do registro que deseja selecionar: ");
        int idSelecionado = Convert.ToInt32(Console.ReadLine());

        Revista revistaAntigo = (Revista)repositorioRevista.SelecionarRegistroPorId(idSelecionado);

        Console.WriteLine();

        Revista revistaEditado = (Revista)ObterDados();

        bool conseguiuEditar = repositorioRevista.EditarRegistro(idSelecionado, revistaEditado);

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

        Console.WriteLine("Excluindo Revista...");
        Console.WriteLine("--------------------------------------------");

        VisualizarRegistros(false);

        Console.Write("Digite o ID do registro que deseja selecionar: ");
        int idSelecionado = Convert.ToInt32(Console.ReadLine());

        Revista amigoSelecionado = (Revista)repositorioRevista.SelecionarRegistroPorId(idSelecionado);

        bool conseguiuExcluir = repositorioRevista.ExcluirRegistro(idSelecionado);

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

        Console.WriteLine("Visualizando Revistas...");
        Console.WriteLine("--------------------------------------------");

        Console.WriteLine();

        Console.WriteLine(
            "{0, -6} | {1, -20} | {2, -15} | {3, -15} | {4, -20} | {5, -20}",
            "ID", "titulo", "Status", "Numero Edicao", "Ano Publicacao", "Etiqueta Caixa"
            );

        List<EntidadeBase> registros = repositorioRevista.SelecionarRegistros();

        foreach(Revista revistas in registros)
        {
            Console.WriteLine(
                "{0, -6} | {1, -20} | {2, -15} | {3, -15} | {4, -20} | {5, -20}",
                revistas.Id, revistas.Titulo, revistas.StatusEmprestimo, revistas.NumeroEdicao, revistas.AnoPublicacao.Year, revistas.Caixa.Etiqueta
            );
        }

        Console.WriteLine();

        Notificador.ExibirMensagem("Pressione ENTER para continuar...", ConsoleColor.DarkYellow);
    }
    public void VisualizarCaixas()
    {
        Console.WriteLine();

        Console.WriteLine("Visualizando Caixas...");
        Console.WriteLine("--------------------------------------------");

        Console.WriteLine();

        Console.WriteLine(
            "{0, -6} | {1, -20} | {2, -20} | {3, -20}",
            "ID", "Etiqueta", "Dias de Emprestimo", "Cor"
            );

        List<EntidadeBase> registros = repositorioCaixa.SelecionarRegistros();

        foreach(Caixa c in registros)
        {
            Console.WriteLine(
                "{0, -6} | {1, -20} | {2, -20} | {3, -20}",
                c.Id, c.Etiqueta, c.DiasDeEmprestimo, c.Cor
            );
        }

        Console.WriteLine();

        Notificador.ExibirMensagem("Pressione ENTER para continuar...", ConsoleColor.DarkYellow);
    }
}