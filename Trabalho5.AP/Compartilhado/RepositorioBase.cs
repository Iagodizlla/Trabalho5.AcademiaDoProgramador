using System.Collections;
namespace Trabalho5.AP.Compartilhado;

public abstract class RepositorioBase
{
    private ArrayList registros = new ArrayList();
    private int contadorIds = 0;

    public void CadastrarRegistro(EntidadeBase novoRegistro)
    {
        novoRegistro.Id = ++contadorIds;

        InserirRegistro(novoRegistro);
    }
    public string EditarSituacao()
    {
        string novosituacao;
        while (true)
        {
            Console.Clear();
            Console.Write("\n1. Disponível\n2. Emprestada\n3. Reservada\nSituacao: ");
            novosituacao = Console.ReadLine()!;
            if (novosituacao == "1")
            {
                novosituacao = "Disponível"; break;
            }
            else if (novosituacao == "2")
            {
                novosituacao = "Emprestada"; break;
            }
            else if (novosituacao == "3")
            {
                novosituacao = "Reservada"; break;
            }
            else
                Console.WriteLine("Invalido, tente novamente!");
            Console.ReadLine();
        }
        return novosituacao;
    }

    public bool EditarRegistro(int idRegistro, EntidadeBase registroEditado)
    {
        foreach(EntidadeBase e in registros)
        {
            if (e.Id == idRegistro)
            {
                e.AtualizarRegistro(registroEditado);
                return true;
            }
        }

        return false;
    }

    public bool ExcluirRegistro(int idRegistro)
    {
        foreach (EntidadeBase e in registros)
        {
            if (e.Id == idRegistro)
            {
                registros.Remove(e);
                return true;
            }
        }

        return false;
    }

    public ArrayList SelecionarRegistros()
    {
        return registros;
    }

    public EntidadeBase SelecionarRegistroPorId(int idRegistro)
    {
        foreach (EntidadeBase e in registros)
        {
            if (e.Id == idRegistro)
                return e;
        }

        return null!;
    }

    private void InserirRegistro(EntidadeBase registro)
    {
        registros.Add(registro);
        return;
    }
}