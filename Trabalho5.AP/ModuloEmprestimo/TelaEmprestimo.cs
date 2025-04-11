using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabalho5.AP.ModuloAmigo;
using Trabalho5.AP.ModuloCaixa;
using Trabalho5.AP.ModuloRevista;

namespace Trabalho5.AP.ModuloEmprestimo;

public class TelaEmprestimo
{
    RepositorioEmprestimo repositorioEmprestimo;
    RepositorioAmigo repositorioAmigo;
    RepositorioRevista repositorioRevista;
    public TelaEmprestimo(RepositorioEmprestimo repositorioEmprestimo, RepositorioAmigo repositorioAmigo, RepositorioRevista repositorioRevista)
    {
        this.repositorioEmprestimo = repositorioEmprestimo;
        this.repositorioAmigo = repositorioAmigo;
        this.repositorioRevista = repositorioRevista;
    }
    public void CadastrarEmprestimo()
    {
        Console.Clear();
        Console.WriteLine("Adicionar Emprestimo");

        ListarAmigos();
        Console.Write("ID: ");
        int idA = Convert.ToInt16(Console.ReadLine()!);
        Amigo amigo = repositorioAmigo.BuscarAmigo(idA);

        Console.Write("Situacao: ");
        string situacao = Console.ReadLine()!;

        ListarRevistas();
        Console.Write("ID: ");
        int idR = Convert.ToInt16(Console.ReadLine()!);
        Revista revista = repositorioRevista.BuscarRevista(idR, situacao);

        Emprestimo emprestimo = new Emprestimo(amigo, revista/*, data*/, situacao);
        repositorioEmprestimo.AdicionarEmprestimo(emprestimo);
    }
    public void ListarEmprestimos()
    {
        Console.Clear();
        Console.WriteLine("Lista de Emprestimos");
        Console.WriteLine("-----------------");
        Emprestimo[] emprestimo = repositorioEmprestimo.ListarEmprestimos();
        Console.WriteLine(
            "{0, -6} | {1, -20} | {2, -20} | {3, -15}",
            "ID", "Nome Amigo", "Titulo Revista", "Situacao"
            );
        for (int i = 0; i < emprestimo.Length; i++)
        {
            if (emprestimo[i] == null) continue;
            Console.WriteLine(
                "{0, -6} | {1, -20} | {2, -20} | {3, -15}",
                emprestimo[i].Id, emprestimo[i].Amigo.Nome, emprestimo[i].Revista.Titulo, emprestimo[i].Situacao
            );
        }
        Console.ReadLine();
    }
    public void RemoverEmprestimo()
    {
        Console.Clear();
        Console.WriteLine("Remover Emprestimo");
        ListarEmprestimos();
        Console.Write("ID: ");
        int id = Convert.ToInt16(Console.ReadLine()!);
        Emprestimo emprestimo = repositorioEmprestimo.BuscarEmprestimo(id);
        if (emprestimo != null)
        {
            repositorioEmprestimo.RemoverEmprestimo(emprestimo);
            Console.WriteLine("Emprestimo removido com sucesso!");
        }
        else
        {
            Console.WriteLine("Emprestimo não encontrado.");
        }
        Console.ReadLine();
    }
    public void RegistrarDevolucao()
    {
        Console.Clear();
        Console.WriteLine("Registrar Devolucao");

        ListarEmprestimos();
        Console.Write("ID: ");
        int id = Convert.ToInt16(Console.ReadLine()!);
        Emprestimo emprestimo = repositorioEmprestimo.BuscarEmprestimo(id);
        if (emprestimo != null)
        {
            emprestimo.Situacao = "Devolvido";
            emprestimo.Revista.StatusEmprestimo = "Disponivel";
            Console.WriteLine("Devolução registrada com sucesso!");
        }
        else
        {
            Console.WriteLine("Emprestimo não encontrado.");
        }
        Console.ReadLine();
    }
    public void EditarEmprestimo()
    {
        Console.Clear();
        Console.WriteLine("Editar Emprestimo");

        ListarEmprestimos();
        Console.Write("ID: ");
        int id = Convert.ToInt16(Console.ReadLine()!);
        Emprestimo emprestimo = repositorioEmprestimo.BuscarEmprestimo(id);
        if (emprestimo != null)
        {
            ListarAmigos();
            Console.Write("ID: ");
            int idA = Convert.ToInt16(Console.ReadLine()!);
            Amigo novoamigo = repositorioAmigo.BuscarAmigo(idA);

            Console.Write("Situacao: ");
            string novosituacao = Console.ReadLine()!;

            ListarRevistas();
            Console.Write("ID: ");
            int idR = Convert.ToInt16(Console.ReadLine()!);
            Revista novorevista = repositorioRevista.BuscarRevista(idR, novosituacao);

            repositorioEmprestimo.EditarEmprestimo(emprestimo, novoamigo, novorevista, novosituacao);
            Console.WriteLine("Emprestimo editado com sucesso!");
        }
        else
        {
            Console.WriteLine("Emprestimo não encontrado.");
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
    public void ListarRevistas()
    {
        Console.Clear();
        Console.WriteLine("Lista de Revistas");
        Console.WriteLine("-----------------");
        Revista[] revistas = repositorioRevista.ListarRevistas();
        Console.WriteLine(
            "{0, -6} | {1, -20} | {2, -20} | {3, -20} | {4, -20}"/* | {5, -20}*/,
            "ID", "titulo", "Status", "Numero Edicao", "Ano Publicacao"/*, "Caixa"*/
            );
        for (int i = 0; i < revistas.Length; i++)
        {
            if (revistas[i] == null) continue;
            Console.WriteLine(
                "{0, -6} | {1, -20} | {2, -20} | {3, -20} | {4, -20}"/* | {5, -20}*/,
                revistas[i].Id, revistas[i].Titulo, revistas[i].StatusEmprestimo, revistas[i].NumeroEdicao, revistas[i].AnoPublicacao/*, revistas[i].Caixa.NomeCaixa*/
            );
        }
        Console.ReadLine();
    }
}