using Trabalho5.AP.Compartilhado;
using Trabalho5.AP.ModuloAmigo;
using Trabalho5.AP.ModuloRevista;

namespace Trabalho5.AP.ModuloEmprestimo;

public class RepositorioEmprestimo : RepositorioBase<Emprestimo>
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
}