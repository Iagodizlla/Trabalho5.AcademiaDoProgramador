using Trabalho5.AP.Compartilhado;
using Trabalho5.AP.ModuloAmigo;
using Trabalho5.AP.Util;

namespace Trabalho5.AP.ModuloCaixa;

public class TelaCaixa : TelaBase
{
    RepositorioCaixa repositorioCaixa;
    public TelaCaixa(RepositorioCaixa repositorioCaixa) : base("Caixa", repositorioCaixa)
    {
        this.repositorioCaixa = repositorioCaixa;
    }
    public override EntidadeBase ObterDados()
    {
        Console.WriteLine("Adicionar Caixa");
        Console.Write("Etiqueta: ");
        string etiqueta = Console.ReadLine()!;
        Console.Write("Cor: ");
        string cor = Console.ReadLine()!;
        Console.Write("Dias de emprestimo: ");
        int diasDeEmprestimo = Convert.ToInt16(Console.ReadLine()!);


        Caixa caixa = new Caixa(etiqueta, cor, diasDeEmprestimo);

        return caixa;
    }
    public override void CadastrarRegistro()
    {
        ExibirCabecalho();

        Console.WriteLine();

        Console.WriteLine("Cadastrando Caixa...");
        Console.WriteLine("--------------------------------------------");

        Console.WriteLine();

        Caixa novoCaixa = (Caixa)ObterDados();

        string erros = novoCaixa.Validar();

        if (erros.Length > 0)
        {
            Notificador.ExibirMensagem(erros, ConsoleColor.Red);
            CadastrarRegistro();

            return;
        }

        repositorioCaixa.CadastrarRegistro(novoCaixa);

        Notificador.ExibirMensagem("O registro foi concluído com sucesso!", ConsoleColor.Green);
    }
    public override void EditarRegistro()
    {
        ExibirCabecalho();

        Console.WriteLine();

        Console.WriteLine("Editando Caixa...");
        Console.WriteLine("--------------------------------------------");

        VisualizarRegistros(false);

        Console.Write("Digite o ID do registro que deseja selecionar: ");
        int idSelecionado = Convert.ToInt32(Console.ReadLine());

        Caixa caixaAntigo = (Caixa)repositorioCaixa.SelecionarRegistroPorId(idSelecionado);

        Console.WriteLine();

        Caixa caixaEditado = (Caixa)ObterDados();

        bool conseguiuEditar = repositorioCaixa.EditarRegistro(idSelecionado, caixaEditado);

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

        Console.WriteLine("Excluindo Caixa...");
        Console.WriteLine("--------------------------------------------");

        VisualizarRegistros(false);

        Console.Write("Digite o ID do registro que deseja selecionar: ");
        int idSelecionado = Convert.ToInt32(Console.ReadLine());

        Caixa caixaSelecionado = (Caixa)repositorioCaixa.SelecionarRegistroPorId(idSelecionado);

        bool conseguiuExcluir = repositorioCaixa.ExcluirRegistro(idSelecionado);

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

        Console.WriteLine("Visualizando Caixas...");
        Console.WriteLine("--------------------------------------------");

        Console.WriteLine();

        Console.WriteLine(
            "{0, -6} | {1, -20} | {2, -20} | {3, -20} | {4, -15}",
            "ID", "Etiqueta", "Dias de Emprestimo", "Cor", "Quantidade de Revistas"
            );

        List<EntidadeBase> registros = repositorioCaixa.SelecionarRegistros();

        foreach(Caixa caixas in registros)
        {
            Console.WriteLine(
               "{0, -6} | {1, -20} | {2, -20} | {3, -20} | {4, -15}",
               caixas.Id, caixas.Etiqueta, caixas.DiasDeEmprestimo, caixas.Cor, caixas.ObterQuantidadeRevistas()
           );
        }

        Console.WriteLine();

        Notificador.ExibirMensagem("Pressione ENTER para continuar...", ConsoleColor.DarkYellow);
    }
}