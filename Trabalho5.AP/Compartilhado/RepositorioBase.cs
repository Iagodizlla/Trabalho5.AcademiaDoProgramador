namespace Trabalho5.AP.Compartilhado;

public abstract class RepositorioBase
{
    private EntidadeBase[] registros = new EntidadeBase[100];
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
        for (int i = 0; i < registros.Length; i++)
        {
            if (registros[i] == null)
                continue;

            else if (registros[i].Id == idRegistro)
            {
                registros[i].AtualizarRegistro(registroEditado);

                return true;
            }
        }

        return false;
    }

    public bool ExcluirRegistro(int idRegistro)
    {
        for (int i = 0; i < registros.Length; i++)
        {
            if (registros[i] == null)
                continue;

            else if (registros[i].Id == idRegistro)
            {
                registros[i] = null!;
                return true;
            }
        }

        return false;
    }

    public EntidadeBase[] SelecionarRegistros()
    {
        return registros;
    }

    public EntidadeBase SelecionarRegistroPorId(int idRegistro)
    {
        for (int i = 0; i < registros.Length; i++)
        {
            EntidadeBase e = registros[i];

            if (e == null)
                continue;

            else if (e.Id == idRegistro)
                return e;
        }

        return null!;
    }

    private void InserirRegistro(EntidadeBase registro)
    {
        for (int i = 0; i < registros.Length; i++)
        {
            if (registros[i] == null)
            {
                registros[i] = registro;
                return;
            }
        }
    }
}