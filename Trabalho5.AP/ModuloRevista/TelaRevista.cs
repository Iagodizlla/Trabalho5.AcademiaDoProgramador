using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabalho5.AP.ModuloAmigo;
using Trabalho5.AP.ModuloCaixa;

namespace Trabalho5.AP.ModuloRevista;

public class TelaRevista
{
    RepositorioRevista repositorioRevista;
    RepositorioCaixa repositorioCaixa;
    public TelaRevista(RepositorioRevista repositorioRevista, RepositorioCaixa repositorioCaixa)
    {
        this.repositorioRevista = repositorioRevista;
        this.repositorioCaixa = repositorioCaixa;
    }
    public void CadastrarRevista()
    {
        Console.Clear();
        Console.WriteLine("Cadastro de Revista");
        Console.Write("Titulo: ");
        string titulo = Console.ReadLine()!;
        Console.Write("Status do emprestimo: ");
        string statusEmprestimo = Console.ReadLine()!;
        Console.Write("Numero de edicao: ");
        int numeroEdicao = Convert.ToInt32(Console.ReadLine()!);
        Console.Write("Ano de publicacao: ");
        DateTime anoPublicacao = Convert.ToDateTime(Console.ReadLine()!);

        ListarCaixas();
        Console.Write("Id da Caixa: ");
        int id = Convert.ToInt16(Console.ReadLine()!);
        Caixa caixa = repositorioCaixa.BuscarCaixa(id);

        Revista revista = new Revista(titulo, statusEmprestimo, caixa, numeroEdicao, anoPublicacao);
        repositorioRevista.AdicionarRevista(revista);
    }
    public void ListarCaixas()
    {
        Console.Clear();
        Console.WriteLine("Lista de Caixas");
        Console.WriteLine("-----------------");
        Caixa[] caixas = repositorioCaixa.ListarCaixas();
        Console.WriteLine(
            "{0, -6} | {1, -20} | {2, -20} | {3, -20}",
            "ID", "Etiqueta", "Dias de Emprestimo", "Cor"
            );
        for (int i = 0; i < caixas.Length; i++)
        {
            if (caixas[i] == null) continue;
            Console.WriteLine(
                "{0, -6} | {1, -20} | {2, -20} | {3, -20}",
                caixas[i].Id, caixas[i].Etiqueta, caixas[i].DiasDeEmprestimo, caixas[i].Cor
            );
        }
        Console.ReadLine();
    }
    public void EditarRevista()
    {
        Console.Clear();
        Console.WriteLine("Editar Revista");

        Console.Write("Status do emprestimo: ");
        string statusEmprestimo = Console.ReadLine()!;

        ListarRevistas();
        Console.Write("ID: ");
        int id = Convert.ToInt16(Console.ReadLine()!);
        Revista revista = repositorioRevista.BuscarRevista(id, statusEmprestimo);
        if (revista != null)
        {
            Console.Write("Titulo: ");
            string titulo = Console.ReadLine()!;
            Console.Write("Numero de edicao: ");
            int numeroEdicao = Convert.ToInt32(Console.ReadLine()!);
            Console.Write("Ano de publicacao: ");
            DateTime anoPublicacao = Convert.ToDateTime(Console.ReadLine()!);

            ListarCaixas();
            Console.Write("Id da Caixa: ");
            int idR = Convert.ToInt16(Console.ReadLine()!);
            Caixa caixa = repositorioCaixa.BuscarCaixa(idR);

            repositorioRevista.EditarRevista(revista, titulo, statusEmprestimo, caixa, numeroEdicao, anoPublicacao);
            Console.WriteLine("Revista editado com sucesso!");
        }
        else
        {
            Console.WriteLine("Revista não encontrado.");
        }
    }
    public void RemoverRevista()
    {
        Console.Clear();
        Console.WriteLine("Remover Revista");
        ListarRevistas();
        Console.Write("ID: ");
        int id = Convert.ToInt16(Console.ReadLine()!);
        Revista revista = repositorioRevista.BuscarRevista(id, "");
        if (revista != null)
        {
            repositorioRevista.RemoverRevista(revista);
            Console.WriteLine("Revista removido com sucesso!");
        }
        else
        {
            Console.WriteLine("Revista não encontrado.");
        }
    }
    public void ListarRevistas()
    {
        Console.Clear();
        Console.WriteLine("Lista de Revistas");
        Console.WriteLine("-----------------");
        Revista[] revistas = repositorioRevista.ListarRevistas();
        Console.WriteLine(
            "{0, -6} | {1, -20} | {2, -20} | {3, -20} | {4, -20} | {5, -20}",
            "ID", "titulo", "Status", "Numero Edicao", "Ano Publicacao", "Caixa"
            );
        for (int i = 0; i < revistas.Length; i++)
        {
            if (revistas[i] == null) continue;
            Console.WriteLine(
                "{0, -6} | {1, -20} | {2, -20} | {3, -20} | {4, -20} | {5, -20}",
                revistas[i].Id, revistas[i].Titulo, revistas[i].StatusEmprestimo, revistas[i].NumeroEdicao, revistas[i].AnoPublicacao, revistas[i].Caixa.Etiqueta
            );
        }
        Console.ReadLine();
    }
}