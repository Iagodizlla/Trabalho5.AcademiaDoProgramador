using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabalho5.AP.Compartilhado;
using Trabalho5.AP.ModuloAmigo;
using Trabalho5.AP.ModuloRevista;

namespace Trabalho5.AP.ModuloEmprestimo;

public class RepositorioEmprestimo
{
    public Emprestimo[] emprestimos = new Emprestimo[100];
    public int contadorEmprestimos = 0;

    public void AdicionarEmprestimo(Emprestimo emprestimo)
    {
        emprestimo.Id = GeradorId.GerarIdEmprestimo();
        emprestimos[contadorEmprestimos++] = emprestimo;
    }
    public Emprestimo[] ListarEmprestimos()
    {
        Emprestimo[] emprestimosAtuais = new Emprestimo[contadorEmprestimos];
        for (int i = 0; i < contadorEmprestimos; i++)
        {
            emprestimosAtuais[i] = emprestimos[i];
        }
        return emprestimosAtuais;
    }
    public void EditarEmprestimo(Emprestimo emprestimo, Amigo novoAmigo, Revista novoRevista, string novoSituacao)
    {
        for (int i = 0; i < contadorEmprestimos; i++)
        {
            if (emprestimos[i] == emprestimo)
            {
                emprestimos[i].Amigo = novoAmigo;
                emprestimos[i].Revista = novoRevista;
                emprestimos[i].Situacao = novoSituacao;
                break;
            }
        }
    }
    public int QuantidadeEmprestimosAmigo(Amigo amigo)
    {
        int contador = 0;
        for (int i = 0; i < 100; i++)
        {
            if (amigo.Emprestimos[i] != null)
                contador++;
        }
        return contador;
    }
    public string EditarSituacao()
    {
        string novosituacao;
        while (true)
        {
            Console.Clear();
            Console.Write("\n1. Aberto\n2. Concluído\n3. Atrasado\nSituacao: ");
            novosituacao = Console.ReadLine()!;
            if (novosituacao == "1")
            {
                novosituacao = "Aberto"; break;
            }
            else if (novosituacao == "2")
            {
                novosituacao = "Concluído"; break;
            }
            else if (novosituacao == "3")
            {
                novosituacao = "Atrasado"; break;
            }
            else
                Console.WriteLine("Invalido, tente novamente!");
            Console.ReadLine();
        }
        return novosituacao;
    }
    public Emprestimo BuscarEmprestimo(int id)
    {
        for (int i = 0; i < contadorEmprestimos; i++)
        {
            if (emprestimos[i].Id == id)
            {
                return emprestimos[i];
            }
        }
        return null!;
    }
    public void RemoverEmprestimo(Emprestimo emprestimo)
    {
        for (int i = 0; i < contadorEmprestimos; i++)
        {
            if (emprestimos[i] == emprestimo)
            {
                emprestimos[i] = null!;
                break;
            }
        }
    }
}