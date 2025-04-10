using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabalho5.AP.Compartilhado;
using Trabalho5.AP.ModuloAmigo;

namespace Trabalho5.AP.ModuloRevista;

public class RepositorioRevista
{
    public Revista[] revistas = new Revista[100];
    public int contadorRevistas = 0;
    public void AdicionarRevista(Revista revista)
    {
        revista.Id = GeradorId.GerarIdRevista();
        revistas[contadorRevistas++] = revista;
    }
    public void RemoverRevista(Revista revista)
    {
        for (int i = 0; i < contadorRevistas; i++)
        {
            if (revistas[i] == revista)
            {
                revistas[i] = null!;
                break;
            }
        }
    }
    public Revista BuscarRevista(int id)
    {
        for (int i = 0; i < contadorRevistas; i++)
        {
            if (revistas[i].Id == id)
            {
                return revistas[i];
            }
        }
        return null!;
    }
    public Revista[] ListarRevistas()
    {
        Revista[] revistasAtuais = new Revista[contadorRevistas];
        for (int i = 0; i < contadorRevistas; i++)
        {
            revistasAtuais[i] = revistas[i];
        }
        return revistasAtuais;
    }
    public void EditarRevista(Revista revista, string novoTitulo, string novoStatusEmprestimo, int novoNumeroEdicao, DateTime novoAnoPublicacao)
    {
        for (int i = 0; i < contadorRevistas; i++)
        {
            if (revistas[i] == revista)
            {
                revistas[i].Titulo = novoTitulo;
                revistas[i].StatusEmprestimo = novoStatusEmprestimo;
                revistas[i].NumeroEdicao = novoNumeroEdicao;
                revistas[i].AnoPublicacao = novoAnoPublicacao;
                break;
            }
        }
    }
}