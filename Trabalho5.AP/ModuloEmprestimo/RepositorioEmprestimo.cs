using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabalho5.AP.Compartilhado;
using Trabalho5.AP.ModuloAmigo;

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
}