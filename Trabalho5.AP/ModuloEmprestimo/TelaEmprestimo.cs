using Trabalho5.AP.Compartilhado;
using Trabalho5.AP.ModuloAmigo;
using Trabalho5.AP.ModuloRevista;
using Trabalho5.AP.Util;
using System.Collections;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Trabalho5.AP.ModuloEmprestimo;

public class TelaEmprestimo : TelaBase
{
    RepositorioEmprestimo repositorioEmprestimo;
    RepositorioAmigo repositorioAmigo;
    RepositorioRevista repositorioRevista;
    public TelaEmprestimo(RepositorioEmprestimo repositorioEmprestimo, RepositorioAmigo repositorioAmigo, RepositorioRevista repositorioRevista) : base("Emprestimo", repositorioEmprestimo)
    {
        this.repositorioEmprestimo = repositorioEmprestimo;
        this.repositorioAmigo = repositorioAmigo;
        this.repositorioRevista = repositorioRevista;
    }
    public override EntidadeBase ObterDados()
    {
        ListarAmigos();
        Console.Write("ID: ");
        int idA = Convert.ToInt16(Console.ReadLine()!);
        Amigo amigo = (Amigo)repositorioAmigo.SelecionarRegistroPorId(idA);
        if (repositorioEmprestimo.QuantidadeEmprestimosAmigo(amigo) >= 1)
        {
            Console.WriteLine("Amigo já possui 1 emprestimo ativo.");
            Console.ReadLine();
            return null!;
        }

        ListarRevistas();
        Console.Write("Id da Caixa: ");
        int idCaixa = Convert.ToInt16(Console.ReadLine()!);
        Revista revistaSelecionado = (Revista)repositorioRevista.SelecionarRegistroPorId(idCaixa);
        string situacao = "Aberto";

        DateTime hoje = DateTime.Today;
        DateTime dataFinal = hoje.AddDays(revistaSelecionado.Caixa.DiasDeEmprestimo);

        Emprestimo emprestimo = new Emprestimo(amigo, revistaSelecionado, situacao, dataFinal, 0);

        return emprestimo;
    }
    public override void CadastrarRegistro()
    {
        ExibirCabecalho();

        Console.WriteLine();

        Console.WriteLine("Cadastrando Emprestimo...");
        Console.WriteLine("--------------------------------------------");

        Console.WriteLine();

        Emprestimo novoEmprestimo = (Emprestimo)ObterDados();

        string erros = novoEmprestimo.Validar();

        if (erros.Length > 0)
        {
            Notificador.ExibirMensagem(erros, ConsoleColor.Red);
            CadastrarRegistro();
            return;
        }

        repositorioEmprestimo.CadastrarRegistro(novoEmprestimo);

        Notificador.ExibirMensagem("O registro foi concluído com sucesso!", ConsoleColor.Green);
    }
    public void ListarEmprestimosAmigo()
    {
        Console.Clear();
        Console.WriteLine("Listar Emprestimos de um Amigo");

        ListarAmigos();
        Console.Write("ID: ");
        int idA = Convert.ToInt16(Console.ReadLine()!);
        Amigo amigo = (Amigo)repositorioAmigo.SelecionarRegistroPorId(idA);
        Console.WriteLine("Lista de Emprestimos");
        Console.WriteLine("-----------------");

        Console.WriteLine(
            "{0, -6} | {1, -20} | {2, -20} | {3, -15}",
            "ID", "Nome Amigo", "Titulo Revista", "Situacao"
        );

        ArrayList registros = repositorioEmprestimo.SelecionarRegistros();

        foreach(Emprestimo emprestimo in registros)
        {
            if (emprestimo.Amigo != amigo) continue;
            Console.WriteLine(
                "{0, -6} | {1, -20} | {2, -20} | {3, -15}",
                emprestimo.Id, emprestimo.Amigo.Nome, emprestimo.Revista.Titulo, emprestimo.Situacao
            );
        }

        Console.ReadLine();
    }
    public override void VisualizarRegistros(bool exibirTitulo)
    {
        if (exibirTitulo)
            ExibirCabecalho();
        string situacaoescolhida;
        Console.WriteLine("1. Aberto\n2. Concluído\n3. Atrasado\n4. Geral");
        char opcao = Console.ReadLine()!.ToUpper()[0];
        switch (opcao)
        {
            case '1': situacaoescolhida = "Aberto"; break;
            case '2': situacaoescolhida = "Concluído"; break;
            case '3': situacaoescolhida = "Atrasado"; break;
            default: situacaoescolhida = "Geral"; break;
        }
        Console.WriteLine();

        Console.WriteLine("Visualizando Emprestimos...");
        Console.WriteLine("--------------------------------------------");

        Console.WriteLine();

        Console.WriteLine(
            "{0, -6} | {1, -20} | {2, -20} | {3, -15} | {4, -15}",
            "ID", "Nome Amigo", "Titulo Revista", "Situacao", "Data Restante"
            );

        ArrayList registros = repositorioEmprestimo.SelecionarRegistros();

        foreach (Emprestimo emprestimo in registros)
        {
            if (emprestimo.Situacao != situacaoescolhida && situacaoescolhida != "Geral") continue;
            TimeSpan Data = emprestimo.DataFinal - DateTime.Today;
            int data = Convert.ToInt32(Data.Days);
            if (data < 0) emprestimo.Situacao = "Atrasado";

            Console.WriteLine(
            "{0, -6} | {1, -20} | {2, -20} | {3, -15} | {4, -15}",
                emprestimo.Id, emprestimo.Amigo.Nome, emprestimo.Revista.Titulo, emprestimo.Situacao, data
            );
        }

        Console.WriteLine();

        Notificador.ExibirMensagem("Pressione ENTER para continuar...", ConsoleColor.DarkYellow);
    }
    public override void ExcluirRegistro()
    {
        ExibirCabecalho();

        Console.WriteLine();

        Console.WriteLine("Excluindo Emprestimo...");
        Console.WriteLine("--------------------------------------------");

        VisualizarRegistros(false);

        Console.Write("Digite o ID do registro que deseja selecionar: ");
        int idSelecionado = Convert.ToInt32(Console.ReadLine());

        bool conseguiuExcluir = repositorioRevista.ExcluirRegistro(idSelecionado);

        if (!conseguiuExcluir)
        {
            Notificador.ExibirMensagem("Houve um erro durante a exclusão de um registro...", ConsoleColor.Red);

            return;
        }
        Emprestimo emprestimoSelecionado = (Emprestimo)repositorioRevista.SelecionarRegistroPorId(idSelecionado);
        Amigo amigo = emprestimoSelecionado.Amigo;
        amigo.RemoverEmprestimo(emprestimoSelecionado);

        Notificador.ExibirMensagem("O registro foi excluído com sucesso!", ConsoleColor.Green);
    }
    public void RegistrarDevolucao()
    {
        Console.Clear();
        Console.WriteLine("Registrar Devolucao");

        VisualizarRegistros(false);
        Console.Write("ID: ");
        int id = Convert.ToInt16(Console.ReadLine()!);
        Emprestimo emprestimo = (Emprestimo)repositorioEmprestimo.SelecionarRegistroPorId(id);
        if (emprestimo != null)
        {
            emprestimo.Situacao = "Concluído";
            emprestimo.Revista.StatusEmprestimo = "Disponível";
            Console.WriteLine("Devolução registrada com sucesso!");
        }
        else
        {
            Console.WriteLine("Emprestimo não encontrado.");
        }
        Console.ReadLine();
    }
    public override void EditarRegistro()
    {
        ExibirCabecalho();

        Console.WriteLine();

        Console.WriteLine("Editando Emprestimo...");
        Console.WriteLine("--------------------------------------------");

        VisualizarRegistros(false);

        Console.Write("Digite o ID do registro que deseja selecionar: ");
        int idSelecionado = Convert.ToInt32(Console.ReadLine());

        Emprestimo emprestimoAntigo = (Emprestimo)repositorioRevista.SelecionarRegistroPorId(idSelecionado);

        Console.WriteLine();

        Emprestimo emprestimoEditado = (Emprestimo)ObterDados();

        bool conseguiuEditar = repositorioRevista.EditarRegistro(idSelecionado, emprestimoEditado);

        if (!conseguiuEditar)
        {
            Notificador.ExibirMensagem("Houve um erro durante a edição de um registro...", ConsoleColor.Red);

            return;
        }

        Notificador.ExibirMensagem("O registro foi editado com sucesso!", ConsoleColor.Green);
    }
    public void ListarAmigos()
    {
        Console.Clear();
        Console.WriteLine("Lista de Amigos");
        Console.WriteLine("-----------------");
        Console.WriteLine(
            "{0, -6} | {1, -20} | {2, -20} | {3, -20}",
            "ID", "Nome", "Telefone", "Responsável"
            );
        ArrayList registros = repositorioAmigo.SelecionarRegistros();
        

        foreach(Amigo amigos in registros)
        {
            Console.WriteLine(
                "{0, -6} | {1, -20} | {2, -20} | {3, -20}",
                amigos.Id, amigos.Nome, amigos.Telefone, amigos.Responsavel
            );
        }
        Console.ReadLine();
    }
    public void ListarRevistas()
    {
        Console.Clear();
        Console.WriteLine("Lista de Revistas");
        Console.WriteLine("-----------------");

        Console.WriteLine(
            "{0, -6} | {1, -20} | {2, -15} | {3, -15} | {4, -20} | {5, -20}",
            "ID", "titulo", "Status", "Numero Edicao", "Ano Publicacao", "Etiqueta Caixa"
        );
        ArrayList registros = repositorioRevista.SelecionarRegistros();

        foreach (Revista Revistas in registros)
        {
            if (Revistas.StatusEmprestimo == "Disponível")
            {
                Console.WriteLine(
                    "{0, -6} | {1, -20} | {2, -15} | {3, -15} | {4, -20} | {5, -20}",
                    Revistas.Id, Revistas.Titulo, Revistas.StatusEmprestimo, Revistas.NumeroEdicao, Revistas.AnoPublicacao.Year, Revistas.Caixa.Etiqueta
                );
            }

        }
        Console.ReadLine();
    }
}