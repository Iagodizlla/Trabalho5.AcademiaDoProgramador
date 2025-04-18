using Trabalho5.AP.Compartilhado;
using Trabalho5.AP.ModuloAmigo;
using Trabalho5.AP.ModuloRevista;

namespace Trabalho5.AP.ModuloEmprestimo;

public class RepositorioEmprestimo : RepositorioBase
{
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
    public Emprestimo BuscarMulta(int id)
    {
        for (int i = 0; i < contadorEmprestimos; i++)
        {
            if (emprestimos[i].Id == id && emprestimos[i].Multa > 0)
            {
                return emprestimos[i];
            }
        }
        return null!;
    }
}